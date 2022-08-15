using FluentValidation;

namespace WebApi.App.SingerOperations.Commands.CreateSinger{
    public class CreateSingerCommandValidator : AbstractValidator<CreateSingerCommand>
    {
        public CreateSingerCommandValidator(){
            RuleFor(comm => comm.Model.FullName).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}