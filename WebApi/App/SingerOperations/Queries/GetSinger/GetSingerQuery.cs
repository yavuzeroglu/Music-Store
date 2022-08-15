using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerOperations.Queries.GetSinger{
    public class GetSingerQuery
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSingerQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetSingerModel> Handle(){
            var singerList = _dbContext.Singers
            .Include(i => i.SingerAlbums)
            .ThenInclude(t => t.Album)
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Id).ToList();

            var model = _mapper.Map<List<GetSingerModel>>(singerList);

            return model;
        }
    }
    public class GetSingerModel{
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Albums { get; set; }
    }
}