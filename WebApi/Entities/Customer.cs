using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities{
    public class Customer{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }

        public ICollection<CustomerAlbum> CustomerAlbums { get; set; }
        public bool IsActive { get; set; } = true;





    }
}