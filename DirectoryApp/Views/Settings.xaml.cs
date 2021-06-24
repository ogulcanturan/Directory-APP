using DirectoryApp.Utility;
using System;
using System.Windows;

namespace DirectoryApp.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            UIHelper.DisableDrag(this);
        }

    }
}
