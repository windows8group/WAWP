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
    public partial class ArchivedChatsPage : PhoneApplicationPage
    {
        public ArchivedChatsPage()
        {
            InitializeComponent();
            header.Text = AppResources.ArchiveMenuItem;
        }
    }
}