using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MergeEquals {
    public class MergeEquals {

        private Dictionary<long, List<int>> Indexes { get; set; }

        private long[] ParseNumbers(string numbers) {

            return Regex.Matches(numbers, @"\d+")
                        .Cast<Match>()
                        .Select(match => long.Parse(match.Value))
                        .ToArray();
        }

        //record all indexes of numbers in an array
        private void GetIndexes(long[] numbers) {

            Indexes = new Dictionary<long, List<int>>();

            for(int i = 0; i < numbers.Length; i++) {

                if(!Indexes.ContainsKey(numbers[i])) {

                    Indexes[numbers[i]] = new List<int>();
                }

                Indexes[numbers[i]].Add(i);
            }
        }

        private List<long> GetKeys(Dictionary<long, List<int>> indexes) {

            return indexes.Select(pair => pair.Key).OrderBy(value => value).ToList();
        }

        //retrieve smaller key from key collections
        private long GetSmallerKey(List<long> oldKeys, List<long> newKeys, ref int oldIndex, ref int newIndex) {

            if(oldIndex < oldKeys.Count && newIndex < newKeys.Count) {

                return oldKeys[oldIndex] < newKeys[newIndex] ? oldKeys[oldIndex++] : newKeys[newIndex++];
            }
            //always retrieve from non-empty one when the other is empty
            return oldIndex < oldKeys.Count ? oldKeys[oldIndex++] : newKeys[newIndex++];
        }

        //add indexes of merged numbers
        private void AddIndexes(long oldKey, long newKey, List<long> newKeys) {

            if(!Indexes.ContainsKey(newKey)) {

                Indexes[newKey] = new List<int>();
                newKeys.Add(newKey);
            }
            //number on the right for every pair will become merged number
            for(int i = 1; i < Indexes[oldKey].Count; i += 2) {

                Indexes[newKey].Add(Indexes[oldKey][i]);
            }

            Indexes[newKey] = Indexes[newKey].OrderBy(value => value).ToList();
        }

        public long[] Merge(string numbers) {

            GetIndexes(ParseNumbers(numbers));
            var oldKeys = GetKeys(Indexes);
            var newKeys = new List<long>();
            var result = new Dictionary<long, int>();
            int i = 0;
            int j = 0;

            while(i < oldKeys.Count || j < newKeys.Count) {

                long oldKey = GetSmallerKey(oldKeys, newKeys, ref i, ref j);
                //record final position in resulting array
                if(Indexes[oldKey].Count % 2 == 1) {

                    result[oldKey] = Indexes[oldKey].Last();
                }
                //only merge when duplicate found
                if(Indexes[oldKey].Count == 1) {

                    continue;
                }

                AddIndexes(oldKey, oldKey * 2, newKeys);
            }

            return result.OrderBy(pair => pair.Value).Select(pair => pair.Key).ToArray();
        }
    }
}