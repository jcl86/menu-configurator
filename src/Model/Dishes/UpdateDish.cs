using System.ComponentModel.DataAnnotations;

namespace MenuConfigurator.Model
{
    public class UpdateDish
    {
        [Required]
        [StringLength(DishMaxLengths.Title)]
        public string Title { get; set; }

        [StringLength(DishMaxLengths.Ingredients)]
        public string Ingredients { get; set; }

        [StringLength(DishMaxLengths.NutritionalInfo)]
        public string NutritionalInfo { get; set; }
        [StringLength(DishMaxLengths.Allergens)]
        public string Allergens { get; set; }
        [StringLength(DishMaxLengths.ImagePath)]
        public string ImagePath { get; set; }
        public DishType Type { get; set; }
    }

}