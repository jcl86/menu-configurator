using System.Threading.Tasks;
using MenuConfigurator.Model;

namespace MenuConfigurator.Domain
{
    public class DishCreator
    {
        private readonly IDishRepository dishRepository;
        private readonly IUnitOfWork unitOfWork;

        public DishCreator(IDishRepository dishRepository, IUnitOfWork unitOfWork)
        {
            this.dishRepository = dishRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Model.Dish> Create(CreateDish dto)
        {
            var entity = new Dish(dto.Id, dto.Title, dto.Ingredients, dto.NutritionalInfo, dto.Allergens, dto.ImagePath, dto.Type);
            await dishRepository.Add(entity);
            await unitOfWork.Complete();
            var dish = DishMapper.Map(entity);
            return dish;
        }
    }
}
