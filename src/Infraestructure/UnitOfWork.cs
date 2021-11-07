using MenuConfigurator.Domain;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuConfigurator.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MenuContext context;

        public UnitOfWork(MenuContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            try
            {

                await context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    string errorsMessages = string.Join(", ", GetErrors(sqlException));
                    throw new System.Exception(errorsMessages);
                }
                throw;
            }
        }

        private IEnumerable<string> GetErrors(SqlException sqlException)
        {
            foreach (var error in sqlException.Errors)
            {
                yield return error.ToString();
            }
        }
    }
}
