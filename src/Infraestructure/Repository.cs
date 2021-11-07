using System.Threading.Tasks;

namespace MenuConfigurator.Infraestructure
{
    public class Repository<T> : Domain.IRepository<T> where T : class
    {
        private readonly MenuContext context;

        public Repository(MenuContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity) => await context.Set<T>().AddAsync(entity);
        public void Delete(T entity) => context.Set<T>().Remove(entity);
        public void Update(T entity) => context.Set<T>().Update(entity);

    }

}
