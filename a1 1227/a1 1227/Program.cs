using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Set the culture to Swedish (Sweden)
        CultureInfo.CurrentCulture = new CultureInfo("sv-SE");

        Console.Write("Enter the number of articles: ");
        if (!int.TryParse(Console.ReadLine(), out int numArticles) || numArticles <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for the number of articles.");
            return;
        }

        List<string> articleNames = new List<string>();
        List<decimal> articlePrices = new List<decimal>();

        for (int i = 1; i <= numArticles; i++)
        {
            Console.Write($"Enter the name and price of article {i} (name; price): ");
            string articleInfo = Console.ReadLine();

            string[] parts = articleInfo.Split(';');
            if (parts.Length != 2 || !decimal.TryParse(parts[1].Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal price))
            {
                Console.WriteLine("Invalid input format. Please use 'name; price' format with a valid decimal number for price.");
                i--;
                continue;
            }

            articleNames.Add(parts[0].Trim());
            articlePrices.Add(price);
        }

        decimal total = 0;
        Console.WriteLine("\nReceipt:");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("{0,-20} {1,-10}", "Article", "Price (SEK)");
        Console.WriteLine(new string('-', 40));

        for (int i = 0; i < articleNames.Count; i++)
        {
            Console.WriteLine("{0,-20} {1,-10:C2}", articleNames[i], articlePrices[i]);
            total += articlePrices[i];
        }

        decimal vatRate = 0.25m; // Assuming a VAT rate of 25%
        decimal vat = total * vatRate;

        Console.WriteLine(new string('-', 40));
        Console.WriteLine("{0,-20} {1,-10:C2}", "Total", total);
        Console.WriteLine("{0,-20} {1,-10:C2}", "VAT (25%)", vat);
        Console.WriteLine(new string('-', 40));
    }
}
