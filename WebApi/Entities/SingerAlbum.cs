using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities{
    public class SingerAlbum
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public int SingerId { get; set; }
        public virtual Singer Singer { get; set; }
    }
}