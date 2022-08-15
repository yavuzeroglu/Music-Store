using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.ProducerOperations.Commands.CreateProducer;
using WebApi.App.ProducerOperations.Commands.DeleteProducer;
using WebApi.App.ProducerOperations.Commands.UpdateProducer;
using WebApi.App.ProducerOperations.Queries.GetProducer;
using WebApi.App.ProducerOperations.Queries.GetProducerDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class ProducerController : ControllerBase{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public ProducerController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducer(){
            var query = new GetProducerQuery(_context,_mapper);
            var response = query.Handle();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetProducerById(int id){
            var query = new GetProducerDetailQuery(_context,_mapper);
            query.Id = id;

            var validator = new GetProducerDetailQueryValidator();
            validator.ValidateAndThrow(query); 
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateProducer([FromBody] CreateProducerModel newProducer){
            var command = new CreateProducerCommand(_context,_mapper);
            command.Model = newProducer;

            var validator = new CreateProducerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProducer(int id,[FromBody] UpdateProducerModel updateProducer){
            var command = new UpdateProducerCommand(_context,_mapper);
            command.Id = id;
            command.Model = updateProducer;

            var validator = new UpdateProducerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProducer(int id){
            var command = new DeleteProducerCommand(_context);
            command.Id = id;

            var validator = new DeleteProducerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        
    }
}