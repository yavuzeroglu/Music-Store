using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbum{
    public class GetCustomerAlbumQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerAlbumQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCustomerAlbumModel> Handle(){
            var customerAlbumList = _context.CustomerAlbums
            .Include(i => i.Album)
            .Include(i => i.Customer)
            .OrderBy(x => x.Id);

            var model = _mapper.Map<List<GetCustomerAlbumModel>>(customerAlbumList);

            return model;
        }
    }
    public class GetCustomerAlbumModel{
        public string Customer { get; set; }
        public string Album { get; set; }
    }
}