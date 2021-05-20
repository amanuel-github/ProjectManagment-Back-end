using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Estimation.Domain.interfaces
{
    public interface IProjectRepository 
    {

        IQueryable<Project> FindAll();
        Task<Project> FindByCondition(int id);
        void Create(Project entity);
        Task<Project> Update(Project entity);
        void Delete(Project entity);

        Task<int> SaveChangesAsync();
    }
}
