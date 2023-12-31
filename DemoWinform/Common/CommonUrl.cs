using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuanXoSoKienThienConGaTrong.Common
{
    public static class CommonUrl
    {
        public static string GET_USER_BY_PHONENUMBER = "http://localhost:5000/api/user/";
        public static string SAVE_USER = "https://localhost:5001/api/user";
        public static string GET_ACTIVE_SLOT = "https://localhost:5001/api/lottery/active-slot";
        public static string SAVE_LOTTERY = "https://localhost:5001/api/lottery";
        public static string GET_LOTTERY_OF_USER = "https://localhost:5001/api/lottery/";
        public static string GET_WIN_LIST = "https://localhost:5001/api/lottery/win_list";
    }
}
