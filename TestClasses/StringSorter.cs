using System;
using System.Collections.Generic;
using System.Linq;

namespace TestClasses
{
    public class StringSorter
    {
        //sort by length
        //and lowercase
        //Lsdfsd -> lsdfsd
        public string[] SortAndChangeCase(IEnumerable<string> strings, bool ascending = true, bool toLower = true)
        {
            if (strings == null)
            {
                return null;
            }
            return strings.ChangeCaseWithFlag(toLower).SortByLengthWithFlag(@ascending).ToArray();
        }
    }
}
