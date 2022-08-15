using FluentValidation;

namespace WebApi.App.CustomerAlbumOperations.Commands.DeleteCustomerAlbum{
    public class DeleteCustomerAlbumCommandValidator : AbstractValidator<DeleteCustomerAlbumCommand>{
        public DeleteCustomerAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}