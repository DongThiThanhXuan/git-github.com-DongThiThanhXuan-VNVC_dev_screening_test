using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace XuanXoSoKienThienConGaTrong.Models
{
    public class DataGrid
    {

        public DateOnly LotteryCalendar { get; set; }
        public int Slot { get; set; }
        public String FullName { get; set; }
        public int Picks { get; set; }
        public int Results { get; set; }
        public string WinFlg { get; set; }
        

    }
}
