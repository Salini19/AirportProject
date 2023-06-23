using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AirportSample.Models;
using static AirportSample.Controllers.AirportController;

namespace AirportSample.Controllers
{
    public class airportinfoesController : Controller
    {
        public AirportDBEntities3 db = new AirportDBEntities3();

        // GET: airportinfoes
        public ActionResult Index()
        {
            var cityList = db.cityinfoes.ToList();
            ViewBag.CityList1 = new SelectList(cityList, "CITY", "CITY");


            ViewBag.CityList2 = new SelectList(cityList, "CITY", "CITY");
            return View();
        }

     
        public ActionResult Create()
        {
            var cityList = db.cityinfoes.ToList();
            ViewBag.CityList1 = new SelectList(cityList, "CITY", "CITY");


            ViewBag.CityList2 = new SelectList(cityList, "CITY", "CITY");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create(FormCollection form)
        {
           
            var cityList = db.cityinfoes.ToList();
            string From = form["CityList1"].ToString();
            cityinfo city1 = cityList.Find(m => m.CITY == From);

            double lat = Convert.ToDouble(city1.LAT);
            double slong = Convert.ToDouble(city1.LONG);
            var startlocation = new Location(lat, slong);
            string To = form["CityList2"].ToString();
            cityinfo city2 = cityList.Find(m => m.CITY == To);
            double dlat = Convert.ToDouble(city2.LAT);
            double dlong = Convert.ToDouble(city2.LONG);
            var destinationlocation = new Location(dlat,dlong);


            var airportsInRange = new List<airportinfo>();

            var airports = db.airportinfoes.ToList();


            var maxDistance = HaversineDistance(startlocation, destinationlocation)+50;
            foreach (var airport in airports)
            {
                
                var airportLocation = new Location(airport.LAT, airport.LONG);
                var distance = CalculateDistance(startlocation, destinationlocation, airportLocation);

                if (distance <= maxDistance)
                    airportsInRange.Add(airport);
            }


            return View(airportsInRange);




            
            }

           
        



    //[HttpPost]
    //public ActionResult Search(double startLatitude, double startLongitude, double destinationLatitude, double destinationLongitude)
    //{
    //    var airportFinder = new AirportFinder();
    //    var airports = airportFinder.FindAirportsBetweenCities(startLatitude, startLongitude, destinationLatitude, destinationLongitude);

    //    return PartialView("_AirportsPartial", airports);
    //}


    
       

        //public List<airportinfo> FindAirportsBetweenCities(double startLatitude, double startLongitude, double destinationLatitude, double destinationLongitude)
        //{
        //    var startLocation = new Location(startLatitude, startLongitude);
        //    var destinationLocation = new Location(destinationLatitude, destinationLongitude);

        //    var airportsInRange = new List<airportinfo>();

        //    var maxDistance = HaversineDistance(startLocation, destinationLocation);
        //    foreach (var airport in airports)
        //    {
        //        var airportLocation = new Location(airport.LAT, airport.LONG);
        //        var distance = CalculateDistance(startLocation, destinationLocation, airportLocation);

        //        if (distance <= maxDistance)
        //            airportsInRange.Add(airport);
        //    }

        //    return airportsInRange;
        //}

        public double CalculateDistance(Location startLocation, Location destinationLocation, Location airportLocation)
        {
            var startToAirportDistance = HaversineDistance(startLocation, airportLocation);
            var airportToDestinationDistance = HaversineDistance(airportLocation, destinationLocation);
            var totalDistance = startToAirportDistance + airportToDestinationDistance;

            return totalDistance;
        }



        public double HaversineDistance(Location location1, Location location2)
        {
            var earthRadius = 6371; // Radius of the Earth in kilometers
            var latitudeDifference = DegreesToRadians(location2.Latitude - location1.Latitude);
            var longitudeDifference = DegreesToRadians(location2.Longitude - location1.Longitude);

            var a = Math.Sin(latitudeDifference / 2) * Math.Sin(latitudeDifference / 2) +
            Math.Cos(DegreesToRadians(location1.Latitude)) * Math.Cos(DegreesToRadians(location2.Latitude)) *
            Math.Sin(longitudeDifference / 2) * Math.Sin(longitudeDifference / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = earthRadius * c;

            return distance;
        }

        public double DegreesToRadians(double degrees)
        {

            return degrees * (Math.PI / 180);
        }


    }

}































    // GET: airportinfoes/Details/5
//    public ActionResult Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            airportinfo airportinfo = db.airportinfoes.Find(id);
//            if (airportinfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(airportinfo);
//        }

//        // GET: airportinfoes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: airportinfoes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Create([Bind(Include = "IATACODE,AIRPORTNAME,CITY,STATE,COUNTRY,LAT,LONG")] airportinfo airportinfo)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        db.airportinfoes.Add(airportinfo);
//        //        db.SaveChanges();
//        //        return RedirectToAction("Index");
//        //    }

//        //    return View(airportinfo);
//        //}
       

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(FormCollection FormCollection)
//        {
//            List<airportinfo> airportinfoList = new List<airportinfo>();
//            string From = FormCollection["From"].ToString();
//            string To = FormCollection["To"].ToString();

//            List<airportinfo> air = airportinfoList.FindAll(x => x.CITY == From && x.CITY==To);

//            return View();
//        }
//        // GET: airportinfoes/Edit/5
//        public ActionResult Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            airportinfo airportinfo = db.airportinfoes.Find(id);
//            if (airportinfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(airportinfo);
//        }

//        // POST: airportinfoes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "IATACODE,AIRPORTNAME,CITY,STATE,COUNTRY,LAT,LONG")] airportinfo airportinfo)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(airportinfo).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(airportinfo);
//        }

//        // GET: airportinfoes/Delete/5
//        public ActionResult Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            airportinfo airportinfo = db.airportinfoes.Find(id);
//            if (airportinfo == null)
//            {
//                return HttpNotFound();
//            }
//            return View(airportinfo);
//        }

//        // POST: airportinfoes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(string id)
//        {
//            airportinfo airportinfo = db.airportinfoes.Find(id);
//            db.airportinfoes.Remove(airportinfo);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
