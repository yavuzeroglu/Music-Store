using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.SingerOperations.Commands.CreateSinger;
using WebApi.App.SingerOperations.Commands.DeleteSinger;
using WebApi.App.SingerOperations.Commands.UpdateSinger;
using WebApi.App.SingerOperations.Queries.GetSinger;
using WebApi.App.SingerOperations.Queries.GetSingerDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class SingerController : ControllerBase{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;


        public SingerController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSinger(){
            var query = new GetSingerQuery(_context,_mapper);


            var response = query.Handle();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingerById(int id){
            var query = new GetSingerDetailQuery(_context,_mapper);
            query.singerId = id;

            var validator = new GetSingerDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateSinger(CreateSingerModel newSinger){
            var command = new CreateSingerCommand(_context,_mapper);
            command.Model = newSinger;

            var validator = new CreateSingerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSinger(int id,UpdateSingerModel updateSinger){
            var command = new UpdateSingerCommand(_context,_mapper);
            command.singerId = id;
            command.Model = updateSinger;

            var validator = new UpdateSingerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSinger(int id){
            var command = new DeleteSingerCommand(_context,_mapper);
            command.singerId = id;

            var validator = new DeleteSingerCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();
        }
    }
}