using FluentValidation;

namespace WebApi.App.ProducerOperations.Commands.CreateProducer{
    public class CreateProducerCommandValidator : AbstractValidator<CreateProducerCommand>
    {
        public CreateProducerCommandValidator(){
            RuleFor(command => command.Model.FullName).MinimumLength(4).NotNull().NotEmpty();
        }
    }
}