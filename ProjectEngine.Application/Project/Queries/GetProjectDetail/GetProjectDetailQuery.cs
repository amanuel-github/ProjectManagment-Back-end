using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Queries.GetProjectDetail
{
    public class GetProjectDetailQuery : IRequest<Project>
    {
        public int Id { get; set; }
    }
}
