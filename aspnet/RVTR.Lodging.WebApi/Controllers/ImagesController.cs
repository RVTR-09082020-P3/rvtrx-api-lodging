using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.ObjectModel.Interfaces;

namespace RVTR.Lodging.WebApi.Controllers
{
  /// <summary>
  /// The ImagesController handles lodging resources
  /// </summary>
  [ApiController]
  [ApiVersion("0.0")]
  [EnableCors("public")]
  [Route("rest/lodging/{version:apiVersion}/[controller]")]
  public class ImagesController : ControllerBase
  {
    private readonly ILogger<ImagesController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the ImagesController sets up logger and unitOfWork dependencies
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public ImagesController(ILogger<ImagesController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get an image by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      _logger.LogDebug("Getting an image by its ID number...");
      return Ok(await Task.FromResult<string[]>(new string[] { "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960", "http://placecorgi.com/1280/960" }));
    }
  }
}
