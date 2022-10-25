using alura_backend_challenge_3.Data.ValueObjects;
using alura_backend_challenge_3.Models.Base;
using AutoMapper;

namespace alura_backend_challenge_3.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<VideoVO, VideoEntity>();
                config.CreateMap<VideoEntity, VideoVO>();
            });

            return mappingConfig;
        }
    }
}
