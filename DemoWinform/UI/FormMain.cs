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
    public partial class FormMain : Form
    {
        AppUserService appUserServiceImpl;
        public FormMain()
        {
            this.appUserServiceImpl = new AppUserService();
            this.MaximizeBox = false;
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {
            UserPhone.Text = "";
            UserPhone.Focus();
        }

        private async void NextButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = UserPhone.Text;
            Msg msg = ValidateHelper.ValidatePhone(phoneNumber);
            if (msg.Id == 0)
            {
                ResultUserAction resultUserAction = await appUserServiceImpl.GetAppUserByPhoneNumber(phoneNumber);              
                if (resultUserAction.Msg.Id == CommonMsg.MSG_GET_VALUE_SUCCESSFULLY)
                {
                    AppUser appUser = resultUserAction.AppUser;
                    FormUser form = new FormUser(appUser);
                    form.Show();
                    this.Close();
                }
                else if (resultUserAction.Msg.Id == CommonMsg.MSG_GET_VALUE_ERROS) {
                    FormSaveUser form = new FormSaveUser(phoneNumber);                    
                    form.Show();
                    this.Close();                    
                }
                else
                {
                    MessageBox.Show(resultUserAction.Msg.MessageContent, CommonMsg.TITLE_ERROS, MessageBoxButtons.OK, MessageBoxIcon.Error);               
                }                
            }
            else
            {
               
                MessageBox.Show(msg.MessageContent, msg.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }        
    }
}


