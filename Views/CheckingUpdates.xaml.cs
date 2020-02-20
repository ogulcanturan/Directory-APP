using DirectoryAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DirectoryAPP.Views
{
    /// <summary>
    /// Interaction logic for CheckingUpdates.xaml
    /// </summary>
    public partial class CheckingUpdates : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public CheckingUpdates()
        {
            InitializeComponent();
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 2);
            dT.Start();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            UIHelper.RemoveIcon(this);
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            dT.Stop();
            this.Close();
            MessageBoxResult result = MessageBox.Show(
                "No updates are available right now. Please try again later.",
                "Directory APP Update",
                MessageBoxButton.OK,
                MessageBoxImage.None);
        }
    }
}
