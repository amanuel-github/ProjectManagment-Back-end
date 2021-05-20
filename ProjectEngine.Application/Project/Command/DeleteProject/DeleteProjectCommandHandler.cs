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

namespace ProjectEngine.Application.Command.DeleteProject
{
    class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _projectRepo.FindByCondition(request.Id);
            
            if(project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _projectRepo.Delete(project.Result);
            var result = _projectRepo.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
