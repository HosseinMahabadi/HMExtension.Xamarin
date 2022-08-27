using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMExtension.Xamarin
{
    public enum ShamsiMonthType
    {
        فروردین = 0,
        اردیبهشت = 1,
        خرداد = 2,
        تیر = 3,
        مرداد = 4,
        شهریور = 5,
        مهر = 6,
        آبان = 7,
        آذر = 8,
        دی = 9,
        بهمن = 10,
        اسفند = 11,
        نامشخص = -1
    }

    public enum CalendarType
    {
        Shamsi, Ghamari, Miladi,
    }
}
