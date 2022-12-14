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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tren2_Gorodkov
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        //private Tren2Entities1 _currentStrahov = new Tren2Entities1();
        private agents _currentAgent = new agents();
        public AddPage(agents selectedAgent)
        {
            InitializeComponent();
            if (selectedAgent != null)
            {
                _currentAgent = selectedAgent;
            }
            DataContext = _currentAgent;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentAgent.ID == 0)
                Tren2Entities1.GetContext().agents.Add(_currentAgent);
            Tren2Entities1.GetContext().SaveChanges();
            NavigationService.GoBack();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
