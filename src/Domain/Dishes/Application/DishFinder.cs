using System;
using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    public class DishFinder
    {
        private readonly IDishRepository dishRepository;

        public DishFinder(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public async Task<Model.Dish> Find(Guid dishId)
        {
            var entity = await Find(dishId);
            var dish = DishMapper.Map(entity);
            return dish;
        }
        public async Task<Dish> FindEntity(Guid dishId)
        {
            var entity = await dishRepository.GetById(dishId);
            if (entity is null)
            {
                throw new NotFoundException(nameof(Dish), dishId);
            }
            return entity;
        }
    }
}
