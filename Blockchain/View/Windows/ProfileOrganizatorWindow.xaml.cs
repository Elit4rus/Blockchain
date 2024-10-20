using Blockchain.AppData;
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
    /// Логика взаимодействия для ProfileOrganizatorWindow.xaml
    /// </summary>
    public partial class ProfileOrganizatorWindow : Window
    {
        public ProfileOrganizatorWindow()
        {
            InitializeComponent();
            GenderCmb.SelectedValuePath = "ID";
            GenderCmb.DisplayMemberPath = "Title";
            GenderCmb.ItemsSource = App.context.Gender.ToList();

            CountryCmb.SelectedValuePath = "ID";
            CountryCmb.DisplayMemberPath= "CountryName";
            CountryCmb.ItemsSource = App.context.Country.ToList();

            EmailTb.Text = RegistrationHelper.newUser.Email;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            #region Обработка пустых строк
            if (ChangePasswordCb.IsChecked == true)
            {
                try
                {
                    // Фамилия
                    if (SurnameTb.Text == string.Empty) MessageBox.Show("Введите фамилию!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Surname = SurnameTb.Text;

                    // Имя
                    if (NameTb.Text == string.Empty) MessageBox.Show("Введите имя!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Name = NameTb.Text;

                    // Отчество (может не быть)
                    RegistrationHelper.newUser.Patronymic = PatronymicTb.Text;

                    // Пол
                    if (GenderCmb.SelectedItem == null) MessageBox.Show("Выберите пол!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.GenderID = Convert.ToInt32(GenderCmb.SelectedValue);

                    // Дата рождения
                    if (DateOfBirthDp.SelectedDate == null) MessageBox.Show("Введите дату рождения!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.DateOfBirth = DateOfBirthDp.SelectedDate;

                    // Страна
                    if (DateOfBirthDp.SelectedDate == null) MessageBox.Show("Выберите страну!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.CountryID = Convert.ToInt32(CountryCmb.SelectedValue);

                    // Номер телефона
                    if (PhoneTb.Text == string.Empty) MessageBox.Show("Введите номер телефона!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Phone = PhoneTb.Text;

                    // Новый пароль
                    if (PasswordTb.Text == string.Empty) MessageBox.Show("Введите новый пароль!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else if (RepeatPasswordTb.Text == string.Empty) MessageBox.Show("Введите пароль повторно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else if (PasswordTb.Text != RepeatPasswordTb.Text) MessageBox.Show("Пароли не совпадают!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (string.IsNullOrEmpty(SurnameTb.Text)
                        || string.IsNullOrEmpty(NameTb.Text)
                        || GenderCmb.SelectedItem == null
                        || DateOfBirthDp.SelectedDate == null
                        || CountryCmb.SelectedItem == null
                        || string.IsNullOrEmpty(PhoneTb.Text)
                        || string.IsNullOrEmpty(PasswordTb.Text)
                        || string.IsNullOrEmpty(RepeatPasswordTb.Text)
                        || PasswordTb.Text != RepeatPasswordTb.Text)
                    {
                        MessageBox.Show("Не все данные введены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        RegistrationHelper.newUser.Password = PasswordTb.Text;
                        App.context.SaveChanges();
                        MessageBox.Show("Данные успешно добавлены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Не все поля заполнены верно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else 
            {
                try
                {
                    // Фамилия
                    if (SurnameTb.Text == string.Empty) MessageBox.Show("Введите фамилию!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Surname = SurnameTb.Text;

                    // Имя
                    if (NameTb.Text == string.Empty) MessageBox.Show("Введите имя!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Name = NameTb.Text;

                    // Отчество (может не быть)
                    RegistrationHelper.newUser.Patronymic = PatronymicTb.Text;

                    // Пол
                    if (GenderCmb.SelectedItem == null) MessageBox.Show("Выберите пол!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.GenderID = Convert.ToInt32(GenderCmb.SelectedValue);

                    // Дата рождения
                    if (DateOfBirthDp.SelectedDate == null) MessageBox.Show("Введите дату рождения!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.DateOfBirth = DateOfBirthDp.SelectedDate;

                    // Страна
                    if (CountryCmb.SelectedItem == null) MessageBox.Show("Выберите страну!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.CountryID = Convert.ToInt32(CountryCmb.SelectedValue);

                    // Номер телефона
                    if (PhoneTb.Text == string.Empty) MessageBox.Show("Введите номер телефона!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    else RegistrationHelper.newUser.Phone = PhoneTb.Text;

                    if (string.IsNullOrEmpty(SurnameTb.Text) 
                        || string.IsNullOrEmpty(NameTb.Text)
                        || GenderCmb.SelectedItem == null
                        || DateOfBirthDp.SelectedDate == null
                        || CountryCmb.SelectedItem == null
                        || string.IsNullOrEmpty(PhoneTb.Text))
                    {
                        MessageBox.Show("Не все данные введены!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else 
                    {
                        App.context.SaveChanges();
                        MessageBox.Show("Данные успешно добавлены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Не все поля заполнены верно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            #endregion
        }
    }
}
