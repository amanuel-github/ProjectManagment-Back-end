using System;
using System.Collections.Generic;
using System.Text;

namespace Estimation.Domain.interfaces
{
    public interface IRepositoryWrapper
    {
        IBusinessUnitRepository BusinessUnit { get; }
        ICostCodeRepository CostCode { get; }
        IDesciplineRepository Descipline { get; }
        IEstimationProjectRepository EstimationProject { get; }
        IItemRepository Item { get; }
        IProjectRepository Project { get; }

        IProjectStatusRepository ProjectStatus { get; }
        IResourceTypeRepository ResourceType { get; }

        void Save();
    }
}
