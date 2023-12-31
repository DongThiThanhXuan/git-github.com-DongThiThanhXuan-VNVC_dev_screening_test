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
using XuanXoSoKienThienConGaTrong.Models;
using XuanXoSoKienThienConGaTrong.Service;

namespace XuanXoSoKienThienConGaTrong.UI
{
    public partial class FormLuckyPerson : Form
    {
        private AppUser appUser;
        LottetyService lottetyService;
        private FormUser formUser;
        public FormLuckyPerson(AppUser appUser)
        {
            InitializeComponent();
            this.appUser = appUser;
            this.lottetyService = new LottetyService();
            this.formUser = new FormUser(this.appUser);
            this.MaximizeBox = false;
        }
        protected override void OnShown(EventArgs e)
        {
            loadGridData();

            base.OnShown(e);
        }
        private async void loadGridData()
        {
            ResultLotteryDetails resultLotteryDetails = await lottetyService.GetListWinPeron();
            if (resultLotteryDetails.Msg.Id == CommonMsg.MSG_SAVE_SUCCESSFULLY)
            {
                List<LotteryDetail> listLotteryDetails = resultLotteryDetails.listLotteryDetails;
                dataGridViewShowWinList.AutoGenerateColumns = false;
                dataGridViewShowWinList.DataSource = listLotteryDetails;

                this.formUser.CreateGrid(dataGridViewShowWinList);
                dataGridViewShowWinList.CellFormatting +=
               new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
               this.dataGridViewUser_CellFormatting);
            }
            else if (resultLotteryDetails.Msg.Id == CommonMsg.MSG_NO_DATA)
            {
                labelDataExits.Text = resultLotteryDetails.Msg.MessageContent;
            }
            else
            {
                MessageBox.Show(resultLotteryDetails.Msg.MessageContent, CommonMsg.TITLE_ERROS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridViewUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewShowWinList.Columns[e.ColumnIndex].Name == "Slot")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    int value = (int)e.Value;
                    e.Value = value + "h";
                }
            }
            if (this.dataGridViewShowWinList.Columns[e.ColumnIndex].Name == "Results")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    int value = (int)e.Value;
                    e.Value = (value == -1) ? "Wait Draw" : value;
                }
            }
            if (this.dataGridViewShowWinList.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    int value = (int)e.Value;
                    switch (value)
                    {
                        case -1:
                            e.Value = "Lose";
                            break;
                        case 1:
                            e.Value = "Win";
                            break;
                        case 0:
                            e.Value = "Wait Draw";
                            break;
                    }
                }
            }
        }

        private void buttonBackToFormUser_Click(object sender, EventArgs e)
        {
            formUser.Show();
            this.Close();
        }
    }
}
