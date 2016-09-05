// <copyright file="Fuel.xaml.cs" company="(none)">
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
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;
    using MyLife.Data;
    using System.Windows.Threading;

    public partial class Fuel : PhoneApplicationPage
    {
        DispatcherTimer holdTimer;
        Action holdAction;

        public Fuel()
        {
            InitializeComponent();

            holdTimer = new DispatcherTimer();
            holdTimer.Interval = TimeSpan.FromSeconds(2);
            holdTimer.Tick += new EventHandler(HoldTimer_Tick);
        }

        public Database Database
        {
            get { return App.Current.DB; }
        }

        private void AddEntryButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Areas/Vehicles/FuelEntryEditor.xaml", UriKind.Relative));
        }

        private void Grid_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            this.holdTimer.Start();
            this.holdAction = () => Grid_LongHold(sender, e);
        }

        private void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            this.holdTimer.Stop();
        }

        void HoldTimer_Tick(object sender, EventArgs e)
        {
            this.holdTimer.Stop();
            var h = this.holdAction;
            if (h != null)
            {
                h();
            }
        }

        private void Grid_LongHold(object sender, ManipulationStartedEventArgs e)
        {
            var entry = ((FrameworkElement)sender).Tag as Database.FuelEntry;
            var index = this.Database.FuelEntries.IndexOf(entry);
            NavigationService.Navigate(new Uri("/Areas/Vehicles/FuelEntryEditor.xaml?itemIndex=" + index, UriKind.Relative));
        }
    }
}
