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

            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            /// I tried to make the send button disabled when there's nothing in the text box,
            /// but got NullReferenceError on textbox edit. That sucks.
            ///
            /// Le Bao Nguyen.
            ApplicationBarIconButton SendMenuItem = new ApplicationBarIconButton();
            SendMenuItem.IconUri = new Uri("/Assets/AppBar/send.png", UriKind.Relative);
            SendMenuItem.Text = AppResources.SendMenuItem;
            SendMenuItem.IsEnabled = false;
            ApplicationBar.Buttons.Add(SendMenuItem);
            SendMenuItem.Click += new EventHandler(SendMenuItem_Click);
            ApplicationBarIconButton AttachMenuItem = new ApplicationBarIconButton();
            AttachMenuItem.IconUri = new Uri("/Assets/AppBar/attach.png", UriKind.Relative);
            AttachMenuItem.Text = AppResources.AttachMenuItem;
            ApplicationBar.Buttons.Add(AttachMenuItem);
            ApplicationBarIconButton EmojiMenuItem = new ApplicationBarIconButton();
            EmojiMenuItem.IconUri = new Uri("/Assets/AppBar/emoji.png", UriKind.Relative);
            EmojiMenuItem.Text = AppResources.EmojiMenuItem;
            ApplicationBar.Buttons.Add(EmojiMenuItem);


            messageBox.Hint = AppResources.messageBox;
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

        /// doesn't disable SendMenuBar after message was sent
        /// 
        /// PickaxeInABox
        private void SendMenuItem_Click(object sender, EventArgs e)
        {
            if (messageBox.Text != "")
            {
                ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                btn.IsEnabled = false;
                ((this.Resources["MessagesPresenter"] as MessageContentPresenter).Content as MessageCollection).Add(
                    new Message()
                    {
                        Text = messageBox.Text,
                        TimeStamp = DateTime.Now,
                        IsFromSelf = true
                    }
                );
                ConversationScrollViewer.Focus();
                messageBox.Text = "";

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
        /// doesn't turn off after messageBox is cleared by a backspaces
        /// 
        /// PickaxeInABox
        private void messageBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
            if (messageBox != null)
            {
            btn.IsEnabled = true;
            };
            if ((messageBox == null) && (btn.IsEnabled == true))
            {
                btn.IsEnabled = false;
            };
            
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
