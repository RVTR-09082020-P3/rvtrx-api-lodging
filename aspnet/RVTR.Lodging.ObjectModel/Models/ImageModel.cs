using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class ImageModel : IValidatableObject
  {
    /// <summary>
    /// The public key Id for each image url 
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The id of the lodging the image url belongs to 
    /// </summary>
    public int LodgingModelId { get; set; }

    /// <summary>
    /// The uri for the image itself
    /// </summary>
   [RegularExpression(@"^(http(s?):\/\/)[^\s]$", ErrorMessage = "Image URI must be a real image URI.")]
    public string ImageUri { get; set; }

    /// <summary>
    /// Represents the ImageModel's `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();

  }
}
