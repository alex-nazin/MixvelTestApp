using Microsoft.Extensions.Options;
using MixvelTestApp.Application.Settings;
using ProviderTwo.Dtos;

namespace MixvelTestApp.Services.ProviderTwo
{
    /// <inheritdoc/>
    public sealed class ProviderTwoClient
        : IProviderTwoClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ProviderTwoSettings _settings;

        /// <summary>
        /// Конструктор типа <see cref="ProviderTwoClient"/>
        /// </summary>
        /// <param name="httpClientFactory">Фабрика Http клиентов</param>
        /// <param name="settings">Настройки для работы с провайдером</param>
        public ProviderTwoClient(
            IHttpClientFactory httpClientFactory,
            IOptions<ProviderTwoSettings> settings)
        {
            _httpClientFactory = httpClientFactory
                ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _settings = settings?.Value
                ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <inheritdoc/>
        public async Task<bool> GetIsAvailableAsync(CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateHttpClient(_settings.ApiEndpointUrl);
            using var response = await httpClient.GetAsync("v1/ping", cancellationToken);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc/>
        public async Task<ProviderTwoSearchResponse?> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken)
        {
            using var httpClient = _httpClientFactory.CreateHttpClient(_settings.ApiEndpointUrl);
            using var response = await httpClient.PostAsJsonAsync("v1/search", request, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProviderTwoSearchResponse>(cancellationToken);
        }
    }
}
