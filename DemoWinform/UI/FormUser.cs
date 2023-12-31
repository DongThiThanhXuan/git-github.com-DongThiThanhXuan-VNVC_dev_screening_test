using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class FormUser : Form
    {
        private AppUser appUser;

        LottetyService lottetyService;

        public FormUser(AppUser appUser)
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

        private async void PickNumberAction_Click(object sender, EventArgs e)
        {
            PickNumber form = new PickNumber(this.appUser);
            form.Show();
            this.Close();
        }
        private async void CreateFrom()
        {
            labelShowFullName.Text = appUser.FullName;
            ResultActiveSlot resultActiveSlot = await GetDateTime.GetActiveSlot();
            if (resultActiveSlot.Msg.Id == CommonMsg.MSG_GET_VALUE_SUCCESSFULLY)
            {
                ResultLotteryDetails resultLotteryDetails = await lottetyService.GetResultLotteryOfUser(appUser.Id);
                if (resultLotteryDetails.Msg.Id == CommonMsg.MSG_SAVE_SUCCESSFULLY)
                {
                    labelDataExits.Text = "";

                    List<LotteryDetail> listLotteryDetails = resultLotteryDetails.listLotteryDetails;
                    loadGridData(listLotteryDetails);
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
            else
            {
                MessageBox.Show(resultActiveSlot.Msg.MessageContent, CommonMsg.TITLE_ERROS, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadGridData(List<LotteryDetail> listLotteryDetails)
        {

            dataGridViewShowLotteryResultOfUser.AutoGenerateColumns = false;
            dataGridViewShowLotteryResultOfUser.DataSource = listLotteryDetails;

            CreateGrid(dataGridViewShowLotteryResultOfUser);
            dataGridViewShowLotteryResultOfUser.CellFormatting +=
               new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
               this.dataGridViewUser_CellFormatting);


        }
        private void dataGridViewUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridViewShowLotteryResultOfUser.Columns[e.ColumnIndex].Name == "Slot")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    int value = (int)e.Value;
                    e.Value = value + "h";
                }
            }
            if (this.dataGridViewShowLotteryResultOfUser.Columns[e.ColumnIndex].Name == "Results")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    int value = (int)e.Value;
                    e.Value = (value == -1) ? "Wait Draw" : value;
                }
            }
            if (this.dataGridViewShowLotteryResultOfUser.Columns[e.ColumnIndex].Name == "Status")
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

        private void BackToMainButton_Click(object sender, EventArgs e)
        {
            FormMain form = new FormMain();
            form.Show();
            this.Close();
        }

        public void CreateGrid(DataGridView dataGridView)
        {
            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.Width = 100;
            column.Name = "Date";
            column.HeaderText = "Date";
            column.DataPropertyName = "lotteryCalendar";
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Slot";
            column.Width = 100;
            column.HeaderText = "Slot";
            column.DataPropertyName = "slot";
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Name";
            column.Width = 250;
            column.HeaderText = "Name";
            column.DataPropertyName = "fullName";
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Pick";
            column.Width = 100;
            column.HeaderText = "Pick Number";
            column.DataPropertyName = "picks";
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Results";
            column.Width = 100;
            column.HeaderText = "Result Draw";
            column.DataPropertyName = "results";
            dataGridView.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Status";
            column.Width = 100;
            column.HeaderText = "Status";
            column.DataPropertyName = "winFlg";

            dataGridView.Columns.Add(column);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLuckyPerson form = new FormLuckyPerson(this.appUser);
            form.Show();
            this.Close();
        }
    }
}
