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
            settings.Add(new SettingsItem() { Name = "about", Description = "meet the Team", Destination = "AboutPage"});
            settings.Add(new SettingsItem() { Name = "contacts", Description = "invite a friend, block", Destination = "ContactsPage" });
            settings.Add(new SettingsItem() { Name = "account", Description = "privacy, delete account", Destination = "AccountPage" });
            settings.Add(new SettingsItem() { Name = "profile", Description = "name, set an avatar, status", Destination = "ProfilePage" });
            settings.Add(new SettingsItem() { Name = "chat settings", Description = "auto-download, wallpaper, backup", Destination = "ChatSettingsPage" });
            settings.Add(new SettingsItem() { Name = "lock screen", Description = "add WAWP on a lock screen", Destination = "LockScreenPage" });
            settings.Add(new SettingsItem() { Name = "notification sounds", Description = "change notification sounds", Destination = "NotificationsPage" });
            settings.Add(new SettingsItem() { Name = "rotation", Description = "auto-rotate or block rotation", Destination = "RotationPage" });
            settings.Add(new SettingsItem() { Name = "connectivity", Description = "change connectivity type", Destination = "ConnectivityPage" });

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
            if (selectedItem.Destination == "LockScreenPage")
                await Windows.System.Launcher.LaunchUriAsync(new System.Uri("ms-settings-lock:"));
            else if (selectedItem.Destination == "RotationPage")
                await Windows.System.Launcher.LaunchUriAsync(new System.Uri("ms-settings-screenrotation:"));
            else
            NavigationService.Navigate(new Uri("/Pages/Settings/" + selectedItem.Destination + ".xaml", UriKind.Relative));

            // Reset selected item to null
            SettingsList.SelectedItem = null;
        }
    }
}