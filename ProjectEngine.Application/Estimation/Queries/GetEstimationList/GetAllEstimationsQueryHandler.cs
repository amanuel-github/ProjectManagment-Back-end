using AutoMapper;
using Estimation.Domain.interfaces;
using Estimation.Domain.models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectEngine.Application.Queries.GetEstimation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEngine.Application.Queries.GetProjectList
{
    

    public class GetAllEstimatoinsQueryHandler : IRequestHandler<GetAllEstimationsQuery, List<EstimationProject>>
    {
        IEstimationProjectRepository _estimationRepo;
        private readonly IMapper _mapper;

        public GetAllEstimatoinsQueryHandler(IEstimationProjectRepository estimationRepo, IMapper mapper)
        {
            _estimationRepo = estimationRepo;
            _mapper = mapper;
        }

        public async Task<List<EstimationProject>> Handle(GetAllEstimationsQuery request, CancellationToken cancellationToken)
        {


            var projects =  await _estimationRepo.FindAll().ToListAsync();

            return projects;
        }
    }
}
