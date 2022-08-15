using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}