using Estimation.Data;
using Estimation.Data.Repostitories;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estimation.Domain.Repostitories
{
    public class DesciplineRepository : RepositoryBase<Descipline>, IDesciplineRepository
    {
        public DesciplineRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }
    }
}
