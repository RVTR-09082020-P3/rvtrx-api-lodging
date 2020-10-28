using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTR.Lodging.ObjectModel.Interfaces;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.WebApi.Controllers
{
  /// <summary>
  /// The ReviewController handles reviews
  /// </summary>
  [ApiController]
  [ApiVersion("0.0")]
  [EnableCors("public")]
  [Route("rest/lodging/{version:apiVersion}/[controller]")]
  public class ReviewController : ControllerBase
  {
    private readonly ILogger<ReviewController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Constructor for the ReviewController sets up logger and unitOfWork dependencies
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="unitOfWork"></param>
    public ReviewController(ILogger<ReviewController> logger, IUnitOfWork unitOfWork)
    {
      _logger = logger;
      _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Delete a review based on ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      _logger.LogDebug("Deleting an review by its ID...");
      try
      {
        await _unitOfWork.Review.DeleteAsync(id);
        await _unitOfWork.CommitAsync();

        return Ok();
      }
      catch
      {
        _logger.LogWarning($"Review with ID {id} does not exist.");
        return NotFound(id);
      }
    }

    /// <summary>
    /// Get all reviews available
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      _logger.LogInformation($"Retrieved the reviews.");
      return Ok(await _unitOfWork.Review.SelectAsync());
    }

    /// <summary>
    /// Get a review based on ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      _logger.LogDebug("Getting a review by its ID...");
      try
      {
        return Ok(await _unitOfWork.Review.SelectAsync(id));
      }
      catch
      {
        _logger.LogWarning($"Review with ID {id} does not exist.");
        return NotFound(id);
      }
    }

    /// <summary>
    /// Add a review
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(ReviewModel review)
    {
      _logger.LogDebug("Adding a review...");
      await _unitOfWork.Review.InsertAsync(review);
      await _unitOfWork.CommitAsync();
      _logger.LogInformation($"Successfully added the review {review}.");
      return Accepted(review);
    }

    /// <summary>
    /// Update an existing review
    /// </summary>
    /// <param name="review"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put(ReviewModel review)
    {
      _logger.LogDebug("Updating a review...");
      _unitOfWork.Review.Update(review);
      await _unitOfWork.CommitAsync();
      _logger.LogInformation($"Successfully updated the review {review}.");
      return Accepted(review);
    }
  }
}
