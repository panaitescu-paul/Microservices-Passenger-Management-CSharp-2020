using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// ReSharper disable UnusedMember.Global

namespace passenger_management.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Passenger
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Id { get; set; }

        [BsonElement("Enabled")] public bool Enabled { get; set; }

        [BsonElement("Cpr")] public string Cpr { get; set; }

        [BsonElement("FirstName")] public string FirstName { get; set; }

        [BsonElement("LastName")] public string LastName { get; set; }

        [BsonElement("Age")] public decimal Age { get; set; }

        [BsonElement("Gender")] public string Gender { get; set; }

        [BsonElement("PassportInfo")] public string PassportInfo { get; set; }

        [BsonElement("Nationality")] public string Nationality { get; set; }
    }
}