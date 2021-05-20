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
    public class ProjectRepository : IProjectRepository
    {
        private readonly RepositoryContext _repoContext;
        public ProjectRepository(RepositoryContext repositoryContext)
           
        {
            _repoContext = repositoryContext;
        }

        public void Create(Project entity)
        {
            _repoContext.Projects.Add(entity);
            //_repoContext.SaveChanges();
        }

        public void Delete(Project entity)
        {
            _repoContext.Projects.Remove(entity);
           
        }

        public async Task<int>  SaveChangesAsync()
        {
            var result = await _repoContext.SaveChangesAsync();

            return result;
        }

        public IQueryable<Project> FindAll()
        {
            var projects = _repoContext.Projects;
            return projects;
        }

        public async Task<Project> FindByCondition(int id)
        {
            var project = await _repoContext.Projects.FindAsync(id);

            return project;
        }

        public async Task<Project> Update(Project entity)
        {
            _repoContext.Projects.Update(entity);
            await  _repoContext.SaveChangesAsync();

            var project = await _repoContext.Projects.FindAsync(entity.Id);

            return project;
        }
    }
}
