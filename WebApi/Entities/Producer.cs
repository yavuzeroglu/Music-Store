using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities{
    public class Producer{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Album> Albums { get; set; }
        public bool IsActive { get; set; } = true;
    }
}