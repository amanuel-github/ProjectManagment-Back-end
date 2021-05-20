using FluentValidation;


namespace ProjectEngine.Application.Queries.GetProjectDetail
{
    class GetProjectDetailQueryValidator : AbstractValidator<GetProjectDetailQuery>
    {
        public GetProjectDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
   
}
