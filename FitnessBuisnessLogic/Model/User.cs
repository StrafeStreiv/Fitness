using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBuisnessLogic.Model
{
    [Serializable]
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        ///  Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /*
        DateTime now = DateTime.Today;
        int age = now.Year - bday.Year;
        if (bday > now.AddYears(-age)) age--;
        */
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name"> Имя</param>
        /// <param name="birthDate"> Дата рождения</param>
        /// <param name="height">Рост</param>
        /// <param name="weight">Вес</param>
        /// <param name="gender">Пол</param>
        public User(string name, DateTime birthDate, double height, double weight, Gender gender)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null", nameof(name));
            }
            
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым или null", nameof(gender));
            }
            
            if (birthDate < DateTime.Parse("12.04.1924") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше нуля или равен нулю", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше нуля или равен нулю", nameof(height));
            }
            #endregion
            Name = name;
            Height = height;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + "\t" + Age;
        }
    }
}
