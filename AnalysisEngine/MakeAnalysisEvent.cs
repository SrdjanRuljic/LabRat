using Application.Common.Interfaces;
using MassTransit;
using System.Text.Json;

namespace AnalysisEngine
{
    public class MakeAnalysisEvent : IConsumer<IAnalysis>
    {
        public async Task Consume(ConsumeContext<IAnalysis> context)
        {
            string serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"Analysis completed succesfully. Message: {serializedMessage}");
        }
    }
}