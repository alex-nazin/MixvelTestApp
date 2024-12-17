using Microsoft.AspNetCore.Mvc;
using ProviderOne.Dtos;
using ProviderOneApp.Services;

namespace ProviderOneApp.Controllers
{
    /// <summary>
    /// Контроллер поиска маршрутов
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IProviderOneSearchService _providerOneSearchService;

        /// <summary>
        /// Конструктор типа <see cref="SearchController"/>
        /// </summary>
        /// <param name="providerOneSearchService">Сервис поиска маршрутов</param>
        public SearchController(
            IProviderOneSearchService providerOneSearchService)
        {
            _providerOneSearchService = providerOneSearchService
                ?? throw new ArgumentNullException(nameof(providerOneSearchService));
        }

        /// <summary>
        /// Поиск маршрутов по заданным критериям
        /// </summary>
        /// <param name="request">Критерии поиска маршрутов</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        [HttpPost]
        public async Task<ProviderOneSearchResponse> SearchAsync(
            [FromBody] ProviderOneSearchRequest request,
            CancellationToken cancellationToken)
        {
            return await _providerOneSearchService.SearchAsync(request, cancellationToken);
        }
    }
}
