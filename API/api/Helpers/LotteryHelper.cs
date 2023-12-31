using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Helpers
{
    public class LotteryHelper
    {
        public static int GetTimeSlot() {
            int timeSlot;
            var currentDateTime = DateTime.Now;

            if (currentDateTime.AddHours(1).Hour == 24) {
                timeSlot = 0;
            } else {
                timeSlot = currentDateTime.AddHours(1).Hour;
            }

            return timeSlot;
        }


        public static string GetCurrentLotteryCalendarFormat() {
            var currentDateTime = DateTime.Now;
            return currentDateTime.ToString("dd/MM/yyyy");
        }

    }
}