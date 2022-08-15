using AutoMapper;
using WebApi.App.GenreOperations.Queries.GetGenre;
using WebApi.DBOperations;

namespace WebApi.App.GenreOperations.Queries.GetGenreDetail{
    public class GetGenreDetailQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetGenreDetailQuery(IMusicStoreDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public GetGenreModel Handle(){
            var genre = _context.Genres.FirstOrDefault(x => x.Id == Id);

            if(genre is null)
                throw new InvalidCastException("Tür bulunamadı");

            var model = _mapper.Map<GetGenreModel>(genre);

            return model;
        }
    }
}