using FluentValidation;

namespace WebApi.App.CustomerAlbumOperations.Commands.UpdateCustomerAlbum{
    public class UpdateCustomerAlbumCommandValidator : AbstractValidator<UpdateCustomerAlbumCommand>
    {
        public UpdateCustomerAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.AlbumId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.CustomerId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}