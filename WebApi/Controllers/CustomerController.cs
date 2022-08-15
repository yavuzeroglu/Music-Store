using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.CustomerOperations.Commands.CreateCustomer;
using WebApi.App.CustomerOperations.Commands.DeleteCustomer;
using WebApi.App.CustomerOperations.Commands.UpdateCustomer;
using WebApi.App.CustomerOperations.Queries.GetCustomer;
using WebApi.App.CustomerOperations.Queries.GetCustomerDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            var query = new GetCustomerQuery(_context,_mapper);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id){
            var query = new GetCustomerDetailQuery(_context,_mapper);
            query.Id = id;

            var validator = new GetCustomerDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer){
            var command = new CreateCustomerCommand(_context,_mapper);
            command.Model = newCustomer;

            var validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id,[FromBody] UpdateCustomerModel updateCustomer){
            var command = new UpdateCustomerCommand(_context,_mapper);
            command.Id = id;
            command.Model = updateCustomer;

            var validator = new UpdateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id){
            var command = new DeleteCustomerCommand(_context);
            command.Id = id;

            command.Handle();
            return Ok();
        }
    }
}