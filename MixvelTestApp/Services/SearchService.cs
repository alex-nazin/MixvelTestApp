using MixvelTestApp.Models;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Сервис поиска маршрутов
    /// </summary>
    public sealed class SearchService
        : ISearchService
    {
        private readonly ILogger<SearchService> _logger;
        private readonly ISearcher[] _searchers;
        private readonly IRoutesCache _routesCache;

        /// <summary>
        /// Конструктор типа <see cref="SearchService"/>
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="searchers">Поисковики</param>
        /// <param name="routesCache">Кэш маршрутов</param>
        public SearchService(
            ILogger<SearchService> logger,
            IEnumerable<ISearcher> searchers,
            IRoutesCache routesCache)
        {
            _logger = logger;
            _searchers = searchers?.ToArray()
                ?? throw new ArgumentNullException(nameof(searchers));
            _routesCache = routesCache
                ?? throw new ArgumentNullException(nameof(routesCache));
        }

        /// <inheritdoc/>
        public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
        {
            // Будем считать что сервис поиска доступен, если хотя бы один из поисковиков доступен
            var tasks = _searchers.Select(s => s.IsAvailableAsync(cancellationToken)).ToArray();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error during availablity request");
            }

            foreach (var task in tasks)
            {
                if (task.IsCompletedSuccessfully &&
                    task.Result)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public async Task<SearchResponseModel> SearchAsync(SearchRequestModel request, CancellationToken cancellationToken)
        {
            var cachedRoutes = _routesCache.GetRoutes(CreateCacheKey(request));

            var providersRoutes = await GetProvidersRoutesAsync(request, cancellationToken);
            var joinedRoutes = JoinRoutes(providersRoutes, cachedRoutes);
            var summaryRoutes = FilterRoutes(request, joinedRoutes);

            SaveRoutesToCache(request, providersRoutes);

            var result = new SearchResponseModel
            {
                Routes = summaryRoutes,
            };

            if (summaryRoutes.Length > 0)
            {
                result.MinPrice = summaryRoutes.Min(r => r.Price);
                result.MaxPrice = summaryRoutes.Max(r => r.Price);
                // Не совсем понятно, что в этих полях, заполним хоть чем-то
                result.MinMinutesRoute = summaryRoutes.Min(r => (int)(r.DestinationDateTime - r.OriginDateTime).TotalMinutes);
                result.MaxMinutesRoute = summaryRoutes.Max(r => (int)(r.DestinationDateTime - r.OriginDateTime).TotalMinutes);
            }

            return result;
        }

        private async Task<List<RouteModel>> GetProvidersRoutesAsync(SearchRequestModel request, CancellationToken cancellationToken)
        {
            var results = new List<RouteModel>();

            if (request.Filters?.OnlyCached == true)
            {
                return results;
            }

            var tasks = _searchers.Select(s => s.SearchAsync(request, cancellationToken)).ToArray();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error during routes search");
            }

            foreach (var task in tasks)
            {
                if (task.IsCompletedSuccessfully &&
                    task.Result?.Length > 0)
                {
                    results.AddRange(task.Result);
                }
            }

            return results;
        }

        private void SaveRoutesToCache(SearchRequestModel request, List<RouteModel> providersRoutes)
        {
            // Если есть данные от провайдеров, то нужно обновить кэш
            if (request.Filters?.OnlyCached != true)
            {
                _routesCache.AddRoutes(CreateCacheKey(request), providersRoutes);
            }
        }

        private static RouteModel[] FilterRoutes(SearchRequestModel request, List<RouteModel> routes)
        {
            var now = DateTime.UtcNow;
            var filteredRoutes = routes
                .Where(r => r.TimeLimit >= now);

            if (request.Filters?.MaxPrice != null)
            {
                filteredRoutes = filteredRoutes
                    .Where(r => r.Price <= request.Filters.MaxPrice);
            }

            if (request.Filters?.DestinationDateTime != null)
            {
                filteredRoutes = filteredRoutes
                    .Where(r => r.DestinationDateTime <= request.Filters.DestinationDateTime);
            }

            if (request.Filters?.MinTimeLimit != null)
            {
                filteredRoutes = filteredRoutes
                    .Where(r => r.TimeLimit >= request.Filters.MinTimeLimit);
            }

            return filteredRoutes.ToArray();
        }

        private static List<RouteModel> JoinRoutes(List<RouteModel> providersRoutes, List<RouteModel>? cachedRoutes)
        {
            List<RouteModel> results = new(providersRoutes.Count + cachedRoutes?.Count ?? 0);

            // Приоритетом являются результаты провайдера
            results.AddRange(providersRoutes);

            // Но если есть записи, отличающиеся по цене или по времени отправления,
            // то можно добавить данные из кэша
            if (cachedRoutes != null)
            {
                foreach (var cachedRoute in cachedRoutes)
                {
                    if (!providersRoutes.Any(r => IsSameRoute(r, cachedRoute)))
                    {
                        results.Add(cachedRoute);
                    }
                }
            }

            return results;
        }

        private static bool IsSameRoute(RouteModel left, RouteModel right)
        {
            return left.Origin == right.Origin &&
                left.Destination == right.Destination &&
                left.OriginDateTime == right.OriginDateTime &&
                left.DestinationDateTime == right.DestinationDateTime &&
                left.Price == right.Price;
        }

        private static RoutesCacheKey CreateCacheKey(SearchRequestModel request)
        {
            return new RoutesCacheKey(request.Origin, request.Destination, request.OriginDateTime, request.Filters?.DestinationDateTime, request.Filters?.MaxPrice);
        }
    }
}
