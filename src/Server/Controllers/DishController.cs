using MenuConfigurator.Shared;
using Microsoft.AspNetCore.Mvc;
using MenuConfigurator.Infraestructure;
using System;

namespace MenuConfigurator.Server.Controllers
{
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DishRepository dishrepository;
        public DishController(DishRepository dishrepository)
        {
            this.dishrepository = dishrepository;
        }

        [Route("api/dishes")]
        public IActionResult GetMenu()
        {
            var dishes = dishrepository.GetAll();
            return Ok(dishes);
        }

        [Route("api/dishes/{id}")]
        public IActionResult GetDish(Guid id)
        {
            var dish = dishrepository.GetById(id);
            return Ok(dish);
        }

        public IActionResult Get(Guid)
        {
            var dishes = dishrepository.GetDishes(type);
            return Ok(dishes);
        }

        //Create dish into database 
        [HttpPost]
        public ActionResult<Dish> Post(Dish dish)
        {
            var dish = dishrepository.Create(dish);
            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, dish);
        }

        //Update dish into database and return the dish
        [HttpPatch]
        public IActionResult Put(Dish dish)
        {
            var dish = dishrepository.Update(dish);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(Dish dish)
        {
            dishrepository.Delete(dish);
            return NoContent();
        }
    }
}