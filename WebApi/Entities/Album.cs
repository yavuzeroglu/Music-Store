using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public double Price { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<Producer> Producers {get; set;}

        public ICollection<SingerAlbum> Singers { get; set; }
        public List<CustomerAlbum> CustomerAlbums { get; set; }
        public bool IsActive { get; set; } = true;

    }
}