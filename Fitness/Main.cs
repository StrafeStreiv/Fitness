using FitnessBuisnessLogic.Controller;
using FitnessBuisnessLogic.Model;
using System;

namespace Fitness
{
    class Program
    {
        private static DateTime InputBirthDay()
        {
            Console.Write("Введите год рождения (dd.MM.yyyy): ");
            var bDay = Console.ReadLine();
            bool fakeOrNo = DateTime.TryParse(bDay, out DateTime result);
            if (!fakeOrNo)
            {
                Console.WriteLine("Неверный формат даты!");
                return InputBirthDay();
            }
            else return result;
        }
        private static double InputDoubleNumber(string weightOrHeight)
        {
            Console.Write($"Введите  {weightOrHeight}: ");
            string checkout = Console.ReadLine();
            bool fakeOrNo = double.TryParse(checkout, out double result);
            if (!fakeOrNo)
            {
                Console.WriteLine("Неправильный ввод, нужно ввести число");
                return InputDoubleNumber(weightOrHeight);
            }
            else return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вы находитесь в приложении Fitness");
            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingFoodController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = InputBirthDay();
                var weight = InputDoubleNumber("вес");
                var height = InputDoubleNumber("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E- ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var food = EnterEating();
                eatingController.Add(food.food, food.weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}" );
                }
            }

        }

        private static (Food food, double weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();
            var weight = InputDoubleNumber("вес (в граммах)");
            var proteins = InputDoubleNumber("белки");
            var fats = InputDoubleNumber("жиры");
            var carbohydrates = InputDoubleNumber("углеводы");
            var calories = InputDoubleNumber("калорийность");
            var product = new Food(foodName, proteins, fats, carbohydrates, calories);
            return (product, weight);
        }
    }
}
