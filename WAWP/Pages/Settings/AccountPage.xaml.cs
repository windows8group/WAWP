using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WAWP.Resources;

namespace WAWP.Pages.Settings
{
    public partial class AccountPage : PhoneApplicationPage
    {
        public AccountPage()
        {
            InitializeComponent();
            header.Text = AppResources.Account;
            privacy.Content = AppResources.PrivacyBtn;
            change.Content = AppResources.ChangeNumberBtn;
            delete.Content = AppResources.DeleteAccountBtn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sadly you can't do that now. let us make the magic here", "Expected exception", MessageBoxButton.OK);
        }
    }
}