using Estimation.Data;
using Estimation.Data.Repostitories;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estimation.Domain.Repostitories
{
    public class ProjectStatusRepository : RepositoryBase<ProjectStatus>, IProjectStatusRepository
    {
        public ProjectStatusRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }
    }
}
