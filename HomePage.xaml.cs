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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            var current_agent = Tren2Entities.GetContext().agents.ToList();
            LVAgent.ItemsSource = current_agent;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPage.xaml", UriKind.Relative));
        }
        private void UpdateAgent()
        {
            //var current_agent = Tren2Entities.GetContext().agents.ToList();
            //current_agent = current_agent.Where(p => p.AgentName.ToLower().Contains(TBSearch.Text.ToLower())).ToList();
            //UpdateAgent();
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBSearch.Text == "")
                plh.Visibility = Visibility.Visible;
            else
                plh.Visibility = Visibility.Collapsed;
        }
    }
}
