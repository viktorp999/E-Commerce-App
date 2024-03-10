using Microsoft.AspNetCore.Mvc;
using SkinetAPI.Errors;
using SkinetInfrastructure.Data;

namespace SkinetAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFoundError()
        {
            var thing = _context.Products.Find(100);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(100);

            var thingToDo = thing.ToString();

            return Ok(thingToDo);
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequestError()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("bad-request/{id}")]
        public ActionResult GetNotFoundErro(int id)
        {
            return Ok();
        }
    }
}
