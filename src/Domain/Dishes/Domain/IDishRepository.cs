using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    public interface IDishRepository : IRepository<Dish>
    {
        Task<IEnumerable<Dish>> GetAll();
        Task<Dish> GetById(Guid dishId);
    }
}
