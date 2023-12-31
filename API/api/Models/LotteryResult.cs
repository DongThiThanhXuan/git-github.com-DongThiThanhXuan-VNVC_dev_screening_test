using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /// Bảng lưu kết quả sổ số
    public class LotteryResult
    {
        public int Id { get; set; }
        public DateOnly LotteryCalendar { get; set; }
        public string LotteryCalendarFormat { get; set; } /// để dễ và tối ưu truy vấn 
        public int Slot { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Results { get; set; } /// bằng -1 nếu chưa đến giờ xổ
    }
}