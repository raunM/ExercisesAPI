using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;

namespace ExercisesAPI.Data.Repositories.Implementations
{
    public class ExerciseTipRepository : Repository<ExerciseTip>, IExerciseTipRepository
    {
        public ExerciseTipRepository(ExercisesContext context) : base(context)
        {

        }

    }
}
