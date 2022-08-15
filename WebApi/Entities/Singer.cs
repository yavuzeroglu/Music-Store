using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities{
    public class Singer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<SingerAlbum> SingerAlbums { get; set; }
        
        public bool IsActive { get; set; } = true;
        
    }
}