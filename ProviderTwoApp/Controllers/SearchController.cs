using Microsoft.AspNetCore.Mvc;
using ProviderTwo.Dtos;
using ProviderTwoApp.Services;

namespace ProviderTwoApp.Controllers
{
    /// <summary>
    /// ���������� ������ ���������
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IProviderTwoSearchService _providerTwoSearchService;

        /// <summary>
        /// ����������� ���� <see cref="SearchController"/>
        /// </summary>
        /// <param name="providerTwoSearchService">������ ������ ���������</param>
        public SearchController(IProviderTwoSearchService providerTwoSearchService)
        {
            _providerTwoSearchService = providerTwoSearchService
                ?? throw new ArgumentNullException(nameof(providerTwoSearchService));
        }

        /// <summary>
        /// ����� ��������� �� �������� ���������
        /// </summary>
        /// <param name="request">�������� ������ ���������</param>
        /// <param name="cancellationToken">����� ������ ��������</param>
        [HttpPost]
        public async Task<ProviderTwoSearchResponse> SearchAsync(
            [FromBody] ProviderTwoSearchRequest request,
            CancellationToken cancellationToken)
        {
            return await _providerTwoSearchService.SearchAsync(request, cancellationToken);
        }
    }
}
