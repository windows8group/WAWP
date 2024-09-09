using System;
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
    public partial class CMDPage : PhoneApplicationPage
    {
        public CMDPage()
        {
            InitializeComponent(); 
        }

        private void help(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Commands: PUSH, more soon", "WAMP CMD", MessageBoxButton.OK);
        }

        private void cmd_go(object sender, RoutedEventArgs e)
        {
            string cmdcommandpush = "PUSH";

            if (cmdbox.Text == cmdcommandpush)
            {
                MessageBox.Show("Moving.");
                NavigationService.Navigate(new Uri("/Pages/CMDPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }
    }
}