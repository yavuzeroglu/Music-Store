using FluentValidation;

namespace WebApi.App.ProducerOperations.Queries.GetProducerDetail{
    public class GetProducerDetailQueryValidator : AbstractValidator<GetProducerDetailQuery>
    {
        public GetProducerDetailQueryValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}