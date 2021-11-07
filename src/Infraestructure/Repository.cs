namespace MenuConfigurator.Infraestructure
{
    public class Repository<T> where T : class
    {
        private readonly MenuContext _context;

        public Repository(MenuContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);

    }

}
