using AutoMapper;
namespace AML.Infrastructure.Mappings
{
    public static class Mappings
    {
        public static MapperConfiguration CreateMapAndReturnConfig<Source, Dest>()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Dest>();
            });
            return config;
        }
    }
}
