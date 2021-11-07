using MenuConfigurator.Domain;
using System.Linq;
using System.Collections.Generic;
using MenuConfigurator.Infraestructure;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MenuConfigurator.Infraestructure
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(MenuContext context) : base(context) { }

        public async Task<Dish> GetById(Guid dishId)
        {
            return await context.Dishes.FindAsync(dishId);
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            var result = await context.Dishes.ToListAsync();
            return result;
        }
    }
}
