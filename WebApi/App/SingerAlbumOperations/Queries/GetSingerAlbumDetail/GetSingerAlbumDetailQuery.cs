using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbum;
using WebApi.DBOperations;

namespace WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbumDetail{
    public class GetSingerAlbumDetailQuery{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public GetSingerAlbumDetailQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetSingerAlbumDetailModel Handle(){
            var singerAlbum = _context.SingerAlbums
                .Include(i => i.Album)
                .Include(i => i.Singer)
                .SingleOrDefault(x => x.Id == Id);
            if(singerAlbum is null)
                throw new InvalidOperationException("Aradığınız kriterlere uygun kayıt bulunamadı");

            var model = _mapper.Map<GetSingerAlbumDetailModel>(singerAlbum);

            return model;
        }
        
    }
    public class GetSingerAlbumDetailModel{
        public string Album { get; set; }
        public string Singer { get; set; }
    }
}