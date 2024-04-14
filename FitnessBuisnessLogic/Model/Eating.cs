using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessBuisnessLogic.Model
{
    /// <summary>
    ///  Приём пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Момент приёма пищи
        /// </summary>
        public DateTime Moment { get;}
        /// <summary>
        /// Еда
        /// </summary>
        public Dictionary<Food, double> Foods { get;  } // можно сделать через отдельный класс (double
        /// <summary>
        /// Пользователь, кушающий еду
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым или null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }

        }

    }
}
