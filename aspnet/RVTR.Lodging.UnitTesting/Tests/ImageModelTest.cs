using System;
using System.Collections.Generic;
using System.Text;
using RVTR.Lodging.ObjectModel.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
  public class ImageModelTest
  {
    public static readonly IEnumerable<object[]> Images = new List<object[]>
    {
      new object[]
      {
        new ImageModel
        {
          Id = 1,
          lodgingId = 1,
          imageUrl = "https://www.cbc.ca/parents/content/imgs/weird-kids-youtube.jpg",
        }
      }
    };

    /// <summary>
    ///Data validation on the creation of an imagemodel object
    /// </summary>
    /// <param name="image"></param>
    [Theory]
    [MemberData(nameof(Images))]
    public void Test_Create_ImageModel(ImageModel image)
    {
      var validationContext = new ValidationContext(image);
      var actual = Validator.TryValidateObject(image, validationContext, null, true);

      Assert.True(actual);
    }

    /// <summary>
    ///Validating the image model objects in the db context 
    /// </summary>
    /// <param name="images"></param>
    [Theory]
    [MemberData(nameof(Images))]
    public void Test_Validate_ImageModel(ImageModel image)
    {
      var validationContext = new ValidationContext(image);

      Assert.Empty(image.Validate(validationContext));
    }
  }
}
