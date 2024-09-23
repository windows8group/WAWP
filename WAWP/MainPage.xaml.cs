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
        public int UnreadNumber
        {
            get
            {
                return Enumerable.Range(0, ChatsList.ItemsSource.Count)
                                 .Where(i => (ChatsList.ItemsSource[i] as ChatItem).isRead == false)
                                 .Count();
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ChatsList.ItemsSource = new List<ChatItem>();
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Kierownik223", ImageUri = "https://marmak.net.pl/images/Kierownik223.png", LastMessage = "UI Testing!", isRead = false });
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Olek47", ImageUri = "https://marmak.net.pl/images/Olek47.png", LastMessage = "UI Testing 2!", isRead = true });
            ChatsList.ItemsSource.Add(new ChatItem() { Name = "Maksym", ImageUri = "https://marmak.net.pl/images/Maksym.png", LastMessage = "Siema", isRead = true });
            UnreadCount.Text = UnreadNumber.ToString();
        }

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