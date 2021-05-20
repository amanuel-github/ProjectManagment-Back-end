using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.CreateEstimation
{
    public class CreateEstimationCommand : IRequest<int>
    {
        public EstimationProject Estimation;
    }
}
