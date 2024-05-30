using System.Security.Claims;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Project.APIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ServiceController(IServiceManager serviceManager)
    {
       _serviceManager=serviceManager;
    }
    
    [HttpGet]
    public ActionResult<List<GetAllServicesDTO>> GetAll()
    {
       return _serviceManager.GetAll();
    }
    [HttpGet]
    [Route("Details")]
    public ActionResult<List<GetAllServicesDetailsDTO>> GetAllDetails()
    {
      return _serviceManager.GetAllDetails();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<GetServiceByIdDTO> GetById(int id)
    {
       var service= _serviceManager.GetById(id);
       if(service==null)
       {
        return NotFound();
       }
         return service;
    }

   [HttpPost]
    [Route("Approve/{id}")]
    public ActionResult Add(int id)
    {
        _serviceManager.approve(id);
        return StatusCode(StatusCodes.Status202Accepted);
    }
    
    [HttpPost]
    public ActionResult Add(AddServiceDTO service)
    {
       _serviceManager.Add(service);
       return StatusCode(StatusCodes.Status201Created);
    }
    [HttpPut]
    public ActionResult Edit(UpdateServiceDTO service)
    {
        bool result=_serviceManager.Update(service);
        if(!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
       var service =_serviceManager.GetById(id);
       if(service==null)
       {
         return NotFound();
       }
       _serviceManager.DeleteById(id);
       return NoContent();
    }

    [HttpGet]
    [Route("Details/{id}")]
    public ActionResult<GetServiceDetailsByIdDTO> GetDetailsById(int id)
    {
       var service=_serviceManager.GetDetailsById(id);
       if(service==null)
       {
        return NotFound();
       }
        return service;
    }

    
    [HttpGet]
    [Route("SpecificDetails")]
    public ActionResult<List<GetSpecificServicesDetailsDTO>> GetSpecificDetails(string loction , string category)
    {
       var service=_serviceManager.GetSpecificDetails(loction,category);
       if(service==null)
       {
        return NotFound();
       }
        return service;
    }
    
}
