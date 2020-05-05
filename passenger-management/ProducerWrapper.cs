using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace passenger_management
{
    public class ProducerWrapper
    {
        private readonly IProducer<Null, string> _producer;

        public ProducerWrapper(ProducerConfig config)
        {
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task WriteMessage(string topicName, string message)
        {
            var deliveryResult = await _producer.ProduceAsync(topicName, new Message<Null, string>
            {
                Value = message
            });
            Console.WriteLine(
                $"Kafka: Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
        }
    }
}