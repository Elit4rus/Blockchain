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
        public static Jury currentJury;
        public static Moderator currentModerator;
        public static Organizer currentOrganizer;
        public static Participant currentParticipant;
        public static string captcha;
        public static bool CheckData(string email, string password)
        {
            // НАВИГАЦИЯ
            // Получаем одну запись по условиям по таблицам БД
            currentJury = App.context.Jury.FirstOrDefault(u => u.Email == email && u.Password == password);
            currentModerator = App.context.Moderator.FirstOrDefault(u => u.Email == email && u.Password == password);
            currentOrganizer = App.context.Organizer.FirstOrDefault(u => u.Email == email && u.Password == password);
            currentParticipant = App.context.Participant.FirstOrDefault(u => u.Email == email && u.Password == password);
            // продолжение
            if (currentJury != null || currentModerator != null || currentOrganizer != null || currentParticipant != null)
            {
                // Генерируем капчу
                if (GenerateCaptcha() == true)
                {
                    // Загружаем страницы
                    if (currentJury.RoleID != null)
                    {

                    }
                    else if (currentModerator.RoleID == 1)
                    {
                        AddEventWindow addEventWindow = new AddEventWindow();
                        addEventWindow.Show();
                    }
                    else if (currentJury.RoleID == 2)
                    {
                        DetailedInfoOfTheEventWindow detailedInfoOfTheEventWindow = new DetailedInfoOfTheEventWindow();
                        detailedInfoOfTheEventWindow.Show();
                    }
                    else
                    { 
                    
                    }
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
