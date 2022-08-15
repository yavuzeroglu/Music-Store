using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerOperations.Commands.UpdateSinger
{
    public class UpdateSingerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int singerId { get; set; }
        public UpdateSingerModel Model { get; set; }
        public UpdateSingerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var singer = _context.Singers.SingleOrDefault(x => x.Id == singerId);
            if(singer is null)
                throw new InvalidOperationException("Şarkıcı bulunamadı");

            bool sameNameExists = _context.Singers.Where( x => 
                x.FullName.ToLower() == (Model.FullName == null ? singer.FullName.ToLower() : Model.FullName.ToLower())).Any();
            
            if(sameNameExists)
                throw new InvalidOperationException("Aynı isimli şarkıcı mevcut");

            singer.FullName = Model.FullName != default ? Model.FullName : singer.FullName;

            _context.SaveChanges();
        }
    }
    public class UpdateSingerModel{
        public string FullName { get; set; }
    }
}