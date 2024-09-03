﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSSReader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            using (var wc = new WebClient()) {
                var url = wc.OpenRead(tbRssUrl.Text);
                XDocument xdoc = XDocument.Load(url);

                var xtitles = xdoc.Root.Descendants("item").Elements("title").Select(x => x.Value);
                foreach (var title in xtitles) {
                    lbRssTitle.Items.Add(title);
                }
            }
        }
    }
}
