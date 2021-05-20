using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Project>
    {
        public Project Project { get; set; }
    }
}
