using Microsoft.EntityFrameworkCore;
using MenuConfigurator.Domain;
using System;

namespace MenuConfigurator.Infraestructure
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishDay> DishDays { get; set; }
    }

}
