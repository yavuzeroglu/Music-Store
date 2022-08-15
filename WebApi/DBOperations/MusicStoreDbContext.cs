using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations{
    public class MusicStoreDbContext : DbContext,  IMusicStoreDbContext
    {
        public MusicStoreDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAlbum> CustomerAlbums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<SingerAlbum> SingerAlbums { get; set; }
        public DbSet<ProducerAlbum> ProducerAlbums { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}