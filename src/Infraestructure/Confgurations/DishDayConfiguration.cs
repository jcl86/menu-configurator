using Microsoft.EntityFrameworkCore;
using MenuConfigurator.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MenuConfigurator.Infraestructure
{
    public class DishDayConfiguration : IEntityTypeConfiguration<DishDay>
    {
        public void Configure(EntityTypeBuilder<DishDay> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedNever();

            builder.HasOne(d => d.Dish)
            .WithMany(c => c.Days)
            .HasForeignKey(d => d.DishId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
