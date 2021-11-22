using System;
using System.Text.Json;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain phillyCoin = new Blockchain();
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));

            Console.WriteLine(JsonSerializer.Serialize(phillyCoin.GetChain(), new JsonSerializerOptions() { WriteIndented = true }));

            Console.WriteLine(phillyCoin.IsValid());

            
        }
    }
}
