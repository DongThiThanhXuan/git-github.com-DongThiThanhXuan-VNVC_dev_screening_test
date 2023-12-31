using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class LotteryService
    {
        /// Sử dụng static và dbcontext ở đây vì cần chạy trong Data/AppDbInitializer.cs

        /// Tạo kết quả xổ số.
        public static async Task UpdateLotteryResult(ApplicationDbContext context) {
            var activeLotteryResult = await GetActiveLottery(context);
            List<LotteryResult> lotteryResults = await context.LotteryResults
                    .Where(l => l.Results == -1
                            && !(l.LotteryCalendarFormat == activeLotteryResult.LotteryCalendarFormat && l.Slot == activeLotteryResult.Slot))
                    .ToListAsync();
            for (int i = 0; i < lotteryResults.Count; i++) { 
                var updateLotteryResult = await context.LotteryResults.FindAsync(lotteryResults[i].Id);

                /// tạo random number để update kết quả xổ số
                Random random = new Random();
                updateLotteryResult.Results = random.Next(0, 9);

                context.LotteryResults.Update(updateLotteryResult);
                await context.SaveChangesAsync();
            }
        }


        /// Khởi tạo lottery slot hiện tại mỗi khi khởi động App để user có thể đặt.
        public static async Task<LotteryResult> GetActiveLottery(ApplicationDbContext context) {
            var activeLotteryResult = new LotteryResult {
                LotteryCalendar = DateOnly.FromDateTime(DateTime.Now),
                LotteryCalendarFormat = LotteryHelper.GetCurrentLotteryCalendarFormat(),
                Slot = LotteryHelper.GetTimeSlot(),
                CreatedAt = DateTime.Now,
                Results = -1
            };
            
            bool lotteryResultExist = await context.LotteryResults
                                            .AnyAsync(l => l.LotteryCalendarFormat == activeLotteryResult.LotteryCalendarFormat
                                                    && l.Slot == activeLotteryResult.Slot);

            if (!lotteryResultExist) {
                await context.LotteryResults.AddAsync(activeLotteryResult);
                await context.SaveChangesAsync();
            } else {
                activeLotteryResult = await context.LotteryResults
                                            .Where(l => l.LotteryCalendarFormat == activeLotteryResult.LotteryCalendarFormat
                                                    && l.Slot == activeLotteryResult.Slot).FirstOrDefaultAsync();

                /// trường hợp này chỉ xảy ra khi thời gian trên đồng hồ server bị thay đổi khi test, reset kết quả về -1
                if (activeLotteryResult.Results > -1) {
                    activeLotteryResult.Results = -1;
                    context.LotteryResults.Update(activeLotteryResult);
                    await context.SaveChangesAsync();
                }
            }

            return activeLotteryResult;
        }


        /// Update kết quả xổ số cho user
        public static async Task UpdateUserLotteryResult(ApplicationDbContext context) {
            List<LotteryDetail> lotteryDetails = await context.LotteryDetails.Where(l => l.WinFlg == 0).Include(l => l.LotteryResult).ToListAsync();

            for (int i = 0; i < lotteryDetails.Count; i++) {
                var foundLotteryResult = await context.LotteryResults.FindAsync(lotteryDetails[i].LotteryResult.Id);
                
                if (foundLotteryResult.Results > -1) {
                    var updateLotteryDetail = await context.LotteryDetails.FindAsync(lotteryDetails[i].Id);

                    if (lotteryDetails[i].Picks == foundLotteryResult.Results) {
                        updateLotteryDetail.WinFlg = 1;
                    } else {
                        updateLotteryDetail.WinFlg = -1;
                    }
                    
                    context.LotteryDetails.Update(updateLotteryDetail);
                    await context.SaveChangesAsync();
                }
                
            }
        }
    }
}