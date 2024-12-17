using ProviderTwo.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ProviderTwoApp.Services
{
    /// <summary>
    /// Этот провайдер предоставляет три варианта путешествия:
    /// 1. На 10 дней
    /// 2. На 15 дней
    /// 3. На 20 дней
    /// Для путешествия на 10 дней актуальность предложения составляет 3 минуты
    /// Для путешествия на 15 дней актуальность предложения составляет 5 минут
    /// Для путешествия на 20 дней актуальность предложения составляет 8 минут
    /// Базовая стоимость одного дня рассчитывается как длина строки "Departure-Arrival" * 1000
    /// и умножается на число дней (сделано для повторяемости результата)
    /// </summary>
    public sealed class ProviderTwoSearchService
        : IProviderTwoSearchService
    {
        /// <summary>
        /// Перечень возможных длительностей путешествий и их соответствующее время жизни
        /// </summary>
        private static readonly (TimeSpan RouteDuration, TimeSpan TimeToLive)[] PredefinedRoutes =
        [
            (TimeSpan.FromDays(10), TimeSpan.FromMinutes(3)),
            (TimeSpan.FromDays(15), TimeSpan.FromMinutes(5)),
            (TimeSpan.FromDays(20), TimeSpan.FromMinutes(8)),
        ];

        /// <inheritdoc/>
        public Task<ProviderTwoSearchResponse> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var basePrice = $"{request.Departure}-{request.Arrival}".Length * 1000;

            var routes = PredefinedRoutes
                .Select(r => CreateRoute(request, basePrice, r.RouteDuration, r.TimeToLive))
                .Where(r => r != null)
                .Select(r => r!)
                .ToArray();

            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(new ProviderTwoSearchResponse
            {
                Routes = routes
            });
        }

        private static void ValidateRequest(ProviderTwoSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Departure))
            {
                throw new ValidationException($"{nameof(request.Departure)} not specified");
            }

            if (string.IsNullOrEmpty(request.Arrival))
            {
                throw new ValidationException($"{nameof(request.Arrival)} not specified");
            }
        }

        private static ProviderTwoRoute? CreateRoute(
            ProviderTwoSearchRequest request,
            int pricePerDay,
            TimeSpan routeDuration,
            TimeSpan timeToLive)
        {
            var timeLimit = DateTime.UtcNow.Add(timeToLive);
            if (request.MinTimeLimit.HasValue &&
                request.MinTimeLimit.Value > timeLimit)
            {
                // Условие по актуальности маршрута до заданного времени не соблюдается
                return null;
            }

            return new ProviderTwoRoute
            {
                Departure = new ProviderTwoPoint
                {
                    Point = request.Departure,
                    Date = request.DepartureDate,
                },
                Arrival = new ProviderTwoPoint
                {
                    Point = request.Arrival,
                    Date = request.DepartureDate.Add(routeDuration),
                },
                Price = pricePerDay * (int)routeDuration.TotalDays,
                TimeLimit = timeLimit,
            };
        }
    }
}
