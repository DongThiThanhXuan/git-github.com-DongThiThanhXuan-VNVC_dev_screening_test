namespace XuanXoSoKienThienConGaTrong.UI
{
    partial class PickNumber
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
            labelShowFullName = new Label();
            label3 = new Label();
            labelShowDate = new Label();
            label5 = new Label();
            labelShowSlot = new Label();
            label7 = new Label();
            textBoxPickNumber = new TextBox();
            PickNumberAction = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(162, 81);
            label1.Name = "label1";
            label1.Size = new Size(80, 37);
            label1.TabIndex = 0;
            label1.Text = "Hello";
            // 
            // labelShowFullName
            // 
            labelShowFullName.AutoSize = true;
            labelShowFullName.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelShowFullName.Location = new Point(245, 81);
            labelShowFullName.Name = "labelShowFullName";
            labelShowFullName.Size = new Size(88, 37);
            labelShowFullName.TabIndex = 1;
            labelShowFullName.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(162, 145);
            label3.Name = "label3";
            label3.Size = new Size(251, 28);
            label3.TabIndex = 2;
            label3.Text = "Lottery Date (dd/mm/yyyy)";
            // 
            // labelShowDate
            // 
            labelShowDate.AutoSize = true;
            labelShowDate.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelShowDate.Location = new Point(417, 145);
            labelShowDate.Name = "labelShowDate";
            labelShowDate.Size = new Size(116, 28);
            labelShowDate.TabIndex = 3;
            labelShowDate.Text = "01/12/2023";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(162, 199);
            label5.Name = "label5";
            label5.Size = new Size(192, 28);
            label5.TabIndex = 4;
            label5.Text = "Time Slot (0h->23h):";
            // 
            // labelShowSlot
            // 
            labelShowSlot.AutoSize = true;
            labelShowSlot.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelShowSlot.Location = new Point(417, 199);
            labelShowSlot.Name = "labelShowSlot";
            labelShowSlot.Size = new Size(34, 28);
            labelShowSlot.TabIndex = 5;
            labelShowSlot.Text = "2h";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(162, 254);
            label7.Name = "label7";
            label7.Size = new Size(231, 28);
            label7.TabIndex = 6;
            label7.Text = "Pick a number from 0->9";
            // 
            // textBoxPickNumber
            // 
            textBoxPickNumber.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPickNumber.Location = new Point(417, 259);
            textBoxPickNumber.Name = "textBoxPickNumber";
            textBoxPickNumber.Size = new Size(100, 34);
            textBoxPickNumber.TabIndex = 7;
            // 
            // PickNumberAction
            // 
            PickNumberAction.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            PickNumberAction.Location = new Point(293, 364);
            PickNumberAction.Name = "PickNumberAction";
            PickNumberAction.Size = new Size(143, 43);
            PickNumberAction.TabIndex = 8;
            PickNumberAction.Text = "Pick Now!";
            PickNumberAction.UseVisualStyleBackColor = true;
            PickNumberAction.Click += PickNumberAction_Click;
            // 
            // PickNumber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PickNumberAction);
            Controls.Add(textBoxPickNumber);
            Controls.Add(label7);
            Controls.Add(labelShowSlot);
            Controls.Add(label5);
            Controls.Add(labelShowDate);
            Controls.Add(label3);
            Controls.Add(labelShowFullName);
            Controls.Add(label1);
            Name = "PickNumber";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rooster Lottery";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelShowFullName;
        private Label label3;
        private Label labelShowDate;
        private Label label5;
        private Label labelShowSlot;
        private Label label7;
        private TextBox textBoxPickNumber;
        private Button PickNumberAction;
    }
}