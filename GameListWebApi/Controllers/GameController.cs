using GameListWebApi.Data;
using GameListWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private ApplicationDbContext _db;
        public GameController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet(Name = "Game")]
        public IEnumerable<Game> GetGames()
        {
            IEnumerable<Game> listOfGame = from game in _db.games
                                           select game;
            return listOfGame.ToArray();
        }
        [HttpGet("{id}")]
        public IEnumerable<Game> GetGame(int id)
        {
            IEnumerable<Game> listOfGame = from game in _db.games
                                           where id == game.Id
                                           select game;
            return listOfGame.ToArray();
        }
        [HttpPost("")]
        public IActionResult PostGame(Game games)
        {
            if (!ModelState.IsValid)
            {
                return Content("The game could not be add to the database");
            }
            else
            { 
                _db.games.Add(games);
                _db.SaveChanges();
                return Content("It has been add to database");
            }
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateGame(int id,string? title,string? description)
        {
            
            Game? gameById = _db.games.Find(id);
            if(gameById == null)
            {
                return Content("Their no game with that id");
            }
            string gameTitle = gameById.Title;
            string gameDescription = gameById.Description;

            if(string.IsNullOrEmpty(title)||string.IsNullOrEmpty(description))
            {
                gameById.Title = gameTitle;
                gameById.Description = gameDescription;
            }
            else
            {
                gameById.Title = title;
                gameById.Description = description;
            }
            _db.games.Update(gameById);
            _db.SaveChanges();
            return Content("the game has been updated");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveGame(int id)
        {
            Game? gameById = _db.games.Find(id);
            if (gameById == null)
            {
                return Content("There nothing to delete to the database");
            }
            _db.games.Remove(gameById);
            _db.SaveChanges();
            return Content("It has been remove from database");
        }
    }
}
