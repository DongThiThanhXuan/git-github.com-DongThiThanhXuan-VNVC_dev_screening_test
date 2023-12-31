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
    public class ResultLotteryDetails
    {
        public List<LotteryDetail> listLotteryDetails { get; set; }
        public Msg Msg { get; set; }
    }
}
