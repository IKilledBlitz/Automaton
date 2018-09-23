﻿using System.Collections.Generic;
using System.Linq;

namespace Automaton.Model.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool NullAndAny<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }
    }
}