using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarechouseInterface.Managers;

namespace WarechouseInterface.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
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
            _rootManager.RootFromTo(this, new WarechouseViewerPage());
        }
    }
}
