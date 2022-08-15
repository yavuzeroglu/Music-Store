using FluentValidation;

namespace WebApi.App.ProducerOperations.Commands.DeleteProducer
{
    public class DeleteProducerCommandValidator : AbstractValidator<DeleteProducerCommand>
    {
        public DeleteProducerCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
        }
    }
}