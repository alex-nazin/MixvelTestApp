using ProviderTwo.Dtos;

namespace MixvelTestApp.Services.ProviderTwo
{
    /// <summary>
    /// Клиент для второго провайдера
    /// </summary>
    public interface IProviderTwoClient
    {
        /// <summary>
        /// Поиск маршрута
        /// </summary>
        /// <param name="request">Критерии поиска</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        /// <returns>Результаты поиска</returns>
        Task<ProviderTwoSearchResponse?> SearchAsync(ProviderTwoSearchRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Получение статуса провайдера
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        Task<bool> GetIsAvailableAsync(CancellationToken cancellationToken);

    }
}
