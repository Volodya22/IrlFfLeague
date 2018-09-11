using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace IrlFfLeague.Web.Infrastructure.Mapping
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass).ToList();

            LoadMappings(types);
        }

        private static void LoadMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();   

            var customMaps = (from t in types
                              from i in t.GetInterfaces()
                              where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                                  && !t.IsAbstract
                                  && i.IsInterface
                              select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            Mapper.Initialize(cfg =>
            {
                foreach (var map in maps)
                {
                    cfg.CreateMap(map.Source, map.Destination);
                }

                foreach (var map in customMaps)
                {
                    map.CreateMappings(cfg);
                }
            });
        }
    }
}
