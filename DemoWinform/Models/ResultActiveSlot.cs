using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuanXoSoKienThienConGaTrong.Models
{
    public class ResultActiveSlot
    {
        public DateOnly LotteryCalendar { get; set; }
        public int Slot { get; set; }

        public Msg Msg { get; set; }
    }
}
