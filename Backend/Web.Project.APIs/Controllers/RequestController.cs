using System.Security.Claims;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khadamati.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private IRequestmanager _manager;
        public RequestController(IRequestmanager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public ActionResult Add(RequestAddDTO request)
        {
            var newID = _manager.Add(request);
            return Ok("Request Created Successfully");
        }
        [HttpPut]
        public ActionResult Update(RequestUpdateDTO request)
        {
            var isFound = _manager.Update(request);
            if (!isFound) { return NotFound(); }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var isFound = _manager.Delete(id);
            if (!isFound) { return NotFound(); }
            return NoContent();
        }

        [HttpGet]
        [Route("Provider/{providerid}")]
        public ActionResult<List<RequestDetailsDTO>> GetbyProviderId(string providerid)
        {
            List<RequestDetailsDTO> request = _manager.GetbyProviderId(providerid);
            if (request == null) return NotFound();
            return request;


        }


        [HttpGet]
        [Route("User/{userid}")]
        public ActionResult<List<RequestDetailsDTO>> GetbyUserId(string userid)
        {
            List<RequestDetailsDTO> request = _manager.GetbyUserId(userid);
            if (request == null) return NotFound();
            return request;


        }

        [HttpGet]
        [Route("Id/{id}")]
        public ActionResult<List<RequestDetailsDTO>> GetbyIdDetails(int id)
        {
            List<RequestDetailsDTO> request = _manager.GetbyIdDetails(id);
            if (request == null) return NotFound();
            return request;

        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<RequestDetailsDTO>> GetAll()
        {
            List<RequestDetailsDTO> request = _manager.GetAll();
            if (request == null) return NotFound();
            return request;
        }
    }
}
