using MenuConfigurator.Domain;
using System.Linq;
using System.Collections.Generic;
using MenuConfigurator.Infraestructure;

public class DishRepository : Repository<Dish>
    {
        private readonly MenuContext _context;

        public DishRepository(MenuContext context) : base(context) { }

        public Dish GetById(int id)
        {
            return _context.Dishes.Find(id);
        }
        public IEnumerable<Dish> GetAll()
        {
            return _context.Dishes.ToList();
        }
    }
}
