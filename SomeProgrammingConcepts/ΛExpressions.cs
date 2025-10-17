using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SomeProgrammingConcepts
{
    internal class ΛExpressions
    {
        private class FirstCharComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y) =>
                (x ?? "").FirstOrDefault() == (y ?? "").FirstOrDefault();

            public int GetHashCode(string obj) => (obj.FirstOrDefault()).GetHashCode();
        }

        public static void Run()
        {
            // Exercise 1 – Anonymous methods → lambdas
            Func<int, int> square = delegate (int x) { return x * x; };
            Func<int, int> squareΛ = x => x * x;
            Func<int, bool> isOdd = delegate (int x) { return x % 2 != 0; };
            Func<int, bool> isOddΛ = x => x % 2 != 0;
            Action<string> print = delegate (string s) { Console.WriteLine(s); };
            Action<string> printΛ = s => Console.WriteLine(s);

            // Exercise 2 – Named method → inline lambda
            bool IsShort(string s) { return s.Length < 5; }

            var names = new[] { "Ann", "Robert", "Ewa", "Tom" };
            var shortOnes = names.Where(IsShort);

            // Exercise 3 – Multi-parameter lambda
            Func<int, int, int> max = delegate (int a, int b) { if (a > b) return a; else return b; };

            // Exercise 4 – Statement lambda (multi-line)
            Func<int, int> fib = delegate (int n)
            {
                if (n <= 1) return n;
                int a = 0, b = 1;
                for (int i = 2; i <= n; i++)
                {
                    int t = a + b; a = b; b = t;
                }
                return b;
            };

            // Exercise 5 – LINQ using a named predicate
            bool Expensive(int x) { return x > 100; }

            var nums = Enumerable.Range(50, 100);
            var expensive = nums.Where(Expensive);

            // Exercise 6 – SelectMany with a named method
            IEnumerable<char> ToChars(string s) { return s.ToCharArray(); }

            var words = new[] { "ab", "cde", "f" };
            var charsQuery = words.SelectMany(ToChars);

            // Exercise 7 – Sorting keys as lambdas
            string Key1(string s) { return s.Substring(0, 1); }
            int Key2(string s) { return s.Length; }

            var sorted = words
                .OrderBy(Key1)
                .ThenByDescending(Key2);

            // Exercise 8 – Join with key selectors and result selector
            var left = new[] { new { Id = 1, Name = "A" }, new { Id = 2, Name = "B" } };
            var right = new[] { new { Id = 10, LId = 1 }, new { Id = 11, LId = 1 }, new { Id = 12, LId = 2 } };

            int LeftKey(dynamic x) { return x.Id; }
            int RightKey(dynamic y) { return y.LId; }

            var joined = left.Join(
                right,
                LeftKey,
                RightKey,
                delegate (dynamic l, dynamic r) { return new { L = l.Name, R = r.Id }; }
            );

            // Exercise 9 – Query syntax → Method syntax
            var q =
                from n in Enumerable.Range(1, 20)
                where n % 3 == 0
                orderby n descending
                select n * n;

            // Exercise 10 – GroupBy with custom comparer
            var animals = new[] { "dog", "deer", "cat", "cow" };
            var g = animals.GroupBy(s => s, new FirstCharComparer());

            // Exercise 11 – Aggregate using a method → lambda
            int SumSquares(int acc, int x) { return acc + x * x; }
            var aggr = Enumerable.Range(1, 5).Aggregate(0, SumSquares);

            // Exercise 12 – Predicates and combined condition
            Predicate<int> p1 = delegate (int x) { return x > 10; };
            Predicate<int> p2 = delegate (int x) { return x % 2 == 0; };
            Func<int, bool> both = delegate (int x) { return p1(x) && p2(x); };

            var filtered = Enumerable.Range(1, 30).Where(both).ToList();


            _ = square(3); _ = isOdd(3); print("ok");
            _ = shortOnes.ToList(); _ = max(1, 2); _ = fib(10);
            _ = expensive.ToList(); _ = charsQuery.ToList(); _ = sorted.ToList();
            _ = joined.ToList(); _ = q.ToList(); _ = g.ToList(); _ = aggr; _ = filtered;
        }
    } 
}     
