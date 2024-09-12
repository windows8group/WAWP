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

namespace WAWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<ChatItem> chats = new List<ChatItem>();
            chats.Add(new ChatItem() { Name = "Kierownik223", ImageUri = "https://marmak.net.pl/images/Kierownik223.png", LastMessage = "UI Testing!" });
            chats.Add(new ChatItem() { Name = "Olek47", ImageUri = "https://marmak.net.pl/images/Olek47.png", LastMessage = "UI Testing 2!" });
            chats.Add(new ChatItem() { Name = "Maksym", ImageUri = "https://marmak.net.pl/images/Maksym.png", LastMessage = "Siema" });

            ChatsList.ItemsSource = chats;
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void ArchiveMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ArchivedChatsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BroadcastsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/BroadcastsListsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}