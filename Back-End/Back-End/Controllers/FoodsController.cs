using Contracts.Interfaces;
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

        public FoodsController(ILoggerManager logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
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

        [HttpDelete("{foodID}")]
        public async Task<ActionResult> DeleteFood(int foodID)
        {
            var food = await _unitOfWork.Foods.GetFoodById(foodID);

            if(food == null)
            {
                return NotFound();
            }
            _unitOfWork.Foods.Delete(food);

            _unitOfWork.Foods.SaveAsync();
            return NoContent();


        }


    }
}
