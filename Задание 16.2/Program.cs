using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Задание_16._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            Product maxPrice = products[0];
            foreach (Product n in products)
            {
                if (n.Price > maxPrice.Price)
                {
                    maxPrice = n;
                }
            }
            Console.WriteLine($"{maxPrice.Name} {maxPrice.Price}");
            Console.ReadKey();
        }
        class Product
        {
            public int Code { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }
    }
}
