using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbumDetail{
    public class GetCustomerAlbumDetailQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCustomerAlbumDetailQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCustomerAlbumDetailModel Handle(){
            var customerAlbum = _context.CustomerAlbums
                .Include(i => i.Album)
                .Include(i => i.Customer)
                .SingleOrDefault(x => x.Id == Id);
            if(customerAlbum is null)
                throw new InvalidOperationException("Kayda ait veri bulunamadı.");
            
            var model = _mapper.Map<GetCustomerAlbumDetailModel>(customerAlbum);

            return model;

        }
    }
    public class GetCustomerAlbumDetailModel{
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Album { get; set; }
    }
}