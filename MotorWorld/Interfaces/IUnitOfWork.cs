using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MotorWorld.DataAccessLayer;

namespace MotorWorld.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TripsClass> TripsRepository { get; }
        IGenericRepository<UserProfile> UserRepository { get; }
        IGenericRepository<BikesOwned> BikesOwnedRepository { get; }
        IGenericRepository<Cities> CitiesRepository { get; }
        IGenericRepository<WayPoints> WayPointsRepository { get; }
        IGenericRepository<BikeTypes> BikeTypesRepository { get; }

        void Commit();
    }
}
