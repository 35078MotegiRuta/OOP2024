namespace DateTimeApp {
    partial class btDayBefore {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpBirthday = new DateTimePicker();
            btDateCount = new Button();
            tbDisp = new TextBox();
            nudDay = new NumericUpDown();
            btDayAfter = new Button();
            btDaybe = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(94, 94);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirthday.Location = new Point(254, 94);
            dtpBirthday.Margin = new Padding(6);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(364, 39);
            dtpBirthday.TabIndex = 1;
            // 
            // btDateCount
            // 
            btDateCount.Location = new Point(343, 145);
            btDateCount.Margin = new Padding(6);
            btDateCount.Name = "btDateCount";
            btDateCount.Size = new Size(184, 74);
            btDateCount.TabIndex = 2;
            btDateCount.Text = "今日までの日数";
            btDateCount.UseVisualStyleBackColor = true;
            btDateCount.Click += btDateCount_Click;
            // 
            // tbDisp
            // 
            tbDisp.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbDisp.Location = new Point(39, 377);
            tbDisp.Margin = new Padding(6);
            tbDisp.Name = "tbDisp";
            tbDisp.Size = new Size(579, 43);
            tbDisp.TabIndex = 3;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(171, 283);
            nudDay.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 46);
            nudDay.TabIndex = 4;
            // 
            // btDayAfter
            // 
            btDayAfter.Location = new Point(343, 319);
            btDayAfter.Margin = new Padding(6);
            btDayAfter.Name = "btDayAfter";
            btDayAfter.Size = new Size(132, 46);
            btDayAfter.TabIndex = 6;
            btDayAfter.Text = "日後";
            btDayAfter.UseVisualStyleBackColor = true;
            btDayAfter.Click += btDayAfter_Click;
            // 
            // btDaybe
            // 
            btDaybe.Location = new Point(343, 242);
            btDaybe.Margin = new Padding(6);
            btDaybe.Name = "btDaybe";
            btDaybe.Size = new Size(132, 46);
            btDaybe.TabIndex = 7;
            btDaybe.Text = "日前";
            btDaybe.UseVisualStyleBackColor = true;
            btDaybe.Click += btDaybe_Click;
            // 
            // btDayBefore
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 470);
            Controls.Add(btDaybe);
            Controls.Add(btDayAfter);
            Controls.Add(nudDay);
            Controls.Add(tbDisp);
            Controls.Add(btDateCount);
            Controls.Add(dtpBirthday);
            Controls.Add(label1);
            Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(6);
            Name = "btDayBefore";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpBirthday;
        private Button btDateCount;
        private TextBox tbDisp;
        private NumericUpDown nudDay;
        private Button btDayAfter;
        private Button btDaybe;
    }
}
