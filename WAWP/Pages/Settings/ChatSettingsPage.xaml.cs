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
    public partial class ChatSettingsPage : PhoneApplicationPage
    {
        public ChatSettingsPage()
        {
            InitializeComponent();
            TogglesList.ItemsSource = new List<SettingsItem>();

            TogglesList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Enter });
            TogglesList.ItemsSource.Add(new SettingsItem() { Name = AppResources.ShowMessage });

            header.Text = AppResources.Chat_Settings;

            SettingsList.ItemsSource = new List<SettingsItem>();

            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Background, Description = AppResources.Background_Des, Destination = "ReplaceMe" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.TextSize, Description = AppResources.TextSize_Des, Destination = "ReplaceMe" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.MediaAuto, Description = AppResources.MediaAuto_Des, Destination = "ReplaceMe" });
            SettingsList.ItemsSource.Add(new SettingsItem() { Name = AppResources.Backup, Description = AppResources.Backup_Des, Destination = "ReplaceMe" });
        }
    }
}