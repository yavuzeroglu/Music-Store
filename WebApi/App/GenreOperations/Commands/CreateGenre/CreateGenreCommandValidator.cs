using FluentValidation;

namespace WebApi.App.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator(){
            RuleFor(command => command.Model.Name).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}
