using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Tren2Entities1 _context = new Tren2Entities1();
        public HomePage()
        {
            InitializeComponent();
            LVAgent.ItemsSource = _context.agents.ToList();

            var alltypes = _context.TypeAgent.ToList();
            alltypes.Insert(0, new TypeAgent
            {
                AgentType = "Все типы"
            }); ;

            ComboFilter.ItemsSource = alltypes;
            ComboFilter.SelectedIndex = 0;
        }
        private void UpdateAgents()
        {
            var currentAgents = _context.agents.ToList();
            //if (ComboFilter.SelectedIndex > 0)
            //{
            //    currentAgents = currentAgents.FindAll(x => x.TypeAgentID.Contains(ComboFilter.SelectedItem as ));
            //}
            currentAgents = currentAgents.FindAll(x => x.AgentName.Contains(TBSearch.Text));
            //currentAgents = currentAgents.Sort(p => p.AgentName.Contains());
            //currentAgents = currentAgents.Sort(x => x.AgentName.Contains(ComboSort.SelectedItem));
            LVAgent.ItemsSource = currentAgents;
            //LVAgent.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddPage.xaml", UriKind.Relative));
        }
        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBSearch.Text == "")
                plh.Visibility = Visibility.Visible;
            else
                plh.Visibility = Visibility.Collapsed;
            UpdateAgents();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            _context.agents.Remove((agents)LVAgent.SelectedItem);
            _context.SaveChanges();
            UpdateAgents();
        }
    }
}
