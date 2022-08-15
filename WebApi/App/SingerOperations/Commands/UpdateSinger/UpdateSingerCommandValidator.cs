using FluentValidation;

namespace WebApi.App.SingerOperations.Commands.UpdateSinger{
    public class UpdateSingerCommandValidator : AbstractValidator<UpdateSingerCommand>
    {
        public UpdateSingerCommandValidator(){
            RuleFor(comm => comm.singerId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(comm => comm.Model.FullName).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}