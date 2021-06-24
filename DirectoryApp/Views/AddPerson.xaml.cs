using DirectoryApp.Models;
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

namespace DirectoryApp.Views
{
    /// <summary>
    /// Interaction logic for AddPerson.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        Person person;
        public AddPerson()
        {
            DataContext = person;
            InitializeComponent();
        }

        private async void savePersonButton_Click(object sender, RoutedEventArgs e)
        {
            person = new Person() { AddedDate = DateTime.Now, Description = description.Text, Email = email.Text, FirstName = firstName.Text, LastName = lastName.Text, Job = job.Text, PhoneNumber = phoneNumber.Text };
            await ((MainWindow)Application.Current.MainWindow).vm.AddPersonAsync(person);
            ((MainWindow)Application.Current.MainWindow).personAllEntriesDelete.IsEnabled = true; // if saved you can also delete all.
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
