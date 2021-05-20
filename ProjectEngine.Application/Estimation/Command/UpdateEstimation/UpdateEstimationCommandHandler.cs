using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using ProjectEngine.Application.Command.DeleteProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Command.UpdateEstimation
{
    class UpdateEstimationCommandHandler : IRequestHandler<UpdateEstimationCommand, EstimationProject>
    {
        private readonly IEstimationProjectRepository _estimationRepo;
        private readonly IMapper _mapper;

        public UpdateEstimationCommandHandler(IEstimationProjectRepository estimationRepo, IMapper mapper)
        {
            _estimationRepo = estimationRepo;
            _mapper = mapper;
        }

        public async Task<EstimationProject> Handle(UpdateEstimationCommand request, CancellationToken cancellationToken)
        {

            var project = await _estimationRepo.Update(request.Estimation);
           
            return project;

        }
    }
}
