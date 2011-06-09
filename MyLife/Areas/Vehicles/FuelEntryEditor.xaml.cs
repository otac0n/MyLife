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

    public partial class FuelEntryEditor : PhoneApplicationPage
    {
        private Database.FuelEntry entry = new Database.FuelEntry();

        public FuelEntryEditor()
        {
            InitializeComponent();
        }

        public Database.FuelEntry Entry
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
    }
}
