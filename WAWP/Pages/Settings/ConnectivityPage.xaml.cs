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
    public partial class ConnectivityPage : PhoneApplicationPage
    {

        public ConnectivityPage()
        {
            InitializeComponent();

            OffServerList.ItemsSource = new List<SettingsItem>();

            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0"});
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server1", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server2", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server3", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server4", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server5", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server6", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server7", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server8", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server9", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server10", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });
            OffServerList.ItemsSource.Add(new SettingsItem() { Name = "Test Server11", Description = "used as a ref for a designer", ImgUri = "/Toolkit.Content/ApplicationBar.Check.png", IsSelected = "0" });

            header.Text = AppResources.Connectivity;
            OfficialTab.Header = AppResources.OfficialTab;
            CustomTab.Header = AppResources.CustomTab;
            ServerAddress.Hint = AppResources.ServerAddress;
            server.Text = AppResources.server;
        }

        private void OffServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = OffServerList.SelectedItem as SettingsItem;
            if (selectedItem != null)
            {
                selectedItem.IsSelected = "1";
                server.Text = selectedItem.Name;
                
            }
        }
    }
}