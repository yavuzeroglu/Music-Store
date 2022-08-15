using WebApi.DBOperations;

namespace WebApi.App.AlbumOperations.Commands.UpdateAlbum{
    public class UpdateAlbumCommand
    {
        private readonly IMusicStoreDbContext _context;
        
        public int Id { get; set; }
        public UpdateAlbumModel Model { get; set; }
        public UpdateAlbumCommand(IMusicStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle(){
            var album = _context.Albums.SingleOrDefault(x => x.Id == Id);
            if(album is null)
                throw new InvalidOperationException("Album bulunamadı");
            
            bool sameNameExists = _context.Albums.Where(x => 
                x.Title.ToLower()== (Model.Title == null ? album.Title.ToLower() : Model.Title.ToLower())).Any();
            
            if(sameNameExists)
                throw new InvalidOperationException("Aynı isimli album mevcut");

            album.Title = Model.Title != default ? Model.Title : album.Title;
            album.Price = Model.Price != default ? Model.Price : album.Price;
            album.PublishDate = 
                Model.PublishDate != default ? Model.PublishDate : album.PublishDate;
            album.GenreId = Model.GenreId != default ? Model.GenreId : album.GenreId;

            _context.SaveChanges();


            
        }        
    }
    public class UpdateAlbumModel{
        public string Title { get; set; }
        public double Price { get; set; }
        public DateTime PublishDate { get; set; }
        public int GenreId { get; set; }
        
    }
}