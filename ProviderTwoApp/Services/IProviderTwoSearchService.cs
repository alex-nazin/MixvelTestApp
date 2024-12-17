using ProviderTwo.Dtos;

namespace ProviderTwoApp.Services
{
    /// <summary>
    /// Сервис поиска маршрутов
    /// </summary>
    public interface IProviderTwoSearchService
    {
        /// <summary>
        /// Поиск маршрута по заданным критериям
        /// </summary>
        /// <param name="request">Объект, описывающий критерии поиска</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<ProviderTwoSearchResponse> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken);
    }
}
