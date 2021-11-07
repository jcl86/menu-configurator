using MenuConfigurator.Model;
using Microsoft.AspNetCore.Mvc;
using MenuConfigurator.Infraestructure;
using System;
using MenuConfigurator.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MenuConfigurator.Api
{

    [ApiController, Route("api/dishes")]
    public class DishController : ControllerBase
    {
        private readonly DishCreator creator;
        private readonly DishFinder finder;
        private readonly DishUpdater updater;
        private readonly DishEraser eraser;
        private readonly DishLister lister;

        public DishController(
            DishCreator creator,
            DishFinder finder,
            DishUpdater updater,
            DishEraser eraser,
            DishLister lister)
        {
            this.creator = creator;
            this.finder = finder;
            this.updater = updater;
            this.eraser = eraser;
            this.lister = lister;
        }

        public async Task<ActionResult<IEnumerable<Model.Dish>>> GetAll()
        {
            var dishes = await lister.GetAll();
            return Ok(dishes);
        }

        [Route("{dishId}")]
        public async Task<ActionResult<Model.Dish>> GetDish(Guid dishId)
        {
            var dish = await finder.Find(dishId);
            return Ok(dish);
        }

        [HttpPost]
        public async Task<ActionResult<Model.Dish>> Post(CreateDish dish)
        {
            await creator.Create(dish);
            return CreatedAtAction(nameof(GetDish), new { id = dish.Id }, dish);
        }

        [HttpPatch, Route("{dishId}")]
        public async Task<IActionResult> PatchUpdate(Guid dishId, UpdateDish dto)
        {
            await updater.Update(dishId, dto);
            return NoContent();
        }

        [HttpDelete, Route("{dishId}")]
        public async Task<IActionResult> Delete(Guid dishId)
        {
            await eraser.Delete(dishId);
            return NoContent();
        }
    }
}