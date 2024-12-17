using MixvelTestApp.Models;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Сервис поиска
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="request">Модель запроса на поиск маршрутов</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<SearchResponseModel> SearchAsync(SearchRequestModel request, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка доступности сервиса
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
    }
}
