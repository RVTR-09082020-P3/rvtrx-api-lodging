using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext
{
  /// <summary>
  /// Represents the _Lodging_ context
  /// </summary>
  public class LodgingContext : DbContext
  {
    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public DbSet<LodgingModel> Lodgings { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public DbSet<RentalModel> Rentals { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public DbSet<RentalUnitModel> RentalUnits { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public DbSet<ReviewModel> Reviews { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public LodgingContext(DbContextOptions<LodgingContext> options) : base(options) { }

    /// <summary>
    ///
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AddressModel>().HasKey(e => e.Id);
      modelBuilder.Entity<LocationModel>().HasKey(e => e.Id);
      modelBuilder.Entity<LodgingModel>().HasKey(e => e.Id);
      modelBuilder.Entity<RentalModel>().HasKey(e => e.Id);
      modelBuilder.Entity<ReviewModel>().HasKey(e => e.Id);

      modelBuilder.Entity<LodgingModel>().HasData(new List<LodgingModel>()
      {
        new LodgingModel() { Id = 1, LocationId = 1, Name = "Dragon Fly", Bathrooms = 2,
          Images = new List<ImageModel>(){
            new ImageModel() { ImageUri = "https://images.pexels.com/photos/417074/pexels-photo-417074.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"},
            new ImageModel() { ImageUri = "https://3.bp.blogspot.com/-ha7tdQrX-NU/WW8YoM1EqwI/AAAAAAAAGXo/-8t35xR6DmsvhSQmuufNy020Jarn9FZYQCHMYBhgL/s1600/pc-nature-wallpapers-cnsoup-collections.jpg"},
            new ImageModel() { ImageUri = "https://swall.teahub.io/photos/small/323-3236437_nature-wallpaper-pc-4k.jpg"},
            new ImageModel() { ImageUri = "https://w.wallhaven.cc/full/md/wallhaven-md5do1.jpg"},
            new ImageModel() { ImageUri = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRQPXqYYN-xTlO2yPaNK8b1GW3m4kQlbKkRhA&usqp=CAU"},
            new ImageModel() { ImageUri = "https://t4.ftcdn.net/jpg/02/91/24/27/360_F_291242770_z3XC7rJB1Mvc5jVMsEY9Dx2xMrX4sxUi.jpg"},
            new ImageModel() { ImageUri = "https://croatia.hr/sites/default/files/styles/image_full_width/public/2020-01/Plitvice-Lakes-National-Park_shutterstock_454592293_1600x900.jpg?itok=xwQuMGjg"},
          }
        },

        new LodgingModel() { Id = 2, LocationId = 2, Name = "Galleywinter", Bathrooms = 3,
          Images = new List<ImageModel>(){
            new ImageModel() { ImageUri = "https://www.nps.gov/lacl/learn/nature/images/LACL_2017_Entering-the-Neacolas-from-Big-Valley_LWilcox.JPG"},
            new ImageModel() { ImageUri = "https://media.nationalgeographic.org/assets/photos/201/399/978429cd-0d04-464b-a3c1-473e163ecc5b.jpg"},
            new ImageModel() { ImageUri = "https://res.cloudinary.com/dk-find-out/image/upload/q_80,w_1920,f_auto/Tundra_Scene1_okuw9s.jpg"},
            new ImageModel() { ImageUri = "https://www.thoughtco.com/thmb/BCx7nDQlalfdT1iXhSeL01Ha454=/1333x1000/smart/filters:no_upscale()/92292471-56a005035f9b58eba4ae83e0.jpg"},
            new ImageModel() { ImageUri = "https://upload.wikimedia.org/wikipedia/commons/a/ac/Nunavut_tundra_-c.jpg"},
            new ImageModel() { ImageUri = "https://nhpbs.org/wild/images/muskoxusfwtimBowman.jpg"},
            new ImageModel() { ImageUri = "https://images.fineartamerica.com/images-medium-large-5/3-bull-caribou-on-autumn-tundra-in-denali-milo-burcham.jpg"},
          }
        },

        new LodgingModel() { Id = 3, LocationId = 3, Name = "Red Creek", Bathrooms = 5,
          Images = new List<ImageModel>(){
            new ImageModel() { ImageUri = "https://eskipaper.com/images/awesome-jungle-wallpaper-2.jpg"},
            new ImageModel() { ImageUri = "https://images.unsplash.com/photo-1588392382834-a891154bca4d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80"},
            new ImageModel() { ImageUri = "https://wallpapermemory.com/uploads/274/jungle-wallpaper-hd-1120x832-447114.jpg"},
            new ImageModel() { ImageUri = "https://images.alphacoders.com/708/thumb-1920-708947.jpg"},
            new ImageModel() { ImageUri = "https://www.worldwalks.com/wp-content/uploads/2018/12/Amazon_870-870x480.jpg"},
            new ImageModel() { ImageUri = "https://www.goodnewsnetwork.org/wp-content/uploads/2014/06/Potaro-river-Kaieteur-falls-Amazon-cc-Allan_Hopkins.jpg"},
            new ImageModel() { ImageUri = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F28%2F2020%2F06%2F18%2Folympia-national-park-hoh-campground-NPCAMP0620.jpg"},
          }
        },

        new LodgingModel() { Id = 4, LocationId = 4, Name = "Lotus Belle", Bathrooms = 6,
          Images = new List<ImageModel>(){
            new ImageModel() { ImageUri = "https://cdn.mos.cms.futurecdn.net/deaceNXy23NF8VsCrwZPgn.jpg"},
            new ImageModel() { ImageUri = "https://geographical.co.uk/media/k2/items/cache/a74a4e8d02982a465da28ab5257d0d4d_XL.jpg"},
            new ImageModel() { ImageUri = "https://i.pinimg.com/originals/e5/cc/49/e5cc49acade6f109f241e8206ade70f0.jpg"},
            new ImageModel() { ImageUri = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/1/colorful-sunset-in-the-desert-anton-petrus.jpg"},
            new ImageModel() { ImageUri = "https://www.turbopass.com/3843-carousel/desert-sunset-experience.jpg"},
            new ImageModel() { ImageUri = "https://www.kcet.org/sites/kl/files/atoms/article_atoms/www.kcet.org/living/travel/socal_wanderer/jumbo-rocks-campground-joshua-tree.jpeg"},
            new ImageModel() { ImageUri = "https://upload.wikimedia.org/wikipedia/commons/6/67/Desert_Fox_Pups.jpg"},
          }
        },
      });

      

      modelBuilder.Entity<RentalModel>().HasData(new List<RentalModel>()
      {
        new RentalModel() { Id = 1, LodgingModelId = 1, LotNumber = "100", Status = "Available", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 2, LodgingModelId = 1, LotNumber = "101", Status = "Available", Price = 300, DiscountedPrice = 280 },
        new RentalModel() { Id = 3, LodgingModelId = 1, LotNumber = "102", Status = "Booked", Price = 300, DiscountedPrice = 280 },
        new RentalModel() { Id = 4, LodgingModelId = 1, LotNumber = "103", Status = "Booked", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 5, LodgingModelId = 2, LotNumber = "100", Status = "Available", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 6, LodgingModelId = 2, LotNumber = "101", Status = "Available", Price = 300, DiscountedPrice = 280 },
        new RentalModel() { Id = 7, LodgingModelId = 2, LotNumber = "102", Status = "Booked", Price = 300, DiscountedPrice = 280 },
        new RentalModel() { Id = 8, LodgingModelId = 2, LotNumber = "103", Status = "Booked", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 9, LodgingModelId = 3, LotNumber = "100", Status = "Available", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 10, LodgingModelId = 3, LotNumber = "101", Status = "Booked", Price = 100, DiscountedPrice = 70 },
        new RentalModel() { Id = 11, LodgingModelId = 4, LotNumber = "100", Status = "Available", Price = 300, DiscountedPrice = 280 },
        new RentalModel() { Id = 12, LodgingModelId = 4, LotNumber = "101", Status = "Booked", Price = 300, DiscountedPrice = 280 },
      });

      modelBuilder.Entity<RentalUnitModel>().HasData(new List<RentalUnitModel>()
      {
        new RentalUnitModel() { Id = 1, RentalId = 1, Capacity = 4, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 2, RentalId = 2, Capacity = 5, Name = "RV", Size = "10x10" },
        new RentalUnitModel() { Id = 3, RentalId = 3, Capacity = 5, Name = "RV", Size = "10x10" },
        new RentalUnitModel() { Id = 4, RentalId = 4, Capacity = 4, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 5, RentalId = 5, Capacity = 4, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 6, RentalId = 6, Capacity = 5, Name = "RV", Size = "10x10" },
        new RentalUnitModel() { Id = 7, RentalId = 7, Capacity = 5, Name = "RV", Size = "10x10" },
        new RentalUnitModel() { Id = 8, RentalId = 8, Capacity = 4, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 9, RentalId = 9, Capacity = 4, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 10, RentalId = 10, Capacity = 5, Name = "Tent", Size = "5x5" },
        new RentalUnitModel() { Id = 11, RentalId = 11, Capacity = 4, Name = "RV", Size = "10x10" },
        new RentalUnitModel() { Id = 12, RentalId = 12, Capacity = 5, Name = "RV", Size = "10x10" },
      });

      modelBuilder.Entity<LocationModel>().HasData(new List<LocationModel>()
      {
        new LocationModel() { Id = 1, AddressId = 1, Latitude = "38.0755", Longitude = "77.9889" },
        new LocationModel() { Id = 2, AddressId = 2, Latitude = "38.0755", Longitude = "77.9889" },
        new LocationModel() { Id = 3, AddressId = 3, Latitude = "38.0755", Longitude = "77.9889" },
        new LocationModel() { Id = 4, AddressId = 4, Latitude = "38.0755", Longitude = "77.9889" },
      });

      modelBuilder.Entity<AddressModel>().HasData(new List<AddressModel>()
      {
        new AddressModel() { Id = 1, City = "Palm Bay", Country = "USA", PostalCode = "32908", StateProvince = "FL", Street = "750 Osmosis Dr SW" },
        new AddressModel() { Id = 2, City = "Afton", Country = "USA", PostalCode = "22920", StateProvince = "VA", Street = "8801 Dick Woods Rd" },
        new AddressModel() { Id = 3, City = "Hanna", Country = "USA", PostalCode = "84031", StateProvince = "UT", Street = "5761 Upper, Red Creek Rd" },
        new AddressModel() { Id = 4, City = "Topanga", Country = "USA", PostalCode = "90290", StateProvince = "CA", Street = "101 S Topanga Canyon Blvd" },
      });
    }
  }
}
