using MixvelTestApp.Models;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Поисковик маршрутов
    /// </summary>
    public interface ISearcher
    {
        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="request">Модель запроса на поиск маршрутов</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<RouteModel[]> SearchAsync(SearchRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Получение признака доступности поиска
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
    }
}
