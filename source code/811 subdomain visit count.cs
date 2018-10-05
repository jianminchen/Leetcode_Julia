using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _811_subdomain_visit_count
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Oct. 5, 2018
        /// </summary>
        /// <param name="cpdomains"></param>
        /// <returns></returns>
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            if (cpdomains == null)
                return new List<string>();

            var numberForDomains = new List<string>();

            var domainCount = new Dictionary<string, int>();

            foreach (var item in cpdomains)
            {
                var split = item.Split(' ');
                var number = Convert.ToInt32(split[0].Trim());
                var domainStr = split[1].Trim();

                var domains = domainStr.Split('.');
                var dotCount = domains.Length;   // should be domains

                // domain 1
                if(!domainCount.ContainsKey(domainStr))
                {
                    domainCount.Add(domainStr, 0);
                }

                domainCount[domainStr] += number; 

                // domain 2
                var domain2 = dotCount == 3 ? (domains[1] + '.' + domains[2]) : domains[1];
                if (!domainCount.ContainsKey(domain2))
                {
                    domainCount.Add(domain2, 0);
                }

                domainCount[domain2] += number; 

                // domain 3
                if (dotCount == 3)
                {
                    var domain3 = domains[2];

                    if (!domainCount.ContainsKey(domain3))
                    {
                        domainCount.Add(domain3, 0);
                    }

                    domainCount[domain3] += number; 
                }
            }

            foreach (var pair in domainCount)
            {
                numberForDomains.Add(pair.Value + " " + pair.Key); 
            }

            return numberForDomains;
        }
    }
}
