using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using ProjectEngine.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Queries.GetEstimationDetail
{
    class GetEstimationDetailQueryHandler : IRequestHandler<GetEstimationDetailQuery, EstimationProject>
    {
        IEstimationProjectRepository _estimationRepo;
        private readonly IMapper _mapper;

        public GetEstimationDetailQueryHandler(IEstimationProjectRepository estimationRepo, IMapper mapper)
        {
            _estimationRepo = estimationRepo;
            _mapper = mapper;
        }

        public async Task<EstimationProject> Handle(GetEstimationDetailQuery request, CancellationToken cancellationToken)
        {

            var estimation = await _estimationRepo.FindByCondition(request.Id);

            if(estimation == null)
            {
                throw new NotFoundException(nameof(EstimationProject), request.Id);
            }

            return estimation;
        }
    }
}
