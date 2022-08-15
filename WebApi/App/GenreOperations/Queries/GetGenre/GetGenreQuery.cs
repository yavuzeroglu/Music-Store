using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.App.GenreOperations.Queries.GetGenre{
    public class GetGenreQuery{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenreModel> Handle(){
            var genre = _context.Genres.OrderBy(x => x.Id);

            var model = _mapper.Map<List<GetGenreModel>>(genre);

            return model;
        }
    }
    public class GetGenreModel{
        public string Name { get; set; }
    }
}