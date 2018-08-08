using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Readify.Controllers
{
    [Produces("application/json")]
    [Route("api/TriangleType")]
    public class TriangleTypeController : Controller
    {
        public string Get(int a, int b, int c)
        {
            ProperNested("(()(())()())()");
            ProperNested("(()(())())");

            CountDistinct(new int[] { 2, 1, 1, 2, 3, 1 });

            FindMissing(new int[] { 2, 3, 1, 5 });

            Rotate(new int[] { 1, 2, 3, 4 }, 4);

            Longest(1041);

            if (a == b && b == c)
            {
                return "Equilateral";
            }



            return "Error";
        }

        private int Longest(int N)
        {
            string binaryString = Convert.ToString(N, 2);

            int total = binaryString.Count();
            var ones = new List<int>();

            for (int index = 0; index < total; index++)
            {
                if (binaryString[index] == '1')
                {
                    ones.Add(index);
                }
            }

            int maxLength = 0;

            for (int index = 0; index < ones.Count - 1; index++)
            {
                var currentLength = (ones[index] - ones[index + 1]) *-1;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength - 1;
                }
            }

            Console.WriteLine(maxLength);

            return 0;
        }

        private int[] Rotate(int[] A, int K)
        {
            int total = A.Count();

            if (total == 0)
            {
                return new int[] { };
            }

            for (int counts = 0; counts < K; counts++)
            {
                var tempList = new List<int>();
                int last = A[total - 1];
                tempList.Add(last);

                for (int index = 0; index < total - 1; index++)
                {
                    tempList.Add(A[index]);
                }

                A = tempList.ToArray();
            }

            return A;
        }

        private int FindMissing(int[] A)
        {
            int total = A.Count();

            if (total == 0)
            {
                return 0;
            }

            if (total == 1)
            {
                return A[0];
            }
                
            Array.Sort(A);
            
            for (int index = 0; index < total; index++)
            {
                if (A[index] != index + 1)
                {
                    return index + 1;
                }
            }

            return 0;
        }

        private int CountDistinct(int[] A)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in A)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, item);
                }
            }

            return dict.Count;
        }

        private int ProperNested(string S)
        {
            var stack = new Stack<char>();
            int total = S.Count();

            for (int index = 0; index < total; index++)
            {
                var current = S[index];

                if (index == total - 1)
                {
                    if (stack.Count == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        var inStack = stack.Pop();

                        if (inStack == '(' && current == ')')
                        {
                            return 1;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }

                if (index + 1 < total)
                {
                    var next = S[index + 1];

                    if (current == '(' && next == ')')
                    {
                        index++;
                        continue;
                    }
                    else if (stack.Count > 0)
                    {
                        var inStack = stack.Pop();

                        if (inStack == '(' && current == ')')
                        {
                            continue;
                        }
                        else
                        {
                            stack.Push(inStack);
                            stack.Push(current);
                        }
                    }
                    else
                    {
                        stack.Push(current);
                    }
                }
            }

            if (stack.Count == 0)
            {
                return 1;
            }

            return 0;
        }
    }

}