namespace XuanXoSoKienThienConGaTrong.UI
{
    partial class FormLuckyPerson
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
            label1 = new Label();
            buttonBackToFormUser = new Button();
            dataGridViewShowWinList = new DataGridView();
            labelDataExits = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowWinList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(318, 23);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 0;
            label1.Text = "Lucky PerSon";
            // 
            // buttonBackToFormUser
            // 
            buttonBackToFormUser.Location = new Point(713, 61);
            buttonBackToFormUser.Name = "buttonBackToFormUser";
            buttonBackToFormUser.Size = new Size(75, 23);
            buttonBackToFormUser.TabIndex = 1;
            buttonBackToFormUser.Text = "Back";
            buttonBackToFormUser.UseVisualStyleBackColor = true;
            buttonBackToFormUser.Click += buttonBackToFormUser_Click;
            // 
            // dataGridViewShowWinList
            // 
            dataGridViewShowWinList.BackgroundColor = SystemColors.Control;
            dataGridViewShowWinList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShowWinList.Location = new Point(14, 104);
            dataGridViewShowWinList.Name = "dataGridViewShowWinList";
            dataGridViewShowWinList.RowTemplate.Height = 25;
            dataGridViewShowWinList.Size = new Size(774, 286);
            dataGridViewShowWinList.TabIndex = 2;
            // 
            // labelDataExits
            // 
            labelDataExits.AutoSize = true;
            labelDataExits.ForeColor = Color.DarkCyan;
            labelDataExits.Location = new Point(318, 69);
            labelDataExits.Name = "labelDataExits";
            labelDataExits.Size = new Size(127, 15);
            labelDataExits.TabIndex = 3;
            labelDataExits.Text = "OOPS. NO DATA HERE!";
            // 
            // FormLuckyPerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDataExits);
            Controls.Add(dataGridViewShowWinList);
            Controls.Add(buttonBackToFormUser);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormLuckyPerson";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLuckyPerson";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShowWinList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonBackToFormUser;
        private DataGridView dataGridViewShowWinList;
        private Label labelDataExits;
    }
}