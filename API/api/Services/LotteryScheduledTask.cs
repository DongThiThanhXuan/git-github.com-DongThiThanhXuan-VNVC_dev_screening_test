using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Quartz;

// [DisallowConcurrentExecution]
namespace api.Services
{
    public class LotteryScheduledTask : IJob
    {
        private readonly ApplicationDbContext _dbContext;

        public LotteryScheduledTask(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task Execute(IJobExecutionContext context) {
            /// Tạo kết quả xổ số. Và Khởi tạo lottery slot mới để user có thể đặt.
            await LotteryService.UpdateLotteryResult(_dbContext);

            /// Update kết quả xổ số cho user
            await LotteryService.UpdateUserLotteryResult(_dbContext);
        }

    }
}