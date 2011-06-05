// <copyright file="MainPage.xaml.cs" company="(none)">
//  Copyright © 2010 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>

namespace MyLife
{
    using System;
    using System.Collections.Generic;
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
            InitializeComponent();

            this.DiscoverAreas();
        }

        private void DiscoverAreas()
        {
            var registries = AreaLoader.GetAreaRegistries();

            foreach (var registry in registries)
            {
                var text = new TextBlock
                {
                    Text = registry.Name,
                };
                this.AreasPanel.Children.Add(text);

                var item = new PanoramaItem
                {
                    Header = registry.Name,
                };
                this.AreasPanorama.Items.Add(item);
            }
        }
    }
}
