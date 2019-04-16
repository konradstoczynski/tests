using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranks = new int[9] { 3, 4, 3, 0, 2, 2, 3, 0, 0 };

            var countPossibleReports = 0;

            Dictionary<int, int> rankings = ranks
                .GroupBy(item => item)
                .ToDictionary(item => item.Key, item => item.Count());

            foreach (KeyValuePair<int, int> entry in rankings)
            {
                var higherRank = entry.Key + 1;
                if (rankings.ContainsKey(higherRank))
                {
                    countPossibleReports += entry.Value;
                }
            }       
            return countPossibleReports;
        }
    }
}
