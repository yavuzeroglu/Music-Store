using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.CustomerOperations.Queries.GetCustomerDetail{
    public class GetCustomerDetailQuery
    {
        private readonly IMusicStoreDbContext _context; 
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCustomerDetailQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCustomerDetailModel Handle(){
            var customer = _context.Customers
                .Where(x => x.IsActive == true)
                .Include(i => i.CustomerAlbums).ThenInclude(t => t.Album) // İki tablo arasında ilişkilendirme yapıldı
                .SingleOrDefault(x => x.Id == Id);
            if(customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı");

            var vm = _mapper.Map<GetCustomerDetailModel>(customer);

            return vm;
        }
    }
    public class GetCustomerDetailModel{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IReadOnlyCollection<string> PurschasedAlbums { get; set; }
    }
}