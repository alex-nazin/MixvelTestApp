using Microsoft.AspNetCore.Mvc;
using ProviderOne.Dtos;
using ProviderOneApp.Services;

namespace ProviderOneApp.Controllers
{
    /// <summary>
    /// ���������� ������ ���������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IProviderOneSearchService _providerOneSearchService;

        /// <summary>
        /// ����������� ���� <see cref="SearchController"/>
        /// </summary>
        /// <param name="providerOneSearchService">������ ������ ���������</param>
        public SearchController(
            IProviderOneSearchService providerOneSearchService)
        {
            _providerOneSearchService = providerOneSearchService
                ?? throw new ArgumentNullException(nameof(providerOneSearchService));
        }

        /// <summary>
        /// ����� ��������� �� �������� ���������
        /// </summary>
        /// <param name="request">�������� ������ ���������</param>
        /// <param name="cancellationToken">����� ������ ��������</param>
        [HttpPost]
        public async Task<ProviderOneSearchResponse> SearchAsync(
            [FromBody] ProviderOneSearchRequest request,
            CancellationToken cancellationToken)
        {
            return await _providerOneSearchService.SearchAsync(request, cancellationToken);
        }
    }
}
