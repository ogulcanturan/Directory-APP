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

namespace DirectoryAPP.Views
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Person person = ((MainWindow)Application.Current.MainWindow).vm.SelectedPerson;
        public Edit()
        {

            DataContext = person;
            InitializeComponent();
        }

        private void savePersonButton_Click(object sender, RoutedEventArgs e)
        {
            #region InOrderToNotUpdateImmediately
            BindingExpression emBE = email.GetBindingExpression(TextBox.TextProperty);
            BindingExpression firstNameBE = firstName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression lastNameBE = lastName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression jobBE = lastName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression phoneNumberBE = phoneNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression descriptionBE = description.GetBindingExpression(TextBox.TextProperty);
            emBE.UpdateSource();
            firstNameBE.UpdateSource();
            lastNameBE.UpdateSource();
            jobBE.UpdateSource();
            phoneNumberBE.UpdateSource();
            descriptionBE.UpdateSource();
            #endregion
            ((MainWindow)Application.Current.MainWindow).vm.Update(person);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
