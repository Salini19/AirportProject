using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportSample.Models;

namespace AirportSample.Controllers
{
    public class AirportController : Controller
    {
        // GET: Airport
        public ActionResult Index()
        {
            return View();
        }




//        [HttpPost]
//        public ActionResult Search(double startLatitude, double startLongitude, double destinationLatitude, double destinationLongitude, double maxDistance)
//        {
//            var airportFinder = new AirportFinder();
//            var airports = airportFinder.FindAirportsBetweenCities(startLatitude, startLongitude, destinationLatitude, destinationLongitude, maxDistance);

//            return PartialView("_AirportsPartial", airports);
//        }



//        public class AirportFinder
//        {
//            private List<Airport> airports;

//            public AirportFinder()
//            {
//                // Load airport data from a data source or API into the airports list.
//                // Each airport should have a Name, Latitude, and Longitude.
//                airports = LoadAirportData();
//            }

//            public List<Airport> FindAirportsBetweenCities(double startLatitude, double startLongitude, double destinationLatitude, double destinationLongitude, double maxDistance)
//            {
//                var startLocation = new Location(startLatitude, startLongitude);
//                var destinationLocation = new Location(destinationLatitude, destinationLongitude);

//                var airportsInRange = new List<Airport>();

//                foreach (var airport in airports)
//                {
//                    var airportLocation = new Location(airport.Latitude, airport.Longitude);
//                    var distance = CalculateDistance(startLocation, destinationLocation, airportLocation);

//                    if (distance <= maxDistance)
//                        airportsInRange.Add(airport);
//                }

//                return airportsInRange;
//            }

//            private double CalculateDistance(Location startLocation, Location destinationLocation, Location airportLocation)
//            {
//                var startToAirportDistance = HaversineDistance(startLocation, airportLocation);
//                var airportToDestinationDistance = HaversineDistance(airportLocation, destinationLocation);
//                var totalDistance = startToAirportDistance + airportToDestinationDistance;

//                return totalDistance;
//            }

//            private double HaversineDistance(Location location1, Location location2)
//            {
//                var earthRadius = 6371; // Radius of the Earth in kilometers
//                var latitudeDifference = DegreesToRadians(location2.Latitude - location1.Latitude);
//                var longitudeDifference = DegreesToRadians(location2.Longitude - location1.Longitude);

//                var a = Math.Sin(latitudeDifference / 2) * Math.Sin(latitudeDifference / 2) +
//                Math.Cos(DegreesToRadians(location1.Latitude)) * Math.Cos(DegreesToRadians(location2.Latitude)) *
//                Math.Sin(longitudeDifference / 2) * Math.Sin(longitudeDifference / 2);

//                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

//                var distance = earthRadius * c;

//                return distance;
//            }

//            private double DegreesToRadians(double degrees)
//            {
//                return degrees * (Math.PI / 180);
//            }

//            private List<Airport> LoadAirportData()
//            {
//                // Implement your logic to load airport data from a data source or API.
//                // Return a list of airports with their Name, Latitude, and Longitude.

//                // Example:
//                var airportData = new List<Airport>
//          {
//new Airport { Name = "Airport 1", Latitude = 40.7128, Longitude = -74.0060 },
//new Airport { Name = "Airport 2", Latitude = 34.0522, Longitude = -118.2437 },
//// Add more airports as needed
//};

//                return airportData;
//            }
//        }

        
    }



}
