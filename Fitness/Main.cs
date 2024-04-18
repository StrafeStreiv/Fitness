using FitnessBuisnessLogic.Controller;
using FitnessBuisnessLogic.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness
{
    class Program
    {
        private static DateTime InputBirthDay(string value, string value2 = "")
        {
            Console.Write($"Введите {value} (dd.MM.yyyy) {value2}: ");
            var bDay = Console.ReadLine();
            bool fakeOrNo = DateTime.TryParse(bDay, out DateTime result);
            if (!fakeOrNo)
            {
                Console.WriteLine("Неверный формат даты!");
                return InputBirthDay(value, value2);
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
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourcesManager = new ResourceManager("Fitness.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourcesManager.GetString("Hello"), culture);
            Console.Write(resourcesManager.GetString("EnterName"), culture);
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingFoodController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourcesManager.GetString("EnterGender"), culture);
                var gender = Console.ReadLine();
                var birthDate = InputBirthDay("год рождения");
                var weight = InputDoubleNumber("вес");
                var height = InputDoubleNumber("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E- ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выйти из приложения");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.Add(food.food, food.weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExeciting();
                        exerciseController.Add(exe.activity, exe.begin, exe.end);
                        foreach (var item in exerciseController.PhysicalExercises)
                        {
                            Console.WriteLine($"\t {item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        private static (DateTime begin, DateTime end, Activity activity)  EnterExeciting()
        {
            Console.Write("Введите название упражнения:");
            var name = Console.ReadLine();
            var energy = InputDoubleNumber("расход энергии в минуту");
            var begin = InputBirthDay("начало упражнения", "HH:MM");
            var end = InputBirthDay("конец упражнения", "HH:MM");
            var activity = new Activity(name, energy);
            return (begin, end, activity);
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
