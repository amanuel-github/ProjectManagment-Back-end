using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using ProjectEngine.Application.Command.CreateEstimation;
using ProjectEngine.Application.Command.CreateProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Command.CreateEstimation
{
    class CreateEstimationCommandHandler : IRequestHandler<CreateEstimationCommand, int>
    {

        private readonly IEstimationProjectRepository _estimationRepo;
        private readonly IMapper _mapper;

        public CreateEstimationCommandHandler(IEstimationProjectRepository estimationRepo, IMapper mapper)
        {
            _estimationRepo = estimationRepo;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateEstimationCommand request, CancellationToken cancellationToken)
        {

            var Estimation = request.Estimation;
            _estimationRepo.Create(Estimation);
            await _estimationRepo.SaveChangesAsync();

            return Estimation.Id;
        }
    }
}
