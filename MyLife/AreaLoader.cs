// <copyright file="AreaLoader.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class AreaLoader
    {
        public static IAreaRegistry[] GetAreaRegistries()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            return (from t in types
                    where t.IsClass
                    where typeof(IAreaRegistry).IsAssignableFrom(t)
                    select (IAreaRegistry)Activator.CreateInstance(t)).ToArray();
        }
    }
}
