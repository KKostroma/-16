using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Задание16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите код товара");
                int Code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string Name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double Price = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product() { Code = Code,Name = Name, Price = Price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string JsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(JsonString);
            }
        }
        class Product
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }
}
