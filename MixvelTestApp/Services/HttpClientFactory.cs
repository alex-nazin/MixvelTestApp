namespace MixvelTestApp.Services
{
    /// <summary>
    /// Реализация фабрики http-клиентов
    /// </summary>
    public sealed class HttpClientFactory
        : IHttpClientFactory
        , IDisposable
    {
        /// <summary>
        /// Создаём обработчик, позволяющий игнорировать проблемы с сертификатами
        /// </summary>
        private readonly HttpClientHandler _httpClientHandler = new()
        {
            ServerCertificateCustomValidationCallback =
                    (message, certificate2, chain, errors) => true
        };

        private bool disposedValue;

        /// <inheritdoc/>
        public HttpClient CreateHttpClient(string baseUrl)
        {
            return new HttpClient(_httpClientHandler, disposeHandler: false)
            {
                BaseAddress = new Uri(baseUrl),
            };
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClientHandler.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
