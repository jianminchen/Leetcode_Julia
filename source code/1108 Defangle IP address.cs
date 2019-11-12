using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1108_Defangle_IP_address
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 1108 Defangle IP address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string DefangIPaddr(string address)
        {
            if (address == null || address.Length == 0)
                return "";

            var defangled = new StringBuilder();

            foreach (var item in address)
            {
                if (item == '.')
                {
                    defangled.Append("[.]");
                }
                else
                {
                    defangled.Append(item);
                }
            }

            return defangled.ToString();
        }
    }
}
