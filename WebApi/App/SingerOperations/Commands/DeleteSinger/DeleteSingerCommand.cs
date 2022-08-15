using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.App.SingerOperations.Commands.DeleteSinger{
    public class DeleteSingerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int singerId { get; set; }

        public DeleteSingerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var singer = _context.Singers.SingleOrDefault(x => x.Id == singerId);
            if(singer is null)
                throw new InvalidOperationException("Şarkıcı bulunamadı");

            singer.IsActive = false;
            _context.SaveChanges();

        }
    }
}