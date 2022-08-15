using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.App.GenreOperations.Commands.CreateGenre;
using WebApi.App.GenreOperations.Commands.DeleteGenre;
using WebApi.App.GenreOperations.Commands.UpdateGenre;
using WebApi.App.GenreOperations.Queries.GetGenre;
using WebApi.App.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMusicStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMusicStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenre(){
            var query = new GetGenreQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id){
            var query = new GetGenreDetailQuery(_context,_mapper);
            query.Id = id;
            
            var validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel newGenre){
            var command = new CreateGenreCommand(_context,_mapper);
            command.Model = newGenre;

            var validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody] UpdateGenreModel updateGenre, int id){
            var command = new UpdateGenreCommand(_context,_mapper);
            command.Id = id;
            command.Model = updateGenre;

            var validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id){
            var command = new DeleteGenreCommand(_context);
            command.Id = id;

            var validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            

            command.Handle();
            return Ok();
        }
    }
}