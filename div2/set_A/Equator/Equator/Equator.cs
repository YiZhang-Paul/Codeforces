using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Equator {
    public class Equator {

        private int[] ParseNumbers(string numbers) {

            return Regex.Matches(numbers, @"\d+")
                        .Cast<Match>()
                        .Select(match => int.Parse(match.Value))
                        .ToArray();
        }

        public int GetDay(string questions) {

            var numbers = ParseNumbers(questions);
            long total = numbers.Sum();
            long current = 0;

            for(int i = 0; i < numbers.Length; i++) {

                current += numbers[i];

                if(current * 2 >= total) {

                    return i + 1;
                }
            }

            return numbers.Length - 1;
        }
    }
}