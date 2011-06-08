// <copyright file="MainPage.xaml.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using Microsoft.Phone.Controls;

    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            this.ViewModel = new MainPageViewModel();

            this.InitializeComponent();

            this.DiscoverAreas();
        }

        public MainPageViewModel ViewModel { get; private set; }

        private void DiscoverAreas()
        {
            var registries = AreaLoader.GetAreaRegistries();

            foreach (var registry in registries)
            {
                this.ViewModel.Areas.Add(registry);
            }
        }

        private void NavigateToTag(object sender, MouseButtonEventArgs e)
        {
            var element = (FrameworkElement)sender;
            App.Current.RootFrame.Navigate(element.Tag as Uri);
        }

        public class MainPageViewModel
        {
            public MainPageViewModel()
            {
                this.Areas = new ObservableCollection<IAreaRegistry>();
            }

            public ObservableCollection<IAreaRegistry> Areas { get; private set; }
        }
    }
}
