using System;
using System.Collections.Generic;

namespace MenuConfigurator.Model
{
    public static class Enums
    {
        public static IEnumerable<T> GetEnumList<T>() where T : Enum
            => new List<T>((T[])Enum.GetValues(typeof(T)));
    }
}