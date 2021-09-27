using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_3
{
    public interface ISortTypes
    {
        bool AscFlag { get; set; }
        int Compare(int comp1, int comp2);
    }
}
