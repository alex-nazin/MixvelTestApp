using Microsoft.Extensions.Caching.Memory;
using MixvelTestApp.Models;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Кэш маршрутов
    /// </summary>
    public sealed class RoutesCache
        : IRoutesCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ReaderWriterLockSlim _guard = new();

        /// <summary>
        /// Конструктор типа <see cref="RoutesCache"/>
        /// </summary>
        /// <param name="memoryCache">Базовый кэш</param>
        public RoutesCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache
                ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        /// <inheritdoc/>
        public void AddRoutes(RoutesCacheKey key, List<RouteModel>? routes)
        {
            _guard.EnterWriteLock();

            try
            {
                if (routes == null ||
                    routes.Count == 0)
                {
                    _memoryCache.Remove(key);
                }
                else
                {
                    // Запись удалится из кэша тогда, когда станет невалидным маршрут с максимальным
                    // сроком жизни.
                    _memoryCache.Set(key, routes!, new DateTimeOffset(routes.Max(r => r.TimeLimit)));
                }
            }
            finally
            {
                _guard.ExitWriteLock();
            }
        }

        /// <inheritdoc/>
        public List<RouteModel>? GetRoutes(RoutesCacheKey key)
        {
            _guard.EnterReadLock();

            try
            {
                return _memoryCache.Get<List<RouteModel>>(key);
            }
            finally
            {
                _guard.ExitReadLock();
            }
        }
    }
}
