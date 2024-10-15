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
using System.Collections.ObjectModel;

namespace WAWP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            ApplicationBarIconButton SearchAppBar = new ApplicationBarIconButton();
            SearchAppBar.IconUri = new Uri("/Assets/AppBar/feature.search.png", UriKind.Relative);
            SearchAppBar.Text = AppResources.SearchAppBar;
            ApplicationBar.Buttons.Add(SearchAppBar);
            ApplicationBarIconButton NewChatAppBar = new ApplicationBarIconButton();
            NewChatAppBar.IconUri = new Uri("/Assets/AppBar1/new.png", UriKind.Relative);
            NewChatAppBar.Text = AppResources.NewChatAppBar;
            ApplicationBar.Buttons.Add(NewChatAppBar);
            ApplicationBarIconButton NewGroupAppBar = new ApplicationBarIconButton();
            NewGroupAppBar.IconUri = new Uri("/Assets/AppBar2/newgroup.png", UriKind.Relative);
            NewGroupAppBar.Text = AppResources.NewGroupAppBar;
            ApplicationBar.Buttons.Add(NewGroupAppBar);

            ApplicationBarMenuItem BroadcastsMenuItem = new ApplicationBarMenuItem();
            BroadcastsMenuItem.Text = AppResources.BroadcastsMenuItem;
            ApplicationBar.MenuItems.Add(BroadcastsMenuItem);
            BroadcastsMenuItem.Click += new EventHandler(BroadcastsMenuItem_Click);
            ApplicationBarMenuItem ArchiveMenuItem = new ApplicationBarMenuItem();
            ArchiveMenuItem.Text = AppResources.ArchiveMenuItem;
            ApplicationBar.MenuItems.Add(ArchiveMenuItem);
            ArchiveMenuItem.Click += new EventHandler(ArchiveMenuItem_Click);
            ApplicationBarMenuItem SettingsMenuItem = new ApplicationBarMenuItem();
            SettingsMenuItem.Text = AppResources.Settings;
            ApplicationBar.MenuItems.Add(SettingsMenuItem);
            SettingsMenuItem.Click += new EventHandler(SettingsMenuItem_Click);

            // localizing strings
            ChatsListName.Header = AppResources.ChatsListName;
            CallsListName.Header = AppResources.CallsListName;
            FavoritesListName.Header = AppResources.FavoritesListName;
            AllListName.Header = AppResources.AllListName;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ChatsList.ItemsSource = new List<ChatItem>();
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Kierownik223", ImageUri = "https://marmak.net.pl/images/Kierownik223.png", LastMessage = "UI Testing!", isRead = false });
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Olek47", ImageUri = "https://marmak.net.pl/images/Olek47.png", LastMessage = "UI Testing 2!", isRead = true });
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Maksym", ImageUri = "https://marmak.net.pl/images/Maksym.png", LastMessage = "Siema", isRead = true });

            UnreadCount.Text = Enumerable.Range(0, ChatsList.ItemsSource.Count)
                                    .Where(i => (ChatsList.ItemsSource[i] as ChatItem).isRead == false)
                                    .Count().ToString();
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

        private void ChatsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChatItem myItem = ((LongListSelector)sender).SelectedItem as ChatItem;
            NavigationService.Navigate(new Uri("/Pages/ChatPage.xaml?name=" + myItem.Name, UriKind.RelativeOrAbsolute));
        }
    }
}