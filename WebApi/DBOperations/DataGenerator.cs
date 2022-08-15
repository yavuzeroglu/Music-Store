using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MusicStoreDbContext>>()))
            {
                if (context.Albums.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre { Name = "Hip-Hop" },
                    new Genre { Name = "R&B" },
                    new Genre { Name = "Pop" }
                );

                context.Singers.AddRange(
                    new Singer { FullName = "Kendrick Lamar" },
                    new Singer { FullName = "Eminem" },
                    new Singer { FullName = "Jhene Aiko" },
                    new Singer { FullName = "Micheal Jackson" }
                );

                context.Producers.AddRange(
                    new Producer { FullName = "Dr. Dre" },
                    new Producer { FullName = "Quincy Jones" },
                    new Producer { FullName = "The Fisticuffs" },
                    new Producer { FullName = "James Blake" }
                );
                context.SaveChanges();

                context.Albums.AddRange(
                    new Album
                    {
                        Title = "Music To Be Murdered By",
                        // Singers = context.Singers.Where(x => x.Id == 2).ToList(),
                        GenreId = 1,
                        Price = 30,
                        Producers = context.Producers.Where(x => x.Id == 1 || x.Id == 4).ToList(),
                        PublishDate = new DateTime(2020, 01, 01)
                    },
                    new Album
                    {
                        Title = "DAMN",
                        GenreId = 1,
                        Producers = context.Producers.Where(x => x.Id == 4).ToList(),
                        Price = 25,
                        PublishDate = new DateTime(2017, 01, 01)
                    },
                    new Album
                    {
                        Title = "Thriller",
                        PublishDate = new DateTime(1982, 01, 01),
                        GenreId = 3,
                        Producers = context.Producers.Where(x => x.Id == 2).ToList(),
                        Price = 50

                    },
                    new Album
                    {
                        Title = "test",
                        GenreId = 2,
                        Producers = context.Producers.Where(x => x.Id == 3 || x.Id == 2).ToList(),
                        PublishDate = new DateTime(2000, 01, 01),
                        Price = 10.20
                    }

                );

                context.CustomerAlbums.AddRange(
                    new CustomerAlbum
                    {
                        CustomerId = 1,
                        AlbumId = 1,
                        OrderDate = DateTime.Now
                    },
                    new CustomerAlbum
                    {
                        CustomerId = 1,
                        AlbumId = 2,
                        OrderDate = DateTime.Now
                    },
                    new CustomerAlbum{
                        CustomerId = 2,
                        AlbumId = 3,
                        OrderDate = DateTime.Now
                    }
                );

                context.ProducerAlbums.AddRange(
                    new ProducerAlbum
                    {
                        AlbumId = 1,
                        ProducerId = 1
                    },
                    new ProducerAlbum
                    {
                        AlbumId = 2,
                        ProducerId = 4
                    }
                );

                context.SingerAlbums.AddRange(
                    new SingerAlbum
                    {
                        AlbumId = 1,
                        SingerId = 2
                    },
                    new SingerAlbum
                    {
                        AlbumId = 2,
                        SingerId = 1
                    },
                    new SingerAlbum
                    {
                        AlbumId = 3,
                        SingerId = 4
                    },
                    new SingerAlbum{
                        SingerId = 1, AlbumId =1
                    }
                );
                context.SaveChanges();

                context.Customers.AddRange(
                    new Customer{
                        Name = "customerName",
                        Surname = "customerSurname",
                        Email = "customer@mail.com",
                        Password ="12345"
                    },
                    new Customer{
                        Name = "customer1Name",
                        Surname = "customer1Surname",
                        Email = "customer1@mail.com",
                        Password = "12345"
                    }
                );

                context.SaveChanges();
            }
        }
    }

}