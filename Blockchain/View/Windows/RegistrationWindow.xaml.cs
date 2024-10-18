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

namespace Blockchain.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            RoleCmb.SelectedValuePath = "ID";
            RoleCmb.DisplayMemberPath = "Name";
            RoleCmb.ItemsSource = App.context.Role.ToList();
        }

        private void RoleCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedRole = Convert.ToInt32(RoleCmb.SelectedValue);
            RoleCmb.ItemsSource = App.context.Role.Where(r => r.ID == SelectedRole);
        }
    }
}
