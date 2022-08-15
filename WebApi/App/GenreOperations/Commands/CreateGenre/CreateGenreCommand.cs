using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommand{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model { get; set; }

        public CreateGenreCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());
            if(genre is not null)
                throw new InvalidOperationException("Tür zaten kayıtlı");

            var newGenre = _mapper.Map<Genre>(Model);

            _context.Genres.Add(newGenre);
            _context.SaveChanges();
        }
    }
    public class CreateGenreModel{
        public string Name { get; set; }
    }
}