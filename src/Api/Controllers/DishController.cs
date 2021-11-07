using MenuConfigurator.Model;
using Microsoft.AspNetCore.Mvc;
using MenuConfigurator.Infraestructure;
using System;

namespace MenuConfigurator.Api
{
    [ApiController, Route("api/dishes")]
    public class DishController : ControllerBase
    {
        private readonly DishRepository dishrepository;
        public DishController(DishRepository dishrepository)
        {
            this.dishrepository = dishrepository;
        }

        public IActionResult GetAll()
        {
            var dishes = dishrepository.GetAll();
            return Ok(dishes);
        }

        [Route("{dishId}")]
        public IActionResult GetDish(Guid dishId)
        {
            var dish = dishrepository.GetById(dishId);
            return Ok(dish);
        }
 
        [HttpPost]
        public ActionResult<Dish> Post(Dish dish)
        {
            //dishrepository.Add(dish);
            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, dish);
        }

        //Update dish into database and return the dish
        [HttpPatch]
        public IActionResult Put(Dish dish)
        {
            //var dish = dishrepository.Update(dish);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Dish dish)
        {
            //dishrepository.Delete(dish);
            return NoContent();
        }
    }
}