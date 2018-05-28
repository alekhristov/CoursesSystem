using System.Collections.Generic;
using System.Linq;

namespace CoursesSystem.Utils.Contracts
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);

        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);

        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);

        IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
