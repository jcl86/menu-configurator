using System;

namespace MenuConfigurator.Domain
{
    public class DishDay
    {
        public Guid Id { get; set; }
        public Guid DishId { get; set; }
        public Dish Dish { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
