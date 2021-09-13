using System;
using System.Globalization;
using System.Collections.Generic;
using CursoCSharp.Entities;

namespace CursoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();

            Console.Write("Enter the number of products: ");
            int numberProducts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberProducts; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                string productType = Console.ReadLine();
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if (productType.ToUpper().Equals("I") || productType.ToUpper().Equals("IMPORTED"))
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    productList.Add(new ImportedProduct(name, price, customsFee));
                }
                else if (productType.ToUpper().Equals("C") || productType.ToUpper().Equals("COMMON"))
                {
                    productList.Add(new Product(name, price));
                }
                else if (productType.ToUpper().Equals("U") || productType.ToUpper().Equals("USED"))
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    productList.Add(new UsedProduct(name, price, manufactureDate));
                }
                else
                {
                    Console.WriteLine("This type of product doesn't exist!!!");
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach (Product prod in productList)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}