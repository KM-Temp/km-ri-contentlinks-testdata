using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace test_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var quotes = File.ReadAllLines(@"..\..\..\input\quotes.txt");
            var data = quotes.Select(l => new
            {
                quote = l.Split('|')[0],
                author = l.Split('|')[1]
            })
            .ToList();

            data.ForEach(d =>
            {
                Console.WriteLine(d);
                File.WriteAllText($"..\\..\\..\\output\\{Guid.NewGuid().ToString()}.json", JsonConvert.SerializeObject(d));
            });
        }
    }
}
