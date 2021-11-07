using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
