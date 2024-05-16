using System.Security.Claims;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khadamati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingManager _ratingRepo;

        public RatingController(IRatingManager ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }
        
        [HttpGet]
        public ActionResult<RatingDto>  GetRatingByUserAndService(int sid,string uid)
        {
            return _ratingRepo. GetRatingByUserAndService(sid,uid);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRating(int id)
        {
            _ratingRepo.DeleteRating(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult AddRating(RatingAddDto rating)
        {
            _ratingRepo.AddRating(rating);
            return Ok();
        }        
    }
}
