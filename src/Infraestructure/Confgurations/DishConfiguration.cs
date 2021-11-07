using Microsoft.EntityFrameworkCore;
using MenuConfigurator.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared = MenuConfigurator.Shared;

namespace MenuConfigurator.Infraestructure
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedNever();
            builder.Property(d => d.Title).HasMaxLength(Shared.DishMaxLengths.Title).IsRequired();
            
            builder.Property(d => d.Ingredients).HasMaxLength(Shared.DishMaxLengths.Ingredients);
            builder.Property(d => d.Allergens).HasMaxLength(Shared.DishMaxLengths.Allergens);
            builder.Property(d => d.NutritionalInfo).HasMaxLength(Shared.DishMaxLengths.NutritionalInfo);
            builder.Property(d => d.ImagePath).HasMaxLength(Shared.DishMaxLengths.ImagePath);

            builder.HasOne(d => d.Days).WithMany(c => c.Dishes).HasForeignKey(d => d.CategoryId);
        }
    }
}
