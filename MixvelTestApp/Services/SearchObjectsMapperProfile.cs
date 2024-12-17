using AutoMapper;

namespace MixvelTestApp.Services
{
    /// <summary>
    /// Профиль конвертации между моделями и DTO
    /// </summary>
    public class SearchObjectsMapperProfile
        : Profile
    {
        /// <summary>
        /// Конструктор типа <see cref="SearchObjectsMapperProfile"/>
        /// </summary>
        public SearchObjectsMapperProfile()
        {
            CreateMap<Dtos.SearchFilters, Models.SearchFiltersModel>();
            CreateMap<Dtos.SearchRequest, Models.SearchRequestModel>();
            CreateMap<Models.SearchResponseModel, Dtos.SearchResponse>();
            CreateMap<Models.RouteModel, Dtos.Route>();
        }
    }
}
