using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.DeleteEstimation 
{ 
    class DeleteEstimationCommandValidator : AbstractValidator<DeleteEstimationCommand>
    {
        public DeleteEstimationCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
