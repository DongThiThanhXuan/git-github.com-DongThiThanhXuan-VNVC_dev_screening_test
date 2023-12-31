using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XuanXoSoKienThienConGaTrong.Common;
using XuanXoSoKienThienConGaTrong.Helper;
using XuanXoSoKienThienConGaTrong.Models;
using XuanXoSoKienThienConGaTrong.Service;

namespace XuanXoSoKienThienConGaTrong.UI
{
    public partial class PickNumber : Form
    {
        private AppUser appUser;
        private DateOnly lotteryCalendar;
        LottetyService lottetyService;
        public PickNumber(AppUser appUser)
        {
            InitializeComponent();
            this.appUser = appUser;
            this.lottetyService = new LottetyService();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        protected override void OnShown(EventArgs e)
        {
            CreateFrom();
            base.OnShown(e);
        }
        private async void CreateFrom()
        {
            labelShowFullName.Text = appUser.FullName;
            ResultActiveSlot resultActiveSlot = await GetDateTime.GetActiveSlot();
            if (resultActiveSlot.Msg.Id == CommonMsg.MSG_GET_VALUE_SUCCESSFULLY)
            {
                lotteryCalendar = resultActiveSlot.LotteryCalendar;
                labelShowDate.Text = lotteryCalendar.ToString("dd/MM/yyyy");
                labelShowSlot.Text = resultActiveSlot.Slot + "h";  
            }
            else
            {
                MessageBox.Show(resultActiveSlot.Msg.MessageContent, CommonMsg.TITLE_ERROS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void PickNumberAction_Click(object sender, EventArgs e)
        {
            string number = textBoxPickNumber.Text;
            string msg = ValidateHelper.ValidatePickNumber(number);
            if (msg.Length > 0)
            {
                MessageBox.Show(msg, CommonMsg.TITLE_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                UserPickNumber userPickNumber = new UserPickNumber
                {
                    Id = appUser.Id,
                    Pick = Int32.Parse(number)
                };
                ResultLotteryDetails resultLotteryDetails = await lottetyService.SaveLottery(userPickNumber);
                if (resultLotteryDetails.Msg.Id == CommonMsg.MSG_SAVE_SUCCESSFULLY)
                {
                    FormUser formUser = new FormUser(this.appUser);
                    formUser.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultLotteryDetails.Msg.MessageContent, CommonMsg.TITLE_ERROS, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
