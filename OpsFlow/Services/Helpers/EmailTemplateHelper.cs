namespace OpsFlow.Services.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string GetVerificationTemplate(string code)
        {
            string fileName = "VerificationCode.html";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "EmailTemplates", fileName);

            if (!File.Exists(filePath))
            {
                return $"Verification Code: {code}";
            }

            string template = File.ReadAllText(filePath);
            return template.Replace("{{CODE}}", code);
        }
    }
}