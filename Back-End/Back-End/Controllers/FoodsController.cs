using AutoMapper;
using Contracts.Interfaces;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;


        public FoodsController(ILoggerManager logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Foods>> GetAllFoods()
        {
            try
            {
                var foods = await _unitOfWork.Foods.GetAllFoods();

                _logger.LogInfo($"Returned all Foods from database.");

                return Ok(foods);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMaterials action:  {ex.Message}");
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpGet("{foodID}")]
        public async Task<ActionResult> GetFood(int foodID)
        {
             var food = await _unitOfWork.Foods.GetFoodById(foodID);

            if(food == null)
            {
                return NotFound();
            }

             return Ok(food);
        }

        [HttpPost]
        public async Task<ActionResult<Foods>> CreateFood(Foods food)
        {
            if (food == null)
            {
                return BadRequest();
            }

            _unitOfWork.Foods.CreateFood(food);
            _unitOfWork.Foods.SaveAsync();

            return Ok();
        }



        [HttpPut("{foodID}")]
        public async Task<ActionResult> UpdateUser(int foodID, [FromBody] FoodsDto food)
        {
            if (food == null)
            {
                return BadRequest();
            }

            var foodFromRepo = await _unitOfWork.Foods.GetFoodById(foodID);

            if (foodFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(food, foodFromRepo);

            _unitOfWork.Foods.UpdateFood(foodFromRepo);

            _unitOfWork.Foods.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{foodID}")]
        public async Task<ActionResult> DeleteFood(int foodID)
        {
            var food = await _unitOfWork.Foods.GetFoodById(foodID);

            if (food == null)
            {
                return NotFound();
            }

            _unitOfWork.Foods.DeleteFood(food);

            _unitOfWork.Foods.SaveAsync();

            return NoContent();
        }

    }
}
