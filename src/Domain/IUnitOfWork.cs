using System.Threading.Tasks;

namespace MenuConfigurator.Domain
{
    public interface IUnitOfWork 
    {
        Task CompleteAsync();
    }
}
