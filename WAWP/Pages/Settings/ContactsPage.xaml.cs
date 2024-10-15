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
    public partial class ContactsPage : PhoneApplicationPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            header.Text = AppResources.Contacts;
            inviteBtn.Text = AppResources.inviteBtn;
            BlockedListLink.Text = AppResources.blockBtn;
        }
    }
}