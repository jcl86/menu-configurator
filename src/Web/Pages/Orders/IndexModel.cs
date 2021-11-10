using MenuConfigurator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuConfigurator.Web.Pages.Orders
{
    public class IndexModel
    {
        public DishType Type { get; set; } = DishType.First;
        public bool IsChecked(DishType type) => Type == type;
        public void TypeChanged(string value)
        {
            if (Enum.TryParse(value, out DishType result))
            {
                Type = result;
            }
        }

        public bool HasLegumes { get; set; } = true;
        public bool HasPastaAndRice { get; set; } = true;
        public bool HasVegetables { get; set; } = true;
        public bool HasSalads { get; set; } = true;
        public bool HasMeat { get; set; } = true;
        public bool HasFish { get; set; } = true;
        public bool HasOtherSeconds { get; set; } = true;
        public bool HasFruit { get; set; } = true;
        public bool HasYogurt { get; set; } = true;
        public bool HasOtherDesserts { get; set; } = true;

        private IEnumerable<Dish> dishes = new List<Dish>();

        public void Initialize(IEnumerable<Dish> dishes)
        {
            this.dishes = dishes;
        }

        public IEnumerable<Dish> Dishes
        {
            get
            {
                return dishes.Where(x =>
                (HasLegumes || x.Category == DishCategory.Legumes) &&
                (HasPastaAndRice || x.Category == DishCategory.PastaAndRice) &&
                (HasVegetables || x.Category == DishCategory.Vegetables) &&
                (HasMeat || x.Category == DishCategory.Meat) &&
                (HasFish || x.Category == DishCategory.Fish) &&
                (HasOtherSeconds || x.Category == DishCategory.OtherSeconds) &&
                (HasFruit || x.Category == DishCategory.Fruit) &&
                (HasYogurt || x.Category == DishCategory.Yogurt) &&
                (HasOtherDesserts || x.Category == DishCategory.OtherDesserts) &&
                x.Type == Type
                ).ToList();
            }
        }
    }
}
