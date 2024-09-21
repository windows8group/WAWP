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

        //protected override void OnManipulationCompleted(ManipulationCompletedEventArgs e)
        //{
        //    base.OnManipulationCompleted(e);
        //    ContentTemplate = new Random().Next(0, 1) == 0 ? MeTemplate : YouTemplate;
        //}
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
            ((this.Resources["cp"] as MessageContentPresenter).Content as MessageCollection).Add(
                new Message()
                {
                    Text = messageBox.Text,
                    TimeStamp = DateTime.Now,
                    IsFromSelf = true
                }
            );
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
    }
}
