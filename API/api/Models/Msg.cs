using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /// Bảng lưu các nội dung message hiển thị cho người dùng 
    public class Msg
    {
        public int Id { get; set; }
        public string MessageContent { get; set; }
    }
}