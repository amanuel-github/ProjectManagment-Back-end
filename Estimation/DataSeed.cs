using Estimation.Domain.models;
using Estimation.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Estimation
{
    public class DataSeed
    {
        private readonly RepositoryContext _apiContext;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;

        public DataSeed(RepositoryContext apiContext)
        {
            this._apiContext = apiContext;
           // this._signInManager = signInManager;
           // this._userManager = userManager;
        }

        public void SeedData()
        {
            /*
            if (!_apiContext.User.Any())
            {
                ApplicationUser user = new ApplicationUser {

                    
                    UserName = "saytoyirga@gmail.com",
                    Email = "saytoyirga@gmail.com"


                };

                 var createUser =  await _userManager.CreateAsync(user, "password").ConfigureAwait(true);

                var isCreated = createUser.Succeeded;
                var error = createUser.Errors;
                var ret = createUser.ToString();

            }*/

            if (!_apiContext.BusinessUnits.Any())
            {
                SeedBusinessUnit();
                _apiContext.SaveChanges();
            }

            if (!_apiContext.CostCodes.Any())
            {
                SeedCostCode();
                _apiContext.SaveChanges();
            }

            if (!_apiContext.Desciplines.Any())
            {
                SeedDescipline();
                _apiContext.SaveChanges();
            }
           
            if (!_apiContext.ResourceTypes.Any())
            {
                SeedResourceTypes();
                _apiContext.SaveChanges();
            }
            
            if (!_apiContext.ProjectStatus.Any())
            {
                SeedProjectStatus();
                _apiContext.SaveChanges();
            }
            if (!_apiContext.Items.Any())
            {
                SeedItem();
                _apiContext.SaveChanges();
            }
            if (!_apiContext.Projects.Any())
            {
                SeedProjects();
                _apiContext.SaveChanges();
            }

           /* if (!_apiContext.Estimations.Any())
            {
                SeedEstimation();
            }*/

        }

       
        private void SeedEstimation()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        private void SeedProjects()
        {
            List<Project> projects = new List<Project>();

            projects.Add(new Project
            {
                
                Name = "Name One",
                BusinessUnitId =  1,
                CostCodeId =  1,
                EstimatedPrice = 1,
                ProjectStatusId = 1,
                StartDate = new DateTime(2020,1,1),
                EndDate = new DateTime(2020, 1, 1),
                EstimatedDuration = 1,
                ClientName = "Client one",
                Location = "Location one",
            });

            projects.Add(new Project
            {

                Name = "Name two",
                BusinessUnitId = 2,
                CostCodeId =  2,
                EstimatedPrice = 2,
                ProjectStatusId =  2,
                StartDate = new DateTime(2020, 2, 2),
                EndDate = new DateTime(2020, 2, 2),
                EstimatedDuration = 2,
                ClientName = "Client two",
                Location = "Location two",
            });

            projects.Add(new Project
            {

                Name = "Name three",
                BusinessUnitId =  3,
                CostCodeId =  3,
                EstimatedPrice = 3,
                ProjectStatusId =  3,
                StartDate = new DateTime(2020, 3, 3),
                EndDate = new DateTime(2020, 3, 3),
                EstimatedDuration = 3,
                ClientName = "Client three",
                Location = "Location three",
            });
            foreach (var project in projects)
            {
                _apiContext.Projects.Add(project);
            }
        }
        private void SeedProjectStatus()
        {
            List<ProjectStatus> projectStatus = new List<ProjectStatus>();

            projectStatus.Add(new ProjectStatus()
            {
                Name = "Status One",
                Description = "Description One"
            });

            projectStatus.Add(new ProjectStatus
            {
                Name = "Status two",
                Description = "Description two"
            });

            projectStatus.Add(new ProjectStatus
            {
                Name = "Status three",
                Description = "Description three"
            });
            foreach (var projectStatu in projectStatus)
            {
                _apiContext.ProjectStatus.Add(projectStatu);
            }
        }
        private void SeedResourceTypes()
        {
            List<ResourceType> resourceTypes = new List<ResourceType>();

            resourceTypes.Add(new ResourceType() { 
                Description = "Description One" 
            });

            resourceTypes.Add(new ResourceType
            {
                
                Description = "Description two"
            });

            resourceTypes.Add(new ResourceType
            {
                Description = "Description three"
            });
            foreach (var resourceType in resourceTypes)
            {
                _apiContext.ResourceTypes.Add(resourceType);
            }
        }

       
        private void SeedItem()
         {
            List<Item> items = new List<Item>();
            items.Add(new Item
            {
                //BusinessUnit_Id = 1,
                ItemDescription = "Name One",
                Description = "Remark One",
                UOM = "UOM",
                EstimatedQuantity = 1,
                RevisedQuantity = 1,
                EstimatedUnitPrice = 1,
                EstimatedPrice = 1,
                BidUnitPrice = 1,
                ProductivtyFactor = "productivity factor one",
                MHRFactor = "MHR Factor one",
                TotalMHR = "total man hour",
                ResourceTypeId = 1
            });

            items.Add(new Item
            {
                ItemDescription = "Name two",
                Description = "Remark two",
                UOM = "UOM two",
                EstimatedQuantity = 2,
                RevisedQuantity = 2,
                EstimatedUnitPrice = 2,
                EstimatedPrice = 2,
                BidUnitPrice = 2,
                ProductivtyFactor = "productivity factor two",
                MHRFactor = "MHR Factor two",
                TotalMHR = "total man hour two",
                ResourceTypeId =  2
            });

            items.Add(new Item
            {
                ItemDescription = "Name three",
                Description = "Remark three",
                UOM = "UOM three",
                EstimatedQuantity = 3,
                RevisedQuantity = 3,
                EstimatedUnitPrice = 3,
                EstimatedPrice = 3,
                BidUnitPrice =3,
                ProductivtyFactor = "productivity factor three",
                MHRFactor = "MHR Factor three",
                TotalMHR = "total man hour three",
                ResourceTypeId =  3
            });

            foreach (var item in items)
            {
                _apiContext.Items.Add(item);
            }
        }
        private void SeedDescipline()
        {
            List<Descipline> desciplines = new List<Descipline>();
            desciplines.Add(new Descipline
            {
                //BusinessUnit_Id = 1,
                Name = "Name One",
                Remarks = "Remark One"
            });

            desciplines.Add(new Descipline
            {
                Name = "Name two",
                Remarks = "Remark two"
            });

            desciplines.Add(new Descipline
            {
                Name = "Name three",
                Remarks = "Remark three"
            });

            foreach (var descipline in desciplines)
            {
                _apiContext.Desciplines.Add(descipline);
            }
        }

        private void SeedCostCode()
        {
            List<CostCode> costCodes = new List<CostCode>();
            costCodes.Add(new CostCode
            {
                //BusinessUnit_Id = 1,
                Value = "Value One",
                Level = "Level One",
                Catagory = "catagory one",
                Description = "Des one",
                UOMMeasure = "UOM one"
            });

            costCodes.Add(new CostCode
            {
                Value = "Value two",
                Level = "Level two",
                Catagory = "catagory two",
                Description = "Des two",
                UOMMeasure = "UOM two"
            });

            costCodes.Add(new CostCode
            {
                Value = "Value three",
                Level = "Level three",
                Catagory = "catagory three",
                Description = "Des three",
                UOMMeasure = "UOM three"
            });

            foreach (var costCode in costCodes)
            {
                _apiContext.CostCodes.Add(costCode);
            }

        }

        private void SeedBusinessUnit()
        {
            List<BusinessUnit> businessUnits = new List<BusinessUnit>();
            businessUnits.Add(new BusinessUnit
            {
                //BusinessUnit_Id = 1,
                Catagory = "Catagory One"
            });

            businessUnits.Add(new BusinessUnit
            {
                //BusinessUnit_Id = 1,
                Catagory = "Catagory One"
            });

            businessUnits.Add(new BusinessUnit
            {
                //BusinessUnit_Id = 1,
                Catagory = "Catagory two"
            });
            businessUnits.Add(new BusinessUnit
            {
                //BusinessUnit_Id = 1,
                Catagory = "Catagory three"
            });

            foreach(var businessUnit in businessUnits)
            {
                _apiContext.BusinessUnits.Add(businessUnit);
            }
        }




    }
}
