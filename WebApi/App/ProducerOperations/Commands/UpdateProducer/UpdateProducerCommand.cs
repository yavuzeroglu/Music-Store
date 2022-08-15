using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.App.ProducerOperations.Commands.UpdateProducer{
    public class UpdateProducerCommand
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateProducerModel Model { get; set; }
        public UpdateProducerCommand(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var producer = _context.Producers.FirstOrDefault(x => x.Id == Id);

            if(producer is null)
                throw new InvalidOperationException("Producer bulunamadı");

            bool sameNameExists = _context.Producers.Where(x => 
                x.FullName.ToLower() == (Model.FullName == null ? producer.FullName.ToLower() : Model.FullName.ToLower() )).Any();

            if(sameNameExists)
                throw new InvalidOperationException("Aynı isimli producer zaten kayıtlı");

            _mapper.Map<UpdateProducerModel, Producer>(Model, producer);

            _context.SaveChanges();
        }
    }

    public class UpdateProducerModel{
        public string FullName { get; set; }
    }
}