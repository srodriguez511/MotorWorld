using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorWorld.Interfaces;

namespace MotorWorld.Controllers
{
    public class BikesController : Controller
    {
        private IUnitOfWork _unitOfWOrk;

        public BikesController(IUnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        /// <summary>
        /// All bikes listing
        /// </summary>
        /// <returns></returns>
        public ActionResult AllBikes()
        {
            var bikes = _unitOfWOrk.BikesOwnedRepository.GetAll().ToList();
            return View(bikes);
        }

    }
}
