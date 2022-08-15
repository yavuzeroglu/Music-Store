using WebApi.DBOperations;

namespace WebApi.App.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommand
    {
        private readonly IMusicStoreDbContext _context;

        public int Id { get; set; }
        public DeleteGenreCommand(IMusicStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);
            if(genre is null)
                throw new InvalidOperationException("Tür bulunamadı");
            
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }


    }
}