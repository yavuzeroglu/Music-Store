using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.ProducerOperations.Commands.CreateProducer{
    public class CreateProducerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateProducerModel Model { get; set; }

        public CreateProducerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var producer = _context.Producers.SingleOrDefault(x => x.FullName.ToLower() == Model.FullName.ToLower());

            if(producer is not null)
                throw new InvalidOperationException("Aynı producer zaten kayıtlı");

            producer = _mapper.Map<Producer>(Model);

            _context.Producers.Add(producer);
            _context.SaveChanges();
            
        }
    }
    

    public class CreateProducerModel{
        public string FullName { get; set; }
    }
}