using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.CustomerOperations.Commands.CreateCustomer{
    public class CreateCustomerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerModel Model { get; set; }
        public CreateCustomerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var customer = _context.Customers.SingleOrDefault(x => 
                x.Email.ToLower() == Model.Email.ToLower());
            
            if(customer is not null)
                throw new InvalidOperationException("Bu E-Mail adresi bir başka kullanıcı tarafından kullanılıyor");

            customer = _mapper.Map<Customer>(Model);

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
    public class CreateCustomerModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}