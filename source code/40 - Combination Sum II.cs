public class Solution
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        int[] counts = new int[target + 1];

        foreach (var number in candidates)
        {
            if (number <= target)
            {
                counts[number]++;
            }
        }

        // get integer values less than target value in candidates array
        var numbers = new List<int>();

        for (int i = 1; i <= target; i++)
        {
            if (counts[i] != 0)
            {
                numbers.Add(i);
            }
        }

        if (numbers.Count == 0)
        {
            return new List<IList<int>>();
        }

        //
        var subsets = new List<IList<int>>[target + 1];

        var emptySubset = new List<IList<int>>();
        emptySubset.Add(new List<int>());

        subsets[0] = emptySubset;  // ?

        for (int start = numbers[0]; start <= target; start++)
        {
            var subset = new List<IList<int>>();
            var sumTarget = start;

            foreach (var number in numbers)
            {
                bool biggerThanStart = number > sumTarget;
                bool numberGoToDp = number == sumTarget || number <= sumTarget / 2;

                if (biggerThanStart)
                {
                    break;
                }

                if (!numberGoToDp)
                {
                    continue; // how to interpret? 
                }

                var list = subsets[start - number];

                foreach (var numbersToCheck in list)
                {
                    if (numbersToCheck.Count == 0 || numbersToCheck[0] >= number)
                    {
                        int count = counts[number];

                        foreach (var num in numbersToCheck)
                        {
                            if (num == number)
                            {
                                count--;
                            }
                        }

                        if (count != 0)
                        {
                            subset.Add(addNumberToFrontOfList(numbersToCheck, number));
                        }
                    }
                }
            }

            subsets[start] = subset;
        }

        return subsets[target];
    }

    private static List<int> addNumberToFrontOfList(IList<int> numbers, int head)
    {
        var list = new List<int>();

        list.Add(head);

        foreach (int number in numbers)
        {
            list.Add(number);
        }

        return list;
    }
}