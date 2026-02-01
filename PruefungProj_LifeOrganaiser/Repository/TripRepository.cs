using PruefungProj_LifeOrganaiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PruefungProj_LifeOrganaiser.Repository
{
    internal class TripRepository
    {
        private readonly LifeOrganiserDbContext _context;

        public TripRepository()
        {
            _context = new LifeOrganiserDbContext();
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public List<Trip> GetAllTrips()
        {
            return _context.Trips.ToList();
        }

        public void UpdateTrip(Trip trip)
        {
            var existing = _context.Trips.Find(trip.Id);
            if (existing != null)
            {
                existing.City = trip.City;
                existing.Description = trip.Description;
                existing.ImagePath = trip.ImagePath;
                existing.IsVisited = trip.IsVisited;
                existing.StartDate = trip.StartDate;
                existing.Budget = trip.Budget;
                existing.Rating = trip.Rating;

                _context.SaveChanges();
            }
        }

        public void DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
            }
        }

        public void CopyTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip != null)
            {
                var newTrip = new Trip
                {
                    City = trip.City,
                    Description = trip.Description,
                    ImagePath = trip.ImagePath,
                    IsVisited = trip.IsVisited,
                    StartDate = trip.StartDate,
                    Budget = trip.Budget,
                    Rating = trip.Rating,
                };

                AddTrip(newTrip);
            }
        }

        public List<Trip> SearchTrips(string keyword)
        {
            return _context.Trips
                .Where(t => t.City.Contains(keyword) || t.Description.Contains(keyword))
                .ToList();
        }

        public void AddDefaultTrips()
        {
            if (!_context.Trips.Any())
            {
                AddTrip(new Trip
                {
                    City = "Český Krumlov",
                    Description = "Beautiful old town with castle",
                    ImagePath = "/images/krum.jpg",
                    IsVisited = true,
                    StartDate = DateTime.Today.AddDays(-30),
                    Budget = 400,
                    Rating = 10
                });
                AddTrip(new Trip
                {
                    City = "Gmunden",
                    Description = "Scenic town on the lake",
                    ImagePath = "/images/gmunden.jpg",
                    IsVisited = true,
                    StartDate = DateTime.Today.AddDays(-32),
                    Budget = 50,
                    Rating = 9
                });
                AddTrip(new Trip
                {
                    City = "Passau",
                    Description = "City at the confluence of three rivers",
                    ImagePath = "/images/pasau.jpg",
                    IsVisited = true,
                    StartDate = DateTime.Today.AddDays(-31),
                    Budget = 180,
                    Rating = 9
                });

                AddTrip(new Trip
                {
                    City = "Prague",
                    Description = "Capital of Czech Republic, historic sights.",
                    ImagePath = "/images/prag.jpg",
                    IsVisited = false,
                    StartDate = DateTime.Today.AddDays(10),
                    Budget = 250,
                    Rating = 0
                });
                AddTrip(new Trip
                {
                    City = "Lissabon",
                    Description = "Capital of Portugal, beautiful coastline.",
                    ImagePath = "/images/liss.jpg",
                    IsVisited = false,
                    StartDate = DateTime.Today.AddDays(50),
                    Budget = 300,
                    Rating = 0
                });
            }
        }
    }

}
