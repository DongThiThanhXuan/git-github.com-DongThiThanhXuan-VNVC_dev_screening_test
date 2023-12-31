using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using XuanXoSoKienThienConGaTrong.Common;
using XuanXoSoKienThienConGaTrong.Models;
using XuanXoSoKienThienConGaTrong.Service;

namespace XuanXoSoKienThienConGaTrong.Helper
{
    public static class ValidateHelper
    {
        private static readonly string regexPhoneNumber = "^[0-9]{4,10}$";
        private static readonly string regexPickNumber = "^[0-9]{1}$";
        private static readonly string regexFullName = @"^[A-Za-z\s]{1,50}$";

        public static Msg ValidatePhone(string Phone)
        {
            if (!Regex.Match(Phone, regexPhoneNumber).Success)
            {
                return new Msg
                {
                    Id = -1,
                    MessageTitle = CommonMsg.TITLE_ERROS,
                    MessageContent = CommonMsg.WRONG_FORMAT + "\n Only Input number And Length From 4 To 10",
                };
            }
            else
            {
                return new Msg
                {
                    Id = 0
                };
            }
        }
        public static string ValidatePickNumber(string number)
        {
            if (!Regex.Match(number, regexPickNumber).Success)
            {
                return CommonMsg.WRONG_FORMAT + ", Only Input number from 0 to 9";
            }
            else
            {
                return "";
            }
        }

        public static string ValidateFullName(string fullName)
        {
            Debug.WriteLine(Regex.Match(fullName, regexFullName).Success);
            if (!Regex.Match(fullName, regexFullName).Success)
            {
                return CommonMsg.WRONG_FORMAT + ", Full Name should only contain letters.";
            }
            else
            {
                return "";
            }
        }

        public static string ValidateDOB(DateOnly d)
        {

            if (!GetAValidDate(d))
            {
                return CommonMsg.WRONG_FORMAT + ", You need to be older than 18 years old";
            }
            else
            {
                return "";
            }
        }


        private async static Task<bool> AValidDate(DateOnly date)
        {
            ResultActiveSlot resultActiveSlot = await GetDateTime.GetActiveSlot();
            DateOnly currentDateTime = resultActiveSlot.LotteryCalendar;
            bool checkUserAge = ((currentDateTime.Year - 18) < date.Year) ? false : true;
            return checkUserAge;

        }
        private static bool GetAValidDate(DateOnly date)
        {
            var task = AValidDate(date);
            task.Wait();
            bool res = task.Result;
            return res;

        }
    }
}
