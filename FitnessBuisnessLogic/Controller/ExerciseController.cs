using FitnessBuisnessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessBuisnessLogic.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISE_FILE_NAME = "exercise.dat";
        private const string ACTIVITY_FILE_NAME = "activity.dat";
        private readonly User user;
        public List<PhysicalExercise> PhysicalExercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым или null", nameof(user));
            PhysicalExercises = GetAllExercesis();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new PhysicalExercise(begin, end, user, activity);
                PhysicalExercises.Add(exercise);
                
            }
            else
            {
                var exercise = new PhysicalExercise(begin, end, user, act);
                PhysicalExercises.Add(exercise);
                
            }
            Save();
        }
        private List<PhysicalExercise> GetAllExercesis()
        {
            return Load<List<PhysicalExercise>>(EXERCISE_FILE_NAME) ?? new List<PhysicalExercise>();
        }
        private void Save()
        {
            base.Save(EXERCISE_FILE_NAME, PhysicalExercises);
            base.Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}
