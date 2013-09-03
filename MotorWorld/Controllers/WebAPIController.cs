using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MotorWorld.Interfaces;
using MotorWorld.DataAccessLayer;

namespace MotorWorld
{
    public class WebAPIController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public WebAPIController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IQueryable<BikesOwned> Bikes()
        {
            var bikes = _unitOfWork.BikesOwnedRepository.GetAll().ToList();
            if (bikes == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return bikes.AsQueryable();
        }

        [HttpGet]
        public BikesOwned Bikes(int id)
        {
            var bike = _unitOfWork.BikesOwnedRepository.Find(x => x.BikeId.Equals(id)).Single();
            if (bike == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return bike;
        }

        [HttpGet]
        public IEnumerable<TripsClass> Trips()
        {
            var trips = _unitOfWork.TripsRepository.GetAll().ToList();
            if (trips == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return trips;
        }


        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}