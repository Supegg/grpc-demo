using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace RpcClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:36", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            var reply = client.SayHello(new HelloRequest { Name = "Su" });
            Console.WriteLine("来自 " + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
