using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeASquare {
    public class MakeASquare {

        //check if given number is the square of another integer
        private bool IsSquare(int number) {

            return Math.Pow((int)Math.Sqrt(number), 2) == number;
        }

        private int MakeNumber(string digits, bool[] used) {

            var number = new StringBuilder();

            for(int i = 0; i < used.Length; i++) {

                if(used[i]) {

                    number.Append(digits[i]);
                }
            }

            return int.Parse(number.ToString());
        }

        private bool IsValid(string digits, bool[] used) {

            for(int i = 0; i < used.Length; i++) {
                //leading zero or empty value is not allowed
                if(used[i]) {

                    return digits[i] != '0';
                }
            }

            return false;
        }

        //deselect digit on given index
        private bool[] Deselect(bool[] used, int index) {

            bool[] deselected = used.ToArray();
            deselected[index] = false;

            return deselected;
        }

        //find minimum number of digits to remove to create square of an integer
        private void GetMinStep(int counter, int current, string digits, bool[] used, ref int min) {

            if(IsValid(digits, used) && IsSquare(MakeNumber(digits, used))) {

                min = min == -1 ? current : Math.Min(current, min);

                return;
            }

            if(counter == digits.Length) {

                return;
            }
            //one can choose to use or not use current digit
            GetMinStep(counter + 1, current + 1, digits, Deselect(used, counter), ref min);
            GetMinStep(counter + 1, current, digits, used, ref min);
        }

        private bool[] GetArray(int total, bool value) {

            return new bool[total].Select(element => value).ToArray();
        }

        public int MinStep(string digits) {

            int steps = -1;
            GetMinStep(0, 0, digits, GetArray(digits.Length, true), ref steps);

            return steps;
        }
    }
}