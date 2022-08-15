using AutoMapper;
using WebApi.App.AlbumOperations.Commands.CreateAlbum;
using WebApi.App.AlbumOperations.Queries.GetAlbum;
using WebApi.App.CustomerAlbumOperations.Commands.CreateCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Commands.UpdateCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbumDetail;
using WebApi.App.CustomerOperations.Commands.CreateCustomer;
using WebApi.App.CustomerOperations.Commands.UpdateCustomer;
using WebApi.App.CustomerOperations.Queries.GetCustomer;
using WebApi.App.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.App.GenreOperations.Commands.CreateGenre;
using WebApi.App.GenreOperations.Queries.GetGenre;
using WebApi.App.ProducerOperations.Commands.CreateProducer;
using WebApi.App.ProducerOperations.Commands.UpdateProducer;
using WebApi.App.ProducerOperations.Queries.GetProducer;
using WebApi.App.ProducerOperations.Queries.GetProducerDetail;
using WebApi.App.SingerAlbumOperations.Commands.CreateSingerAlbum;
using WebApi.App.SingerAlbumOperations.Commands.UpdateSingerAlbum;
using WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbum;
using WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbumDetail;
using WebApi.App.SingerOperations.Commands.CreateSinger;
using WebApi.App.SingerOperations.Queries.GetSinger;
using WebApi.App.SingerOperations.Queries.GetSingerDetail;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Singer Maps ...
            CreateMap<Singer, GetSingerModel>()
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(src =>src.SingerAlbums.Select(x => x.Album.Title)));
            
            CreateMap<Singer, GetSingerDetailModel>();
            CreateMap<CreateSingerModel, Singer>();

            // Genre Maps ...
            CreateMap<Genre, GetGenreModel>();
            CreateMap<CreateGenreModel, Genre>();

            // Album Maps ...
            CreateMap<Album, GetAlbumModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(s => s.Genre.Name))
                .ForMember(dest => dest.Producers, opt => opt.MapFrom(s => s.Producers.Select(src => src.FullName)))
                .ForMember(dest => dest.Singers, opt => opt.MapFrom(s => s.Singers.Select(src => src.Singer.FullName)));

            CreateMap<CreateAlbumModel, Album>();

            // Producer Maps
            CreateMap<Producer, GetProducerModel>()
                .ForMember(dest=>dest.Albums, opt => opt.MapFrom(s => s.Albums.Select(src => src.Title)));

            CreateMap<Producer, GetProducerDetailModel>()
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(s => s.Albums.Select(src => src.Title)));

            CreateMap<CreateProducerModel, Producer>();

            CreateMap<UpdateProducerModel, Producer>()
                .ForMember(dest => dest.FullName, opt=> opt.Condition(src => src.FullName is not null));

            // Customer Maps ...
            CreateMap<Customer, GetCustomerModel>()
                .ForMember(dest => dest.PurschasedAlbums, opt => 
                opt.MapFrom(s => s.CustomerAlbums.Select(src => src.Album.Title)));
            CreateMap<Customer, GetCustomerDetailModel>();
            CreateMap<CreateCustomerModel, Customer>();
            // CreateMap<UpdateCustomerModel, Customer>();

            // CustomerAlbum Maps ...
            CreateMap<CustomerAlbum, GetCustomerAlbumModel>()
                .ForMember(dest => dest.Album, opt => opt.MapFrom(s => s.Album.Title))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(s => s.Customer.Name + " "+s.Customer.Surname));

            CreateMap<CustomerAlbum, GetCustomerAlbumDetailModel>()
                .ForMember(dest => dest.Album, opt => opt.MapFrom(s => s.Album.Title))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(s => s.Customer.Name + " "+s.Customer.Surname));

            CreateMap<CreateCustomerAlbumModel, CustomerAlbum>();
            CreateMap<UpdateCustomerAlbumModel, CustomerAlbum>();

            // SingerAlbum Maps ...
            CreateMap<SingerAlbum, GetSingerAlbumModel>()
                .ForMember(dest => dest.Album, opt => opt.MapFrom(s => s.Album.Title))
                .ForMember(dest => dest.Singer, opt => opt.MapFrom(s => s.Singer.FullName));

            CreateMap<SingerAlbum, GetSingerAlbumDetailModel>()
                .ForMember(dest => dest.Album, opt => opt.MapFrom(s => s.Album.Title))
                .ForMember(dest => dest.Singer, opt => opt.MapFrom(s => s.Singer.FullName));

            CreateMap<CreateSingerAlbumModel, SingerAlbum>();
            CreateMap<UpdateSingerAlbumModel, SingerAlbum>();


        }
    }
}