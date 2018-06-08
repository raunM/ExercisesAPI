using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace ExercisesAPI.Data.Repositories.Implementations
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ExercisesContext context) : base(context)
        {
            
        }

        public Exercise GetExerciseWithTips(int exerciseId)
        {
            return _context.Exercise
                .Where(e => e.Id == exerciseId)
                .Include(e => e.ExerciseTip)
                .FirstOrDefault();
        }

        public void CreateExerciseWithTips(int exerciseId)
        {
            
        }
    }
}
