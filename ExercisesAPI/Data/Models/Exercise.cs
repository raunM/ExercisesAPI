using System;
using System.Collections.Generic;

namespace ExercisesAPI.Data.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            ExerciseTip = new HashSet<ExerciseTip>();
        }

        public int Id { get; set; }
        public int ExerciseCategoryId { get; set; }
        public string Description { get; set; }

        public ExerciseCategory ExerciseCategory { get; set; }
        public ICollection<ExerciseTip> ExerciseTip { get; set; }
    }
}
