using Microsoft.Extensions.Options;
using MixvelTestApp.Application.Settings;
using ProviderOne.Dtos;

namespace MixvelTestApp.Services.ProviderOne
{
    /// <inheritdoc/>
    public sealed class ProviderOneClient
        : IProviderOneClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProviderOneSettings _settings;

        /// <summary>
        /// Конструктор типа <see cref="ProviderOneClient"/>
        /// </summary>
        /// <param name="httpClientFactory">Фабрика Http клиентов</param>
        /// <param name="settings">Настройки для работы с провайдером</param>
        public ProviderOneClient(
            IHttpClientFactory httpClientFactory,
            IOptions<ProviderOneSettings> settings)
        {
            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _settings = settings?.Value
                ?? throw new ArgumentNullException(nameof(settings)); ;
        }

        /// <inheritdoc/>
        public async Task<bool> GetIsAvailableAsync(CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateHttpClient(_settings.ApiEndpointUrl);
            using var response = await httpClient.GetAsync("v1/ping", cancellationToken);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc/>
        public async Task<ProviderOneSearchResponse?> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateHttpClient(_settings.ApiEndpointUrl);
            using var response = await httpClient.PostAsJsonAsync("v1/search", request, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProviderOneSearchResponse>(cancellationToken);
        }
    }
}
