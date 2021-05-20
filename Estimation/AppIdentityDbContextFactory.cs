using Microsoft.EntityFrameworkCore;
using Estimation.Data;

namespace Estimation.Data
{
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactoryBase<RepositoryContext>
    {
        protected override RepositoryContext CreateNewInstance(DbContextOptions<RepositoryContext> options)
        {
            return new RepositoryContext(options);
        }
    }
}
