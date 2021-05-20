using Estimation.Domain.models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEngine.Application.Command.UpdateEstimation
{
    public class UpdateEstimationCommand : IRequest<EstimationProject>
    {
        public EstimationProject Estimation { get; set; }
    }
}
