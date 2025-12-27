using OpsFlow.Core.Exceptions;
using OpsFlow.Core.Models;
using OpsFlow.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OpsFlow.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        private static readonly Dictionary<string, VerificationSession> _sessions = new Dictionary<string, VerificationSession>();
        private static readonly Dictionary<string, List<DateTime>> _resendHistory = new Dictionary<string, List<DateTime>>();

        public string CreateVerificationSession(string email)
        {
            return GenerateAndStoreCode(email);
        }

        public void VerifyCode(string email, string code)
        {
            if (!_sessions.ContainsKey(email))
                throw new VerificationException("Doğrulama oturumu bulunamadı veya süresi dolmuş.");

            var session = _sessions[email];

            if (session.IsExpired)
            {
                _sessions.Remove(email);
                throw new VerificationException("Doğrulama kodunun süresi dolmuş.");
            }

            if (session.Code != code)
                throw new VerificationException("Girdiğiniz kod hatalı.");

            session.IsVerified = true;
        }

        public void ClearSession(string email)
        {
            if (_sessions.ContainsKey(email))
                _sessions.Remove(email);
        }

        public string ResendVerificationCode(string email)
        {
            CheckRateLimit(email);
            return GenerateAndStoreCode(email);
        }

        private void CheckRateLimit(string email)
        {
            if (!_resendHistory.ContainsKey(email))
                _resendHistory[email] = new List<DateTime>();

            var history = _resendHistory[email];
            var now = DateTime.Now;

            history.RemoveAll(t => (now - t).TotalMinutes >= 1);

            if (history.Count >= 3)
                throw new BusinessException("Dakikada en fazla 3 kod isteyebilirsiniz. Lütfen bekleyip tekrar deneyin.");

            history.Add(now);
        }

        private string GenerateAndStoreCode(string email)
        {
            Random rnd = new Random();
            string code = rnd.Next(100000, 999999).ToString();

            if (_sessions.ContainsKey(email))
                _sessions.Remove(email);

            var session = new VerificationSession(email, code);
            _sessions.Add(email, session);

            return code;
        }
    }
}