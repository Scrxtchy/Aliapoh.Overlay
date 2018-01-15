using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aliapoh.Overlay
{
    public static class IntExtender
    {
        public static bool Search(this int i, List<System.Windows.Forms.Keys> l)
        {
            foreach (var x in l)
                if (i == (int)x)
                    return true;

            return false;
        }

        public static bool Search(this int i, int[] l)
        {
            return Search(i, l);
        }

        public static bool Search(this int i, List<int> l)
        {
            return Search(i, l);
        }

        public static bool Search(this int i, IEnumerable<int> l)
        {
            foreach (var x in l)
                if (i == x)
                    return true;

            return false;
        }
    }
}
