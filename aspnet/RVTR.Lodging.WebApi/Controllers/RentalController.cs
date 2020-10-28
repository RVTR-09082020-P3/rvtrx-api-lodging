using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(RentalModel rental)
    {
      _logger.LogDebug("Adding a rental...");
      //Checks to see if rental obj is valid. Returns a bad request if invalid, otherwise inserts it into the db.
      var validationResults = rental.Validate(new ValidationContext(rental));
      if (validationResults != null || validationResults.Count() > 0) //If rental obj is invalid...
      {
        _logger.LogInformation($"Invalid rental '{rental}'.");
        return BadRequest(rental);                                    //Return bad request
      }
      else
      {
        _logger.LogInformation($"Successfully added the rental {rental}.");
        await _unitOfWork.Rental.InsertAsync(rental);
        await _unitOfWork.CommitAsync();

        return Accepted(rental);
      }
    }

    /// <summary>
    /// Update a rental
    /// </summary>
    /// <param name="rental"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(RentalModel rental)
    {
      _logger.LogDebug("Updating a rental...");
      //Checks to see if rental obj is valid. Returns a bad request if invalid, otherwise updates the db entry.
      var validationResults = rental.Validate(new ValidationContext(rental));
      if (validationResults != null || validationResults.Count() > 0)
      {
        _logger.LogInformation($"Failed to update rental due to validation.");
        return BadRequest(rental);           //Returns bad request if invalid input given
      }
      else
      {
        try
        {
          _unitOfWork.Rental.Update(rental); //Updates the entry
          await _unitOfWork.CommitAsync();   //Saves changes to the context
          _logger.LogInformation($"Successfully updated the rental {rental}.");
          return Accepted(rental);           //Returns 202 ok code
        }
        catch
        {
          _logger.LogInformation($"Failed to update rental - invalid rental given.");
          return NotFound(rental);          //Returns 404 if entry not found in db
        }
      }
    }
  }
}
