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
            Console.Write($"Введите свой {weightOrHeight}: ");
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
        }
    }
}
