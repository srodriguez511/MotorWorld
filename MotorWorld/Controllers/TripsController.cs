using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using MotorWorld.Interfaces;

namespace MotorWorld.Controllers
{
    public class TripsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public TripsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Latest trips for home page
        /// </summary>
        /// <returns></returns>
        public PartialViewResult LatestTrips()
        {
            var trips = _unitOfWork.TripsRepository.GetAll().OrderByDescending(trip => trip.Date).Take(5).ToList();
            return PartialView("_TripsPartial", trips);
        }

        /// <summary>
        /// Search for trip by city
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Search(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                city = "";
            }

            var result = _unitOfWork.TripsRepository.Find(trip => trip.WayPoints.Any(pt => pt.City.city.ToUpper().Equals(city.ToUpper()))).ToList();
            return PartialView("_TripsPartial", result);
        }

        /// <summary>
        /// Returns a list of autocomplete choices for a given search term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public ActionResult SearchAutoComplete(string term)
        {
            var choices = _unitOfWork.CitiesRepository.Find(city => city.city.Contains(term)).Take(10).Select(r => new { label = r.city }).Distinct();
            return Json(choices, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Full list of trips
        /// </summary>
        /// <returns></returns>
        public ActionResult AllTrips()
        {
            var trips = _unitOfWork.TripsRepository.GetAll().OrderByDescending(trip => trip.Date).ToList();
            return View(trips);
        }
    }
}
