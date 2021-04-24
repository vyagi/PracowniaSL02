using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Geometry
{
    public class Network
    {
        public int[] Bits { get; }

        public Network(string networkAddress, int prefixLength)
        {
            if (!Regex.IsMatch(networkAddress, @"^((25[0-5]|(2[0-4]|1[0-9]|[1-9]|)[0-9])(\.(?!$)|$)){4}$"))
                throw new Exception();

            if (prefixLength>32 || prefixLength < 0)
                throw new Exception();


            //var t = networkAddress.Split(".").Select(x => Convert.ToString(Convert.ToInt32(x), 2).PadLeft(8, '0'));

           Bits = string.Join("", networkAddress.Split(".")
                .Select(x => Convert.ToString(Convert.ToInt32(x), 2).PadLeft(8, '0')))
               .Select(x=>int.Parse(x.ToString()))
               .ToArray();

           var network = Bits.Select((x, i) => i > prefixLength ? 0 : 1).ToArray();

           if (ne)
           {
           }


        }
    }
}
