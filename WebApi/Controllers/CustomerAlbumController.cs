using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.CustomerAlbumOperations.Commands.CreateCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Commands.DeleteCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Commands.UpdateCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbum;
using WebApi.App.CustomerAlbumOperations.Queries.GetCustomerAlbumDetail;

using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerAlbumController : ControllerBase
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerAlbumController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomerAlbum(){
            var query = new GetCustomerAlbumQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerAlbumById(int id){
            var query = new GetCustomerAlbumDetailQuery(_context,_mapper);
            query.Id = id;

            var validator = new GetCustomerAlbumDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomerAlbum([FromBody] CreateCustomerAlbumModel newCustomerAlbum){
            var command = new CreateCustomerAlbumCommand(_context,_mapper);
            command.Model = newCustomerAlbum;

            var validator = new CreateCustomerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomerAlbum([FromBody] UpdateCustomerAlbumModel updateCustomerAlbum, int id){
            var command = new UpdateCustomerAlbumCommand(_context, _mapper);
            command.Id = id;
            command.Model = updateCustomerAlbum;

            var validator = new UpdateCustomerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerAlbum(int id){
            var command = new DeleteCustomerAlbumCommand(_context);
            command.Id = id;

            var validator = new DeleteCustomerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}