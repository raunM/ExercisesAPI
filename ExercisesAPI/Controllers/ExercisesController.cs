using AutoMapper;
using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;
using ExercisesAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseTipRepository _exerciseTipRepository;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseRepository exerciseRepository, IExerciseTipRepository exerciseTipRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _exerciseTipRepository = exerciseTipRepository;
            _mapper = mapper;
        }

        // GET: api/Exercises
        [HttpGet]
        public string Exercises()
        {
            return "";
        }

        // GET: api/Exercises/5
        [HttpGet("{exerciseId}")]
        public ExerciseViewModel Get(int exerciseId)
        {
            var exerciseEntity = _exerciseRepository.GetExerciseWithTips(exerciseId);
            var exerciseViewModel = _mapper.Map<ExerciseViewModel>(exerciseEntity);
            return exerciseViewModel;
        }
        
        // POST: api/Exercises
        [HttpPost]
        public void Post([FromBody]ExerciseViewModel exercise)
        {
            var exerciseEntity = new Exercise
            {
                ExerciseCategoryId = exercise.ExerciseCategoryId,
                Description = exercise.Description,
            };
            _exerciseRepository.Create(exerciseEntity);
            foreach (var exerciseTip in exercise.ExerciseTip)
            {
                var exerciseTipEntity = new ExerciseTip
                {
                    ExerciseId = exerciseEntity.Id,
                    Description = exerciseTip.Description
                };
                _exerciseTipRepository.Create(exerciseTipEntity);
            }
        }
        
        // PUT: api/Exercises/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
