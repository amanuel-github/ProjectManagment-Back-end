using FluentValidation;


namespace ProjectEngine.Application.Queries.GetEstimationDetail
{
    class GetEstimationDetailQueryValidator : AbstractValidator<GetEstimationDetailQuery>
    {
        public GetEstimationDetailQueryValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
        }
    }
   
}
