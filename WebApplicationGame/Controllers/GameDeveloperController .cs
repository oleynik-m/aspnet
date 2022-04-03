using Microsoft.AspNetCore.Mvc;
using WebApplicationGame.repository;

namespace WebApplicationGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameDeveloperController : Controller
    {

        private readonly Repository repository;

        public GameDeveloperController(Repository repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(repository.GameDeveloperRepo.GetAllDevelopers());
        }
        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repository.GameDeveloperRepo.GetGameDeveloper(id));
        }

        [HttpPost]
        public JsonResult Create([FromBody] GameDeveloper gameDeveloper)
        {
            return new JsonResult(repository.GameDeveloperRepo.Create(gameDeveloper));
        }

        
        [HttpPut]
        [Route("{id}")]
        public int Update(int id, [FromBody] GameDeveloper gameDeveloper)
        {
            GameDeveloper currentGameDeveloper = repository.GameDeveloperRepo.GetGameDeveloper(id);
            currentGameDeveloper.Name = gameDeveloper.Name;
            return repository.GameDeveloperRepo.Update(currentGameDeveloper);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            repository.GameDeveloperRepo.Delete(id);
        }

    }
}
