using AutoMapper;
using MixvelTestApp.Models;
using ProviderOne.Dtos;

namespace MixvelTestApp.Services.ProviderOne
{
    /// <summary>
    /// Поисковик маршрутов в первом провайдере
    /// </summary>
    public sealed class ProviderOneSearcher
        : ISearcher
    {
        private readonly IProviderOneClient _providerOneClient;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор типа <see cref="ProviderOneSearcher"/>
        /// </summary>
        /// <param name="providerOneClient">Клиент к первому провайдеру</param>
        /// <param name="mapper">Маппер объектов</param>
        public ProviderOneSearcher(
            IProviderOneClient providerOneClient,
            IMapper mapper)
        {
            _providerOneClient = providerOneClient
                ?? throw new ArgumentNullException(nameof(providerOneClient));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            return await _providerOneClient.GetIsAvailableAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<RouteModel[]> SearchAsync(SearchRequestModel request, CancellationToken cancellationToken)
        {
            if (await IsAvailableAsync(cancellationToken))
            {
                // Не будем искать, если провайдеру плохо
                var providerOneRequest = _mapper.Map<ProviderOneSearchRequest>(request);
                var searchResult = await _providerOneClient.SearchAsync(providerOneRequest, cancellationToken);
                if (searchResult?.Routes?.Length > 0)
                {
                    return _mapper.Map<RouteModel[]>(searchResult.Routes);
                }
            }

            return [];
        }
    }
}
