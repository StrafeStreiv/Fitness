using FitnessBuisnessLogic.Controller;
using FitnessBuisnessLogic.Model;
using System;

namespace Fitness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы находитесь в приложении Fitness");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            // TODO: переделать
            var birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите вес ");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, height, weight, birthDate);
            userController.Save();
        }
    }
}
