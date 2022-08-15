using FluentValidation;

namespace WebApi.App.ProducerOperations.Commands.UpdateProducer{
    public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
    {
        public UpdateProducerCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.FullName).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}