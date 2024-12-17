namespace MixvelTestApp.Services
{
    /// <summary>
    /// Фабрика http-клиентов
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Создать http-клиент с указанным базовым адресом
        /// </summary>
        /// <param name="baseUrl">Базовый адрес клиента</param>
        HttpClient CreateHttpClient(string baseUrl);
    }
}
