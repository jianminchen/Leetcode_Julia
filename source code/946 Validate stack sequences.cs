using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _946_validate_statck_sequences
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            if (pushed == null || popped == null)
                return false;
            if (pushed.Length == 0 && popped.Length == 0)
                return true;
            if (pushed.Length != popped.Length)
                return false;

            var length = pushed.Length;

            var pushIndex = 0;
            var popIndex = 0;
            var stack = new Stack<int>();
            var hashset = new HashSet<int>();
            var removed = new HashSet<int>();

            while (pushIndex < length || popIndex < length)
            {
                var pop = popped[popIndex];

                if (removed.Contains(pop))
                    return false;

                if (stack.Count > 0 && stack.Peek() == pop)
                {
                    stack.Pop();
                    popIndex++;
                    hashset.Remove(pop);
                    continue;
                }

                if (hashset.Contains(pop))
                {
                    while (stack.Count > 0)
                    {
                        var number = stack.Pop();
                        hashset.Remove(number);
                        removed.Add(number);
                        if (number == pop)
                        {
                            popIndex++;
                            break;
                        }
                    }
                }
                else
                {
                    if (pushIndex < length)
                    {
                        var visit = pushed[pushIndex];
                        stack.Push(visit);
                        pushIndex++;
                        hashset.Add(visit);
                    }
                }
            }

            return pushIndex == length && popIndex == length;
        }
    }
}
