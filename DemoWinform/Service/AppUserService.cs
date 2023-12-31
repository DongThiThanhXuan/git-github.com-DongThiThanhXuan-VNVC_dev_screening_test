using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using XuanXoSoKienThienConGaTrong.Common;
using XuanXoSoKienThienConGaTrong.Helper;
using XuanXoSoKienThienConGaTrong.Models;

namespace XuanXoSoKienThienConGaTrong.Service
{
    public  class AppUserService 
    {
        static HttpClient client = new HttpClient();
       
        public  async Task<ResultUserAction> GetAppUserByPhoneNumber(string phoneNumber)
        {

            ResultUserAction resultUserAction = null;
            try {
                HttpResponseMessage response = await client.GetAsync(CommonUrl.GET_USER_BY_PHONENUMBER + phoneNumber);               
                if (response.IsSuccessStatusCode)
                {
                    resultUserAction = await response.Content.ReadAsAsync<ResultUserAction>();
                }
                else
                {
                    resultUserAction = new ResultUserAction();
                    resultUserAction.Msg = new Msg();
                    resultUserAction.Msg.MessageContent = CommonMsg.ERROS;
                }
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                resultUserAction = new ResultUserAction();
                resultUserAction.Msg = new Msg();
                resultUserAction.Msg.MessageContent = CommonMsg.ERROS;
            }
                      
            return resultUserAction;

        }

        public  async Task<ResultUserAction> SaveAppUser(AppUser appUser)
        {

            ResultUserAction resultUserAction = new ResultUserAction();
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
               CommonUrl.SAVE_USER, appUser);
                response.EnsureSuccessStatusCode();
                resultUserAction = await response.Content.ReadAsAsync<ResultUserAction>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                resultUserAction.Msg.MessageContent = CommonMsg.ERROS;
            }

            return resultUserAction;

        }

        
    }
}
