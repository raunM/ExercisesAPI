using System.Collections.Generic;

namespace ExercisesAPI.ViewModels
{
    public class ExerciseViewModel
    {
        public int ExerciseCategoryId { get; set; }
        public string Description { get; set; }
        public IEnumerable<ExerciseTipViewModel> ExerciseTip { get; set; }
    }
}
