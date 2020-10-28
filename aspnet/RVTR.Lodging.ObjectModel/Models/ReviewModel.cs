using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Review_ model
  /// </summary>
  public class ReviewModel : IValidatableObject
  {
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; }

    public string Comment { get; set; }

    public DateTime DateCreated { get; set; }

    public int Rating { get; set; }

    public int? LodgingId { get; set; }

    public LodgingModel Lodging { get; set; }

    /// <summary>
    /// Represents the _Review_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}
