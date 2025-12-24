using System;

namespace OpsFlow.Core.Models
{
    public class VerificationSession
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsVerified { get; set; }

        public bool IsExpired => DateTime.UtcNow > ExpiresAt;

        public VerificationSession(string email, string code, int durationMinutes = 3)
        {
            Email = email;
            Code = code;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = DateTime.UtcNow.AddMinutes(durationMinutes);
            IsVerified = false;
        }
    }
}