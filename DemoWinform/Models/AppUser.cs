using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuanXoSoKienThienConGaTrong.Helper;
using System.Text.Json.Serialization;

namespace XuanXoSoKienThienConGaTrong.Models
{
    public class AppUser
    {      
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
