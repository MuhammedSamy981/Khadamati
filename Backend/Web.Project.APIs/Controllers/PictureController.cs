using System.Security.Claims;
using FinalProject.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Project.APIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController : ControllerBase
{
    private readonly IPictureManager _pictureManager;

    public PictureController(IPictureManager pictureManager )
    {
       _pictureManager=pictureManager;
    }

    [HttpPost]
    public ActionResult Add(AddPictureDTO picture)
    {
       _pictureManager.Add(picture);
       return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    public ActionResult Edit(UpdatePictureDTO picture)
    {
        _pictureManager.Update(picture);
        return NoContent();
    }

    
}
