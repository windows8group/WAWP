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

namespace WAWP.Assets.Pages
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            SettingsList.ItemsSource = new List<SettingsItem>();

            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.About, Description = AppResources.About_Des, Destination = "AboutPage"});
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Contacts, Description = AppResources.Contacts_Des, Destination = "ContactsPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Account, Description = AppResources.Account_Des, Destination = "AccountPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Profile, Description = AppResources.Profile_Des, Destination = "ProfilePage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Chat_Settings, Description = AppResources.Chat_Settings_Des, Destination = "ChatSettingsPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Lock_Screen, Description = AppResources.Lock_Screen_Des, Destination = "LockScreenPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Notif_Sounds, Description = AppResources.Notif_Sounds_Des, Destination = "NotificationsPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Rotation, Description = AppResources.Rotation_Des, Destination = "RotationPage" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Connectivity, Description = AppResources.Connectivity_Des, Destination = "ConnectivityPage" });

            header.Text = AppResources.Settings;
        }

        private async void SettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (SettingsList.SelectedItem == null)
                return;

            // Get the selected item
            SettingsItem selectedItem = SettingsList.SelectedItem as SettingsItem;

            // Navigate to the next page using the 'dest' property
            switch (selectedItem.Destination)
            {
                case "LockScreenPage":
                    await Windows.System.Launcher.LaunchUriAsync(new System.Uri("ms-settings-lock:"));
                    break;

                case "RotationPage":
                    await Windows.System.Launcher.LaunchUriAsync(new System.Uri("ms-settings-screenrotation:"));
                    break;

                default:
                    NavigationService.Navigate(new Uri("/Pages/Settings/" + selectedItem.Destination + ".xaml", UriKind.Relative));
                    break;
            }

            // Reset selected item to null
            SettingsList.SelectedItem = null;
        }
    }
}