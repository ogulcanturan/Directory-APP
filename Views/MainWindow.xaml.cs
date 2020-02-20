using DirectoryAPP.Models;
using DirectoryAPP.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DirectoryAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDataRepository<Person> data = new SQLiteRepository();
        public PersonVM vm;
        public MainWindow()
        {
            Application.Current.MainWindow = this;
            vm = new PersonVM(data);
            vm.Initialize();
            DataContext = vm;
            InitializeComponent();
        }

        private void personAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPerson addPerson = new AddPerson();
            addPerson.Show();
        }

        private void personEdit_Click(object sender, RoutedEventArgs e)
        {
            if(vm.SelectedPerson != null)
            {
                Edit edit = new Edit();
                edit.Show();
            }
        }

        private void personDelete_Click(object sender, RoutedEventArgs e)
        {
            vm?.RemovePerson(vm.SelectedPerson);
        }

        private void personAllEntriesDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete all person entries in Directory APP??",
                                         "Confirm Deletion",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                vm.RemoveAllPerson();

            }
            else
            {

            }
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "mailto:?subject=This%20Directory%20APP%20-%20is%20amazing!!!&body=you%20can%20download%20in%20ogulcanturan.com/folders/DirectoryApp.zip",
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }

        private void sendError_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "mailto:ismetogulcanturan@gmail.com?subject=Error%20About%20DirectoryAPP&body=The%20Error%20is:%20",
                UseShellExecute = true
            };
            Process.Start(psi);
            e.Handled = true;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Owner = this;
            settings.ShowDialog();
        }

        private void unselectList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HitTestResult r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListBoxItem))
                unselectList.UnselectAll();
        }

        #region ANIMATIONPART
        private void ButtonMouse_Enter(object sender, MouseEventArgs e)
        {
            DoubleAnimation daImg = new DoubleAnimation(40, 45, TimeSpan.FromSeconds(0.3));
            daImg.AutoReverse = true;
            daImg.RepeatBehavior = RepeatBehavior.Forever;
            Image image = UIHelper.GetChildOfType<Image>(e.Source as Button);
            image.BeginAnimation(Image.WidthProperty, daImg);
        }

        private void ButtonMouse_Leave(object sender,MouseEventArgs e)
        {
            DoubleAnimation daImg = null;
            Image image = UIHelper.GetChildOfType<Image>(e.Source as Button);
            image.BeginAnimation(Image.WidthProperty, daImg);
        }

        private void SettingsButtonMouse_Enter(object sender,MouseEventArgs e)
        {
            DoubleAnimation daWheelImg = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(2));
            daWheelImg.AutoReverse = false;
            daWheelImg.RepeatBehavior = RepeatBehavior.Forever;
            RotateTransform rotateTransform = new RotateTransform();
            settingsImg.RenderTransform = rotateTransform;
            settingsImg.RenderTransformOrigin = new Point(0.5, 0.5); // in order to rotate around center
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, daWheelImg);
        }

        private void SettingsButtonMouse_Leave(object sender,MouseEventArgs e)
        {
            DoubleAnimation daWheelImg = null;
            RotateTransform rotateTransform = new RotateTransform();
            settingsImg.RenderTransform = rotateTransform;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, daWheelImg);
        }

        #endregion
    }
}
