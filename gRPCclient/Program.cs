using System.Threading.Tasks;
using Grpc.Net.Client;
namespace gRPCclient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // The port number must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:7220");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            var input=Console.ReadLine();
            var reply2 = await client.SayHelloAsync(
                              new HelloRequest { Name = input });
            Console.WriteLine("Greeting: " + reply2.Message);
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}