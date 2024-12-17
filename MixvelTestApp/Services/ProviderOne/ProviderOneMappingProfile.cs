using AutoMapper;
using MixvelTestApp.Models;
using ProviderOne.Dtos;

namespace MixvelTestApp.Services.ProviderOne
{
    /// <summary>
    /// Профиль конвертеров объектов для первого провайдера
    /// </summary>
    public class ProviderOneMappingProfile
        : Profile
    {
        /// <summary>
        /// Конструктор типа <see cref="ProviderOneMappingProfile"/>
        /// </summary>
        public ProviderOneMappingProfile()
        {
            CreateMap<SearchRequestModel, ProviderOneSearchRequest>()
                .ConvertUsing(ConvertSearchRequest);
            CreateMap<ProviderOneRoute, RouteModel>()
                .ConvertUsing(ConvertRoute);
        }

        private static RouteModel ConvertRoute(ProviderOneRoute route, RouteModel _)
        {
            return new RouteModel
            {
                Id = Guid.NewGuid(),
                Origin = route.From,
                Destination = route.To,
                OriginDateTime = route.DateFrom,
                DestinationDateTime = route.DateTo,
                Price = route.Price,
                TimeLimit = route.TimeLimit,
            };
        }

        private static ProviderOneSearchRequest ConvertSearchRequest(SearchRequestModel source, ProviderOneSearchRequest _)
        {
            return new ProviderOneSearchRequest
            {
                From = source.Origin,
                To = source.Destination,
                DateFrom = source.OriginDateTime,
                DateTo = source.Filters?.DestinationDateTime,
                MaxPrice = source.Filters?.MaxPrice,
            };
        }
    }
}
