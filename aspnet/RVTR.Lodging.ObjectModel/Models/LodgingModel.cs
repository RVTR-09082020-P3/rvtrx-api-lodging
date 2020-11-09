using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Lodging_ model
  /// </summary>
  public class LodgingModel : IValidatableObject
  {
    /// <summary>
    /// id of the lodging model in the db
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Location id of the lodging's location
    /// </summary>
    /// <value></value>
    public int LocationId { get; set; }

    /// <summary>
    /// Location property of the lodging model (required)
    /// </summary>
    /// <value></value>
    public LocationModel Location { get; set; }

    /// <summary>
    /// Name of the lodging (required)
    /// </summary>
    /// <value></value>
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Max length is 100 characters")]
    public string Name { get; set; }

    /// <summary>
    /// Number of bathrooms at the lodging
    /// </summary>
    /// <value></value>
    [Required(ErrorMessage = "Number of bathrooms is required")]
    [Range(1, 100, ErrorMessage = "Must have between 1 and 100 bathrooms")]
    public int Bathrooms { get; set; }

    /// <summary>
    /// List of the lodging's image uris
    /// </summary>
    public IEnumerable<ImageModel> Images { get; set; } = new List<ImageModel>();


    /// <summary>
    /// Rental list of the lodging
    /// </summary>
    /// <value></value>
    public IEnumerable<RentalModel> Rentals { get; set; } = new List<RentalModel>();

    /// <summary>
    /// Review list for the lodging
    /// </summary>
    /// <value></value>
    public IEnumerable<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

    /// <summary>
    /// Represents the _Lodging_ `Validate` model
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}
