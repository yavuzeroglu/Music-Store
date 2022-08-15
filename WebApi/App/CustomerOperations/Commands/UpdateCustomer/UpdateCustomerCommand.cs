using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateCustomerModel Model { get; set; }
        public UpdateCustomerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");

            // bool sameCustomerExists = _context.Customers.Where(x =>
            //     x.Email.ToLower() == (Model.Email == null ? customer.Email.ToLower() : Model.Email.ToLower())).Any();

            // if(sameCustomerExists)
            //     throw new InvalidOperationException("E-Mail adresi başka bir kullancı tarafından kullanılıyor");

            customer.Name = Model.Name != default ? Model.Name : customer.Name;
            customer.Surname = Model.Surname != default ? Model.Surname : customer.Surname;
            customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;

            // _mapper.Map<UpdateCustomerModel, Customer>(Model, customer);

            _context.SaveChanges();

        }
    }
    public class UpdateCustomerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}