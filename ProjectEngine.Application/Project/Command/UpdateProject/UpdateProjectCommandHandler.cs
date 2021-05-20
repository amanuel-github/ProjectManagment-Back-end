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

namespace ProjectEngine.Application.Command.UpdateProject
{
    class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Project>
    {
        IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }
        public Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {

            var project = _projectRepo.Update(request.Project);
           
            return project;

        }
    }
}
