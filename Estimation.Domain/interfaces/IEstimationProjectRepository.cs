using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estimation.Domain.interfaces
{
    public interface IEstimationProjectRepository
    {

        IQueryable<EstimationProject> FindAll();
        Task<EstimationProject> FindByCondition(int id);
        void Create(EstimationProject entity);
        Task<EstimationProject> Update(EstimationProject entity);
        void Delete(EstimationProject entity);
        Task<int> SaveChangesAsync();
    }
}
