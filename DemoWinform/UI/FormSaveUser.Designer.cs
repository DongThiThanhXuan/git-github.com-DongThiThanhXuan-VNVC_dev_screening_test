namespace XuanXoSoKienThienConGaTrong
{
    partial class FormSaveUser
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            showMsgErrorDOB = new Label();
            showMsgErrorFullName = new Label();
            label6 = new Label();
            backButton = new Button();
            label3 = new Label();
            birthDate = new DateTimePicker();
            timeSlotLabel = new Label();
            dateLabel = new Label();
            saveButton = new Button();
            phoneNumberTextBox = new TextBox();
            label2 = new Label();
            fullNameTextBox = new TextBox();
            label1 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(showMsgErrorDOB);
            groupBox1.Controls.Add(showMsgErrorFullName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(backButton);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(birthDate);
            groupBox1.Controls.Add(timeSlotLabel);
            groupBox1.Controls.Add(dateLabel);
            groupBox1.Controls.Add(saveButton);
            groupBox1.Controls.Add(phoneNumberTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(fullNameTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(798, 448);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "User Information";
            // 
            // showMsgErrorDOB
            // 
            showMsgErrorDOB.AutoSize = true;
            showMsgErrorDOB.ForeColor = Color.IndianRed;
            showMsgErrorDOB.Location = new Point(299, 249);
            showMsgErrorDOB.Name = "showMsgErrorDOB";
            showMsgErrorDOB.Size = new Size(0, 21);
            showMsgErrorDOB.TabIndex = 13;
            // 
            // showMsgErrorFullName
            // 
            showMsgErrorFullName.AutoSize = true;
            showMsgErrorFullName.ForeColor = Color.IndianRed;
            showMsgErrorFullName.Location = new Point(299, 187);
            showMsgErrorFullName.Name = "showMsgErrorFullName";
            showMsgErrorFullName.Size = new Size(0, 21);
            showMsgErrorFullName.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(397, 290);
            label6.Name = "label6";
            label6.Size = new Size(28, 21);
            label6.TabIndex = 11;
            label6.Text = "Or";
            // 
            // backButton
            // 
            backButton.Location = new Point(448, 283);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 35);
            backButton.TabIndex = 10;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 223);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 7;
            label3.Text = "Birthday";
            // 
            // birthDate
            // 
            birthDate.Location = new Point(299, 217);
            birthDate.Name = "birthDate";
            birthDate.Size = new Size(276, 29);
            birthDate.TabIndex = 6;
            // 
            // timeSlotLabel
            // 
            timeSlotLabel.AutoSize = true;
            timeSlotLabel.Location = new Point(299, 367);
            timeSlotLabel.Name = "timeSlotLabel";
            timeSlotLabel.Size = new Size(0, 21);
            timeSlotLabel.TabIndex = 5;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(299, 319);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(0, 21);
            dateLabel.TabIndex = 4;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(299, 283);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(78, 33);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(299, 104);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.ReadOnly = true;
            phoneNumberTextBox.Size = new Size(417, 29);
            phoneNumberTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 112);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 0;
            label2.Text = "Phone Number";
            // 
            // fullNameTextBox
            // 
            fullNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            fullNameTextBox.Location = new Point(299, 155);
            fullNameTextBox.Name = "fullNameTextBox";
            fullNameTextBox.Size = new Size(417, 29);
            fullNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 158);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 0;
            label1.Text = "Full Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(121, 44);
            label4.Name = "label4";
            label4.Size = new Size(621, 36);
            label4.TabIndex = 14;
            label4.Text = "Input Your Info In The First Time Visit Rooster Lottery";
            // 
            // FormSaveUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 460);
            Controls.Add(groupBox1);
            Name = "FormSaveUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rooster Lottery";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox phoneNumberTextBox;
        private Label label2;
        private TextBox fullNameTextBox;
        private Button saveButton;
        private Label dateLabel;
        private Label timeSlotLabel;
        private Label label3;
        private DateTimePicker birthDate;
        private Button backButton;
        private Label label6;
        private Label showMsgErrorFullName;
        private Label showMsgErrorDOB;
        private Label label4;
    }
}
