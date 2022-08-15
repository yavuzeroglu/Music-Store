using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator(){
            RuleFor(command => command.Model.Name).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(command => command.Model.Surname).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(command => command.Model.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(command => command.Model.Password).MinimumLength(4).NotEmpty().NotNull();
        }
    }
}