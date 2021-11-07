using System.Collections.Generic;
using System.Linq;

namespace MenuConfigurator.Domain
{
    public class DishLister
    {
        private readonly IDishRepository dishRepository;

        public DishLister(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        
        public IEnumerable<Model.Dish> ToList()
        {
            var entities = dishRepository.GetAll();
            var result = entities.Select(DishMapper.Map);
            return result;
        }
    }
}
