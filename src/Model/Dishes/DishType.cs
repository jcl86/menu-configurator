using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MenuConfigurator.Model
{
    public enum DishType
    {
        [Description("Primer plato")]
        First,

        [Description("Segundo plato")]
        Second,

        [Description("Postre")]
        Dessert
    }
}