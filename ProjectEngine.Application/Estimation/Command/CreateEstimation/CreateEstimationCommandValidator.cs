using FluentValidation;
using ProjectEngine.Application.Command.CreateProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.CreateEstimation
{
    class CreateEstimationCommandValidator : AbstractValidator<CreateEstimationCommand>
    {
        public CreateEstimationCommandValidator()
        {
            RuleFor(v => v.Estimation.Id).NotEmpty();
            RuleFor(v => v.Estimation.ItemId).NotEmpty();
            RuleFor(v => v.Estimation.MHRFactor).NotEmpty();
            RuleFor(v => v.Estimation.ProjectId).NotEmpty();
            RuleFor(v => v.Estimation.Rounded).NotEmpty();
            RuleFor(v => v.Estimation.TotalMHR).NotEmpty();
            RuleFor(v => v.Estimation.Contingency).NotEmpty();
            RuleFor(v => v.Estimation.CostCodeId).NotEmpty();
            RuleFor(v => v.Estimation.DesciplineId).NotEmpty();
            RuleFor(v => v.Estimation.EstimatedHourRate).NotEmpty();
            
        }
    }


}
