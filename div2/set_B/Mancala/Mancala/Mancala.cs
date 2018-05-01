using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Mancala {
    public class Mancala {

        private decimal[] GetNumbers(string input) {

            return Regex.Matches(input, @"\d+")
                        .Cast<Match>()
                        .Select(number => decimal.Parse(number.Value))
                        .ToArray();
        }

        private decimal SumEvenNumbers(decimal[] numbers) {

            decimal sum = 0;

            for(int i = 0; i < numbers.Length; i++) {

                if(numbers[i] > 0 && numbers[i] % 2 == 0) {

                    sum += numbers[i];
                }
            }

            return sum;
        }

        private decimal CountScore(decimal[] slots, int slot) {

            decimal total = slots[slot];
            decimal repeats = Math.Floor(total / slots.Length);
            total -= repeats * slots.Length;
            slots[slot] = 0;

            for(int i = 0; i < slots.Length; i++) {

                slots[i] += repeats;
            }

            for(int i = 0; i < total; i++) {

                slot = (slot + 1) % slots.Length;
                slots[slot]++;
            }

            return SumEvenNumbers(slots);
        }

        public decimal GetMaxScore(string input) {

            var slots = GetNumbers(input);
            decimal max = 0;

            for(int i = 0; i < slots.Length; i++) {

                if(slots[i] > 0) {

                    max = Math.Max(max, CountScore(slots.ToArray(), i));
                }
            }

            return max;
        }
    }
}