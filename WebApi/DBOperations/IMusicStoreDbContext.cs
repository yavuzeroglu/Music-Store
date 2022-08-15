using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IMusicStoreDbContext
    {
        DbSet<Album> Albums { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAlbum> CustomerAlbums { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Producer> Producers { get; set; }
        DbSet<Singer> Singers { get; set; }
        DbSet<SingerAlbum> SingerAlbums { get; set; }
        DbSet<ProducerAlbum> ProducerAlbums { get; set; }

        int SaveChanges();
    }
}