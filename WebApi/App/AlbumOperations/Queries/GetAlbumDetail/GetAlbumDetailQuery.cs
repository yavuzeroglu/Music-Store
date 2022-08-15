using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.App.AlbumOperations.Queries.GetAlbum;
using WebApi.DBOperations;

namespace WebApi.App.AlbumOperations.Queries.GetAlbumDetail{
    public class GetAlbumDetailQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetAlbumDetailQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public GetAlbumModel Handle(){
            var album = _context.Albums
                .Include(i => i.Genre)
                .Include(i => i.Producers).ThenInclude(t => t.Albums)
                .Include(i => i.Singers).ThenInclude(t => t.Singer)
                .Where(x => x.IsActive == true)
                .SingleOrDefault(x => x.Id == Id);
            if(album is null)
                throw new InvalidOperationException("Albüm bulunamadı");

            var model = _mapper.Map<GetAlbumModel>(album);
            return model;
        }
    }
}