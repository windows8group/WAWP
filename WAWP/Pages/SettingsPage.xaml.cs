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
            settings.Add(new SettingsItem() { name = "about", desc = "meet the Team" });
            settings.Add(new SettingsItem() { name = "contacts", desc = "invite a friend, block" });
            settings.Add(new SettingsItem() { name = "account", desc = " privacy, delete account" });
            settings.Add(new SettingsItem() { name = "profile", desc = "name, set an avatar, status" });
            settings.Add(new SettingsItem() { name = "chat settings", desc = "auto-download, wallpaper, backup" });
            settings.Add(new SettingsItem() { name = "lock screen", desc = "add WAWP on a lock screen" });
            settings.Add(new SettingsItem() { name = "notification sounds", desc = "change notification sounds" });
            settings.Add(new SettingsItem() { name = "rotation", desc = "auto-rotate or block rotation" });
            settings.Add(new SettingsItem() { name = "connectivity", desc = "change connectivity type" });

            SettingsList.ItemsSource = settings;
        }
    }
}