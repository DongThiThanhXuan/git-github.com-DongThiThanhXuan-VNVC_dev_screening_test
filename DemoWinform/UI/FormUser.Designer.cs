namespace XuanXoSoKienThienConGaTrong.UI
{
    partial class FormUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            dataGridViewShowLotteryResultOfUser = new DataGridView();
            PickNumberAction = new Button();
            ShowName = new Label();
            BackToMainButton = new Button();
            labelShowFullName = new Label();
            labelDataExits = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowLotteryResultOfUser).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(369, 32);
            label3.Name = "label3";
            label3.Size = new Size(101, 37);
            label3.TabIndex = 2;
            label3.Text = "History";
            // 
            // dataGridViewShowLotteryResultOfUser
            // 
            dataGridViewShowLotteryResultOfUser.BackgroundColor = SystemColors.Control;
            dataGridViewShowLotteryResultOfUser.BorderStyle = BorderStyle.None;
            dataGridViewShowLotteryResultOfUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowLotteryResultOfUser.GridColor = SystemColors.ButtonHighlight;
            dataGridViewShowLotteryResultOfUser.Location = new Point(9, 112);
            dataGridViewShowLotteryResultOfUser.Name = "dataGridViewShowLotteryResultOfUser";
            dataGridViewShowLotteryResultOfUser.ReadOnly = true;
            dataGridViewShowLotteryResultOfUser.RowTemplate.Height = 35;
            dataGridViewShowLotteryResultOfUser.RowTemplate.ReadOnly = true;
            dataGridViewShowLotteryResultOfUser.Size = new Size(795, 255);
            dataGridViewShowLotteryResultOfUser.TabIndex = 3;
            // 
            // PickNumberAction
            // 
            PickNumberAction.Location = new Point(340, 457);
            PickNumberAction.Name = "PickNumberAction";
            PickNumberAction.Size = new Size(130, 23);
            PickNumberAction.TabIndex = 4;
            PickNumberAction.Text = "Pick Lottery Now";
            PickNumberAction.UseVisualStyleBackColor = true;
            PickNumberAction.Click += PickNumberAction_Click;
            // 
            // ShowName
            // 
            ShowName.AutoSize = true;
            ShowName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ShowName.Location = new Point(12, 9);
            ShowName.Name = "ShowName";
            ShowName.Size = new Size(53, 21);
            ShowName.TabIndex = 12;
            ShowName.Text = "Hello, ";
            // 
            // BackToMainButton
            // 
            BackToMainButton.Location = new Point(12, 457);
            BackToMainButton.Name = "BackToMainButton";
            BackToMainButton.Size = new Size(130, 23);
            BackToMainButton.TabIndex = 13;
            BackToMainButton.Text = "Back";
            BackToMainButton.UseVisualStyleBackColor = true;
            BackToMainButton.Click += BackToMainButton_Click;
            // 
            // labelShowFullName
            // 
            labelShowFullName.AutoSize = true;
            labelShowFullName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelShowFullName.Location = new Point(61, 9);
            labelShowFullName.Name = "labelShowFullName";
            labelShowFullName.Size = new Size(52, 21);
            labelShowFullName.TabIndex = 14;
            labelShowFullName.Text = "label2";
            // 
            // labelDataExits
            // 
            labelDataExits.AutoSize = true;
            labelDataExits.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataExits.ForeColor = Color.DarkGreen;
            labelDataExits.Location = new Point(334, 78);
            labelDataExits.Name = "labelDataExits";
            labelDataExits.Size = new Size(170, 21);
            labelDataExits.TabIndex = 16;
            labelDataExits.Text = "OOPS. NO DATA HERE!";
            // 
            // button1
            // 
            button1.Location = new Point(674, 457);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 17;
            button1.Text = "List Win Person";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 492);
            Controls.Add(button1);
            Controls.Add(labelDataExits);
            Controls.Add(labelShowFullName);
            Controls.Add(BackToMainButton);
            Controls.Add(ShowName);
            Controls.Add(PickNumberAction);
            Controls.Add(dataGridViewShowLotteryResultOfUser);
            Controls.Add(label3);
            Name = "FormUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rooster Lottery";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowLotteryResultOfUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private DataGridView dataGridViewShowLotteryResultOfUser;
        private Button PickNumberAction;
        private Label ShowName;
        private Button BackToMainButton;
        private Label labelShowFullName;
        private Label labelDataExits;
        private Button button1;
    }
}