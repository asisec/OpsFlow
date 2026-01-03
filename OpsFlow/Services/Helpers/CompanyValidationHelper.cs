namespace OpsFlow.Services.Helpers
{
    public static class CompanyValidationHelper
    {
        public static (bool IsValid, string? ErrorMessage) ValidateCompanyForm(
            string companyName,
            string? taxNumber,
            string? phone)
        {
            if (string.IsNullOrWhiteSpace(companyName))
            {
                return (false, "Lütfen şirket adını giriniz.");
            }

            if (companyName.Length > 255)
            {
                return (false, "Şirket adı en fazla 255 karakter olabilir.");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber) && taxNumber.Length > 50)
            {
                return (false, "Vergi numarası en fazla 50 karakter olabilir.");
            }

            if (!string.IsNullOrWhiteSpace(phone) && phone.Length > 20)
            {
                return (false, "Telefon numarası en fazla 20 karakter olabilir.");
            }

            return (true, null);
        }
    }
}

