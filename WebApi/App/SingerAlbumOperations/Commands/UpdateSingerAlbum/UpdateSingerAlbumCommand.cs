using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.SingerAlbumOperations.Commands.UpdateSingerAlbum{
    public class UpdateSingerAlbumCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public UpdateSingerAlbumModel Model { get; set; }

        public UpdateSingerAlbumCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var singerAlbum = _context.SingerAlbums.SingleOrDefault(x => x.Id == Id);
            if(singerAlbum is null)
                throw new InvalidOperationException("Aradığınz kriterlere uygun kayıt bulunamamıştır.");

            _mapper.Map<UpdateSingerAlbumModel, SingerAlbum>(Model, singerAlbum);

            _context.SaveChanges();
        }
    }
    public class UpdateSingerAlbumModel{
        public int AlbumId { get; set; }
        public int SingerId { get; set; }
    }
}