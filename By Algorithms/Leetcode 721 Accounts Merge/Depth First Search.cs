using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _721___DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<IList<string>>();

            var list1 = new List<string>(new string[] { "John", "johnsmith@mail.com", "john00@mail.com" });
            var list2 = new List<string>(new string[] { "John", "johnnybravo@mail.com" });
            var list3 = new List<string>(new string[] { "John", "johnsmith@mail.com", "john_newyork@mail.com" });
            var list4 = new List<string>(new string[] { "Mary", "mary@mail.com" });

            accounts.Add(list1);
            accounts.Add(list2);
            accounts.Add(list3);
            accounts.Add(list4);

            var result = AccountsMerge(accounts);
        }

        /// <summary>
        /// study code 
        /// https://leetcode.com/problems/accounts-merge/discuss/149433/C%3A-Easy-to-understand-readable-solution.-Build-graph-of-emails-and-do-DFS.
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var graphOfEmails  = new Dictionary<String, HashSet<string>>();  //<Email -> NeighboringEmail
            var emailToNameMap = new Dictionary<string, string>();           //<Email-> Name         

            foreach (var account in accounts)
            {
                var name = account[0];

                for (int i = 1; i < account.Count; i++)
                {
                    var current = account[i];

                    if (!graphOfEmails.ContainsKey(current))
                    {
                        graphOfEmails.Add(current, new HashSet<string>());
                    }

                    emailToNameMap[current] = name;

                    if (i == 1)
                    {
                        continue;
                    }

                    var previous = account[i - 1];

                    graphOfEmails[current].Add(previous);
                    graphOfEmails[previous].Add(current);
                }
            }

            //DFS
            var mergedAccounts = new List<IList<string>>();
            var visited = new List<string>();

            foreach (var email in emailToNameMap.Keys)
            {
                if (!visited.Contains(email))
                {
                    var connectedEmails = new SortedSet<string>(StringComparer.Ordinal);

                    DFS(graphOfEmails, email, connectedEmails, visited);

                    var mergedAccount = new List<string>();

                    mergedAccount.Add(emailToNameMap[email]);

                    foreach (string connectedEmail in connectedEmails)
                    {
                        mergedAccount.Add(connectedEmail);
                    }

                    mergedAccounts.Add(mergedAccount);
                }
            }

            return mergedAccounts;
        }

        /// <summary>
        /// code review on March 29, 2019
        /// </summary>
        /// <param name="graphOfEmails"></param>
        /// <param name="email"></param>
        /// <param name="connectedEmails"></param>
        /// <param name="visited"></param>
        private static void DFS(Dictionary<string, HashSet<string>> graphOfEmails, string email, SortedSet<string> connectedEmails, List<string> visited)
        {
            if (visited.Contains(email))
            {
                return;
            }

            connectedEmails.Add(email);
            visited.Add(email);

            var neighboringEmails = graphOfEmails[email];

            foreach (string neighboringEmail in neighboringEmails)
            {
                DFS(graphOfEmails, neighboringEmail, connectedEmails, visited);
            }
        }
    }
}
