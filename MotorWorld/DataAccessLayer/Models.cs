using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MotorWorld.DataAccessLayer
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual int UserId { get; set; }
        public virtual string UserName { get; set; }

        public virtual ICollection<BikesOwned> BikesOwned { get; set; }
        public virtual ICollection<TripsClass> Trips { get; set; }
    }

    [Table("Trips")]
    [DataContract]
    public class TripsClass
    {
        [Key]
        public virtual int TripId { get; set; }
        public virtual int BikeId { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime Date { get; set; }
        public virtual int UserId { get; set; }
        public virtual string TripName { get; set; }

        public virtual ICollection<WayPoints> WayPoints { get; set; }
        public virtual BikesOwned BikesOwned { get; set; }
        public virtual UserProfile User { get; set; }
    }

    [Table("WayPoints")]
    [DataContract]
    public class WayPoints
    {
        [Key]
        [Column(Order = 0)]
        public virtual int TripId { get; set; }
        [Key]
        [Column(Order = 1)]
        public virtual int Sequence { get; set; }
        public virtual int CityId { get; set; }

        public virtual TripsClass Trips { get; set; }
        public virtual Cities City { get; set; }
    }

    [Table("Cities_extended")]
    [DataContract]
    public class Cities
    {
        [Key]
        public virtual int cityId { get; set; }
        public virtual string city { get; set; }
        public virtual string state_code { get; set; }
        public virtual string zip { get; set; }
        public virtual double latitude { get; set; }
        public virtual double longitude { get; set; }
        public virtual string county { get; set; }

        public virtual ICollection<WayPoints> Waypoints { get; set; }
    }

    [Table("BikesOwned")]
    [DataContract]
    public class BikesOwned
    {
        [Key]
        [Column(Order = 0)]
        public virtual int UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        [DataMember]
        public virtual int BikeId { get; set; }

        public virtual ICollection<TripsClass> Trips { get; set; }
        [DataMember]
        public virtual BikeTypes BikeType { get; set; }
        public virtual UserProfile User { get; set; }
    }

    [Table("BikeTypes")]
    [DataContract]
    public class BikeTypes
    {
        [DataMember]
        public virtual int Year { get; set; }
        [DataMember]
        public virtual string Make { get; set; }
        [DataMember]
        public virtual string Model { get; set; }
        [Key]
        public virtual int BikeId { get; set; }

        public virtual ICollection<BikesOwned> BikesOwned { get; set; }
    }
}