using AutoMapper;
using MixvelTestApp.Models;
using ProviderTwo.Dtos;

namespace MixvelTestApp.Services.ProviderTwo
{
    /// <summary>
    /// Профиль конвертеров объектов для второго провайдера
    /// </summary>
    public class ProviderTwoMappingProfile
        : Profile
    {
        /// <summary>
        /// Конструктор типа <see cref="ProviderTwoMappingProfile"/>
        /// </summary>
        public ProviderTwoMappingProfile()
        {
            CreateMap<SearchRequestModel, ProviderTwoSearchRequest>()
                .ConvertUsing(ConvertSearchRequest);
            CreateMap<ProviderTwoRoute, RouteModel>()
                .ConvertUsing(ConvertRouteModel);
        }

        private static RouteModel ConvertRouteModel(ProviderTwoRoute route, RouteModel _)
        {
            return new RouteModel
            {
                Id = Guid.NewGuid(),
                Origin = route.Departure.Point,
                OriginDateTime = route.Departure.Date,
                Destination = route.Arrival.Point,
                DestinationDateTime = route.Arrival.Date,
                Price = route.Price,
                TimeLimit = route.TimeLimit,
            };
        }

        private static ProviderTwoSearchRequest ConvertSearchRequest(SearchRequestModel source, ProviderTwoSearchRequest _)
        {
            return new ProviderTwoSearchRequest
            {
                Departure = source.Origin,
                Arrival = source.Destination,
                DepartureDate = source.OriginDateTime,
                MinTimeLimit = source.Filters?.MinTimeLimit,
            };
        }
    }
}
