using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.ProducerOperations.Queries.GetProducerDetail{
    public class GetProducerDetailQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetProducerDetailQuery(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetProducerDetailModel Handle(){
            var producer = _context.Producers
            .Include(i => i.Albums)
            .Where(x => x.IsActive == true)
            .FirstOrDefault(x => x.Id == Id);
            if(producer is null)
                throw new InvalidOperationException("Producer bulunamadı");

            var vm = _mapper.Map<GetProducerDetailModel>(producer);

            return vm;
        }
    }
    public class GetProducerDetailModel{
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Albums { get; set; }
    }
}