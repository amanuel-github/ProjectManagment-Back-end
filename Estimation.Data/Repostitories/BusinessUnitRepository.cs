using Estimation.Domain.models;
using Estimation.Domain.interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using Estimation.Data;
using Estimation.Data.Repostitories;

namespace Estimation.Domain.Repostitories
{
    public class BusinessUnitRepository : RepositoryBase<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
