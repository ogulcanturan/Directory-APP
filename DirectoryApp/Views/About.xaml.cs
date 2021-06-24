using DirectoryApp.Models;
using DirectoryApp.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DirectoryApp.Views
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            version.Text = BuildInfo.Instance.VersionText; //1.0 Build 1(Feb / 15 / 2020)";
            thatUser.Text = Environment.UserName; // this will take current user account name
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            UIHelper.DisableDrag(this);
        }

        private async void checkUpdates_Click(object sender, RoutedEventArgs e)
        {
            LoadingWindow.Start("Quick Update", "Checking For Updates...");
            bool? isProjectUpToDate = await Helper.IsProjectUpToDateAsync();
            LoadingWindow.Stop();
            if (isProjectUpToDate.HasValue)
            {
                if (isProjectUpToDate.Value)
                {
                    _ = MessageBox.Show(
                    "No updates are available right now.",
                    "Quick Update",
                    MessageBoxButton.OK,
                    MessageBoxImage.None);
                }
                else
                {
                   MessageBoxResult result = MessageBox.Show(
                   "DirectoryApp update is available.",
                   "Quick Update",
                   MessageBoxButton.OK,
                   MessageBoxImage.None);
                }
            }
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
                FileName = "https://ogulcanturan.com/",
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }

       
    }
}
