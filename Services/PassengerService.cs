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

        public List<Passenger> Get() =>
            //TODO: Add 'hide' field to hide object from reads, updates and deletes, to simulate deletion
            _passengers.Find(passenger => true).ToList();

        public Passenger Get(string id) =>
            //TODO: Add 'hide' field to hide object from reads, updates and deletes, to simulate deletion
            _passengers.Find(passenger => passenger.Id == id).FirstOrDefault();

        // ReSharper disable once UnusedMethodReturnValue.Global
        public Passenger Create(Passenger passenger)
        {
            _passengers.InsertOne(passenger);
            return passenger;
        }

        public void Update(string id, Passenger passengerIn) =>
            //TODO: Add 'hide' field to hide object from reads, updates and deletes, to simulate deletion
            _passengers.ReplaceOne(passenger => passenger.Id == id, passengerIn);

        public void Remove(Passenger passengerIn) =>
            //TODO: Add 'hide' field to hide object from reads, updates and deletes, to simulate deletion
            _passengers.DeleteOne(passenger => passenger.Id == passengerIn.Id);

        public void Remove(string id) => 
            //TODO: Add 'hide' field to hide object from reads, updates and deletes, to simulate deletion
            _passengers.DeleteOne(passenger => passenger.Id == id);
    }
}