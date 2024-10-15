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

namespace WAWP.Pages
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            AppExist.Text = AppResources.AppExistence;
            manager.Text = AppResources.Manager;
            ClientDev.Text = AppResources.ClientDev;
            ClientDev1.Text = AppResources.ClientDev;
            ServerDev.Text = AppResources.ServerDev;
            header.Text = AppResources.About;
        }
    }
}