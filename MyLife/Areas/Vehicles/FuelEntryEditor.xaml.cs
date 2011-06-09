// <copyright file="FuelEntryEditor.xaml.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife.Areas.Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using MyLife.Data;

    public partial class FuelEntryEditor : PhoneApplicationPage
    {
        private FuelEntryViewModel entry = new FuelEntryViewModel();

        public FuelEntryEditor()
        {
            InitializeComponent();
        }

        public FuelEntryViewModel Entry
        {
            get
            {
                return this.entry;
            }

            set
            {
                this.entry = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = GetItemIndex();
            if (index.HasValue)
            {
                var oldEntry = App.Current.DB.FuelEntries[index.Value];
                this.entry.Date = oldEntry.Date;
                this.entry.Odometer = oldEntry.Odometer;
                this.entry.Gallons = oldEntry.Gallons;
                this.entry.Cost = oldEntry.Cost;
            }
            else
            {
                this.entry.Date = DateTime.Today;
            }
        }

        private int? GetItemIndex()
        {
            string indexStr;
            if (!NavigationContext.QueryString.TryGetValue("itemIndex", out indexStr))
            {
                return null;
            }

            int index;
            if (!int.TryParse(indexStr, out index))
            {
                return null;
            }

            return index;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var index = GetItemIndex();
            if (index.HasValue)
            {
                var oldEntry = App.Current.DB.FuelEntries[index.Value];
                oldEntry.Date = this.entry.Date;
                oldEntry.Odometer = this.entry.Odometer;
                oldEntry.Gallons = this.entry.Gallons;
                oldEntry.Cost = this.entry.Cost;
            }
            else
            {
                var newEntry = new Database.FuelEntry
                {
                    Date = this.entry.Date,
                    Odometer = this.entry.Odometer,
                    Gallons = this.entry.Gallons,
                    Cost = this.entry.Cost,
                };
                App.Current.DB.FuelEntries.Add(newEntry);
            }

            Database.Save(App.Current.DB);

            NavigationService.GoBack();
        }

        public class FuelEntryViewModel : DependencyObject
        {
            public static readonly DependencyProperty DateProperty =
                DependencyProperty.Register("Date", typeof(DateTime), typeof(FuelEntryViewModel), new PropertyMetadata(null));

            public static readonly DependencyProperty OdometerProperty =
                DependencyProperty.Register("Odometer", typeof(decimal), typeof(FuelEntryViewModel), new PropertyMetadata(0M));

            public static readonly DependencyProperty GallonsProperty =
                DependencyProperty.Register("Gallons", typeof(decimal), typeof(FuelEntryViewModel), new PropertyMetadata(0M));

            public static readonly DependencyProperty CostProperty =
                DependencyProperty.Register("Cost", typeof(decimal), typeof(FuelEntryViewModel), new PropertyMetadata(0M));

            public DateTime Date
            {
                get { return (DateTime)GetValue(DateProperty); }
                set { SetValue(DateProperty, value); }
            }

            public decimal Odometer
            {
                get { return (decimal)GetValue(OdometerProperty); }
                set { SetValue(OdometerProperty, value); }
            }

            public decimal Gallons
            {
                get { return (decimal)GetValue(GallonsProperty); }
                set { SetValue(GallonsProperty, value); }
            }

            public decimal Cost
            {
                get { return (decimal)GetValue(CostProperty); }
                set { SetValue(CostProperty, value); }
            }
        }
    }
}
