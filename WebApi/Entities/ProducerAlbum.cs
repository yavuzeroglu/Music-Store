using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class ProducerAlbum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

    }
}