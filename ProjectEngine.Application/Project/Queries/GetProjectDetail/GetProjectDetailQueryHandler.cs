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

namespace ProjectEngine.Application.Queries.GetProjectDetail
{
    class GetProjectDetailQueryHandler : IRequestHandler<GetProjectDetailQuery, Project>
    {
        IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public GetProjectDetailQueryHandler(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public Task<Project> Handle(GetProjectDetailQuery request, CancellationToken cancellationToken)
        {

            var project = _projectRepo.FindByCondition(request.Id);

            if(project == null)
            {
                throw new NotFoundException(nameof(project), request.Id);
            }

            return project;
        }
    }
}
