namespace OpsFlow.Services.Helpers
{
    public static class UrlHelper
    {
        public static string ConvertPathToFileUrl(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return string.Empty;

            if (Uri.TryCreate(filePath, UriKind.Absolute, out Uri? uri) &&
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                return filePath;
            }

            try
            {
                string fullPath = Path.GetFullPath(filePath);
                if (!File.Exists(fullPath) && !Directory.Exists(Path.GetDirectoryName(fullPath)))
                {
                    return filePath;
                }

                Uri fileUri = new Uri(fullPath);
                return fileUri.AbsoluteUri;
            }
            catch
            {
                return filePath;
            }
        }

        public static string ConvertRelativePathToFileUrl(string relativePath, string baseDirectory)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return string.Empty;

            string fullPath = Path.Combine(baseDirectory, relativePath.Replace('/', Path.DirectorySeparatorChar));
            return ConvertPathToFileUrl(fullPath);
        }

        public static bool IsValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            return Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp ||
                    uri.Scheme == Uri.UriSchemeHttps ||
                    uri.Scheme == Uri.UriSchemeFile);
        }
    }
}