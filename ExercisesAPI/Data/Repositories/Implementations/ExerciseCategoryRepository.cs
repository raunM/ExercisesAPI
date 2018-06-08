using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ExercisesAPI.Data.Repositories.Implementations
{
    public class ExerciseCategoryRepository : Repository<ExerciseCategory>, IExerciseCategoryRepository
    {
        public ExerciseCategoryRepository(ExercisesContext context) : base(context)
        {

        }

        public IEnumerable<ExerciseCategory> GetAll1()
        {
            return _context.ExerciseCategory
                //.Include(ec => ec.Exercise)
                //.Include(ec => ec.Exercise.Select(e => e.ExerciseTip));
                .Include("Exercise")
                .Include("Exercise.ExerciseTip");
        }

        public IEnumerable<Exercise> GetAllExercises(int exerciseCategoryId)
        {
            return _context.Exercise
                .Where(e => e.ExerciseCategoryId == exerciseCategoryId);
        }

    }
}
