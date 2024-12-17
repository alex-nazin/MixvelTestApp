
using MixvelTestApp.Application.Settings;
using MixvelTestApp.Services;
using MixvelTestApp.Services.ProviderOne;
using MixvelTestApp.Services.ProviderTwo;

namespace MixvelTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(x =>
            {
                x.AddProfile<SearchObjectsMapperProfile>();
                x.AddProfile<ProviderOneMappingProfile>();
                x.AddProfile<ProviderTwoMappingProfile>();
            });
            builder.Services.AddMemoryCache();

            builder.Services.AddSingleton<Services.IHttpClientFactory, HttpClientFactory>();
            builder.Services.AddSingleton<IRoutesCache, RoutesCache>();
            builder.Services.AddTransient<ISearchService, SearchService>();
            builder.Services.AddTransient<IProviderOneClient, ProviderOneClient>();
            builder.Services.AddTransient<IProviderTwoClient, ProviderTwoClient>();
            builder.Services.AddTransient<ISearcher, ProviderOneSearcher>();
            builder.Services.AddTransient<ISearcher, ProviderTwoSearcher>();

            var configuration = builder.Configuration;
            builder.Services.Configure<ProviderOneSettings>(configuration.GetSection(nameof(ProviderOneSettings)));
            builder.Services.Configure<ProviderTwoSettings>(configuration.GetSection(nameof(ProviderTwoSettings)));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
