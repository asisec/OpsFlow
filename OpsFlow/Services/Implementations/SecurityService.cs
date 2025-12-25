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

        public string CreateVerificationSession(string email)
        {
            Random rnd = new Random();
            string code = rnd.Next(100000, 999999).ToString();

            if (_sessions.ContainsKey(email))
            {
                _sessions.Remove(email);
            }

            var session = new VerificationSession(email, code);
            _sessions.Add(email, session);

            return code;
        }

        public void VerifyCode(string email, string code)
        {
            if (!_sessions.ContainsKey(email))
                throw new VerificationException("Doğrulama oturumu bulunamadı.");

            var session = _sessions[email];

            if (session.IsExpired)
            {
                _sessions.Remove(email);
                throw new VerificationException("Kodun süresi doldu.");
            }

            if (session.Code != code)
            {
                throw new VerificationException("Hatalı kod.");
            }

            session.IsVerified = true;
        }

        public void ClearSession(string email)
        {
            if (_sessions.ContainsKey(email))
                _sessions.Remove(email);
        }
    }
}