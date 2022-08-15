using FluentValidation;

namespace WebApi.App.CustomerOperations.Commands.UpdateCustomer{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator(){
            RuleFor(command => command.Id).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(command => command.Model.Name).MinimumLength(2).NotEmpty().NotNull();
            RuleFor(command => command.Model.Surname).MinimumLength(2).NotNull().NotEmpty();
            RuleFor(command => command.Model.Email).EmailAddress().NotNull().NotEmpty();
            RuleFor(command => command.Model.Password).MinimumLength(4).NotEmpty().NotNull();
        }
    }
}