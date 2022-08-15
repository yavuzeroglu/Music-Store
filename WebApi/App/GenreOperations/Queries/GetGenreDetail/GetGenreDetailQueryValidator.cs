using FluentValidation;

namespace WebApi.App.GenreOperations.Queries.GetGenreDetail{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}