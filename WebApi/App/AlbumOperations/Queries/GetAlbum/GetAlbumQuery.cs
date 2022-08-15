using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.AlbumOperations.Queries.GetAlbum{
    public class GetAlbumQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAlbumQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAlbumModel> Handle(){
            var albumList = _context.Albums
                .Include(i => i.Genre)
                .Include(i => i.Producers).ThenInclude(t => t.Albums)
                .Include(i => i.Singers).ThenInclude(t => t.Singer)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id);
            
            var model = _mapper.Map<List<GetAlbumModel>>(albumList);

            return model;
        }
    }
    public class GetAlbumModel{
        public int Id { get; set; }
        public string? Title { get; set; }
        public IReadOnlyCollection<string>? Singers { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }
        public string? Genre { get; set; }
        public IReadOnlyCollection<string>? Producers { get; set; }
        

    }
}