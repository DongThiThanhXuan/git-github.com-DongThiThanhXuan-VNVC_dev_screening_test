namespace XuanXoSoKienThienConGaTrong.UI
{
    partial class FormMain
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
            UserPhone = new TextBox();
            label1 = new Label();
            nextButton = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // UserPhone
            // 
            UserPhone.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            UserPhone.Location = new Point(289, 119);
            UserPhone.Name = "UserPhone";
            UserPhone.Size = new Size(168, 34);
            UserPhone.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(116, 124);
            label1.Name = "label1";
            label1.Size = new Size(155, 21);
            label1.TabIndex = 1;
            label1.Text = "Your Phone Number:";
            // 
            // nextButton
            // 
            nextButton.Location = new Point(477, 119);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 34);
            nextButton.TabIndex = 3;
            nextButton.Text = "Start";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += NextButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(223, 69);
            label3.Name = "label3";
            label3.Size = new Size(367, 28);
            label3.TabIndex = 5;
            label3.Text = "Get Ready To Say Hello To Your New Life!";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(nextButton);
            Controls.Add(label1);
            Controls.Add(UserPhone);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rooster Lottery";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserPhone;
        private Label label1;
        private Button nextButton;
        private Label label3;
    }
}