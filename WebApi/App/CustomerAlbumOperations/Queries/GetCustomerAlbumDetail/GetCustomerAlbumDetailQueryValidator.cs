using FluentValidation;

namespace WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbumDetail{
    public class GetCustomerAlbumDetailQueryValidator : AbstractValidator<GetCustomerAlbumDetailQuery>
    {
        public GetCustomerAlbumDetailQueryValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}