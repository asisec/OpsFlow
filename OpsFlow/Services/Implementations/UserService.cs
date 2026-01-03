using Microsoft.EntityFrameworkCore;

using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Data.Context;
using OpsFlow.Services.Helpers;
using OpsFlow.Services.Interfaces;

namespace OpsFlow.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users
                    .Include(u => u.Company)
                    .Include(u => u.Role)
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Kullanıcı listesi alınırken bir hata oluştu.", ex);
            }
        }

        public User GetUserById(int id)
        {
            if (id <= 0)
                throw new ValidationException("Geçersiz kullanıcı kimliği.");

            try
            {
                var user = _context.Users
                    .Include(u => u.Company)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Id == id);

                if (user == null)
                    throw new NotFoundException("Kullanıcı bulunamadı.");

                return user;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException($"{id} numaralı kullanıcı sorgulanırken hata oluştu.", ex);
            }
        }

        public void RegisterUser(User user)
        {
            ValidateUser(user);

            try
            {
                bool emailExists = _context.Users.Any(u => u.Email == user.Email);
                if (emailExists)
                {
                    throw new BusinessException("Bu e-posta adresi sistemde zaten kayıtlı.");
                }

                if (user.CreatedAt == default)
                {
                    user.CreatedAt = DateTime.UtcNow;
                }
                if (!user.IsActive)
                {
                    user.IsActive = true;
                }
                user.Password = HashingHelper.HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                string errorDetail = "Veritabanı güncelleme hatası oluştu.";
                if (dbEx.InnerException != null)
                {
                    if (dbEx.InnerException is Npgsql.PostgresException pgEx)
                    {
                        errorDetail = $"Veritabanı hatası: {pgEx.MessageText}";
                        if (!string.IsNullOrEmpty(pgEx.Detail))
                        {
                            errorDetail += $"\nDetay: {pgEx.Detail}";
                        }
                    }
                    else
                    {
                        errorDetail = $"Veritabanı hatası: {dbEx.InnerException.Message}";
                    }
                }
                throw new DatabaseQueryException(errorDetail, dbEx);
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Kayıt işlemi sırasında veritabanı hatası oluştu.", ex);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                var existingUser = _context.Users.Find(user.Id);
                if (existingUser == null)
                {
                    throw new NotFoundException("Güncellenmek istenen kullanıcı bulunamadı.");
                }

                ValidateUser(user);

                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.CompanyId = user.CompanyId;
                existingUser.RoleId = user.RoleId;
                existingUser.IsActive = user.IsActive;
                existingUser.AvatarUrl = user.AvatarUrl;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.Password = HashingHelper.HashPassword(user.Password);
                }

                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Güncelleme işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public void DeleteUser(int id)
        {
            if (id <= 0)
                throw new ValidationException("Silinecek kullanıcı seçilmedi.");

            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                {
                    throw new NotFoundException("Silinmek istenen kullanıcı bulunamadı.");
                }

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Silme işlemi sırasında bir hata oluştu.", ex);
            }
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new ValidationException("Lütfen e-posta adresinizi ve şifrenizi giriniz.");

            try
            {
                var user = _context.Users
                    .Include(u => u.Company)
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Email == email);

                if (user == null)
                    throw new AuthenticationException("Kullanıcı bulunamadı.");

                if (!user.IsActive)
                    throw new AuthenticationException("Hesabınız şu an pasif durumda. Lütfen yöneticiyle iletişime geçin.");

                bool isPasswordValid = HashingHelper.VerifyPassword(password, user.Password);

                if (!isPasswordValid)
                    throw new AuthenticationException("E-posta adresi veya şifre hatalı.");

                return user;
            }
            catch (AuthenticationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new DatabaseQueryException("Giriş işlemi sırasında teknik bir hata oluştu.", ex);
            }
        }

        private void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name) || user.Name.Length < 2)
                throw new ValidationException("İsim alanı en az 2 karakter olmalıdır.");

            if (string.IsNullOrWhiteSpace(user.Surname) || user.Surname.Length < 2)
                throw new ValidationException("Soyisim alanı en az 2 karakter olmalıdır.");

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                throw new ValidationException("Lütfen geçerli bir e-posta adresi giriniz.");

            if (user.CompanyId <= 0)
                throw new ValidationException("Lütfen geçerli bir şirket seçiniz.");

            if (user.RoleId <= 0)
                throw new ValidationException("Lütfen kullanıcı için bir rol tanımlayınız.");
        }

        public bool UserExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void ResetPassword(string email, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword) || newPassword.Length < 6)
                throw new ValidationException("Yeni şifreniz en az 6 karakterden oluşmalıdır.");

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                throw new NotFoundException("Şifresi sıfırlanacak kullanıcı bulunamadı.");

            user.Password = HashingHelper.HashPassword(newPassword);

            _context.SaveChanges();
        }
    }
}