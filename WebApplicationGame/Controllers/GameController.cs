using Microsoft.AspNetCore.Mvc;
using WebApplicationGame.repository;
using Microsoft.EntityFrameworkCore;
namespace WebApplicationGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {

        private readonly Repository repository;

        public GameController(Repository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(repository.GameRepo.GetAllGame());
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repository.GameRepo.GetGame(id));
        }

        [HttpPost]
        public JsonResult Create([FromBody] Game game)
        {
            foreach (int i in game.Tag)
            {
                game.Tags.Add(repository.TagRepo.GetTag(i));
            }


            return new JsonResult(repository.GameRepo.Create(game));
        }

        
        [HttpPut]
        [Route("{id}")]
        public int Update(int id, [FromBody] Game game)
        {
            Game currentGame = repository.GameRepo.GetGame(id);
            List<Tag> currentTags = currentGame.Tags;
            List<Tag> updateTags = new List<Tag>();
            foreach (int i in game.Tag)
            {
                updateTags.Add(repository.TagRepo.GetTag(i));
            }
            currentGame.Tags.AddRange(updateTags.Except(currentTags));
            foreach (var t in currentTags.Except(updateTags).ToList())
            {
                currentGame.Tags.Remove(t);
            }
            //currentGame.GameDeveloper = repository.GameDeveloperRepo.GetGameDeveloper(1);
            currentGame.Name = game.Name;            
            return repository.GameRepo.Update(currentGame);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            repository.GameRepo.Delete(id);
        }

    }
}
