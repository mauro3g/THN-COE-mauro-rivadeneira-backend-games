using Company.BL.Repositories;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {


        private readonly IGameRepository _gameService;

        public GameController(IGameRepository gameService)
        {
            _gameService = gameService;
        }

        // GET: api/<GameController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _gameService.GetVideogames();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var gameFound = await _gameService.GetVideogameById(id);
                if (gameFound == null) return NotFound();

                return Ok(gameFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GameController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game data)
        {
            try
            {
                var resultUser = await _gameService.PostVideogame(data);
                return Ok(resultUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Game data)
        {
            try
            {
                if (id != data.Id) return NotFound();
                await _gameService.UpdateVideogame(id, data);
                return Ok(new { message = "Data updated successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _gameService.DeleteVIdeogameById(id);
                if (result == "NOT_FOUND") return NotFound();
                return Ok(new { message = "Data deleted successfuly." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
