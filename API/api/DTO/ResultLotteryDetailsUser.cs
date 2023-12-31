using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /// format kết quả trả về client sau khi kiểm tra thông tin user
    public class ResultLotteryDetailsUser
    {
        public string LotteryCalendar { get; set; }
        public int Slot { get; set; }
        public string FullName { get; set; }
        public int Picks { get; set; }
        public int Results { get; set; }
        public int WinFlg { get; set; }
    }
}