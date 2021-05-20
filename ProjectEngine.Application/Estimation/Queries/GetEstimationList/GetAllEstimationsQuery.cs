using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Estimation.Domain.models;

namespace ProjectEngine.Application.Queries.GetEstimation
{
    public class GetAllEstimationsQuery : IRequest<List<EstimationProject>>
    {


    }
}