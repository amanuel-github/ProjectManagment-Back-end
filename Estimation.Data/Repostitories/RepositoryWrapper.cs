using Estimation.Domain.interfaces;
using Estimation.Domain.Repostitories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estimation.Data.Repostitories
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IBusinessUnitRepository _businessUnit;
        private ICostCodeRepository _costCode;
        private IDesciplineRepository _descipline;
        private IEstimationProjectRepository _estimationProject;
        private IItemRepository _item;
        private IProjectRepository _project;
        private IProjectStatusRepository _projectStatus;
        private IResourceTypeRepository _resourceType;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IBusinessUnitRepository BusinessUnit
        {
            get
            {
                if(_businessUnit == null)
                {
                    _businessUnit = new BusinessUnitRepository(_repoContext);
                }

                return _businessUnit;
            }
        }


        public ICostCodeRepository CostCode
        {
            get
            {
                if (_costCode == null)
                {
                    _costCode = new CostCodeRepository(_repoContext);
                }

                return _costCode;
            }
        }


        public IDesciplineRepository Descipline
        {
            get
            {
                if (_descipline == null)
                {
                    _descipline = new DesciplineRepository(_repoContext);
                }

                return _descipline;
            }
        }


        public IEstimationProjectRepository EstimationProject
        {
            get
            {
                if (_estimationProject == null)
                {
                    _estimationProject = new EstimationProjectRepository(_repoContext);
                }

                return _estimationProject;
            }
        }


        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_repoContext);
                }

                return _item;
            }
        }

        public IProjectRepository Project
        {
            get
            {
                if (_project == null)
                {
                    _project = new ProjectRepository(_repoContext);
                }

                return _project;
            }
        }

        public IProjectStatusRepository ProjectStatus
        {
            get
            {
                if (_projectStatus == null)
                {
                    _projectStatus = new ProjectStatusRepository(_repoContext);
                }

                return _projectStatus;
            }
        }


        public IResourceTypeRepository ResourceType
        {
            get
            {
                if (_resourceType == null)
                {
                    _resourceType = new ResourceTypeRepository(_repoContext);
                }

                return _resourceType;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }
}
