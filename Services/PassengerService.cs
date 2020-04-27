using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MongoDB.Driver;
using passenger_management.Models;

namespace passenger_management.Services
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class PassengerService
    {
        private readonly IMongoCollection<Passenger> _passengers;

        public PassengerService(IPassengersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _passengers = database.GetCollection<Passenger>(settings.PassengersCollectionName);
        }

        public List<Passenger> Get(bool includeDisabled = false) =>
            _passengers.Find(passenger => passenger.Enabled || includeDisabled).ToList();

        public Passenger Get(string id, bool includeDisabled = false) =>
            _passengers.Find(passenger => passenger.Id == id && (passenger.Enabled || includeDisabled)).FirstOrDefault();

        // ReSharper disable once UnusedMethodReturnValue.Global
        public Passenger Create(Passenger passenger)
        {
            passenger.Enabled = true;
            _passengers.InsertOne(passenger);
            return passenger;
        }

        public void Update(string id, Passenger passengerIn, bool includeDisabled = false) =>
            _passengers.ReplaceOne(passenger => passenger.Id == id && (passenger.Enabled || includeDisabled), passengerIn);

        public void Remove(Passenger passengerIn)
        {
            passengerIn.Enabled = false;
            _passengers.ReplaceOne(passenger => passenger.Id == passengerIn.Id, passengerIn);
        }

        public void Remove(string id) =>
            Remove(Get(id));
    }
}