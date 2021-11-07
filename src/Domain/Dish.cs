using System;
using System.Collections.Generic;
using MenuConfigurator.Shared;

namespace MenuConfigurator.Domain
{
    public class Dish
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Ingredients { get; private set; }
        public string NutritionalInfo { get; private set; }
        public string Allergens { get; private set; }
        public string ImagePath { get; private set; }
        public DishType Type { get; private set; }
        
        public ICollection<DishDay> Days { get; set; }
    }
}
