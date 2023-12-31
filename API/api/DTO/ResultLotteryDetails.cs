using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /// format kết quả trả về client sau khi kiểm tra thông tin user
    public class ResultLotteryDetails
    {
        public List<ResultLotteryDetailsUser> listLotteryDetails { get; set; }
        public Msg Msg { get; set; }
    }
}