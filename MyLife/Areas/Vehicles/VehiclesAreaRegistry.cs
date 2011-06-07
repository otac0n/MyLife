// <copyright file="VehiclesAreaRegistry.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Areas.Transportation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VehiclesAreaRegistry : IAreaRegistry
    {
        private static PageRegistration[] pages = new[]
        {
            new PageRegistration("Fuel", "/Areas/Vehicles/Fuel.xaml"),
            new PageRegistration("Maintenance", "/Areas/Vehicles/Maintenance.xaml"),
        };

        public VehiclesAreaRegistry()
        {
            this.Pages = pages.ToList().AsReadOnly();
        }

        public string Name
        {
            get { return "Vehicles"; }
        }

        public IList<PageRegistration> Pages { get; private set; }
    }
}
