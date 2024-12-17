using AutoMapper;
using MixvelTestApp.Models;
using ProviderTwo.Dtos;

namespace MixvelTestApp.Services.ProviderTwo
{
    /// <summary>
    /// Поисковик маршрутов во втором провайдере
    /// </summary>
    public sealed class ProviderTwoSearcher
        : ISearcher
    {
        private readonly IProviderTwoClient _providerTwoClient;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор типа <see cref="ProviderTwoSearcher"/>
        /// </summary>
        /// <param name="providerTwoClient">Клиент к второму провайдеру</param>
        /// <param name="mapper">Маппер объектов</param>
        public ProviderTwoSearcher(
            IProviderTwoClient providerTwoClient,
            IMapper mapper)
        {
            _providerTwoClient = providerTwoClient
                ?? throw new ArgumentNullException(nameof(providerTwoClient));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            return await _providerTwoClient.GetIsAvailableAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<RouteModel[]> SearchAsync(SearchRequestModel request, CancellationToken cancellationToken)
        {
            if (await IsAvailableAsync(cancellationToken))
            {
                // Не будем искать, если провайдеру плохо
                var providerTwoRequest = _mapper.Map<ProviderTwoSearchRequest>(request);
                var searchResult = await _providerTwoClient.SearchAsync(providerTwoRequest, cancellationToken);
                if (searchResult?.Routes?.Length > 0)
                {
                    return _mapper.Map<RouteModel[]>(searchResult.Routes);
                }
            }

            return [];
        }
    }
}
