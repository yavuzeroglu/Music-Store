using FluentValidation;

namespace WebApi.App.SingerOperations.Commands.DeleteSinger{
    public class DeleteSingerCommandValidator : AbstractValidator<DeleteSingerCommand>
    {
        public DeleteSingerCommandValidator(){
            RuleFor(comm => comm.singerId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}