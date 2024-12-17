using ProviderOne.Dtos;

namespace MixvelTestApp.Services.ProviderOne
{
    /// <summary>
    /// Клиент для первого провайдера
    /// </summary>
    public interface IProviderOneClient
    {
        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="request">Критерии поиска</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результаты поиска</returns>
        Task<ProviderOneSearchResponse?> SearchAsync(ProviderOneSearchRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получение статуса провайдера
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<bool> GetIsAvailableAsync(CancellationToken cancellationToken);
    }
}
