namespace OpsFlow.Services.Interfaces
{
    public interface ISecurityService
    {
        string CreateVerificationSession(string email);
        void VerifyCode(string email, string code);
        void ClearSession(string email);
    }
}