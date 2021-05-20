using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Queries.GetProjectList
{
    

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<Project>>
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepo, IMapper mapper)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
        }

        public async Task<List<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {


            var projects =  await _projectRepo.FindAll().ToListAsync();

            return projects;
        }
    }
}
