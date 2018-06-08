using ExercisesAPI.Data.Models;

namespace ExercisesAPI.Data.Repositories.Interfaces
{
    public interface IExerciseRepository : IRepository<Exercise> 
    {
        Exercise GetExerciseWithTips(int exerciseId);
    }
}
