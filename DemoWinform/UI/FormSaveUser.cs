using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel;
using FluentValidation.Results;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms;
using XuanXoSoKienThienConGaTrong.Helper;
using XuanXoSoKienThienConGaTrong.Models;
using XuanXoSoKienThienConGaTrong.Service;
using XuanXoSoKienThienConGaTrong.UI;
using XuanXoSoKienThienConGaTrong.Common;

namespace XuanXoSoKienThienConGaTrong
{
    public partial class FormSaveUser : Form
    {

        private AppUser appUser;
        AppUserService appUserServiceImpl;
        public FormSaveUser(string phoneNumber)
        {
            InitializeComponent();
            appUser = new AppUser();
            appUser.PhoneNumber = phoneNumber;
            this.appUserServiceImpl = new AppUserService();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        protected override void OnShown(EventArgs e)
        {
            phoneNumberTextBox.Text = appUser.PhoneNumber;
            fullNameTextBox.Text = "";
            base.OnShown(e);
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearErrosForm();
                appUser.FullName = fullNameTextBox.Text;
                appUser.Birthday = DateOnly.FromDateTime(birthDate.Value);
                
                AppUserValidation validator = new AppUserValidation();
                ValidationResult results = validator.Validate(appUser);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        switch (failure.PropertyName)
                        {
                            case "FullName":
                                showMsgErrorFullName.Text = failure.ErrorMessage;
                                break;
                            /*case "Birthday":
                                showMsgErrorDOB.Text = failure.ErrorMessage;
                                break;*/
                        }
                    } 
                }
                else
                {
                    ResultUserAction resultUserAction = await appUserServiceImpl.SaveAppUser(appUser);
                    if (resultUserAction.Msg.Id == CommonMsg.MSG_SAVE_SUCCESSFULLY)
                    {
                        appUser = resultUserAction.AppUser;
                        FormUser form = new FormUser(appUser);
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultUserAction.Msg.MessageContent, resultUserAction.Msg.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                /*
                showMsgErrorFullName.Text = ValidateHelper.ValidateFullName(appUser.FullName);
                showMsgErrorDOB.Text = ValidateHelper.ValidateDOB(appUser.Birthday);
                if(showMsgErrorFullName.Text.Equals("") && showMsgErrorDOB.Text.Equals("")) {
                    ResultUserAction resultUserAction = await appUserServiceImpl.SaveAppUser(appUser);
                    if (resultUserAction.Msg.Id == CommonMsg.MSG_SAVE_SUCCESSFULLY)
                    {
                        appUser = resultUserAction.AppUser;
                        FormUser form = new FormUser(appUser);
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultUserAction.Msg.MessageContent, resultUserAction.Msg.MessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                */
               
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
           
        }

        protected void ClearErrosForm()
        {
            showMsgErrorFullName.Text = "";
            showMsgErrorDOB.Text = "";

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            FormMain form = new FormMain();
            form.Show();
            this.Close();
        }
    }
}
