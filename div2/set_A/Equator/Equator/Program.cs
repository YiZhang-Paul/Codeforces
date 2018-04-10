using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equator {
    class Program {
        static void Main(string[] args) {

            string days = Console.ReadLine().Trim();
            string questions = Console.ReadLine().Trim();

            Console.WriteLine(new Equator().GetDay(questions));
        }
    }
}