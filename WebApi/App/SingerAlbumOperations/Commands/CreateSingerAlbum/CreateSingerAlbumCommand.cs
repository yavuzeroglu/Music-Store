using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerAlbumOperations.Commands.CreateSingerAlbum{
    public class CreateSingerAlbumCommand{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateSingerAlbumModel Model { get; set; }
        public CreateSingerAlbumCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var singerAlbum = _context.SingerAlbums.SingleOrDefault(x => 
                x.AlbumId == Model.AlbumId && x.SingerId == Model.SingerId);
            if(singerAlbum is not null)
                throw new InvalidOperationException("Bu şarkı - albüm eşleştirmesi önceden yapılmış");

            singerAlbum = _mapper.Map<SingerAlbum>(Model);

            _context.SingerAlbums.Add(singerAlbum);
            _context.SaveChanges();
        }
    }
    public class CreateSingerAlbumModel{
        public int AlbumId { get; set; }
        public int SingerId { get; set; }
    }
}