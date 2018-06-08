using ExercisesAPI.Data.Models;
using System.Collections.Generic;

namespace ExercisesAPI.Data.Repositories.Interfaces
{
    public interface IExerciseCategoryRepository : IRepository<ExerciseCategory>
    {
        IEnumerable<ExerciseCategory> GetAll1();

        IEnumerable<Exercise> GetAllExercises(int exerciseCategoryId);
    }
}
