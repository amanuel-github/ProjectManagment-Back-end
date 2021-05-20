using Estimation.Data;
using Estimation.Data.Repostitories;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Estimation.Domain.Repostitories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RepositoryContext _repoContext;
        public ItemRepository(RepositoryContext repositoryContext)

        {
            _repoContext = repositoryContext;
        }

        public void Create(Item entity)
        {
            _repoContext.Items.Add(entity);
        }

        public void Delete(Item entity)
        {
            _repoContext.Items.Remove(entity);
        }

        public IQueryable<Item> FindAll()
        {
            return _repoContext.Items;
        }

        public async Task<Item> FindByCondition(int id)
        {
            return await _repoContext.Items.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _repoContext.SaveChangesAsync();
        }

        public Task<Item> Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
