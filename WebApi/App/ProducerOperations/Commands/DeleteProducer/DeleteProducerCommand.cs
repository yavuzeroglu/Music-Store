using System.Linq;
using WebApi.DBOperations;

namespace WebApi.App.ProducerOperations.Commands.DeleteProducer
{
    public class DeleteProducerCommand
    {
        private readonly IMusicStoreDbContext _context;
        public int Id { get; set; }
        public DeleteProducerCommand(IMusicStoreDbContext context)
        {
            _context = context;

        }

        public void Handle()
        {
            var producer = _context.Producers.SingleOrDefault(x => x.Id == Id);
            if (producer is null)
                throw new InvalidOperationException("Producer bulunamadı");

            // bool hasAlbumExists = _context.Albums.Any();
            // if (hasAlbumExists)
            //     throw new InvalidOperationException("Producer'ın albümleri bulunmaktadır. Önce albümlerini silmelisiniz");

            _context.Producers.Remove(producer);
            _context.SaveChanges();
        }
    }
}