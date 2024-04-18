using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBuisnessLogic.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get;  }
        public double CaloriesPerMinute { get;  }
        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: проверка
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
