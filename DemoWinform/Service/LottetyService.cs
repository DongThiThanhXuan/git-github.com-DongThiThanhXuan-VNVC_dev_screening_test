using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using XuanXoSoKienThienConGaTrong.Common;
using XuanXoSoKienThienConGaTrong.Models;

namespace XuanXoSoKienThienConGaTrong.Service
{
    public class LottetyService
    {
        static HttpClient client = new HttpClient();
        public async Task<ResultLotteryDetails> SaveLottery(UserPickNumber userPickNumber)
        {

            ResultLotteryDetails resultLotteryDetails = new ResultLotteryDetails(); 
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
               CommonUrl.SAVE_LOTTERY, userPickNumber);
                response.EnsureSuccessStatusCode();
 
                resultLotteryDetails = await response.Content.ReadAsAsync<ResultLotteryDetails>();
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                resultLotteryDetails = new ResultLotteryDetails();
                resultLotteryDetails.Msg = new Msg();
                resultLotteryDetails.Msg.MessageContent = CommonMsg.ERROS;
            }
            return resultLotteryDetails;
        }

        public async Task<ResultLotteryDetails> GetResultLotteryOfUser(int userID)
        {

            ResultLotteryDetails resultLotteryDetails = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(CommonUrl.GET_LOTTERY_OF_USER + userID);
                if (response.IsSuccessStatusCode)
                {
                    resultLotteryDetails= await response.Content.ReadAsAsync<ResultLotteryDetails>();
                }
                else
                {
                    resultLotteryDetails = new ResultLotteryDetails();
                    resultLotteryDetails.Msg = new Msg();
                    resultLotteryDetails.Msg.MessageContent = CommonMsg.ERROS;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                resultLotteryDetails = new ResultLotteryDetails();
                resultLotteryDetails.Msg = new Msg();
                resultLotteryDetails.Msg.MessageContent = CommonMsg.ERROS;
            }

            return resultLotteryDetails;
        }

        public async Task<ResultLotteryDetails> GetListWinPeron()
        {

            ResultLotteryDetails resultLotteryDetails = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(CommonUrl.GET_WIN_LIST);
                if (response.IsSuccessStatusCode)
                {
                    resultLotteryDetails = await response.Content.ReadAsAsync<ResultLotteryDetails>();
                }
                else
                {
                    resultLotteryDetails = new ResultLotteryDetails();
                    resultLotteryDetails.Msg = new Msg();
                    resultLotteryDetails.Msg.MessageContent = CommonMsg.ERROS;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                resultLotteryDetails = new ResultLotteryDetails();
                resultLotteryDetails.Msg = new Msg();
                resultLotteryDetails.Msg.MessageContent = CommonMsg.ERROS;
            }

            return resultLotteryDetails;
        }
    }
}
