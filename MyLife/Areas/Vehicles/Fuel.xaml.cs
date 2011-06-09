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

    public partial class Fuel : PhoneApplicationPage
    {
        public Fuel()
        {
            InitializeComponent();
        }

        public Database Database
        {
            get { return App.Current.DB; }
        }
    }
}
