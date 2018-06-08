using AutoMapper;
using ExercisesAPI.Data.Models;
using ExercisesAPI.Data.Repositories.Interfaces;
using ExercisesAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExercisesAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ExerciseTips")]
    public class ExerciseTipsController : Controller
    {
        private readonly IExerciseTipRepository _exerciseTipRepository;
        private readonly IMapper _mapper;

        public ExerciseTipsController(IExerciseTipRepository exerciseTipRepository)
        {
            _exerciseTipRepository = exerciseTipRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]ExerciseTipViewModel exerciseTip)
        {
            var exerciseTipEntity = new ExerciseTip
            {
                ExerciseId = exerciseTip.ExerciseId,
                Description = exerciseTip.Description
            };
            _exerciseTipRepository.Create(exerciseTipEntity);
        }
        
        [HttpPut("{exerciseTipId}")]
        public void Put(int exerciseTipId, [FromBody]string description)
        {
            var exerciseTipEntity = _exerciseTipRepository.GetById(exerciseTipId);
            exerciseTipEntity.Description = description;
            _exerciseTipRepository.Update(exerciseTipEntity);
        }
        
        [HttpDelete("{exerciseTipId}")]
        public void Delete(int exerciseTipId)
        {
            var exerciseTipEntity = _exerciseTipRepository.GetById(exerciseTipId);
            _exerciseTipRepository.Delete(exerciseTipEntity);
        }
    }
}
