﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBuisnessLogic.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        ///  Наименование продукта
        /// </summary>
        public string Name { get;  }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get;  }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get;  }
        /// <summary>
        ///  Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; }
        


        public Food(string name): this (name, 0, 0, 0, 0)
        {
        }
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: Проверка
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
