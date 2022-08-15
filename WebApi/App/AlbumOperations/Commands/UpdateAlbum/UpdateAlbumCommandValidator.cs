using FluentValidation;

namespace WebApi.App.AlbumOperations.Commands.UpdateAlbum{
    public class UpdateAlbumCommandValidator : AbstractValidator<UpdateAlbumCommand>{
        public UpdateAlbumCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.GenreId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.Price).LessThan(10).NotEmpty().NotNull();
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now.AddDays(1)).NotEmpty().NotNull();
            RuleFor(command => command.Model.Title).MinimumLength(2).NotEmpty().NotNull();
        }
    }
}