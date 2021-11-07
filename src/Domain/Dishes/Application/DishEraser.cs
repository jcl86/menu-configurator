using System;
using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    public class DishEraser
    {
        private readonly DishFinder finder;
        private readonly IDishRepository dishRepository;
        private readonly IUnitOfWork unitOfWork;

        public DishEraser(
            DishFinder finder,
            IDishRepository dishRepository,
            IUnitOfWork unitOfWork)
        {
            this.finder = finder;
            this.dishRepository = dishRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Delete(Guid dishId)
        {
            var entity = await finder.FindEntity(dishId);
            dishRepository.Delete(entity);
            await unitOfWork.Complete();
        }
    }
}
