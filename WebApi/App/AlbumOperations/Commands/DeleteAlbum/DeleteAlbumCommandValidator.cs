using FluentValidation;

namespace WebApi.App.AlbumOperations.Commands.DeleteAlbum{
    public class DeleteAlbumCommandValidator : AbstractValidator<DeleteAlbumCommand>{
        public DeleteAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}