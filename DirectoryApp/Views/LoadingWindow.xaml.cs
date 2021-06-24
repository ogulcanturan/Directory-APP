using DirectoryApp.Utility;
using System;
using System.Threading;
using System.Windows;

namespace DirectoryApp.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private LoadingWindow()
        {
            InitializeComponent();
            Topmost = true;
        }

        private static readonly object lockObject = new object();
        private static LoadingWindow instance = null;
        public static LoadingWindow Instance
        {
            get
            {
                lock (lockObject)
                {
                    return instance ??= new LoadingWindow();
                }
            }
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            UIHelper.RemoveIcon(this);
        }

        public static void Start(string windowTitle = "Loading", string description = "Loading...")
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Instance.Title = windowTitle;
            Instance.descriptionTextBlock.Text = description;
            Instance.Show();
        }
        public static void Stop()
        {
            Instance.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Instance.Hide();
        }
    }
}
