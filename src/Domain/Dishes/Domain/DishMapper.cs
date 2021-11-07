namespace MenuConfigurator.Domain
{
    public static class DishMapper
    {
        public static Model.Dish Map(Dish dish)
        {
            return new Model.Dish()
            {
                Id = dish.Id,
                Title = dish.Title,
                Ingredients = dish.Ingredients,
                NutritionalInfo = dish.NutritionalInfo,
                Allergens = dish.Allergens,
                ImagePath = dish.ImagePath,
                Type = dish.Type
            };
        }
    }
}
