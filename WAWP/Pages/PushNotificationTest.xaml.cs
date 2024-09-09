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
    public partial class PushNotificationTest : PhoneApplicationPage
    {
        public PushNotificationTest()
        {
            InitializeComponent();
        }

        private void NotifyButton_Click(object sender, RoutedEventArgs e)
        {
            // Define the toast message
            ShellToast toast = new ShellToast();
            toast.Title = "WAMP Notificitation Test";
            toast.Content = "This is the message content!";
            toast.NavigationUri = new Uri("/Pages/PushNotificationTest.xaml", UriKind.Relative); // Navigation on click

            // Show the toast notification
            toast.Show();
        }

        private void NotifyButton_Click_Server(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sadly, we couldn't reach our servers, try checking your connection!", "WAMP Notification Test", MessageBoxButton.OK);
        }

    }
}