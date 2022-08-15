using FluentValidation;

namespace WebApi.App.SingerAlbumOperations.Commands.DeleteSingerAlbum{
    public class DeleteSingerAlbumCommandValidator : AbstractValidator<DeleteSingerAlbumCommand>
    {
        public DeleteSingerAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}