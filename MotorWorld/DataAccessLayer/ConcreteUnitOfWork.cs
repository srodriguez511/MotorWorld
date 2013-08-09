using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MotorWorld.Interfaces;

namespace MotorWorld.DataAccessLayer
{
    public class ConcreteUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly ConcreteRepository<TripsClass> _tripsRepo;
        private readonly ConcreteRepository<UserProfile> _userRepo;
        private readonly ConcreteRepository<BikesOwned> _bikesOwnedRepo;
        private readonly ConcreteRepository<WayPoints> _wayPointsRepo;
        private readonly ConcreteRepository<BikeTypes> _bikeTypesRepo;
        private readonly ConcreteRepository<Cities> _citiesRepo;

        public DbSet<TripsClass> TripsDbSet { private get; set; }
        public DbSet<UserProfile> UserProfileDbSet { private get; set; }
        public DbSet<BikesOwned> BikesOwnedDbSet { private get; set; }
        public DbSet<WayPoints> WayPointsDbSet { private get; set; }
        public DbSet<BikeTypes> BikeTypesDbSet { private get; set; }
        public DbSet<Cities> CitiesDbSet { private get; set; }


        public ConcreteUnitOfWork()
            : base("DefaultConnection")
        {
            _tripsRepo = new ConcreteRepository<TripsClass>(TripsDbSet);
            _userRepo = new ConcreteRepository<UserProfile>(UserProfileDbSet);
            _bikesOwnedRepo = new ConcreteRepository<BikesOwned>(BikesOwnedDbSet);
            _wayPointsRepo = new ConcreteRepository<WayPoints>(WayPointsDbSet);
            _bikeTypesRepo = new ConcreteRepository<BikeTypes>(BikeTypesDbSet);
            _citiesRepo = new ConcreteRepository<Cities>(CitiesDbSet);
        }

        public void Commit()
        {
            this.SaveChanges();
        }

        public IGenericRepository<TripsClass> TripsRepository
        {
            get { return _tripsRepo; }
        }

        public IGenericRepository<UserProfile> UserRepository
        {
            get { return _userRepo; }
        }

        public IGenericRepository<BikesOwned> BikesOwnedRepository
        {
            get { return _bikesOwnedRepo; }
        }

        public IGenericRepository<Cities> CitiesRepository
        {
            get { return _citiesRepo; }
        }

        public IGenericRepository<WayPoints> WayPointsRepository
        {
            get { return _wayPointsRepo; }
        }

        public IGenericRepository<BikeTypes> BikeTypesRepository
        {
            get { return _bikeTypesRepo; }
        }

    }
}