using ProviderOne.Dtos;

namespace ProviderOneApp.Services
{
    /// <summary>
    /// Сервис поиска маршрутов
    /// </summary>
    public interface IProviderOneSearchService
    {
        /// <summary>
        /// Поиск маршрута по заданным критериям
        /// </summary>
        /// <param name="request">Объект, описывающий критерии поиска</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<ProviderOneSearchResponse> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken);
    }
}
