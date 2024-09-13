using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        private List<ItemData> items;
        private List<CategoryUrlPair> categoryUrlPairs;
        private List<CategoryUrlPair> defaultCategories;

        public Form1() {
            InitializeComponent();
            InitializeCategoryUrlPairs();
            MessageBox.Show("①カテゴリ選択またはURLを入力して取得ボタンを押す\n" +
                "②お気に入り名称とURLを入力して登録ボタンを押す", "使い方", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbRssUrl.DropDownStyle = ComboBoxStyle.DropDown;
            cbRssUrl.SelectedIndex = -1;
            cbRssUrl.Text = "";
        }

        private void InitializeCategoryUrlPairs() {
            categoryUrlPairs = new List<CategoryUrlPair>
            {
                new CategoryUrlPair("主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml"),
                new CategoryUrlPair("国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml"),
                new CategoryUrlPair("国際", "https://news.yahoo.co.jp/rss/topics/world.xml"),
                new CategoryUrlPair("経済", "https://news.yahoo.co.jp/rss/topics/business.xml"),
                new CategoryUrlPair("エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml"),
                new CategoryUrlPair("スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml"),
                new CategoryUrlPair("IT", "https://news.yahoo.co.jp/rss/topics/it.xml"),
                new CategoryUrlPair("科学", "https://news.yahoo.co.jp/rss/topics/science.xml"),
                new CategoryUrlPair("地域", "https://news.yahoo.co.jp/rss/topics/local.xml"),
            };

            defaultCategories = new List<CategoryUrlPair>(categoryUrlPairs);

            cbRssUrl.DataSource = categoryUrlPairs;
            cbRssUrl.DisplayMember = "Category";
            cbRssUrl.ValueMember = "Url";
        }

        private async void btGet_Click(object sender, EventArgs e) {
            string selectedUrl;

            if (cbRssUrl.SelectedItem is CategoryUrlPair selectedPair) {
                selectedUrl = selectedPair.Url;
            } else {
                selectedUrl = cbRssUrl.Text;
            }

            if (!string.IsNullOrWhiteSpace(selectedUrl)) {
                try {
                    using (var wc = new WebClient()) {
                        wc.Encoding = Encoding.UTF8;
                        var rssData = await wc.DownloadStringTaskAsync(selectedUrl);

                        try {
                            var xdoc = XDocument.Parse(rssData);

                            items = xdoc.Root.Descendants("item")
                                            .Select(item => new ItemData {
                                                Title = item.Element("title").Value,
                                                Link = item.Element("link").Value,
                                            }).ToList();

                            lbRssTitle.Invoke(new Action(() => {
                                lbRssTitle.Items.Clear();
                                foreach (var item in items) {
                                    lbRssTitle.Items.Add(item.Title);
                                }
                            }));
                        }
                        catch (XmlException xmlEx) {
                            MessageBox.Show($"RSSデータのXML解析エラー: {xmlEx.Message}", "XMLエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (WebException webEx) {
                    MessageBox.Show($"正式なURLを入力してください", "URLエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) {
                    MessageBox.Show($"エラーが発生しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("URLを入力またはカテゴリを選択してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedIndex >= 0) {
                var selectedItem = items[lbRssTitle.SelectedIndex];
                if (!string.IsNullOrEmpty(selectedItem.Link)) {
                    wbRss.Navigate(selectedItem.Link);
                }
            }
        }

        public class ItemData {
            public string Title { get; set; }
            public string Link { get; set; }
        }

        public class CategoryUrlPair {
            public string Category { get; set; }
            public string Url { get; set; }

            public CategoryUrlPair(string category, string url) {
                Category = category;
                Url = url;
            }
        }

        private void btJoin_Click(object sender, EventArgs e) {
            string categoryName = tbRssName.Text;
            string url = cbRssUrl.Text;

            if (string.IsNullOrWhiteSpace(categoryName)) {
                MessageBox.Show("カテゴリ名を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(url)) {
                MessageBox.Show("URLを入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPair = new CategoryUrlPair(categoryName, url);
            categoryUrlPairs.Add(newPair);

            cbRssUrl.DataSource = null;
            cbRssUrl.DataSource = categoryUrlPairs;
            cbRssUrl.DisplayMember = "Category";
            cbRssUrl.ValueMember = "Url";

            tbRssName.Text = "";
            cbRssUrl.Text = "";

            MessageBox.Show(categoryName + "が登録されました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btDelete_Click(object sender, EventArgs e) {
            var selectedPair = cbRssUrl.SelectedItem as CategoryUrlPair;

            if (selectedPair == null) {
                MessageBox.Show("削除するアイテムを選択してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (defaultCategories.Contains(selectedPair)) {
                MessageBox.Show("デフォルトの項目は削除できません。", "削除エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            categoryUrlPairs.Remove(selectedPair);

            cbRssUrl.DataSource = null;
            cbRssUrl.DataSource = categoryUrlPairs;
            cbRssUrl.DisplayMember = "Category";
            cbRssUrl.ValueMember = "Url";

            MessageBox.Show("削除しました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
