using System.ComponentModel;

namespace MenuConfigurator.Model
{
    public enum DishCategory
    {
        [Description("Cocidos")]
        Legumes,

        [Description("Pastas y arroces")]
        PastaAndRice,

        [Description("Verduras")]
        Vegetables,

        [Description("Ensaladas")]
        Salads,

        [Description("Carnes")]
        Meat,

        [Description("Pescados")]
        Fish,

        [Description("Otros")]
        OtherSeconds,

        [Description("Fruta")]
        Fruit,

        [Description("Yogurt")]
        Yogurt,

        [Description("Otros")]
        OtherDesserts,
    }
}