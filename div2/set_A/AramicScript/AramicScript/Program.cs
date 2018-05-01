using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AramicScript {
    class Program {
        static void Main(string[] args) {

            var script = new AramicScript();
            Console.WriteLine(script.CountObjects("a aa aaa ab abb"));
            Console.WriteLine(script.CountObjects("amer arem mrea"));
        }
    }
}