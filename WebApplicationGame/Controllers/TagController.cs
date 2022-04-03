using Microsoft.AspNetCore.Mvc;
using WebApplicationGame.repository;

namespace WebApplicationGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly Repository repository;

        public TagController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(repository.TagRepo.GetAllTags());
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repository.TagRepo.GetTag(id));
        }

        [HttpGet]
        [Route("games/{id}")]
        public JsonResult GetAllGamesByTag(int id)
        {
            return new JsonResult(repository.TagRepo.GetAllGamesByTag(id));
        }

        [HttpPost]
        public JsonResult Create([FromBody] Tag tag)
        {
            return new JsonResult(repository.TagRepo.Create(tag));
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            repository.TagRepo.Delete(id);
        }
    }
}
