using Estimation.Domain.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estimation.Data
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<EstimationProject> Estimations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<CostCode> CostCodes { get; set; }
        public DbSet<Descipline> Desciplines { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }

        //public DbSet<ApplicationUser> User { get; set; }
        
    }
}
