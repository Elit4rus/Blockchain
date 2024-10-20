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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorizationHelper.CheckData(EmailTb.Text, PasswordPb.Password) == true)
            {
                // успешная авторизация
                MessageBox.Show("Пользователь успешно авторизован");
                SaveUserData();
                Close();
                ProfileOrganizatorWindow profileOrganizatorWindow = new ProfileOrganizatorWindow();
                profileOrganizatorWindow.Show();
            }
            else
            {
                if (BlockSystemHelper.IncreaseIncorrectInput() == 3)
                {

                    BlockWindow blockWindow = new BlockWindow();
                    if (blockWindow.ShowDialog() == true)
                    {
                        BlockSystemHelper.incorrectInput = 0;
                    }
                }
                else
                {
                    // неуспешная авторизация
                    MessageBox.Show("Пользователь не найден");
                }
            }
        }
        private void SaveUserData()
        {
            if (RememberMeCb.IsChecked == true)
            {
                // Сохранение данных
                Properties.Settings.Default.EmailValue = EmailTb.Text;
                Properties.Settings.Default.PasswordValue = PasswordPb.Password;
            }
            else
            {
                // Очистка данных
                Properties.Settings.Default.EmailValue = string.Empty; // => ""
                Properties.Settings.Default.PasswordValue = string.Empty; // => ""
            }
            // Фиксируем изменения
            Properties.Settings.Default.Save();
        }
        private void LoadUserData()
        {
            EmailTb.Text = Properties.Settings.Default.EmailValue;
            PasswordPb.Password = Properties.Settings.Default.PasswordValue;
        }

        private void RegistrationHl_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
    }
}
