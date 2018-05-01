using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala {
    class Program {
        static void Main(string[] args) {

            var mancala = new Mancala();
            Console.WriteLine(mancala.GetMaxScore("0 1 1 0 0 0 0 0 0 7 0 0 0 0"));
            Console.WriteLine(mancala.GetMaxScore("5 1 1 1 1 0 0 0 0 0 0 0 0 0"));
        }
    }
}