using System;
using System.Collections.Generic;

namespace ExercisesAPI.Data.Models
{
    public partial class ExerciseCategory
    {
        public ExerciseCategory()
        {
            Exercise = new HashSet<Exercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Exercise> Exercise { get; set; }
    }
}
