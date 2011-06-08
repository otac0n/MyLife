// <copyright file="VehicleDatabase.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.Collections.Generic;

    public partial class Database
    {
        private List<FuelEntry> entries = new List<FuelEntry>();

        public List<FuelEntry> Entries
        {
            get
            {
                return this.entries;
            }

            set
            {
                this.entries = value;
            }
        }

        public class FuelEntry
        {
            public DateTime Date { get; set; }

            public decimal Cost { get; set; }

            public decimal Gallons { get; set; }
        }
    }
}
