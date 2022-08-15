using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerOperations.Commands.CreateSinger
{
    public class CreateSingerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateSingerModel Model { get; set; }
        public CreateSingerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var singer = _context.Singers.SingleOrDefault(x => x.FullName.ToLower() == Model.FullName.ToLower());
            if(singer is not null)
                throw new InvalidOperationException("Şarkıcı zaten kayıtlı");

            singer = _mapper.Map<Singer>(Model);
            
            _context.Singers.Add(singer);
            _context.SaveChanges();
        }

    }
    public class CreateSingerModel
    {
        public string FullName { get; set; }
    }
}