using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.CustomerAlbumOperations.Commands.UpdateCustomerAlbum{
    public class UpdateCustomerAlbumCommand
    {
        private readonly IMusicStoreDbContext _context; 
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateCustomerAlbumModel Model { get; set; }

        public UpdateCustomerAlbumCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var customerAlbum = _context.CustomerAlbums.SingleOrDefault(x => x.Id == Id);
            if(customerAlbum is null)
                throw new InvalidOperationException("Aradığınız kritere ait kayıt bulunamadı");

            bool hasAlbumExists = _context.CustomerAlbums.Where(x => 
                x.AlbumId == Model.AlbumId && x.CustomerId == Model.CustomerId).Any();
            
            if(hasAlbumExists)
                throw new InvalidOperationException("Müşteri, albüme zaten sahip");

            
            
            _mapper.Map<UpdateCustomerAlbumModel, CustomerAlbum>(Model, customerAlbum);

            _context.SaveChanges();



            
        }
    }
    public class UpdateCustomerAlbumModel{
        public int AlbumId { get; set; }
        public int CustomerId { get; set; }
    }
}