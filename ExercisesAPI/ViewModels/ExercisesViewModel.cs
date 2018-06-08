using System.Collections.Generic;

namespace ExercisesAPI.ViewModels
{
    public class ExercisesViewModel
    {
        public IEnumerable<ExerciseCategoryViewModel> ExerciseCategories { get; set; }
    }
}
