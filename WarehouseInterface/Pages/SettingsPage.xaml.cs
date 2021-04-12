using System.Windows;
using WarehouseInterface.Managers;

namespace WarehouseInterface.Pages
{
    public partial class SettingsPage : Window
    {
        private RootManager _rootManager;
        public SettingsPage()
        {
            _rootManager = new RootManager();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromTo(this, new WarehouseViewerPage(this));
        }

        private void CloseAppButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.ExitApp();
        }

        private void CategorySettignsButton_Click(object sender, RoutedEventArgs e)
        {
            _rootManager.RootFromTo(this, new CategorySettingPage(this));
        }
    }
}
