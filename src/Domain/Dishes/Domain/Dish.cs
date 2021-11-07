using System;
using System.Collections.Generic;
using MenuConfigurator.Model;

namespace MenuConfigurator.Domain
{
    public class Dish
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public void SetTitle(string value)
        {
            Ensure.NotNullOrEmpty(value, nameof(Title));
            Ensure.Argument.FitsToLength(value, DishMaxLengths.Title);
            Title = value;
        }
        public string Ingredients { get; private set; }
        public void SetIngredients(string value)
        {
            Ensure.Argument.FitsToLength(value, DishMaxLengths.Ingredients);
            Ingredients = value;
        }
        public string NutritionalInfo { get; private set; }
        public void SetNutritionalInfo(string value)
        {
            Ensure.Argument.FitsToLength(value, DishMaxLengths.NutritionalInfo);
            NutritionalInfo = value;
        }
        public string Allergens { get; private set; }
        public void SetAllergens(string value)
        {
            Ensure.Argument.FitsToLength(value, DishMaxLengths.Allergens);
            Allergens = value;
        }
        public string ImagePath { get; private set; }
        public void SetImagePath(string value)
        {
            Ensure.Argument.FitsToLength(value, DishMaxLengths.ImagePath);
            ImagePath = value;
        }
        public DishType Type { get; private set; }
        public void SetType(DishType value)
        {
            Type = value;
        }

        public ICollection<DishDay> Days { get; set; }

        private Dish() { Days = new HashSet<DishDay>(); }

        public Dish(Guid id, string title, string ingredients, string nutritionalInfo, string allergens, string imagePath, DishType type) : this()
        {
            Id = id;
            SetTitle(title);
            SetIngredients(ingredients);
            SetNutritionalInfo(nutritionalInfo);
            SetAllergens(allergens);
            SetImagePath(imagePath);
            SetType(type);
        }
    }
}
