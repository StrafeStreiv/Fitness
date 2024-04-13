using FitnessBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public List<User> Users  { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user">Имя пользователя</param>
        public UserController(string userName )
        {

            // TODO: проверка
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            
        }
        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else return new List<User>();
            }
            
        }

        public void SetNewUserData(string genderName, DateTime birthDay, double weight = 1, double height = 1)
        {
            // TODO: Проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
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
                formatter.Serialize(fs, Users);
            }
        }
        
        
    }
}
