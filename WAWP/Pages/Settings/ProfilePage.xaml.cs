using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WAWP.Pages.Settings
{
    public partial class ProfilePage : PhoneApplicationPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private void ChangeName_Click(object sender, RoutedEventArgs e)
        {
            profileBox.BorderThickness = new Thickness(3.0, 3.0, 3.0, 3.0); // checked with XAML from Microsoft
            profileBox.Focus();
        }

        private void profileBox_LostFocus(object sender, RoutedEventArgs e)
        {
            profileBox.BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0);
        }
    }
}