using System.Windows;
using WarehouseInterface.Managers;
using WarehouseInterface.Repositories;
using WarehouseInterface.Validators;

namespace WarehouseInterface.Pages
{
    public partial class PasswordSettingPage : Window
    {
        private SettingsPage _settingsPage;
        private RootManager _rootManager;
        private PasswordManager _passwordManager;
        private PasswordValidator _passwordValidator;

        public PasswordSettingPage(SettingsPage settingsPage)
        {
            _settingsPage = settingsPage;
            _rootManager = new RootManager();
            _passwordValidator = new PasswordValidator();

            var context = new DatabaseContext();

            _passwordManager = new PasswordManager(context);

            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.CloseFromShowTo(this, _settingsPage);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_passwordValidator.ValidateNewPassword(OldPasswordBoxItem.Password, NewPasswordBoxItem.Password, NewPasswordBoxItem2.Password))
            {
                _passwordManager.SetNewPassword(NewPasswordBoxItem.Password);
                MessageBox.Show("Pomyślnie zmieniono hasło");
                _rootManager.CloseFromShowTo(this, _settingsPage);
            };
        }
    }
}
