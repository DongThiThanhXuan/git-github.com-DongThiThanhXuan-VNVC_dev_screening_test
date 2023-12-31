using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Common;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase 
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> GetUsers() {
            List<AppUser> users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<ActionResult<ResultGetPostAction>> GetSingleUser(string phoneNumber) {
            ResultGetPostAction result = new ResultGetPostAction();
             AppUser user = null;
             Msg msg=new Msg();
            try{
                 user = await _context.Users.Where(u => u.PhoneNumber ==phoneNumber).FirstOrDefaultAsync();            
                if (user != null) {
                    msg.Id = CommonMsg.MSG_CHECK_EXISTS_PHONE;
                }
                else{
                 user = new AppUser();
                 msg.Id = CommonMsg.MSG_CREATE_NEW_USER;    
                }
            }catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
                user = new AppUser();
                msg.Id = CommonMsg.MSG_ERROS_EX;                  
            }

            
            var temp = await _context.Messages.FindAsync(msg.Id);
            msg.MessageContent = temp.MessageContent;
            result.AppUser = user;
            result.Msg=msg;
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<ResultGetPostAction>> AddUser(AppUser input) {
            ResultGetPostAction result = new ResultGetPostAction();
            AppUser user = new AppUser
            {
                PhoneNumber = input.PhoneNumber,
                FullName = input.FullName,
                Birthday = input.Birthday
            };
            Msg msg=new Msg();
            /// Kiểm tra số điện thoại nhập vào đã tồn tại chưa. Nếu đã tồn tại thì trả lỗi id = 4
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == user.PhoneNumber)) {
                msg.Id = CommonMsg.MSG_DATA_ERROS;
                user.Id = CommonMsg.USER_ID_ERROS;
                user.FullName = "";
            } else {
                try {
                    await _context.Users.AddAsync(user);
                    int totalAddedRecords = await _context.SaveChangesAsync();

                    /// kiểm tra thêm dữ liệu thành công không
                    if (totalAddedRecords > 0) {
                        msg.Id = CommonMsg.MSG_SAVE_SUCCESSFULl;
                    } else {
                        msg.Id = CommonMsg.MSG_DATA_ERROS;
                        user.Id = -1;
                        user.FullName = "";
                    }
                } catch (Exception ex) { /// bắt lỗi hệ thống
                    Console.WriteLine(ex);
                    msg.Id = CommonMsg.MSG_ERROS_EX;
                    user.Id = CommonMsg.USER_ID_ERROS;
                    user.FullName = "";
                }
            }
            
            
            var temp = await _context.Messages.FindAsync(msg.Id);
            msg.MessageContent = temp.MessageContent;
            result.AppUser = user;
            result.Msg=msg;
            return Ok(result);
        }
    }
}