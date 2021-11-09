using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MenuConfigurator.Model
{
    public enum DishType
    {
        [Description("Primeros platos")]
        First,

        [Description("Segundos platos")]
        Second,

        [Description("Postres")]
        Dessert
    }
}