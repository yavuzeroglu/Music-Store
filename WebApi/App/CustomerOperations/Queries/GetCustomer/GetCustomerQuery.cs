using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.CustomerOperations.Queries.GetCustomer{
    public class GetCustomerQuery{
        private readonly IMusicStoreDbContext _context; 
        private readonly IMapper _mapper;

        public GetCustomerQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCustomerModel> Handle(){
            var customerList = _context.Customers
                .Where(x => x.IsActive == true)
                .Include(i => i.CustomerAlbums).ThenInclude(t => t.Album) // İki tablo arasında ilişkilendirme yapıldı
                .OrderBy(x => x.Id).ToList<Customer>();
            
            var model = _mapper.Map<List<GetCustomerModel>>(customerList);

            return model;


        }
    }
    public class GetCustomerModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IReadOnlyCollection<string> PurschasedAlbums { get; set; }

    }
}