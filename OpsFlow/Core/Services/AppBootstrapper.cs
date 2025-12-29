using OpsFlow.Services.Interfaces;

namespace OpsFlow.Core.Services
{
    public class AppBootstrapper
    {
        private readonly IDatabaseConnectionService _dbService;

        public AppBootstrapper(IDatabaseConnectionService dbService)
        {
            _dbService = dbService;
        }

        public async Task InitializeAsync(Action<string, int> progressCallback)
        {
            progressCallback("Yapılandırma dosyaları kontrol ediliyor...", 15);
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env")))
            {
                throw new Exception("Kritik sistem dosyası (.env) bulunamadı.");
            }
            await Task.Delay(500);

            progressCallback("Veritabanı bağlantısı doğrulanıyor...", 40);
            bool isDbOk = await Task.Run(() =>
            {
                try
                {
                    using var context = _dbService.CreateContext();
                    return context.Database.CanConnect();
                }
                catch { return false; }
            });

            if (!isDbOk)
            {
                throw new Exception("Veritabanı sunucusu yanıt vermiyor.");
            }

            progressCallback("Sistem kaynakları ve fontlar yükleniyor...", 65);
            string fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Fonts", "poppins", "Poppins-Regular.ttf");
            if (!File.Exists(fontPath))
            {
                await Task.Delay(200);
            }
            await Task.Delay(500);

            progressCallback("E-posta servisleri hazırlanıyor...", 85);
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "EmailTemplates", "VerificationCode.html");
            if (!File.Exists(templatePath))
            {
                throw new Exception("E-posta şablonları eksik.");
            }
            await Task.Delay(500);

            progressCallback("Uygulama hazır, başlatılıyor...", 100);
            await Task.Delay(500);
        }
    }
}