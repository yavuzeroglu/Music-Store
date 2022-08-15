using WebApi.DBOperations;

namespace WebApi.App.AlbumOperations.Commands.DeleteAlbum{
    public class DeleteAlbumCommand{
        private readonly IMusicStoreDbContext _context;
        
        public int Id { get; set; }

        public DeleteAlbumCommand(IMusicStoreDbContext context)
        {
            _context = context;
           
        }

        public void Handle(){
            var album = _context.Albums.SingleOrDefault(x => x.Id == Id);
            if(album is null)
                throw new InvalidOperationException("Album bulunamadı");

            album.IsActive = false;
            _context.SaveChanges();
        }
    }
}