using Confluent.Kafka;

try
{
    Console.WriteLine("Started...");
    var config = new ConsumerConfig { GroupId = "exampledb-consumer", BootstrapServers = "kafka:9092" };

    using (var consumer = new ConsumerBuilder<string,string>(config).Build())
    {
        consumer.Subscribe("postgres.public.employee");

        while (true)
        {
            ConsumeResult<string, string> consumeResult = consumer.Consume();
            Console.WriteLine($"Name of topic {consumeResult.TopicPartitionOffset} message :{consumeResult.Message.Value}");
            consumer.Commit();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}