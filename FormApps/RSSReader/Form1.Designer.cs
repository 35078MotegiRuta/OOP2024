﻿namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRssUrl = new System.Windows.Forms.ComboBox();
            this.tbRssName = new System.Windows.Forms.TextBox();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbRss = new System.Windows.Forms.WebBrowser();
            this.btGet = new System.Windows.Forms.Button();
            this.btJoin = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "URLまたはカテゴリ名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "お気に入り名称：";
            // 
            // cbRssUrl
            // 
            this.cbRssUrl.FormattingEnabled = true;
            this.cbRssUrl.Location = new System.Drawing.Point(125, 13);
            this.cbRssUrl.Name = "cbRssUrl";
            this.cbRssUrl.Size = new System.Drawing.Size(596, 20);
            this.cbRssUrl.TabIndex = 2;
            // 
            // tbRssName
            // 
            this.tbRssName.Location = new System.Drawing.Point(125, 45);
            this.tbRssName.Name = "tbRssName";
            this.tbRssName.Size = new System.Drawing.Size(412, 19);
            this.tbRssName.TabIndex = 3;
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(12, 73);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(201, 496);
            this.lbRssTitle.TabIndex = 4;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged);
            // 
            // wbRss
            // 
            this.wbRss.Location = new System.Drawing.Point(219, 74);
            this.wbRss.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRss.Name = "wbRss";
            this.wbRss.ScriptErrorsSuppressed = true;
            this.wbRss.Size = new System.Drawing.Size(689, 495);
            this.wbRss.TabIndex = 5;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(727, 11);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(75, 23);
            this.btGet.TabIndex = 6;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // btJoin
            // 
            this.btJoin.Location = new System.Drawing.Point(543, 43);
            this.btJoin.Name = "btJoin";
            this.btJoin.Size = new System.Drawing.Size(75, 23);
            this.btJoin.TabIndex = 7;
            this.btJoin.Text = "登録";
            this.btJoin.UseVisualStyleBackColor = true;
            this.btJoin.Click += new System.EventHandler(this.btJoin_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(833, 10);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 8;
            this.btDelete.Text = "削除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(920, 581);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btJoin);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.wbRss);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.tbRssName);
            this.Controls.Add(this.cbRssUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "RssReader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRssUrl;
        private System.Windows.Forms.TextBox tbRssName;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbRss;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.Button btJoin;
        private System.Windows.Forms.Button btDelete;
    }
}

