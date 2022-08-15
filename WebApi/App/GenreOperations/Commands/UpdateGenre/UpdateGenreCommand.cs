using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.App.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateGenreModel Model { get; set; }
        public UpdateGenreCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);
            if(genre is null)
                throw new InvalidOperationException("Tür bulunamadı");

            bool sameNameExists = _context.Genres.Where( x =>
                x.Name.ToLower() == (Model.Name == null ? genre.Name.ToLower() : Model.Name.ToLower() )).Any();

            if(sameNameExists)
                throw new InvalidOperationException("Aynı isimli tür mevcut");

            genre.Name = Model.Name != default ? Model.Name : genre.Name;

            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel{
        public string Name { get; set; }
    }
}