using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StudentsInRailwayCarriage {
    public class StudentsInRailwayCarriage {

        private int[] ParseNumbers(string numbers) {

            return Regex.Matches(numbers, @"\d+")
                        .Cast<Match>()
                        .Select(match => int.Parse(match.Value))
                        .ToArray();
        }

        private string[] FindEmptySeats(string seats) {

            return seats.Split('*').Where(seat => seat.Length > 0).ToArray();
        }

        public int FindMaxStudent(string numbers, string seats) {

            int[] students = ParseNumbers(numbers).Skip(1).ToArray();
            int total = students[0] + students[1];
            int more = Math.Max(students[0], students[1]);
            int less = Math.Min(students[0], students[1]);

            foreach(var seat in FindEmptySeats(seats)) {
                //try fitting in student type with more unsettled members first
                more -= Math.Min(more, (seat.Length + seat.Length % 2) / 2);
                less -= Math.Min(less, seat.Length / 2);
                //re-adjust current larger/smaller student group
                int remain = more + less;
                more = remain - Math.Min(more, less);
                less = remain - more;

                if(more == 0 && less == 0) {

                    break;
                }
            }

            return total - more - less;
        }
    }
}