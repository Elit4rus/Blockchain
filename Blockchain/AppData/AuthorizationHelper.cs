using Blockchain.Model;
using Blockchain.View.Windows;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blockchain.AppData
{
    internal class AuthorizationHelper
    {
        public static User currentUser;
        public static string captcha;
        public static bool CheckData(string email, string password)
        {
            // НАВИГАЦИЯ
            // Получаем одну запись по условиям по таблицам БД
            currentUser = App.context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            // продолжение
            if (currentUser != null)
            {
                // Генерируем капчу
                if (GenerateCaptcha() == true)
                {
                    // Загружаем страницы
                    switch (currentUser.RoleID)
                    {
                        case 1:
                            // загрузка страницы
                            OrganizatorWindow organizatorWindow = new OrganizatorWindow();
                            organizatorWindow.Show();
                            break;
                        case 2:
                            ProfileOrganizatorWindow profileOrganizator = new ProfileOrganizatorWindow();
                            profileOrganizator.Show();
                            break;
                    }
                    return true;
                }
                // Иначе, то...
                else
                {
                    MessageBox.Show("Капча введена не правильно");
                }
            }
            return false;
        }
        public static bool GenerateCaptcha()
        {
            // Создаем генератор случайных чисел
            Random random = new Random();

            // Очищаем поле с капчей
            captcha = string.Empty; // captcha = "";

            for (int i = 1; i <= 4; i++)
            {
                // Генерируем число и конвертируем его в символ
                char character = Convert.ToChar(random.Next(65, 91));

                // Складываем символы
                captcha += character;
            }

            // Открываем окно
            CaptchaWindow captchaWindow = new CaptchaWindow();
            if (captchaWindow.ShowDialog() == true)
            {
                return true;
            }
            return false;
        }
    }
}
