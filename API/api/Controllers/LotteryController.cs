using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.Data;
using api.Helpers;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotteryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LotteryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LotteryResult>>> GetLotteryResults()
        {
            List<LotteryResult> lotteries = await _context.LotteryResults.ToListAsync();
            return Ok(lotteries);
        }


        /// user đặt số từ 0 -> 9
        /// Ghi chú: chỉ cho phép user đặt 1 số trong mỗi slot lottery.
        [HttpPost]
        public async Task<ActionResult<ResultLotteryDetails>> PickLotteryNumber(UserPickNumber userPickNumber)
        {
            Msg msg = new Msg();
            ResultLotteryDetails result = new ResultLotteryDetails();
            int userId = userPickNumber.Id;
            int pickNumber = userPickNumber.Pick;
            try
            {
                LotteryResult activeLotteryResult = await LotteryService.GetActiveLottery(_context);
                AppUser user = await _context.Users.FindAsync(userId);

                LotteryDetail lotteryDetail;
                var lotteryResultExists = await _context.LotteryDetails
                                    .AnyAsync(l => l.AppUserId == user.Id && l.LotteryResultId == activeLotteryResult.Id);

                if (lotteryResultExists)
                { /// Update số đặt mới của user
                    lotteryDetail = await _context.LotteryDetails.Where(l => l.AppUserId == user.Id && l.LotteryResultId == activeLotteryResult.Id).FirstOrDefaultAsync();
                    lotteryDetail.Picks = pickNumber;
                    lotteryDetail.WinFlg = CommonMsg.WAIT_DRAW_STT;
                }
                else
                {
                    lotteryDetail = new LotteryDetail
                    {
                        AppUser = user,
                        LotteryResult = activeLotteryResult,
                        Picks = pickNumber,
                        WinFlg = CommonMsg.WAIT_DRAW_STT
                    };
                }
                _context.LotteryDetails.Update(lotteryDetail);
                await _context.SaveChangesAsync();
                List<ResultLotteryDetailsUser> resultLotteryDetailsUsers = await _context.LotteryDetails
                                                                        .Where(l => l.AppUserId == userId)
                                                                        .Include(l => l.AppUser)
                                                                        .Include(l => l.LotteryResult)
                                                                        .Select(x => new ResultLotteryDetailsUser
                                                                        {
                                                                            LotteryCalendar = x.LotteryResult.LotteryCalendarFormat,
                                                                            Slot = x.LotteryResult.Slot,
                                                                            FullName = x.AppUser.FullName,
                                                                            Picks = x.Picks,
                                                                            Results = x.LotteryResult.Results,
                                                                            WinFlg = x.WinFlg
                                                                        })
                                                                        .ToListAsync();
                msg.Id = CommonMsg.MSG_SAVE_SUCCESSFULl;
                var temp = await _context.Messages.FindAsync(msg.Id);
                msg.MessageContent = temp.MessageContent;
                result.listLotteryDetails = resultLotteryDetailsUsers;
                result.Msg = msg;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = new ResultLotteryDetails();
                msg.Id = CommonMsg.MSG_ERROS_EX;
                var temp = await _context.Messages.FindAsync(msg.Id);
                msg.MessageContent = temp.MessageContent;
                result.Msg = msg;
            }


            return Ok(result);
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<ResultLotteryDetails>> GetLotteryByUserId(int userId)
        {
            Msg msg = new Msg();
            ResultLotteryDetails result = new ResultLotteryDetails();
            try
            {
                List<ResultLotteryDetailsUser> resultLotteryDetailsUsers = await _context.LotteryDetails
                                                        .Where(l => l.AppUserId == userId)
                                                        .Include(l => l.AppUser)
                                                        .Include(l => l.LotteryResult)
                                                        .Select(x => new ResultLotteryDetailsUser
                                                        {
                                                            LotteryCalendar = x.LotteryResult.LotteryCalendarFormat,
                                                            Slot = x.LotteryResult.Slot,
                                                            FullName = x.AppUser.FullName,
                                                            Picks = x.Picks,
                                                            Results = x.LotteryResult.Results,
                                                            WinFlg = x.WinFlg
                                                        })
                                                        .ToListAsync();

                if (resultLotteryDetailsUsers.Count() > 0)
                {
                    msg.Id = CommonMsg.MSG_SAVE_SUCCESSFULl;

                  result.listLotteryDetails=  resultLotteryDetailsUsers;
                }
                else
                {
                    msg.Id = CommonMsg.MSG_NO_HAS_DATA;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = new ResultLotteryDetails();
                msg.Id = CommonMsg.MSG_ERROS_EX;
            }
            var temp = await _context.Messages.FindAsync(msg.Id);
            msg.MessageContent = temp.MessageContent;
            result.Msg = msg;
            return Ok(result);
        }

        [HttpGet("win_list")]
        public async Task<ActionResult<ResultLotteryDetails>> GetWinList()
        {
            Msg msg = new Msg();
            ResultLotteryDetails result = new ResultLotteryDetails();
            try
            {
                List<ResultLotteryDetailsUser> resultLotteryDetailsUsers = await _context.LotteryDetails
                                                        .Where(l => l.WinFlg == 1)
                                                        .Include(l => l.AppUser)
                                                        .Include(l => l.LotteryResult)
                                                        .Select(x => new ResultLotteryDetailsUser
                                                        {
                                                            LotteryCalendar = x.LotteryResult.LotteryCalendarFormat,
                                                            Slot = x.LotteryResult.Slot,
                                                            FullName = x.AppUser.FullName,
                                                            Picks = x.Picks,
                                                            Results = x.LotteryResult.Results,
                                                            WinFlg = x.WinFlg
                                                        })
                                                        .ToListAsync();

                if (resultLotteryDetailsUsers.Count() > 0)
                {
                    msg.Id = CommonMsg.MSG_SAVE_SUCCESSFULl;

                  result.listLotteryDetails=  resultLotteryDetailsUsers;
                }
                else
                {
                    msg.Id = CommonMsg.MSG_NO_HAS_DATA;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = new ResultLotteryDetails();
                msg.Id = CommonMsg.MSG_ERROS_EX;
            }
            var temp = await _context.Messages.FindAsync(msg.Id);
            msg.MessageContent = temp.MessageContent;
            result.Msg = msg;
            return Ok(result);
        }

        [HttpGet("active-slot")]
        public async Task<ActionResult<LotteryResult>> GetActiveSlot()
        {
            LotteryResult result = await LotteryService.GetActiveLottery(_context);
            return Ok(result);
        }
    }
}