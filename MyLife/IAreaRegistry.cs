// <copyright file="IAreaRegistry.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.Collections.Generic;

    public interface IAreaRegistry
    {
        string Name { get; }

        IList<PageRegistration> Pages { get; }
    }
}
