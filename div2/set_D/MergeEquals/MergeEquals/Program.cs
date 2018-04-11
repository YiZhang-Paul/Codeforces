using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeEquals {
    class Program {
        static void Main(string[] args) {

            string total = Console.ReadLine().Trim();
            string numbers = Console.ReadLine().Trim();

            long[] result = new MergeEquals().Merge(numbers);
            Console.WriteLine(result.Length);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}