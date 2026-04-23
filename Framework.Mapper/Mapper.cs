using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Mapper
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<TSource, TDestination>(source);
        }
        public static IList<TDestination> Map<TSource, TDestination>(IList<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }
    }
}
