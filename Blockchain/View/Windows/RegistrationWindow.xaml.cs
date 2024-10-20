using Blockchain.AppData;
using Blockchain.Model;
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
            RoleCmb.DisplayMemberPath = "Title";
            RoleCmb.ItemsSource = App.context.Role.ToList();
        }

        private void RoleCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedRole = Convert.ToInt32(RoleCmb.SelectedValue);
            RoleCmb.ItemsSource = App.context.Role.Where(r => r.ID == SelectedRole).ToList();
        }

        private void LoginHl_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Добавление нового пользователя
                // 1) Создаём объект
                RegistrationHelper.newUser = new User()
                {
                    Email = EmailTb.Text,
                    Password = PasswordPb.Password,
                    RoleID = Convert.ToInt32(RoleCmb.SelectedValue)
                };

                // 2) Добавляем объект в таблицу
                App.context.User.Add(RegistrationHelper.newUser);

                // 3) Сохраняем изменения
                App.context.SaveChanges();

                // 4) Уведомить пользователя о добавлении новой записи
                MessageBox.Show("Успешная регистрация", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                // Открываем окно для внесения дополнительной информации о пользователе
                ProfileOrganizatorWindow profileOrganizatorWindow = new ProfileOrganizatorWindow();
                profileOrganizatorWindow.Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Данные введены некорректно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
