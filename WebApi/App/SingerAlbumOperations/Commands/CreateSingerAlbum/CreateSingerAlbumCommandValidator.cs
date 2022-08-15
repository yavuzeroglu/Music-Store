using FluentValidation;

namespace WebApi.App.SingerAlbumOperations.Commands.CreateSingerAlbum{
    public class CreateSingerAlbumCommandValidator : AbstractValidator<CreateSingerAlbumCommand>
    {
        public CreateSingerAlbumCommandValidator(){
            RuleFor(command => command.Model.AlbumId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.SingerId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}