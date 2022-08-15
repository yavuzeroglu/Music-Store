using FluentValidation;

namespace WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbumDetail{
    public class GetSingerAlbumDetailQueryValidator : AbstractValidator<GetSingerAlbumDetailQuery>
    {
        public GetSingerAlbumDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}