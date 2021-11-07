using MenuConfigurator.Domain;
using System.Linq;
using System.Collections.Generic;
using MenuConfigurator.Infraestructure;
using System;

namespace MenuConfigurator.Infraestructure
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        private readonly MenuContext _context;

        public DishRepository(MenuContext context) : base(context) { }

        public Dish GetById(Guid dishId)
        {
            return _context.Dishes.Find(dishId);
        }

        public IEnumerable<Dish> GetAll()
        {
            return _context.Dishes.ToList();
        }
    }
}
