using FluentValidation;

namespace WebApi.App.SingerOperations.Queries.GetSingerDetail{
    public class GetSingerDetailQueryValidator : AbstractValidator<GetSingerDetailQuery>
    {
        public GetSingerDetailQueryValidator(){
            RuleFor(query =>query.singerId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}