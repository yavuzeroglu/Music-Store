using WebApi.DBOperations;

namespace WebApi.App.SingerAlbumOperations.Commands.DeleteSingerAlbum{
    public class DeleteSingerAlbumCommand{
        private readonly IMusicStoreDbContext _context;
        public int Id { get; set; }
        public DeleteSingerAlbumCommand(IMusicStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var singerAlbum = _context.SingerAlbums.SingleOrDefault(x => x.Id == Id);
            if(singerAlbum is null)
                throw new InvalidOperationException("Aradığınz kriterlere uygun kayıt bulunamamıştır.");
            
            _context.SingerAlbums.Remove(singerAlbum);
            _context.SaveChanges();
        }
    }
    public class DeleteSingerAlbumModel{
        public int AlbumId { get; set; }
        public int SingerId { get; set; }
    }
}