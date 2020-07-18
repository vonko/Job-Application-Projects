using AutoMapper;
using System;

namespace FootballLeague.Services.Automapper
{
    public class AutomapperConfiguration
    {
        public static void Configure<TProfile>(Action<IMapperConfigurationExpression> configuration = null)
            where TProfile: Profile, new()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new TProfile());
                // if any callback config is passed, call it...
                configuration?.Invoke(cfg);
            });
        }
    }
}