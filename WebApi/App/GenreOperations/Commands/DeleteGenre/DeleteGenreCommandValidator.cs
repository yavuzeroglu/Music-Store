using FluentValidation;

namespace WebApi.App.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}