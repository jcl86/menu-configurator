using System;
using System.Threading.Tasks;
using MenuConfigurator.Model;

namespace MenuConfigurator.Domain
{
    [Service]
    public class DishUpdater
    {
        private readonly DishFinder finder;
        private readonly IDishRepository dishRepository;
        private readonly IUnitOfWork unitOfWork;

        public DishUpdater(
            DishFinder finder,
            IDishRepository dishRepository,
            IUnitOfWork unitOfWork)
        {
            this.finder = finder;
            this.dishRepository = dishRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task Update(Guid dishId, UpdateDish dto)
        {
            var entity = await finder.FindEntity(dishId);
            entity.SetTitle(dto.Title);
            entity.SetIngredients(dto.Ingredients);
            entity.SetNutritionalInfo(dto.NutritionalInfo);
            entity.SetAllergens(dto.Allergens);
            entity.SetImagePath(dto.ImagePath);
            entity.SetType(dto.Type);
            dishRepository.Update(entity);
            await unitOfWork.CompleteAsync();
        }
    }
}
