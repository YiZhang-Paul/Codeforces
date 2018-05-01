using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValhallaSiege {
    public class ValhallaSiege {

        private decimal[] GetNumbers(string input) {

            return Regex.Matches(input, @"\d+")
                        .Cast<Match>()
                        .Select(match => decimal.Parse(match.Value))
                        .ToArray();
        }

        private decimal[] GetPrefixSum(decimal[] numbers) {

            decimal[] result = new decimal[numbers.Length];
            result[0] = numbers[0];

            for(int i = 1; i < numbers.Length; i++) {

                result[i] = result[i - 1] + numbers[i];
            }

            return result;
        }

        private decimal CountDeath(decimal[] strength, decimal counter) {

            int low = 0;
            int high = strength.Length - 1;

            while(low < high) {

                int mid = (low + high) / 2;

                if(strength[mid] == counter) {

                    return mid + 1;
                }

                if(strength[mid] > counter) {

                    high = mid - 1;

                    continue;
                }

                low = mid + 1;
            }

            return counter >= strength[low] ? low + 1 : low;
        }

        private decimal CountAlive(decimal[] strength, decimal arrows, ref decimal counter) {

            counter += arrows;

            if(counter >= strength.Last()) {

                counter = 0;

                return strength.Length;
            }

            return strength.Length - CountDeath(strength, counter);
        }

        public decimal[] CountAliveByMinute(string warriors, string order) {

            var strength = GetPrefixSum(GetNumbers(warriors));
            var arrows = GetNumbers(order);
            var alives = new decimal[arrows.Length];
            decimal counter = 0;

            for(int i = 0; i < arrows.Length; i++) {

                alives[i] = CountAlive(strength, arrows[i], ref counter);
            }

            return alives;
        }
    }
}