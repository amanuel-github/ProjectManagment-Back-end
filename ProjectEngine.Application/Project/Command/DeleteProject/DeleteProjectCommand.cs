using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
