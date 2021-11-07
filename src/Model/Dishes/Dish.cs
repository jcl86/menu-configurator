using System;

namespace MenuConfigurator.Model
{
    public class Dish
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string NutritionalInfo { get; set; }
        public string Allergens { get; set; }
        public string ImagePath { get; set; }
        public DishType Type { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}