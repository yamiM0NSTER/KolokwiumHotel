using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumHotel
{
    interface IData
    {
        void UstawDate(DateTime Time);
        bool SprawdzDate(DateTime Time);
    }
}
