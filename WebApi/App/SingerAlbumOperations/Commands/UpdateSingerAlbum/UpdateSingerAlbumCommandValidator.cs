using FluentValidation;

namespace WebApi.App.SingerAlbumOperations.Commands.UpdateSingerAlbum{
    public class UpdateSingerAlbumCommandValidator : AbstractValidator<UpdateSingerAlbumCommand>
    {
        public UpdateSingerAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.AlbumId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.SingerId).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}