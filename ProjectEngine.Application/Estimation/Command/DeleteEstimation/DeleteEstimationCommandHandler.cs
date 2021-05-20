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
using ProjectEngine.Application.Common.Exceptions;

namespace ProjectEngine.Application.Command.DeleteEstimation
{
    class DeleteEstimationCommandHandler : IRequestHandler<DeleteEstimationCommand, Unit>
    {
        private readonly IEstimationProjectRepository _estimationRepo;
        private readonly IMapper _mapper;

        public DeleteEstimationCommandHandler(IEstimationProjectRepository estimationRepo, IMapper mapper)
        {
            _estimationRepo = estimationRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEstimationCommand request, CancellationToken cancellationToken)
        {
            var estimation = _estimationRepo.FindByCondition(request.Id);
            
            if(estimation == null)
            {
                throw new NotFoundException(nameof(EstimationProject), request.Id);
            }

            _estimationRepo.Delete(estimation.Result);
            var result = _estimationRepo.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
