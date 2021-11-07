using System;

namespace MenuConfigurator.Domain
{
    public static class DishMapper
    {
        //public static Func<Dish, Model.Dish> MapFunction => (x) => Map(x);
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
