using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeASquare {
    class Program {
        static void Main(string[] args) {

            string digits = Console.ReadLine().Trim();

            Console.WriteLine(new MakeASquare().MinStep(digits));
        }
    }
}