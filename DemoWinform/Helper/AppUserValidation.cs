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
using Microsoft.EntityFrameworkCore.Diagnostics;
using FluentValidation;
using XuanXoSoKienThienConGaTrong.Service;

namespace XuanXoSoKienThienConGaTrong.Helper
{
    public  class AppUserValidation : AbstractValidator<AppUser>
    {
        public AppUserValidation()
        {
            RuleFor(x => x.FullName)
                    .Length(1, 50).WithMessage("Length From 1 To 50")
                    .Matches(@"^[A-Za-z\s]*$").WithMessage("'{PropertyName}' should only contain letters.");
            /*RuleFor(x => x.Birthday)
                    .Must(d=> GetAValidDate(d)).WithMessage("You need to be older than 18 years old");*/
        }

        private async Task<bool> AValidDate(DateOnly date)
        {
            ResultActiveSlot resultActiveSlot= await GetDateTime.GetActiveSlot();
            DateOnly currentDateTime = resultActiveSlot.LotteryCalendar;
            bool checkUserAge = ((currentDateTime.Year - 18) < date.Year) ? false : true;
             return checkUserAge;

        }
        private  bool GetAValidDate(DateOnly date)
        {
            var task = AValidDate(date);
            task.Wait();
            bool res = task.Result;
            return res;

        }
    }
}
