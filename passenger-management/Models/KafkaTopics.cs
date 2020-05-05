namespace passenger_management.Models
{
    public class KafkaTopics : IKafkaTopics
    {
        public string Create { get; set; }
        public string Update { get; set; }
        public string Delete { get; set; }
    }

    public interface IKafkaTopics
    {
        string Create { get; set; }
        string Update { get; set; }
        string Delete { get; set; }
    }
}