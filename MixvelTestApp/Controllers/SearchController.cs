using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MixvelTestApp.Dtos;
using MixvelTestApp.Models;
using MixvelTestApp.Services;

namespace MixvelTestApp.Controllers
{
    /// <summary>
    /// ���������� ������ ���������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        /// <summary>
        /// ����������� ���� <see cref="SearchController"/>
        /// </summary>
        /// <param name="searchService">������ ������</param>
        /// <param name="mapper">��������������� ��������</param>
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
        /// ����� ���������
        /// </summary>
        /// <param name="request">������ � ���������� ������</param>
        /// <param name="cancellationToken">����� ������ ��������</param>
        [HttpPost]
        public async Task<SearchResponse> SearchAsync(
            [FromBody] SearchRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _searchService.SearchAsync(_mapper.Map<SearchRequestModel>(request), cancellationToken);
            return _mapper.Map<SearchResponse>(result);
        }

        /// <summary>
        /// ��������� �������� ����������������� ������� ������
        /// </summary>
        /// <param name="cancellationToken">����� ������ ��������</param>
        [HttpGet("status")]
        public async Task<bool> GetStatusAsync(CancellationToken cancellationToken)
        {
            return await _searchService.IsAvailableAsync(cancellationToken);
        }
    }
}
