// <copyright file="VehiclesAreaRegistry.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Areas.Transportation
{
    using System;

    public class VehiclesAreaRegistry : IAreaRegistry
    {
        public string Name
        {
            get { return "Vehicles"; }
        }
    }
}
