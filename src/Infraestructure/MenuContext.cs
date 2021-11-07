using Microsoft.EntityFrameworkCore;
using MenuConfigurator.Domain;
using System;
using System.Threading.Tasks;

namespace MenuConfigurator.Infraestructure
{
    public class MenuContext : DbContext, Domain.IUnitOfWork
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishDay> DishDays { get; set; }

        public async Task CompleteAsync() => await SaveChangesAsync();
    }

}
