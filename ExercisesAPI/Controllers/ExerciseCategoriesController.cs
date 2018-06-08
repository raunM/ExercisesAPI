using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;
using ExercisesAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExercisesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ExerciseCategories")]
    public class ExerciseCategoriesController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseCategoryRepository _exerciseCategoryRepository;
        private readonly IMapper _mapper;

        public ExerciseCategoriesController(IExerciseRepository exerciseRepository, IExerciseCategoryRepository exerciseCategoryRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _exerciseCategoryRepository = exerciseCategoryRepository;
            _mapper = mapper;
        }

        // GET: api/ExerciseCategories
        [HttpGet]
        public ExercisesViewModel GetAll()
        {
            var exerciseCategoryEntities = _exerciseCategoryRepository.GetAll1();
            var exercisesViewModel = new ExercisesViewModel
            {
                ExerciseCategories = _mapper.Map<IEnumerable<ExerciseCategoryViewModel>>(exerciseCategoryEntities)
            };
            return exercisesViewModel;
        }

        [HttpGet("{exerciseCategoryId}")]
        public IEnumerable<ExerciseViewModel> GetExercises(int exerciseCategoryId)
        {
            var exerciseEntities = _exerciseCategoryRepository.GetAllExercises(exerciseCategoryId);
            var exerciseViewModels = _mapper.Map<IEnumerable<ExerciseViewModel>>(exerciseEntities);
            return exerciseViewModels;
        }

        // POST: api/ExerciseCategories
        [HttpPost]
        public void Post(string exerciseCategoryName)
        {
            var exerciseCategoryEntity = new ExerciseCategory
            {
                Name = exerciseCategoryName
            };
            _exerciseCategoryRepository.Create(exerciseCategoryEntity);
        }
        
        // PUT: api/ExerciseCategories/5
        [HttpPut("{exerciseCategoryId}")]
        public void Put(int exerciseCategoryId, string newName)
        {
            var exerciseCategoryEntity = _exerciseCategoryRepository.GetById(exerciseCategoryId);
            exerciseCategoryEntity.Name = newName;
            _exerciseCategoryRepository.Update(exerciseCategoryEntity);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{exerciseCategoryId}")]
        public void Delete(int exerciseCategoryId)
        {
            var exerciseCategoryEntity = _exerciseCategoryRepository.GetById(exerciseCategoryId);
            _exerciseCategoryRepository.Delete(exerciseCategoryEntity);
        }
    }
}
