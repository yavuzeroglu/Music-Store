using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.CustomerAlbumOperations.Commands.CreateCustomerAlbum
{
    public class CreateCustomerAlbumCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerAlbumModel Model { get; set; }

        public CreateCustomerAlbumCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var customerAlbum = _context.CustomerAlbums.FirstOrDefault(x =>
                x.CustomerId == Model.CustomerId && x.AlbumId == Model.AlbumId);
            
            if(customerAlbum is not null)
                throw new InvalidOperationException("Müşteri, albüme zaten sahip");
            
            customerAlbum = _mapper.Map<CustomerAlbum>(Model);

            _context.CustomerAlbums.Add(customerAlbum);
            _context.SaveChanges();
        }
    }
    public class CreateCustomerAlbumModel{
        public int CustomerId { get; set; }
        public int AlbumId { get; set; }
    }
}