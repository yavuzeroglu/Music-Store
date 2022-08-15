using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.AlbumOperations.Commands.CreateAlbum;
using WebApi.App.AlbumOperations.Commands.DeleteAlbum;
using WebApi.App.AlbumOperations.Commands.UpdateAlbum;
using WebApi.App.AlbumOperations.Queries.GetAlbum;
using WebApi.App.AlbumOperations.Queries.GetAlbumDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class AlbumController : ControllerBase{
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public AlbumController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAlbum(){
            var query = new GetAlbumQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id){
            var query = new GetAlbumDetailQuery(_context,_mapper);
            query.Id = id;

            var validator = new GetAlbumDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAlbum([FromBody] CreateAlbumModel newAlbum){
            var command = new CreateAlbumCommand(_context,_mapper);
            command.Model = newAlbum;

            var validator = new CreateAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAlbum([FromBody] UpdateAlbumModel updateAlbum, int id){
            var command = new UpdateAlbumCommand(_context);
            command.Id = id;
            command.Model = updateAlbum;

            var validator = new UpdateAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum(int id){
            var command = new DeleteAlbumCommand(_context);
            command.Id = id;

            var validator = new DeleteAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}