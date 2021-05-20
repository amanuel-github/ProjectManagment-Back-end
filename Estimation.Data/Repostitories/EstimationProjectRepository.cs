using Estimation.Data;
using Estimation.Data.Repostitories;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estimation.Domain.Repostitories
{
    public class EstimationProjectRepository : IEstimationProjectRepository
    {

        private readonly RepositoryContext _repoContext;

        public EstimationProjectRepository(RepositoryContext repoContext)
        {
            this._repoContext = repoContext;
        }
        public void Create(EstimationProject entity)
        {
            _repoContext.Estimations.Add(entity);
            //_repoContext.SaveChanges();
        }

        public void Delete(EstimationProject entity)
        {
            _repoContext.Estimations.Remove(entity);
            _repoContext.SaveChanges();
        }

        public IQueryable<EstimationProject> FindAll()
        {
            return _repoContext.Estimations.Include(E => E.Project).Include(E => E.CostCode)
                                                            .Include(E => E.Item).Include(E => E.Descipline);
        }

        public async Task<EstimationProject> FindByCondition(int id)
        {
            return await _repoContext.Estimations.FindAsync(id);
        }

        public async Task<EstimationProject> Update(EstimationProject entity)
        {

            _repoContext.Estimations.Update(entity);
            var result = _repoContext.SaveChanges();

            var estimation = await _repoContext.Estimations.FindAsync(entity.Id);

            return estimation;

        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _repoContext.SaveChangesAsync();

            return result;
        }


    }
}
