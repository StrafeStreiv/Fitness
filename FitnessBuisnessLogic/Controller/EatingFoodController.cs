using FitnessBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessBuisnessLogic.Controller
{
    public class EatingFoodController: ControllerBase
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingFoodController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым или null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEatings()
        {
            return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            base.Save(FOOD_FILE_NAME, Foods);
            base.Save(EATING_FILE_NAME, Eating);
        }
        
    }
}
