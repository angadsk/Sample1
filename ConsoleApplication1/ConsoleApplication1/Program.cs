using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string initialString = "ccdaabcdbab";
            var substringList = new List<string> { "ab", "cd" };
            substringList = new List<string>(substringList.OrderByDescending(x => x.Length));

            var newS = initialString;
            while (substringList.Exists(newS.Contains))
            {
                substringList.ForEach(x => newS = newS.Replace(x, string.Empty));
            }
            Console.WriteLine(newS);

            // Find the pair whose difference is 2 i.e.
            int[] a = { 1, 5, 3, 4, 2 };
            int kj = 2;
            int count = 0;
            var abc = new Dictionary<int, int>();
            for (var ij = 0; ij < a.Length - 1; ij++)
            {
                for (var j = ij + 1; j < a.Length; j++)
                {
                    if (Math.Abs(a[ij] - a[j]) == kj)
                    {
                        if (!(abc.ContainsKey(a[ij]) || abc.ContainsValue(a[ij])))
                        {
                            Console.WriteLine(a[ij].ToString() + " : " + a[j].ToString());
                            abc.Add(a[ij], a[j]);
                            count++;
                        }
                        else
                        {
                            abc.Add(a[ij], a[j]);
                        }
                    }
                }
            }

            Console.WriteLine(count.ToString());

            // PrintPairs  sum of numbers in array is 6
            PrintPairs(a, 6);

            //PrintPairsLinq(a, 6);

            /// Find the Longest common substring
            int i = 9;
            Program tst = new Program();
            Console.WriteLine(tst.LongestCommonSubstring("Hello", "testMindHllo"));
            for (var j = 1; j < i + 1; j++)
            {
                int k = j;
                string strLadder = "";
                for (var m = i; m >= 1; m--)
                {
                    if (m <= k)
                    {
                        strLadder = strLadder + "#";
                    }
                    else
                    {
                        strLadder = strLadder + " ";
                    }

                }

                Console.WriteLine(strLadder);
            }

            // Check the equation is correct or not.
            bool error = false;
            var str = "( a[i]+-1}*(8-9) )";
            Stack<char> stack = new Stack<char>();
            for (int index = 0; index < str.ToCharArray().Length; index++)
            {
                var item = str.ToCharArray()[index];
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                }
                else if (item == ')' || item == '}' || item == ']')
                {
                    if (stack.Peek() != GetComplementBracket(item))
                    {
                        error = true;
                        break;
                    }
                    stack.Pop();
                }
            }

            if (error || stack.Count > 0)
                Console.WriteLine("Incorrect brackets");
            else
                Console.WriteLine("Brackets are fine");
            Console.ReadLine();

            Console.ReadLine();
        }

        private static char GetComplementBracket(char item)
        {
            switch (item)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default:
                    return ' ';
            }
        }

        public int LongestCommonSubstring(string str1, string str2)
        {
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
                return 0;

            int[,] num = new int[str1.Length, str2.Length];
            int maxlen = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                        }
                    }
                }
            }
            return maxlen;
        }

        public int LongestCommonSubstring(string str1, string str2, out string sequence)
        {
            sequence = string.Empty;
            if (String.IsNullOrEmpty(str1) || String.IsNullOrEmpty(str2))
                return 0;

            int[,] num = new int[str1.Length, str2.Length];
            int maxlen = 0;
            int lastSubsBegin = 0;
            StringBuilder sequenceBuilder = new StringBuilder();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] != str2[j])
                        num[i, j] = 0;
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];
                            int thisSubsBegin = i - num[i, j] + 1;
                            if (lastSubsBegin == thisSubsBegin)
                            {//if the current LCS is the same as the last time this block ran
                                sequenceBuilder.Append(str1[i]);
                            }
                            else //this block resets the string builder if a different LCS is found
                            {
                                lastSubsBegin = thisSubsBegin;
                                sequenceBuilder.Length = 0; //clear it
                                sequenceBuilder.Append(str1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }
            sequence = sequenceBuilder.ToString();
            return maxlen;
        }

        public static void PrintPairs(int[] arr, int sumOfNumbers)
        {
            List<int> arrayItemList = new List<int>();
            foreach (var item in arr)
            {
                var remainingvalue = sumOfNumbers - item;
                if (arrayItemList.Contains(remainingvalue))
                {
                    Console.WriteLine(item + " : " + remainingvalue);
                }
                else
                {
                    arrayItemList.Add(item);
                }
            }
        }

        
    }
}
