using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using ProjectEngine.Application.Command.CreateProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Command.CreateProject
{
    class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {

        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var Project = request.Project;
             _projectRepo.Create(Project);
            await _projectRepo.SaveChangesAsync();

            return Project.Id;
        }
    }
}
