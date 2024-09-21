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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> settings = new List<SettingsItem>();

            settings.Add(new SettingsItem() { Name = AppResources.About, Description = AppResources.About_Des, Destination = "AboutPage"});
            settings.Add(new SettingsItem() { Name = AppResources.Contacts, Description = "invite a friend, block", Destination = "ContactsPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Account, Description = "privacy, delete account", Destination = "AccountPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Profile, Description = "name, set an avatar, status", Destination = "ProfilePage" });
            settings.Add(new SettingsItem() { Name = AppResources.Chat_Settings, Description = "auto-download, wallpaper, backup and customize more", Destination = "ChatSettingsPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Lock_Screen, Description = "add WAWP on a lock screen", Destination = "LockScreenPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Notif_Sounds, Description = "change notification sounds", Destination = "NotificationsPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Rotation, Description = "auto-rotate or block rotation", Destination = "RotationPage" });
            settings.Add(new SettingsItem() { Name = AppResources.Connectivity, Description = "change connectivity type", Destination = "ConnectivityPage" });

            SettingsList.ItemsSource = settings;

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