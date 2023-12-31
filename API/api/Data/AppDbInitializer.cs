using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder) 
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context != null)
                {
                    context.Database.Migrate();

                    if (!context.Messages.Any())
                    {
                        await context.Messages.AddRangeAsync(new List<Msg>()
                        {
                            new Msg { Id = 1, MessageContent = "WELCOME BACK" },
                            new Msg { Id = 2, MessageContent = "PLEASE INPUT MORE INFORMATION FOR THE FIRST BUY LOTTERY" },
                            new Msg { Id = 3, MessageContent = "SUCCESSFULLY" },
                            new Msg { Id = 4, MessageContent = "FAILS" },
                            new Msg { Id = 5, MessageContent = "ERROS" },
                            new Msg { Id = 6, MessageContent = "OOPS. NOT SURE WHAT HAPPEND THERE.PLEASE TRY AGAIN!" },
                            new Msg { Id = 7, MessageContent = "OOPS. NO DATA HERE!" }
                        });
                        await context.SaveChangesAsync();
                    }

                    if (!context.Users.Any())
                    {
                        await context.Users.AddRangeAsync(new List<AppUser>()
                        {
                            new AppUser { 
                                Id = 1, 
                                FullName = "customer 1", 
                                PhoneNumber = "1111", 
                                Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-19).AddMonths(2)) 
                            },
                            new AppUser { 
                                Id = 2, 
                                FullName = "customer 2", 
                                PhoneNumber = "2222", 
                                Birthday = DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(5)) 
                            }
                        });
                        await context.SaveChangesAsync();
                    }
                    
                     if (!context.LotteryResults.Any())
                    {
                        await context.LotteryResults.AddRangeAsync(new List<LotteryResult>()
                        {
                            new LotteryResult { 
                                LotteryCalendar = DateOnly.FromDateTime(DateTime.Now),
                                LotteryCalendarFormat = LotteryHelper.GetCurrentLotteryCalendarFormat(),
                                Slot = LotteryHelper.GetTimeSlot() -2,
                                CreatedAt = DateTime.Now,
                                Results = 4
                            },
                            new LotteryResult { 
                                LotteryCalendar = DateOnly.FromDateTime(DateTime.Now),
                                LotteryCalendarFormat = LotteryHelper.GetCurrentLotteryCalendarFormat(),
                                Slot = LotteryHelper.GetTimeSlot() -1,
                                CreatedAt = DateTime.Now,
                                Results = 9
                            }
                        });
                        await context.SaveChangesAsync();
                    }
                     if (!context.LotteryDetails.Any())
                    {
                        await context.LotteryDetails.AddRangeAsync(new List<LotteryDetail>()
                        {
                            new LotteryDetail { 
                                AppUserId = 1,
                                LotteryResultId = 1,
                                Picks = 4,
                                WinFlg = 1
                            },
                            new LotteryDetail { 
                                AppUserId = 2,
                                LotteryResultId = 1,
                                Picks = 4,
                                WinFlg = 1
                            },
                            new LotteryDetail { 
                                AppUserId = 2,
                                LotteryResultId = 2,
                                Picks = 9,
                                WinFlg = 1
                            }
                        });
                        await context.SaveChangesAsync();
                    }

                    /// Nếu App chạy liên tục, Scheduled Tasks sẽ chạy các function này.
                    /// Nếu App không chạy liên tục thì sẽ được update trong AppDbInitializer.
                    /// Kiểm tra xem có time slot nào chưa xổ số thì tạo ra kết quả xổ số.
                    /// Và khởi tạo lottery slot hiện tại mỗi khi khởi động App để user có thể đặt.
                    await LotteryService.UpdateLotteryResult(context);

                    /// Kiểm tra xem có kết quả nào chưa update cho user thì update.
                    await LotteryService.UpdateUserLotteryResult(context);
                }
            }
        }
    }
}