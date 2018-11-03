using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq4
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Comic> comics = Comic.BuildCatalog();
            Dictionary<int, decimal> values = Comic.GetPrices();
            IEnumerable<Purchase> purchases = Purchase.FindPurchases();
            var results =
                from comic in comics
                join purchase in purchases
                on comic.Issue equals purchase.Issue
                orderby comic.Issue ascending
                select new { comic.Name, comic.Issue, purchase.Price };
            decimal gregListValue = 0;
            decimal totalSpent = 0;
            foreach(var result in results)
            {
                gregListValue += values[result.Issue];
                totalSpent += result.Price;
                Console.WriteLine($"Numer {result.Issue} ({result.Name}) kupiony za {result.Price:c}");
            }
            Console.WriteLine($"Wydałem {totalSpent:c} za komiksy warte {gregListValue:c}");
            Console.ReadKey();
        }
    }
}
