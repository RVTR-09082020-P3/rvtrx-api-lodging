using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.ObjectModel.Interfaces;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.WebApi.Controllers
{
  /// <summary>
  /// The RentalController handles rental resources
  /// </summary>
  [ApiController]
  [ApiVersion("0.0")]
  [EnableCors("public")]
  [Route("rest/lodging/{version:apiVersion}/[controller]")]
  public class RentalController : ControllerBase
  {
    private readonly ILogger<RentalController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the RentalController sets up logger and unitOfWork dependencies
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public RentalController(ILogger<RentalController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Deletes a rental based on ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        _logger.LogDebug("Deleting a rental by its ID number...");
        await _unitOfWork.Rental.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        _logger.LogInformation($"Deleted rental with ID number {id}.");
        return Ok();
      }
      catch
      {
        _logger.LogWarning($"Rental with ID number {id} does not exist.");
        return NotFound(id);
      }
    }

    /// <summary>
    /// Get all rentals
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      _logger.LogInformation($"Retrieved the rentals.");
      return Ok(await _unitOfWork.Rental.SelectAsync());
    }

    /// <summary>
    /// Get a rental based on ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      _logger.LogDebug("Getting a rental by its ID number...");
      try
      {
        return Ok(await _unitOfWork.Rental.SelectAsync(id));
      }
      catch
      {
        _logger.LogWarning($"Rental with ID number {id} does not exist.");
        return NotFound(id);
      }
    }

    /// <summary>
    /// Add a rental
    /// </summary>
    /// <param name="rental"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(RentalModel rental)
    {
      _logger.LogDebug("Adding a rental...");
      await _unitOfWork.Rental.InsertAsync(rental);
      await _unitOfWork.CommitAsync();
      _logger.LogInformation($"Successfully added the rental {rental}.");
      return Accepted(rental);
    }

    /// <summary>
    /// Update a rental
    /// </summary>
    /// <param name="rental"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put(RentalModel rental)
    {
      _logger.LogDebug("Updating a rental...");
      _unitOfWork.Rental.Update(rental);
      await _unitOfWork.CommitAsync();
      _logger.LogInformation($"Successfully updated the rental {rental}.");
      return Accepted(rental);
    }
  }
}
