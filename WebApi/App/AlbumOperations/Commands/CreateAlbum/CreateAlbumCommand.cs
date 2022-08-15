using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.AlbumOperations.Commands.CreateAlbum{
    public class CreateAlbumCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAlbumModel Model { get; set; }

        public CreateAlbumCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var album = _context.Albums.SingleOrDefault(x => x.Title.ToLower() == Model.Title.ToLower());
            if(album is not null)
                throw new InvalidOperationException("Album zaten kayıtlı");
            
            album = _mapper.Map<Album>(Model);

            _context.Albums.Add(album);
            _context.SaveChanges();
        }
    }
    public class CreateAlbumModel{
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public int GenreId { get; set; }
        
    }

    
}