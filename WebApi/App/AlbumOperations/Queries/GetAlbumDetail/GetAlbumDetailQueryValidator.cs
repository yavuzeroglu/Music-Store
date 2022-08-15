using FluentValidation;

namespace WebApi.App.AlbumOperations.Queries.GetAlbumDetail{
    public class GetAlbumDetailQueryValidator : AbstractValidator<GetAlbumDetailQuery>{
        public GetAlbumDetailQueryValidator(){
            RuleFor(query => query.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}