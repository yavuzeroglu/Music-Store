using FluentValidation;

namespace WebApi.App.AlbumOperations.Commands.CreateAlbum{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>{
        public CreateAlbumCommandValidator(){
            RuleFor(command => command.Model.Title).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(command => command.Model.GenreId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.Price).LessThan(10).NotEmpty().NotNull();
        }
    }
}