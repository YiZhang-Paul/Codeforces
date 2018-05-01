using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AramicScript {
    public class AramicScript {

        private string[] GetWords(string input) {

            return Regex.Matches(input, @"\w+")
                        .Cast<Match>()
                        .Select(match => match.Value)
                        .ToArray();
        }

        private string GetRoot(string word) {

            return string.Join("", new HashSet<char>(word).OrderBy(letter => letter));
        }

        public int CountObjects(string input) {

            return new HashSet<string>(GetWords(input).Select(GetRoot)).Count;
        }
    }
}