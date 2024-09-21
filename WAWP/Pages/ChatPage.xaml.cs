using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WAWP.Resources;

namespace WAWP.Pages
{
    public class MessageContentPresenter : ContentControl
    {
        /// <summary>
        /// The DataTemplate to use when the message comes from the current user
        /// </summary>
        public DataTemplate MeTemplate { get; set; }

        /// <summary>
        /// The opposite of MeTemplate
        /// </summary>
        public DataTemplate YouTemplate { get; set; }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (MeTemplate != null)
                ContentTemplate = (newContent as Message).IsFromSelf ? MeTemplate : YouTemplate;
        }
    }

    public partial class ChatPage : PhoneApplicationPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PaddingRectangle.Visibility = Visibility.Visible;
            PaddingRectangleShowAnim.Begin();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PaddingRectangle.Visibility = Visibility.Collapsed;
            PaddingRectangleHideAnim.Begin();
        }

        private void SendMenuItem_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "")
            {
                ((this.Resources["MessagesPresenter"] as MessageContentPresenter).Content as MessageCollection).Add(
                    new Message()
                    {
                        Text = messageBox.Text,
                        TimeStamp = DateTime.Now,
                        IsFromSelf = true
                    }
                );
                ConversationScrollViewer.Focus();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string userName;

            if (NavigationContext.QueryString.TryGetValue("name", out userName))
            {
                chatTitle.Text = userName;
            }
        }

        private void messageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((SendMenuItem != null) && (SendMenuItem.IsEnabled == false))
            {
                SendMenuItem.IsEnabled = true;
            }
        }

        private void Grid_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // TODO: Static context menu
            var contextMenu = new ContextMenu()
            {
                DataContext = (sender as Grid).DataContext,
                IsOpen = true,
                VerticalOffset = e.GetPosition(sender as Grid).Y + 20.0 // FIXME
            };
            
            var shareBtn = new MenuItem()
            {
                Header = AppResources.Share
            };
            contextMenu.Items.Add(shareBtn);

            var deleteBtn = new MenuItem()
            {
                Header = AppResources.Delete
            };
            deleteBtn.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(deleteBtn);

            var copyBtn = new MenuItem()
            {
                Header = AppResources.Copy
            };
            copyBtn.Click += CopyBtn_Click;
            contextMenu.Items.Add(copyBtn);
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(
                (((sender as MenuItem).Parent as ContextMenu).DataContext as Message).Text
            );
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ((this.Resources["MessagesPresenter"] as MessageContentPresenter).Content as MessageCollection).Remove(
                ((sender as MenuItem).Parent as ContextMenu).DataContext as Message
            );
        }
    }
}
