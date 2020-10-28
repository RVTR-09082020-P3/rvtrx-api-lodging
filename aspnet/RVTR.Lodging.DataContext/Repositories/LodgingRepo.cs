using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RVTR.Lodging.ObjectModel.Interfaces;
using RVTR.Lodging.ObjectModel.Models;

namespace RVTR.Lodging.DataContext.Repositories
{
  public class LodgingRepo : Repository<LodgingModel>, ILodgingRepo
  {
    public LodgingRepo(LodgingContext context) : base(context)
    { }

    /// <summary>
    /// This Method will select all lodgings, including their Rentals, Location,Locations Address, and reviews
    /// </summary>
    public override async Task<IEnumerable<LodgingModel>> SelectAsync() => await Db
      .Include(r => r.Rentals)
        .ThenInclude(ru => ru.Unit)
      .Include(l => l.Location)
        .ThenInclude(a => a.Address)
      .Include(a => a.Reviews)
      .ToListAsync();

    /// <summary>
    /// This method will get a Lodging with the given Id and will include its Location, the locations address, and reviews
    /// </summary>
    public override async Task<LodgingModel> SelectAsync(int id) => await Db
      .Include(r => r.Rentals)
        .ThenInclude(ru => ru.Unit)
      .Include(l => l.Location)
        .ThenInclude(a => a.Address)
      .Include(a => a.Reviews)
      .FirstOrDefaultAsync(x => x.Id == id);

    /// <summary>
    /// This method will return all the lodgings in the given location whose rental status is "available" and where occupancy is not less than the
    /// desired occupancy. It will include the Rentals, Location, and Address tables in its non-case-sensitive filter action. Optional fields
    /// for City, State/Province, or Country that are either null or empty are ignored. These parameters must be entered as arguments in that order.
    /// </summary>
    public async Task<IEnumerable<LodgingModel>> LodgingByLocationAndOccupancy(int occupancy, params string[] location)
    {
      var numParams = location.Length;

      Expression<Func<LodgingModel, bool>> matchesAll = c =>
        (numParams < 1 || string.IsNullOrEmpty(location[0]) || c.Location.Address.City.ToLower() == location[0].ToLower()) &&
        (numParams < 2 || string.IsNullOrEmpty(location[1]) || c.Location.Address.StateProvince.ToLower() == location[1].ToLower()) &&
        (numParams < 3 || string.IsNullOrEmpty(location[2]) || c.Location.Address.Country.ToLower() == location[2].ToLower());

      var lodgingsByLocation = await Db
        .Include(r => r.Rentals)
          .ThenInclude(ru => ru.Unit)
        .Include(l => l.Location)
          .ThenInclude(la => la.Address)
        // .Include(a => a.Location.Address)
        .Where(matchesAll)
        .ToListAsync();

      var filteredLodgings = new List<LodgingModel>();

      foreach (var item in lodgingsByLocation)
      {
        foreach (var rental in item.Rentals)
        {
          if (rental.Status.Equals("available") && rental.Unit.Capacity >= occupancy && !filteredLodgings.Contains(item))
          {
            filteredLodgings.Add(item);
          }
        }
      }
      return filteredLodgings;
    }
  }
}
