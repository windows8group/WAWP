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
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<SettingsItem> settings = new List<SettingsItem>();
            settings.Add(new SettingsItem() { Name = "about", Description = "meet the Team" });
            settings.Add(new SettingsItem() { Name = "contacts", Description = "invite a friend, block" });
            settings.Add(new SettingsItem() { Name = "account", Description = "privacy, delete account" });
            settings.Add(new SettingsItem() { Name = "profile", Description = "name, set an avatar, status" });
            settings.Add(new SettingsItem() { Name = "chat settings", Description = "auto-download, wallpaper, backup" });
            settings.Add(new SettingsItem() { Name = "lock screen", Description = "add WAWP on a lock screen" });
            settings.Add(new SettingsItem() { Name = "notification sounds", Description = "change notification sounds" });
            settings.Add(new SettingsItem() { Name = "rotation", Description = "auto-rotate or block rotation" });
            settings.Add(new SettingsItem() { Name = "connectivity", Description = "change connectivity type" });

            SettingsList.ItemsSource = settings;
        }
    }
}