namespace OpsFlow.Services.Helpers
{
    public static class FormValidationHelper
    {
        public static (bool IsValid, string? ErrorMessage) ValidatePersonelForm(
            string name,
            string surname,
            string email,
            string password,
            string? roleName,
            string? companyName,
            int roleId,
            string? departmentName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return (false, "Lütfen ad bilgisini giriniz.");
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                return (false, "Lütfen soyad bilgisini giriniz.");
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                return (false, "Lütfen geçerli bir e-posta adresi giriniz.");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return (false, "Şifre en az 6 karakter olmalıdır.");
            }

            if (string.IsNullOrWhiteSpace(roleName) || roleName == "Rol seçiniz")
            {
                return (false, "Lütfen bir rol seçiniz.");
            }

            if (roleId == 1 || roleId == 2)
            {
                if (!string.IsNullOrWhiteSpace(companyName) && companyName != "Şirket seçiniz")
                {
                    return (false, "Bu rol için şirket seçimi yapılamaz.");
                }
            }
            else if (roleId == 3)
            {
                if (!string.IsNullOrWhiteSpace(departmentName) && departmentName != "Departman seçiniz")
                {
                    return (false, "Bu rol için departman seçimi yapılamaz.");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(companyName) || companyName == "Şirket seçiniz")
                {
                    return (false, "Lütfen bir şirket seçiniz.");
                }
            }

            if (roleId != 3)
            {
                if (string.IsNullOrWhiteSpace(departmentName) || departmentName == "Departman seçiniz")
                {
                    return (false, "Lütfen bir departman seçiniz.");
                }
            }

            return (true, null);
        }
    }
}