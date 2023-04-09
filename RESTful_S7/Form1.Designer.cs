namespace RESTful_S7
{
    partial class Form1
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
            responseTextBox = new TextBox();
            value_1 = new TextBox();
            value_2 = new TextBox();
            value_3 = new TextBox();
            value_4 = new TextBox();
            controlwordTextBox = new TextBox();
            key_4 = new TextBox();
            key_3 = new TextBox();
            key_2 = new TextBox();
            key_1 = new TextBox();
            LinkStatus = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // responseTextBox
            // 
            responseTextBox.Location = new Point(19, 73);
            responseTextBox.Multiline = true;
            responseTextBox.Name = "responseTextBox";
            responseTextBox.Size = new Size(302, 340);
            responseTextBox.TabIndex = 0;
            // 
            // value_1
            // 
            value_1.Location = new Point(500, 41);
            value_1.Name = "value_1";
            value_1.Size = new Size(288, 27);
            value_1.TabIndex = 1;
            // 
            // value_2
            // 
            value_2.Location = new Point(500, 88);
            value_2.Name = "value_2";
            value_2.Size = new Size(288, 27);
            value_2.TabIndex = 2;
            // 
            // value_3
            // 
            value_3.Location = new Point(500, 141);
            value_3.Name = "value_3";
            value_3.Size = new Size(288, 27);
            value_3.TabIndex = 3;
            // 
            // value_4
            // 
            value_4.Location = new Point(500, 189);
            value_4.Name = "value_4";
            value_4.Size = new Size(288, 27);
            value_4.TabIndex = 4;
            // 
            // controlwordTextBox
            // 
            controlwordTextBox.Location = new Point(428, 355);
            controlwordTextBox.Name = "controlwordTextBox";
            controlwordTextBox.Size = new Size(116, 27);
            controlwordTextBox.TabIndex = 5;
            // 
            // key_4
            // 
            key_4.Location = new Point(342, 189);
            key_4.Name = "key_4";
            key_4.Size = new Size(119, 27);
            key_4.TabIndex = 9;
            // 
            // key_3
            // 
            key_3.Location = new Point(342, 141);
            key_3.Name = "key_3";
            key_3.Size = new Size(119, 27);
            key_3.TabIndex = 8;
            // 
            // key_2
            // 
            key_2.Location = new Point(342, 88);
            key_2.Name = "key_2";
            key_2.Size = new Size(119, 27);
            key_2.TabIndex = 7;
            // 
            // key_1
            // 
            key_1.Location = new Point(342, 41);
            key_1.Name = "key_1";
            key_1.Size = new Size(119, 27);
            key_1.TabIndex = 6;
            // 
            // LinkStatus
            // 
            LinkStatus.AutoSize = true;
            LinkStatus.Location = new Point(587, 355);
            LinkStatus.Name = "LinkStatus";
            LinkStatus.Size = new Size(105, 24);
            LinkStatus.TabIndex = 10;
            LinkStatus.Text = "LinkStatus";
            LinkStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 41);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 11;
            label1.Text = "response";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 9);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 12;
            label2.Text = "responseKey";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(557, 9);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 13;
            label3.Text = "responseValue";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(458, 320);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 14;
            label4.Text = "交互字";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(587, 320);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 15;
            label5.Text = "PLC连接状态";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LinkStatus);
            Controls.Add(key_4);
            Controls.Add(key_3);
            Controls.Add(key_2);
            Controls.Add(key_1);
            Controls.Add(controlwordTextBox);
            Controls.Add(value_4);
            Controls.Add(value_3);
            Controls.Add(value_2);
            Controls.Add(value_1);
            Controls.Add(responseTextBox);
            Name = "Form1";
            Text = "RESTful_S7";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox responseTextBox;
        private TextBox value_1;
        private TextBox value_2;
        private TextBox value_3;
        private TextBox value_4;
        private TextBox controlwordTextBox;
        private TextBox key_4;
        private TextBox key_3;
        private TextBox key_2;
        private TextBox key_1;
        private CheckBox LinkStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}