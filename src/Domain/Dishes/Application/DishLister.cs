using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    [Service]
    public class DishLister
    {
        private readonly IDishRepository dishRepository;

        public DishLister(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        
        public async Task<IEnumerable<Model.Dish>> ToList()
        {
            var entities = await dishRepository.GetAll();
            var result = entities.Select(x => DishMapper.Map(x));
            return result;
        }
    }
}
