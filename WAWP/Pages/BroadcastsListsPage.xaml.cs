﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WAWP.Assets.Pages
{
    public partial class BroadcastsListsPage : PhoneApplicationPage
    {
        public BroadcastsListsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("YAY MAP!", "WAWP Button Test", MessageBoxButton.OK);
        }
    }
}