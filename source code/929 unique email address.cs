using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _929_unique_email_address
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int NumUniqueEmails(string[] emails)
        {
            if (emails == null || emails.Length == 0)
                return 0;

            var hashset = new HashSet<string>();
            foreach (var email in emails)
            {
                //need to figure out email address
                var split1 = email.Split('@');
                var domainName = split1[1];
                var name = split1[0];
                var userName = name.Split('+');
                var withDot = userName[0];
                var splitWithDot = withDot.Split('.');
                var address = string.Join("", splitWithDot);
                hashset.Add(address + "@" + domainName);
            }

            return hashset.Count;
        }
    }
}
