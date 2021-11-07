using System;

namespace MenuConfigurator.Model
{
    public class ProgrammedDish
    {
        public Guid Id { get; set; }
        public Dish Dish { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}