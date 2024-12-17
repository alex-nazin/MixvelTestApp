using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MixvelTestApp.Dtos;
using MixvelTestApp.Models;
using MixvelTestApp.Services;

namespace MixvelTestApp.Controllers
{
    /// <summary>
    /// Контроллер поиска маршрутов
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор типа <see cref="SearchController"/>
        /// </summary>
        /// <param name="searchService">Сервис поиска</param>
        /// <param name="mapper">Преобразователь объектов</param>
        public SearchController(
            ISearchService searchService,
            IMapper mapper)
        {
            _searchService = searchService
                ?? throw new ArgumentNullException(nameof(searchService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Поиск маршрутов
        /// </summary>
        /// <param name="request">Запрос с критериями поиска</param>
        /// <param name="cancellationToken">Токен отмены операции</param>
        [HttpPost]
        public async Task<SearchResponse> SearchAsync(
            [FromBody] SearchRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _searchService.SearchAsync(_mapper.Map<SearchRequestModel>(request), cancellationToken);
            return _mapper.Map<SearchResponse>(result);
        }

        /// <summary>
        /// Получение признака работоспособности сервиса поиска
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции</param>
        [HttpGet("status")]
        public async Task<bool> GetStatusAsync(CancellationToken cancellationToken)
        {
            return await _searchService.IsAvailableAsync(cancellationToken);
        }
    }
}
