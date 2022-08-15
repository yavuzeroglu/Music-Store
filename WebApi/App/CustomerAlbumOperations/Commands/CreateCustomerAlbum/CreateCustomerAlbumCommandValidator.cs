using FluentValidation;

namespace WebApi.App.CustomerAlbumOperations.Commands.CreateCustomerAlbum{
    public class CreateCustomerAlbumCommandValidator : AbstractValidator<CreateCustomerAlbumCommand>
    {
        public CreateCustomerAlbumCommandValidator(){
            RuleFor(command => command.Model.AlbumId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
            
        }
    }
}