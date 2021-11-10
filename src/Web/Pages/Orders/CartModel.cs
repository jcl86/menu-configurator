using MenuConfigurator.Model;
using System.Collections.Generic;

namespace MenuConfigurator.Web.Pages.Orders
{
    public class CartModel
    {
        public List<Dish> Cart { get; private set; }
        public void AddToCart(Dish dish) => Cart.Add(dish);

        public CartModel()
        {
            Cart = new List<Dish>();
        }
    }
}
