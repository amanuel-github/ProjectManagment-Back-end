using FluentValidation;
using ProjectEngine.Application.Command.CreateProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.CreateProject
{
    class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(v => v.Project.Id).NotEmpty();
            RuleFor(v => v.Project.Name).NotEmpty();
            RuleFor(v => v.Project.StartDate).NotEmpty();
            RuleFor(v => v.Project.ProjectStatusId).NotEmpty();
            RuleFor(v => v.Project.Location).NotEmpty();
            RuleFor(v => v.Project.EndDate).NotEmpty();
            RuleFor(v => v.Project.ClientName).NotEmpty();
            RuleFor(v => v.Project.CostCodeId).NotEmpty();
            RuleFor(v => v.Project.BusinessUnitId).NotEmpty();
            RuleFor(v => v.Project.EstimatedDuration).NotEmpty();
            RuleFor(v => v.Project.EstimatedPrice).NotEmpty();
        }
    }


}
