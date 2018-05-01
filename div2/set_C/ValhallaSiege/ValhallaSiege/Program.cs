using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaSiege {
    class Program {
        static void Main(string[] args) {

            var siege = new ValhallaSiege();
            Console.WriteLine(string.Join("\n", siege.CountDeath("1 2 1 2 1", "3 10 1 1 1")));
            Console.WriteLine(string.Join("\n", siege.CountDeath("1 2 3 4", "9 1 10 6")));
        }
    }
}