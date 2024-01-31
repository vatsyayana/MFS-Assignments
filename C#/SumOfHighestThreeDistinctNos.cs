using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class SumOfHighestThreeDistinctNos
    {

        static void Main(string[] args)
        {

            string test = "23,45,21|09,33,98,,36,89,-11,09,4,100.5|33,89";
            string[] numberStrings = test.Split(new[] {',', '|'}, StringSplitOptions.RemoveEmptyEntries);
            double[] numbers = Array.ConvertAll(numberStrings, double.Parse);
            Array.Sort(numbers);
            Array.Reverse(numbers);
            double sum = numbers.Take(3).Sum();
            Console.WriteLine($"Sum of highest three distinct numbers: {sum}");
            Console.ReadLine();
        }
    }
}
