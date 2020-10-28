using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.ObjectModel.Interfaces;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.WebApi.Controllers
{
  /// <summary>
  /// The LodgingController handles lodging resources
  /// </summary>
  [ApiController]
  [ApiVersion("0.0")]
  [EnableCors("public")]
  [Route("rest/lodging/{version:apiVersion}/[controller]")]
  public class LodgingController : ControllerBase
  {
    private readonly ILogger<LodgingController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the LodgingController sets up logger and unitOfWork dependencies
    /// </summary>
    /// <param name="logger">The Logger</param>
    /// <param name="unitOfWork">The UnitOfWork</param>
    public LodgingController(ILogger<LodgingController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Gets all the lodgings in the database
    /// </summary>
    /// <returns>The Lodgings</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LodgingModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await _unitOfWork.Lodging.SelectAsync());
    }

    /// <summary>
    /// Gets one Lodging based on its id
    /// </summary>
    /// <param name="id">The Lodging Id</param>
    /// <returns>The Lodgings if successful or NotFound if no lodging was found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LodgingModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
      var lodging = await _unitOfWork.Lodging.SelectAsync(id);
      if (lodging != null)
      {
        return Ok(lodging);
      }
      else
      {
        return NotFound(id);
      }
    }

    /// <summary>
    /// Gets all lodgings with available rentals by City, State/Province, Country and occupancy
    /// </summary>
    /// <param name="city">The city</param>
    /// <param name="state">The state/province</param>
    /// <param name="country">The country</param>
    /// <param name="occupancy">The occupancy</param>
    /// <returns>The filtered Lodgings</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LodgingModel>), StatusCodes.Status200OK)]
    [Route("available")]
    public async Task<IActionResult> GetLodgingsByLocationAndOccupancy(string city, string state, string country, int occupancy)
    {
      return Ok(await _unitOfWork.Lodging.LodgingByLocationAndOccupancy(occupancy, city, state, country));
    }
  }
}
