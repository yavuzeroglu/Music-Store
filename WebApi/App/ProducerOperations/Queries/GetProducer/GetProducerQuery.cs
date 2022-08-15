using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.App.ProducerOperations.Queries.GetProducer{
    public class GetProducerQuery
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProducerQuery(IMusicStoreDbContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public List<GetProducerModel> Handle(){
            var producerList = _context.Producers
                .Include(i => i.Albums)
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id);

            var vm = _mapper.Map<List<GetProducerModel>>(producerList);

            return vm;

        }
    }
    public class GetProducerModel{
        public int Id { get; set; }
        public string FullName { get; set; }
        public IReadOnlyCollection<string> Albums { get; set; }
    }
}