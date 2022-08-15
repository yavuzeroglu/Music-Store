using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.SingerAlbumOperations.Commands.CreateSingerAlbum;
using WebApi.App.SingerAlbumOperations.Commands.DeleteSingerAlbum;
using WebApi.App.SingerAlbumOperations.Commands.UpdateSingerAlbum;
using WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbum;
using WebApi.App.SingerAlbumOperations.Queries.GetSingerAlbumDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class SingerAlbumController : ControllerBase
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public SingerAlbumController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSingerAlbum(){
            var query = new GetSingerAlbumQuery(_context,_mapper);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetSingerAlbumById(int id){
            var query = new GetSingerAlbumDetailQuery(_context,_mapper);
            query.Id = id;

            var validator = new GetSingerAlbumDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSingerAlbum([FromBody] CreateSingerAlbumModel newSingerAlbum){
            var command = new CreateSingerAlbumCommand(_context,_mapper);
            command.Model = newSingerAlbum;

            var validator = new CreateSingerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSingerAlbum(int id, [FromBody] UpdateSingerAlbumModel updateSingerAlbum){
            var command = new UpdateSingerAlbumCommand(_context,_mapper);
            command.Id = id;
            command.Model = updateSingerAlbum;

            var validator = new UpdateSingerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSingerAlbum(int id){
            var command = new DeleteSingerAlbumCommand(_context);
            command.Id = id;

            var validator = new DeleteSingerAlbumCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}