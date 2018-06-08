using System.Collections.Generic;

namespace ExercisesAPI.ViewModels
{
    public class ExerciseCategoryViewModel
    {
        public string Name{ get; set; }
        public IEnumerable<ExerciseViewModel> Exercise { get; set; }
    }
}
