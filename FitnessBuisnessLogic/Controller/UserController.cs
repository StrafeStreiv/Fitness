using FitnessBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessBuisnessLogic.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public UserController(string userName, string genderName,double height, double weight, DateTime birthDay )
        {
            // TODO: проверка
            var gender = new Gender(genderName);
            User = new User(userName, birthDay, height, weight, gender);
            
        }
        /// <summary>
        /// Получить данные пользоватлея
        /// </summary>
        /// <returns> Пользователь приложения</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    user = User;
                }
                // TODO: Что делать если не прочитали
            }
        }
        /// <summary>
        /// Cохранить данные пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        
        
    }
}
