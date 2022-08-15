using WebApi.DBOperations;

namespace WebApi.App.CustomerAlbumOperations.Commands.DeleteCustomerAlbum{
    public class DeleteCustomerAlbumCommand
    {
        private readonly IMusicStoreDbContext _context;
        public int Id { get; set; }
        public DeleteCustomerAlbumCommand(IMusicStoreDbContext context){
            _context = context;
        }

        public void Handle(){
            var customerAlbum = _context.CustomerAlbums.SingleOrDefault(x => x.Id == Id);
            if(customerAlbum is null)
                throw new InvalidOperationException("Aradığınız kritere uygun veri bulunamadı");

            _context.CustomerAlbums.Remove(customerAlbum);
            _context.SaveChanges();

        }
    }
}