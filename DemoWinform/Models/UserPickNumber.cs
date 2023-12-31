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
    public class UserPickNumber
    {      
        public int Id { get; set; }
        public int Pick { get; set; }
    }
}
