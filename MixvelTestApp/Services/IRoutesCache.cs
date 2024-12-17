using MixvelTestApp.Models;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Кэш маршрутов
    /// </summary>
    public interface IRoutesCache
    {
        /// <summary>
        /// Добавление набора маршрутов в кэш
        /// </summary>
        /// <param name="key">Ключ, связанный с набором</param>
        /// <param name="routes">Сохраняемые маршруты</param>
        void AddRoutes(RoutesCacheKey key, List<RouteModel>? routes);

        /// <summary>
        /// Получение набора маршрутов по ключу
        /// </summary>
        /// <param name="key">Ключ, связанный с набором</param>
        /// <returns>Набор маршрутов из кэша, или null, если такого набора нет</returns>
        List<RouteModel>? GetRoutes(RoutesCacheKey key);
    }
}
