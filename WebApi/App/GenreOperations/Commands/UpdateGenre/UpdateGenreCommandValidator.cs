using FluentValidation;

namespace WebApi.App.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.Name).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}