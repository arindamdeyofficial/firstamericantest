using AutoMapper;
using BusinessModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public class AutomapperProfile
    {
        public static void AutomapperConfig(IServiceCollection services, IConfiguration config)
        {
            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new MappingProfile())
            );
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}