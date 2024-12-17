using ProviderOne.Dtos;

namespace ProviderOneApp.Services
{
    /// <summary>
    /// Этот провайдер предоставляет два варианта путешествия:
    /// 1. На две недели
    /// 2. На три недели
    /// Для путешествия на две недели актуальность предложения составляет 5 минут
    /// Для путешествия на три недели актуальность предложения составляет 10 минут
    /// Базовая стоимость одного дня рассчитывается как длина строки "From-To" * 1000
    /// и умножается на число дней (сделано для повторяемости результата)
    /// </summary>
    public sealed class ProviderOneSearchService
        : IProviderOneSearchService
    {
        /// <summary>
        /// Перечень возможных длительностей путешествий и их соответствующее время жизни
        /// </summary>
        private static readonly (TimeSpan RouteDuration, TimeSpan TimeToLive)[] PredefinedRoutes =
        [
            (TimeSpan.FromDays(14), TimeSpan.FromMinutes(5)),
            (TimeSpan.FromDays(28), TimeSpan.FromMinutes(10)),
        ];

        /// <inheritdoc/>
        public Task<ProviderOneSearchResponse> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken)
        {
            var basePrice = $"{request.From}-{request.To}".Length * 1000;

            var routes = PredefinedRoutes
                .Select(r => CreateRoute(request, basePrice, r.RouteDuration, r.TimeToLive))
                .Where(r => r != null)
                .Select(r => r!)
                .ToArray();

            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(new ProviderOneSearchResponse
            {
                Routes = routes
            });
        }

        private static ProviderOneRoute? CreateRoute(
            ProviderOneSearchRequest request,
            int pricePerDay,
            TimeSpan routeDuration,
            TimeSpan timeToLive)
        {
            var dateTo = request.DateFrom.Add(routeDuration);
            if (request.DateTo.HasValue &&
                request.DateTo.Value < dateTo)
            {
                // Условие по дате окончания путешествия не соблюдается, предлагаемое путешествие заканчивается позже
                return null;
            }

            var fullPrice = pricePerDay * (int)routeDuration.TotalDays;
            if (request.MaxPrice.HasValue &&
                request.MaxPrice.Value > fullPrice)
            {
                // Условие по максимальной стоимости путешествия не соблюдается
                return null;
            }

            return new ProviderOneRoute
            {
                From = request.From,
                To = request.To,
                DateFrom = request.DateFrom,
                DateTo = dateTo,
                Price = fullPrice,
                TimeLimit = DateTime.UtcNow.Add(timeToLive),
            };
        }
    }
}
