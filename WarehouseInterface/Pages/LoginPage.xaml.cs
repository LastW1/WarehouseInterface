using System;
using System.Windows;
using System.Windows.Input;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;

namespace WarehouseInterface.Pages.PageLogic
{
    public partial class LoginPage : Window
    {
        private RootManager _rootManager;
        private PasswordManager _passwordManager;

        public LoginPage()
        {
            var context = new DatabaseContext();
            _passwordManager = new PasswordManager(context);
            _rootManager = new RootManager();
            InitializeComponent();
            PasswordBoxItem.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void PasswordBoxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.ExitApp();
        }

        private void PasswordBoxItem_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PasswordBoxItem.Password = "";
            MessageLabel.Content = "";
        }

        private void Login()
        {

            if (_passwordManager.PasswordCheck(PasswordBoxItem.Password))
            {
                _rootManager.RootFromTo(this, new SettingsPage());
            }
            else
            {
                MessageLabel.Content = "Podano niepoprawne hasło!";
            }
        }
    }
}
