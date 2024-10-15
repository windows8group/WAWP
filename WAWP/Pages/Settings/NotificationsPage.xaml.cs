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
    public partial class NotificationsPage : PhoneApplicationPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
            header.Text = AppResources.Notif_Sounds;
            NotifyPrivate.Text = AppResources.NotifyPrivate;
            select1.Text = AppResources.SelectSound;
            NotifyGroup.Text = AppResources.NotifyGroup;
            select2.Text = AppResources.SelectSound;
            NotifyCalls.Text = AppResources.NotifyCalls;
            SelectCall.Text = AppResources.SelectCall;
            inapp.Text = AppResources.inapp;
            idk.Header = AppResources.idk;
            inappSounds.Header = AppResources.inappSounds;
            inappVibrate.Header = AppResources.inappVibrate;
            PopupPreview.Text = AppResources.popupPreview;
            popup.Header = AppResources.popup;
            resetBtn.Content = AppResources.resetBtn;
            resetTxt.Text = AppResources.resetTxt;
            notsel.Content = AppResources.notselectable;
            notsel1.Content = AppResources.notselectable;
            notsel2.Content = AppResources.notselectable;
        }
    }
}