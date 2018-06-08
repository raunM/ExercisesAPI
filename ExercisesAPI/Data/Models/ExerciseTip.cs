using System;
using System.Collections.Generic;

namespace ExercisesAPI.Data.Models
{
    public partial class ExerciseTip
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string Description { get; set; }

        public Exercise Exercise { get; set; }
    }
}
