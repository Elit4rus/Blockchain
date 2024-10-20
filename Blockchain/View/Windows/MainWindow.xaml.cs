using Blockchain.Model;
using Blockchain.View.Windows;
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

namespace Blockchain
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Создаем список для хранения направлений для ComboBox (таблица Direction)
        List<Direction> directions = App.context.Direction.ToList();
        // Создаём список для хранения мероприятий для ListView (таблица Event)
        List<Event> events = App.context.Event.ToList();
        public MainWindow()
        {
            InitializeComponent();
            // Загружаем записи из таблицы Event в ListView
            EventsLv.ItemsSource = events;
            // Добавляем пункт "Все направления" в List
            directions.Insert(0, new Direction() { Title = "Все направления"});
            // Загружаем записи из таблицы Direction в ComboBox
            DirectionCmb.ItemsSource = directions;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        private void DirectionCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Direction selectedDirection = DirectionCmb.SelectedItem as Direction;
            if (DirectionCmb.SelectedIndex == 0) 
            { 
                EventsLv.ItemsSource = events;
            }
            else 
            { 
                EventsLv.ItemsSource = events.Where(ev => ev.DirectionID == selectedDirection.ID);
            }
        }

        private void DateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = DateDp.SelectedDate.Value.Date;
            if (DateDp.SelectedDate == null) 
            {
                EventsLv.ItemsSource = events;
            }
            else
            {
                EventsLv.ItemsSource = events.Where(ev => ev.Date == selectedDate.Date);
            }
        }

    }
}
