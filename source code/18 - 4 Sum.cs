public class Solution
{
    public IList<IList<int>> FourSum(int[] numbers, int target)
    {
        var quadruplets = new List<IList<int>>();

        if (numbers == null || numbers.Length == 0)
        {
            return quadruplets;
        }

        Array.Sort(numbers);

        var firstTwoNumbersSums = new Dictionary<int, IList<int[]>>();
        var quadrupletsUnique = new HashSet<string>();

        int length = numbers.Length;

        for (int third = 0; third < length - 1; third++)
        {
            var thirdNumber = numbers[third];

            for (int fourth = third + 1; fourth < length; fourth++)
            {
                var fourthNumber = numbers[fourth];
                var lastTwoSum = thirdNumber + fourthNumber;

                var search = target - lastTwoSum;

                if (!firstTwoNumbersSums.ContainsKey(search))
                {
                    continue;
                }

                foreach (var item in firstTwoNumbersSums[search])
                {
                    var firstNumber = numbers[item[0]];
                    var secondNumber = numbers[item[1]];

                    var quadruplet = new int[] { firstNumber, secondNumber, thirdNumber, fourthNumber };
                    var key = string.Join(",", quadruplet);
                    if (!quadrupletsUnique.Contains(key))
                    {
                        quadrupletsUnique.Add(key);
                        quadruplets.Add(new List<int>(quadruplet));
                    }
                }
            }

            // It is time to add visited element into two sum dictionary.
            // Argue that no need to add any two indexes smaller than third, why?            
            for (int firstId = 0; firstId < third; firstId++)
            {
                var firstNumber = numbers[firstId];
                var firstTwoSum = firstNumber + thirdNumber;

                var newItems = new int[] { firstId, third };

                if (!firstTwoNumbersSums.ContainsKey(firstTwoSum))
                {
                    var items = new List<int[]>();

                    firstTwoNumbersSums.Add(firstTwoSum, items);
                }

                firstTwoNumbersSums[firstTwoSum].Add(newItems);
            }
        }

        return quadruplets;
    }
}