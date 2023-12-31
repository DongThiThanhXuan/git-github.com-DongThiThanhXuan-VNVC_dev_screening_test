using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /// Bảng lưu thông tin user chọn số nào
    public class LotteryDetail
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int LotteryResultId { get; set; }
        public LotteryResult LotteryResult { get; set; }

        public int Picks { get; set; } /// số user đã chọn
        public int WinFlg { get; set; } /// cái này để khi chạy schedule function so sánh kết quả: 0: chưa quay số, -1 là ko trúng, 1 là trúng
    }
}