using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Union_Find_Algorithm
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
        /// Leetcode 721
        /// https://leetcode.com/problems/accounts-merge/
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            var emailSet = getAllEmails(accounts);

            // https://leetcode.com/problems/accounts-merge/discuss/164699/C-Solution-(Union-Find)-beats-91.49
            var emailList = emailSet.ToList();
            
            var ordCmp = StringComparer.Ordinal;
            emailList.Sort(ordCmp);            

            var emailNameMap = getEmailNameMap(accounts);
            var emailIdmap = new Dictionary<string, int>();

            int index = 0;
            var emailLookup = new List<string>();
            foreach (var item in emailList)
            {
                emailIdmap.Add(item, index);
                index++;
                emailLookup.Add(item); 
            }

            var unionFind = new QuickUnion(emailSet.Count);
            unionFind.EmailIdMap = emailIdmap;

            foreach (var list in accounts)
            {
                for (int i = 1; i < list.Count - 1; i++)
                {
                    var email1 = list[i];
                    var email2 = list[i + 1];

                    var connected = unionFind.Connected(email1, email2);
                    if (!connected)
                    {
                        unionFind.Union(email1, email2);
                    }
                }
            }

            // flat the tree
            for (int i = 0; i < emailSet.Count; i++)
            {
                unionFind.QuickFindAndPathCompression(i);
            }

            var dict = new Dictionary<int, List<string>>();
            var parent = unionFind.GetParent();

            for (int i = 0; i < parent.Length; i++)
            {
                var key = parent[i];
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }

                dict[key].Add(emailLookup[i]); 
            }

            // output a list
            var result = new List<IList<string>>(); 
            foreach (var item in dict.Keys)
            {
                var list = new List<string>();
                var email = emailLookup[item];
                var name = emailNameMap[email];

                list.Add(name);

                var values = dict[item];
                list.AddRange(values);

                result.Add(list);
            }

            return result; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        private static HashSet<string> getAllEmails(IList<IList<string>> accounts)
        {
            var hashset = new HashSet<string>(); 

            foreach (var item in accounts)
            {
                foreach(var str in item)
                {
                    if(str.Contains('@'))    
                    {
                        hashset.Add(str); 
                    }
                }                                
            }

            return hashset; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        private static Dictionary<string, string> getEmailNameMap(IList<IList<string>> accounts)
        {
            var map = new Dictionary<string, string>();

            foreach (var item in accounts)
            {
                for(int i = 1; i < item.Count; i++)
                {
                    var email = item[i];
                    if (!map.ContainsKey(email))
                    {
                        map.Add(email, item[0]);
                    }                   
                }
            }

            return map;
        }

        /// <summary>
        /// 2019-March 26
        /// Union API is updated. 
        /// 
        /// May 28, 2018
        /// 
        /// Julia likes to write her own union find algorithm
        /// The coach spent almost 100 minutes in the mock interview to show her 
        /// the solution, and also he wrote two functions called 
        /// QuickFind() and Union()
        /// 
        /// source code reference used:
        /// https://gist.github.com/jianminchen/cb889def70be4563581113daa8a8fb2a
        /// </summary>
        internal class QuickUnion
        {
            private int[] parent { get; set; }

            private int count { get; set; }

            public Dictionary<string, int> EmailIdMap { get; set; }

            public int[] GetParent()
            {
                return parent;
            }

            public QuickUnion(int number)
            {
                if (number <= 0)
                {
                    return;
                }

                count = number;
                parent = new int[number];

                for (int i = 0; i < number; i++)
                {
                    parent[i] = i;
                }
            }

            public int GetCount()
            {
                return count;
            }

            /// <summary>
            /// Find group id given the node value
            /// </summary>
            /// <returns></returns>
            public int QuickFind(int search)
            {
                if (search < 0)
                {
                    return -1;
                }

                if (search == parent[search])
                {
                    return search;
                }

                return QuickFind(parent[search]);
            }

            /// <summary>
            /// Reset all parent node's to its original ancestor
            /// path compression - all node's parent will be reset to its ancestor
            /// </summary>
            /// <returns></returns>
            public int QuickFindAndPathCompression(int search)
            {
                if (search == parent[search])
                {
                    return search;
                }

                int root = QuickFindAndPathCompression(parent[search]);

                parent[search] = root;

                return root;
            }

            public void Union(string email1, string email2)
            {
                int p = EmailIdMap[email1];
                int q = EmailIdMap[email2];

                Union(p, q);
            }
            /// <summary>
            /// code review March 26, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            public void Union(int p, int q)
            {
                //int pRoot = QuickFind(p);
                //int qRoot = QuickFind(q);

                int pRoot = QuickFindAndPathCompression(p);
                int qRoot = QuickFindAndPathCompression(q);

                if (pRoot == qRoot)
                {
                    return;
                }

                // set one tree to another tree's subtree
                parent[pRoot] = qRoot;

                // update count of groups
                count--;
            }

            public bool Connected(string email1, string email2)
            {
                var p = EmailIdMap[email1];
                var q = EmailIdMap[email2];

                return Connected(p, q); 
            }

            /// <summary>
            /// code review March 6, 2019
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            public bool Connected(int p, int q)
            {
                return QuickFind(p) == QuickFind(q);
            }
        }
    }
}
