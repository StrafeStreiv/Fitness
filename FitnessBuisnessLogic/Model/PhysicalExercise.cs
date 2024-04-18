using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBuisnessLogic.Model
{
    [Serializable]
    public class PhysicalExercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get;}
        public User User { get; }
        public PhysicalExercise(DateTime start, DateTime finish, User user, Activity activity)
        {
            // TODO: проверка
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }


    }
}
