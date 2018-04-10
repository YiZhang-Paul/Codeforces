using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsInRailwayCarriage {
    class Program {
        static void Main(string[] args) {

            string numbers = Console.ReadLine().Trim();
            string seats = Console.ReadLine().Trim();

            Console.WriteLine(new StudentsInRailwayCarriage().FindMaxStudent(numbers, seats));
        }
    }
}