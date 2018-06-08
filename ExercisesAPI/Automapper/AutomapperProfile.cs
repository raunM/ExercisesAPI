using AutoMapper;
using ExercisesAPI.Data.Models;
using ExercisesAPI.ViewModels;

namespace ExercisesAPI.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Exercise, ExerciseViewModel>();
            CreateMap<ExerciseCategory, ExerciseCategoryViewModel>();
            CreateMap<ExerciseTip, ExerciseTipViewModel>();
        }
    }
}
