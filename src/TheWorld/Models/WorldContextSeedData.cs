using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("brucewayne@theworld.com") == null)
            {
                // Add the user
                var newUser = new WorldUser()
                {
                    UserName = "brucewayne",
                    Email = "brucewayne@theworld.com"
                };

                await _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }

            if (!_context.Trips.Any())
            {
                //Add new data
                var usTrip = new Trip()
                {
                    Name = "US Trip",
                    Created = DateTime.UtcNow,
                    UserName = "brucewayne",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014, 6, 4), Latitude = 33.748995, Longitude = -84.387982, Order = 0 },
                        new Stop() { Name = "New York, NY", Arrival = new DateTime(2014, 6, 9), Latitude = 40.712784, Longitude = -74.005941, Order = 1 },
                        new Stop() { Name = "Boston, MA", Arrival = new DateTime(2014, 7, 1), Latitude = 42.360082, Longitude = -71.058880, Order = 2 },
                        new Stop() { Name = "Chicago, IL", Arrival = new DateTime(2014, 7, 10), Latitude = 41.878114, Longitude = -87.629798, Order = 3 },
                        new Stop() { Name = "Seattle, WA", Arrival = new DateTime(2014, 8, 13), Latitude = 47.606209, Longitude = -122.332071, Order = 4 },
                        new Stop() { Name = "Atlanta, GA", Arrival = new DateTime(2014, 8, 23), Latitude = 33.748995, Longitude = -84.387982, Order = 5 }
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                var europeTrip = new Trip()
                {
                    Name = "Europe Trip",
                    Created = DateTime.UtcNow,
                    UserName = "brucewayne",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Order = 0, Latitude = 43.644991, Longitude = -79.394358, Name = "Toronto, Canada", Arrival = new DateTime(2015, 8, 21) },
                        new Stop() { Order = 1, Latitude = 41.391666, Longitude = 2.182251, Name = "Bacrelona, Spain", Arrival = new DateTime(2015, 8, 22) },
                        new Stop() { Order = 2, Latitude = 41.901885, Longitude = 12.479503, Name = "Rome, Italy", Arrival = new DateTime(2015, 8, 25) },
                        new Stop() { Order = 3, Latitude = 52.369898, Longitude = 4.894068, Name = "Amsterdam, Netherlands", Arrival = new DateTime(2015, 8, 28) },
                        new Stop() { Order = 4, Latitude = 51.513605, Longitude = -0.127010, Name = "London, United Kingdom", Arrival = new DateTime(2015, 8, 31) },
                        new Stop() { Order = 5, Latitude = 43.644991, Longitude = -79.394358, Name = "Toronto, Canada", Arrival = new DateTime(2015, 9, 5) }
                    }
                };

                _context.Trips.Add(europeTrip);
                _context.Stops.AddRange(europeTrip.Stops);

                _context.SaveChanges();

            }
        }
    }
}
