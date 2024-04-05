using L2O___D09;
using System.Reflection.Metadata;
namespace LinqLab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listProd = ListGenerators.ProductList;
            var listCust = ListGenerators.CustomerList;

            var q1 = listProd.Where(p => p.UnitsInStock == 0);
            foreach (var p in q1)
            {
                Console.WriteLine($"Products out of stock: {p.ProductName}");
            }
            Console.WriteLine("==========================================");
            var q2 = listProd.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var p in q2)
            {
                Console.WriteLine($"Products in stock and cost more than 3.00: {p.ProductName}");
            }
            Console.WriteLine("==========================================");
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] q3 = Arr.Where((num, index) => num.Length < index).ToArray();
            foreach (var p in q3) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q4 = listProd.Where(p => p.UnitsInStock == 0).Take(1);
            foreach (var p in q4) { Console.WriteLine($"First product out of stock: {p.ProductName}"); }
            Console.WriteLine("==========================================");
            var q5 = listProd.FirstOrDefault(p => p.UnitPrice > 1000);
            if (q5 == null) { Console.WriteLine("There is no Product with this price!"); }
            Console.WriteLine("==========================================");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q6 = Arr2.Where(p => p > 5).Skip(1).Take(1);
            foreach (var p in q6) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q7 = listProd.Select(p => p.Category).Distinct();
            foreach (var p in q7) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q8 = listProd.Select(p => p.ProductName[0]).Distinct().Concat(listCust.Select(c => c.CustomerID[0]).Distinct());
            foreach (var p in q8) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q9 = listProd.Select(p => p.ProductName[0]).Intersect(listCust.Select(c => c.CustomerID[0]));
            foreach (var p in q9) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q10 = listProd.Select(p => p.ProductName[0]).Except(listCust.Select(c => c.CustomerID[0]));
            foreach (var p in q10) { Console.WriteLine(p); }
            Console.WriteLine("==========================================");
            var q11 = listProd.SelectMany(p => p.ProductName.Reverse().Take(3)).Concat(listCust.SelectMany(c => c.CustomerID.Reverse().Take(3)));
            string chars = "";
            int count = 0;
            foreach (var p in q11)
            {
                chars += p;
                count++;
                if (count == 3)
                {
                    Console.WriteLine(chars);
                    chars = "";
                    count = 0;
                }
            }
            Console.WriteLine("==========================================");
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q12 = Arr3.Count(p => p % 2 != 0);
            Console.WriteLine(q12);
            Console.WriteLine("==========================================");
            var q13 = listCust.Select(c => new
            {
                Customer = c,
                OrderCount = c.Orders.Count()
            });

            foreach (var item in q13)
            {
                Console.WriteLine($"Customer: {item.Customer.CustomerID}, Orders: {item.OrderCount}");
            }
            Console.WriteLine("==========================================");
            var q14 = listProd.GroupBy(p => p.Category).Select(g => new { Category = g.Key, ProductCount = g.Count() });
            foreach (var p in q14)
            {
                Console.WriteLine($"Category: {p.Category}, Product Count: {p.ProductCount}");
            }
            Console.WriteLine("==========================================");
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q15 = Arr4.Sum(p => p);
            Console.WriteLine(q15);
            Console.WriteLine("==========================================");
            string text = File.ReadAllText("dictionary_english.txt");
            var dicList = text.Split("\n");
            var q16 = dicList.Sum(x => x.Length);
            Console.WriteLine(q16);
            Console.WriteLine("==========================================");
            var q17 = listProd.GroupBy(p => p.Category).Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
            foreach (var p in q17)
            {
                Console.WriteLine($"Category: {p.Category}, Total Units in Stock: {p.TotalUnits}");
            }
            Console.WriteLine("==========================================");
            int q18 = dicList.Min(x => x.Trim().Length);
            Console.WriteLine(q18);
            Console.WriteLine("==========================================");
            var q19 = listProd.GroupBy(p => p.Category).Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            foreach (var p in q19)
            {
                Console.WriteLine($"Category: {p.Category}, Cheapest Price: {p.CheapestPrice}");
            }
            Console.WriteLine("==========================================");
            var q20 = from p in listProd
                      group p by p.Category into g
                      let cheapestProduct = g.OrderBy(p => p.UnitPrice).FirstOrDefault()
                      select new { Category = g.Key, CheapestProduct = cheapestProduct };

            foreach (var p in q20)
            {
                Console.WriteLine($"Category: {p.Category}, Cheapest Product: {p.CheapestProduct.ProductName}, Price: {p.CheapestProduct.UnitPrice}");
            }
            Console.WriteLine("==========================================");
            int q21 = dicList.Max(w => w.Trim().Length);
            Console.WriteLine(q21);
            Console.WriteLine("==========================================");
            var q22 = listProd.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                MostExpensive = g.Max(p => p.UnitPrice)
            });
            foreach(var p in q22)
            {
                Console.WriteLine($"Category: {p.Category}, Most Expensive Price: {p.MostExpensive}");
            }
            Console.WriteLine("==========================================");
            var q23 = listProd.GroupBy(p => p.Category).Select(g => g.OrderByDescending(p => p.UnitPrice).First());
            foreach (var p in q23)
            {
                Console.WriteLine($"Category: {p.Category}, Product: {p.ProductName}, Price: {p.UnitPrice}");
            }
            Console.WriteLine("==========================================");
            double q24 = dicList.Average(w => w.Trim().Length);
            Console.WriteLine(q24);
            Console.WriteLine("==========================================");
            var q25 = listProd.GroupBy(p => p.Category).Select(g => new
            { Category = g.Key,AveragePrice = g.Average(p => p.UnitPrice) });
            foreach(var p in q25)
            {
                Console.WriteLine($"Category: {p.Category}, Average Price: {p.AveragePrice}");
            }
            Console.WriteLine("==========================================");
            var q26 = listProd.OrderBy(p => p.ProductName);
            foreach(var p in q26)
            {
                Console.WriteLine(p.ProductName);
            }
            Console.WriteLine("==========================================");
            string[] Arr5 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q27 = Arr5.OrderBy(w => w.ToLower());
            foreach(var p in q27)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            var q28 = listProd.OrderByDescending(p => p.UnitsInStock);
            foreach(var p in q28)
            {
                Console.WriteLine($"Product: {p.ProductName}, Units in stock: {p.UnitsInStock}");
            }
            Console.WriteLine("==========================================");
            string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q29 = Arr6.OrderBy(w => w.Length).ThenBy(w => w);
            foreach(var p in q29)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q30 = words.OrderBy(w => w.Length).ThenBy(w => w.ToLower());
            foreach(var p in q30)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            var q31 = listProd.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach( var p in q31)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            string[] Arr7 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q32 = Arr7.OrderBy(w => w.Length).ThenByDescending(w => w.ToLower());
            foreach (var p in q32)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            string[] Arr8 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var q33 = Arr8.Where(d => d.Length > 1 && d[1] == 'i').Reverse().ToList();
            foreach (var p in q33)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            var q34 = listCust.Where(c => c.Region == "WA").SelectMany(customer => customer.Orders.Take(3)); 
            foreach (var p in q34)
            {
                Console.WriteLine(p.OrderID);
            }
            Console.WriteLine("==========================================");
            var q35 = listCust.Where(c => c.Region == "WA").SelectMany(customer => customer.Orders.Skip(2));
            foreach(var p in q35)
            {
                Console.WriteLine(p.OrderID);
            }
            Console.WriteLine("==========================================");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q36 = numbers.TakeWhile((n, i) => n >= i);
            foreach (var p in q36)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q37 = numbers2.SkipWhile(n => n % 3 != 0);
            foreach (var p in q37)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q38 = numbers3.SkipWhile((n, i) => n >= i);
            foreach(var p in q38)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            var q39 = listProd.Select(p => p.ProductName);
            foreach(var p in q39)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q40 = words2.Select(w => new {UpperCase = w.ToUpper(), LowerCase = w.ToLower()});
            foreach(var p in q40)
            {
                Console.WriteLine($"Uppercase: {p.UpperCase}, Lowercase: {p.LowerCase}");
            }
            Console.WriteLine("==========================================");
            var q41 = listProd.Select(p => new
            {
                p.ProductName,p.Category, Price = p.UnitPrice
            });
            foreach (var p in q41)
            {
                Console.WriteLine($"Product: {p.ProductName}, Category: {p.Category}, Price: {p.Price}");
            }
            Console.WriteLine("==========================================");
            int[] Arr9 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q42 = Arr9.Select((n, i) => new { Number = n, InPlace = n == i });
            Console.WriteLine("Result");
            Console.WriteLine("Number: In-place?");
            foreach(var p in q42)
            {
                Console.WriteLine($"{p.Number}: {p.InPlace}");
            }
            Console.WriteLine("==========================================");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q43 = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => new { NumberA = a, NumberB = b });
            Console.WriteLine("Pairs where a < b:");
            foreach( var p in q43)
            {
                Console.WriteLine($"{p.NumberA} is less than {p.NumberB}");
            }
            Console.WriteLine("==========================================");
            var q44 = listCust.SelectMany(c => c.Orders).Where(o => o.Total < 500);
            foreach(var p in q44)
            {
                Console.WriteLine($"Order ID: {p.OrderID}, Total: {p.Total}");
            }
            Console.WriteLine("==========================================");
            var q45 = listCust.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
            foreach (var p in q45)
            {
                Console.WriteLine($"Order ID: {p.OrderID}, Order Date: {p.OrderDate}");
            }
            Console.WriteLine("==========================================");
            var q46 = dicList.Where(w => w.Contains("ei"));
            foreach(var p in q46)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("==========================================");
            var q47 = listProd
                .Where(p => p.UnitsInStock == 0)
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Products = g.ToList() });
            foreach (var p in q47)
            {
                Console.WriteLine($"Category: {p.Category}");
                foreach (var p2 in p.Products)
                {
                    Console.WriteLine($"  Product Name: {p2.ProductName}");
                }
            }
            Console.WriteLine("==========================================");
            var q48 = listProd.GroupBy(p => p.Category).Where(g => g.All(p => p.UnitsInStock > 0)).Select(g => new { Category = g.Key, Products = g.ToList() });
            foreach (var p in q48)
            {
                Console.WriteLine($"Category: {p.Category}");
                foreach (var p2 in p.Products)
                {
                    Console.WriteLine($"  Product Name: {p2.ProductName}");
                }
            }
            Console.WriteLine("==========================================");
            int[] numbers4 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var q49 = numbers4.GroupBy(n => n % 5);
            foreach(var p in q49)
            {
                Console.WriteLine($"Numbers with a remainder of {p.Key} when divided by 5:");
                foreach (var p2 in p)
                {
                    Console.WriteLine(p2);
                }
            }
            Console.WriteLine("==========================================");
            string[] words3 = File.ReadAllLines("dictionary_english.txt");
            var q50 = words3.GroupBy(w => w[0]);
            foreach(var p in q50)
            {
                Console.WriteLine($"Words starting with '{p.Key}':");
                foreach(var p2 in p)
                {
                    Console.WriteLine(p2);
                }
                Console.WriteLine();
            }
            Console.WriteLine("==========================================");
            string[] Arr10 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var q51 = Arr10.GroupBy(w => w.Trim(), new WordComparer());

            foreach (var p in q51)
            {
                foreach (var p2 in p)
                {
                    Console.WriteLine(p2);
                }
                Console.WriteLine("...");
            }
        }
    }
    public class WordComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return NormalizeString(x) == NormalizeString(y);
        }

        public int GetHashCode(string obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return NormalizeString(obj).GetHashCode();
        }

        private string NormalizeString(string str)
        {
            char[] chars = str.Trim().ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
