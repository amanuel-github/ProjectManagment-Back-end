using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Queries.GetEstimationDetail
{
    public class GetEstimationDetailQuery : IRequest<EstimationProject>
    {
        public int Id { get; set; }
    }
}
