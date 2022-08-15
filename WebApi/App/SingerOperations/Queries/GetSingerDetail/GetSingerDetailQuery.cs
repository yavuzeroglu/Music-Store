using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerOperations.Queries.GetSingerDetail{
    public class GetSingerDetailQuery
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int singerId { get; set; }

        public GetSingerDetailQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetSingerDetailModel Handle(){
            var singer = _dbContext.Singers
                .Include(i => i.SingerAlbums)
                .ThenInclude(t => t.Album)
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == singerId);
            if(singer is null)
                throw new InvalidOperationException("Şarkıcı bulunamadı");

            var model = _mapper.Map<GetSingerDetailModel>(singer);

            return model;
        }
    }
    public class GetSingerDetailModel{
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Albums { get; set; }
    }
}