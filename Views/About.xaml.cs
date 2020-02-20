using DirectoryAPP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DirectoryAPP.Views
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            thatUser.Text = Environment.UserName; // this will take current user account name
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            UIHelper.DisableDrag(this);
        }

        private void checkUpdates_Click(object sender, RoutedEventArgs e)
        {
            CheckingUpdates cU = new CheckingUpdates();
            cU.Show();
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void enterWebPage_Click(object sender, RoutedEventArgs e)
        {
            //in order to accessing web page.
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "http://ogulcanturan.com/",
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }

       
    }
}
