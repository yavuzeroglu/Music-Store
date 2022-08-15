using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbum{
    public class GetSingerAlbumQuery{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetSingerAlbumQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetSingerAlbumModel> Handle(){
            var singerAlbumList = _context.SingerAlbums
                .Include(i => i.Album)
                .Include(i =>i.Singer)
                .OrderBy(x => x.Id);

            var model = _mapper.Map<List<GetSingerAlbumModel>>(singerAlbumList);

            return model;

        }
    }
    public class GetSingerAlbumModel{
        public string Album { get; set; }
        public string Singer { get; set; }
    }
}