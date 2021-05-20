using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public Project Project;
    }
}
