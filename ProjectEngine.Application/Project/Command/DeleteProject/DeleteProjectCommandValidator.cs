using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.DeleteProject
{
    class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
}
