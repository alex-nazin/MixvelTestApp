using Microsoft.AspNetCore.Mvc;
using ProviderTwo.Dtos;
using ProviderTwoApp.Services;

namespace ProviderTwoApp.Controllers
{
    /// <summary>
    /// Контроллер поиска маршрутов
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IProviderTwoSearchService _providerTwoSearchService;

        /// <summary>
        /// Конструктор типа <see cref="SearchController"/>
        /// </summary>
        /// <param name="providerTwoSearchService">Сервис поиска маршрутов</param>
        public SearchController(IProviderTwoSearchService providerTwoSearchService)
        {
            _providerTwoSearchService = providerTwoSearchService
                ?? throw new ArgumentNullException(nameof(providerTwoSearchService));
        }

        /// <summary>
        /// Поиск маршрутов по заданным критериям
        /// </summary>
        /// <param name="request">Критерии поиска маршрутов</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        [HttpPost]
        public async Task<ProviderTwoSearchResponse> SearchAsync(
            [FromBody] ProviderTwoSearchRequest request,
            CancellationToken cancellationToken)
        {
            return await _providerTwoSearchService.SearchAsync(request, cancellationToken);
        }
    }
}
