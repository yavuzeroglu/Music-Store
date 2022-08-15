using WebApi.DBOperations;

namespace WebApi.App.CustomerOperations.Commands.DeleteCustomer{
    public class DeleteCustomerCommand{
        private readonly IMusicStoreDbContext _context;
        public int Id { get; set; }

        public DeleteCustomerCommand(IMusicStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");
            
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}