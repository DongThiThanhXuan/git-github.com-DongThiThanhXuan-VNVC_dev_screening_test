using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XuanXoSoKienThienConGaTrong.Common;
using XuanXoSoKienThienConGaTrong.Models;

namespace XuanXoSoKienThienConGaTrong.Service
{
    public static class GetDateTime
    {
        static HttpClient client = new HttpClient();
        public async static Task<ResultActiveSlot> GetActiveSlot()
        {

            ResultActiveSlot resultActiveSlot = new ResultActiveSlot(); ;
           
            try
            {
                HttpResponseMessage response = await client.GetAsync(CommonUrl.GET_ACTIVE_SLOT);
                if (response.IsSuccessStatusCode)
                {
                    resultActiveSlot = await response.Content.ReadAsAsync<ResultActiveSlot>();
                    resultActiveSlot.Msg = new Msg();
                    resultActiveSlot.Msg.Id = CommonMsg.MSG_GET_VALUE_SUCCESSFULLY;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                resultActiveSlot = new ResultActiveSlot();
                resultActiveSlot.Msg = new Msg();
                resultActiveSlot.Msg.MessageContent = CommonMsg.ERROS;
            }

            return resultActiveSlot;

        }
    }
}
