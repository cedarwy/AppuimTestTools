using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ivony.Html.Parser;
using Ivony.Html;
using mshtml;
using System.Diagnostics;
using System.Configuration;

namespace AppuimTestTools
{
    public partial class Compare : Form
    {
        public Compare()
        {
            InitializeComponent();
        }

        private string path_1;
        private string path_2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                this.path_1 = this.folderBrowserDialog1.SelectedPath;
                this.lb_path1.Text = this.path_1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                this.path_2 = this.folderBrowserDialog1.SelectedPath;
                this.lb_path2.Text = this.path_2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string build1 = path_1.Substring(path_1.LastIndexOf("build"), 14);
            string build2 = path_2.Substring(path_2.LastIndexOf("build"), 14);
            //新建保存目录
            string ressavePath = ConfigurationManager.AppSettings["ResultPath"] + "\\Result\\" + build1 + "vs" + build2 + "\\";
            Directory.CreateDirectory(ressavePath);

            //加载路径1的文件列表
            string[] filelist = Directory.GetFiles(this.path_1);
            foreach(string one in filelist)
            {
                string a = one.Substring(one.LastIndexOf("\\")+1);
                FileInfo file1 = new FileInfo(path_1 + "\\" + a);
                FileInfo file2 = new FileInfo(path_2 + "\\" + a); 
                Stream s1 = file1.OpenRead();
                Bitmap bitmap1 = new Bitmap(s1);
                s1.Close();

                Stream s2 = file2.OpenRead();
                Bitmap bitmap2 = new Bitmap(s2);
                s2.Close();

                bool res = ImageCompareString2(bitmap1, bitmap2, ressavePath + "\\" + a);
                if(!res)
                {
                    loadPIC(a,file1.FullName, build1, file2.FullName, build2, ressavePath + "\\" + a);
                }
            }
            
        }
        private static bool ImageCompareString2(Bitmap firstImage, Bitmap secondImage,string filename)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Rectangle> rects = ImageComparer.Compare(firstImage, secondImage);
            watch.Stop();
            if (rects.Count != 0)
            {
                using (Graphics g = Graphics.FromImage(firstImage))
                {
                    g.DrawRectangles(new Pen(Brushes.Blue, 1f), rects.ToArray());
                    g.Save();
                    firstImage.Save(filename);
                }
            }
            if (rects.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private static bool ImageCompareString(Bitmap firstImage, Bitmap secondImage)
        {
            MemoryStream ms = new MemoryStream();
            firstImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String firstBitmap = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            secondImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String secondBitmap = Convert.ToBase64String(ms.ToArray());

            if (firstBitmap.Equals(secondBitmap))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void loadPIC(string titleS,string file1,string build1,string file2,string build2,string result)
        {
            HtmlDocument doc = webBrowser1.Document;
            HtmlElement html = doc.GetElementById("myhtml");
            HtmlElement body = doc.GetElementById("mybody");

            //全部
            HtmlElement all = doc.CreateElement("div");
            all.SetAttribute("class", "all");
            //标题：
            HtmlElement title = doc.CreateElement("div");
            title.SetAttribute("class", "font");
            title.InnerText = titleS;
            all.AppendChild(title);
            //左侧
            HtmlElement left = doc.CreateElement("div");
            left.SetAttribute("class", "left");
            left.InnerHtml = "<div>" + build1 + "</div><div><img style='display: block; width: 100 %;' src='" + file1 + "'></img></div>";
            //中间
            HtmlElement center = doc.CreateElement("div");
            center.SetAttribute("class", "left");
            center.InnerHtml = "<div>" + build2 + "</div><div><img style='display: block; width: 100 %;' src='" + file2 + "'></img></div>";

            HtmlElement abc = doc.CreateElement("div");
            abc.SetAttribute("class", "abc");

            //右侧
            HtmlElement right = doc.CreateElement("div");
            right.SetAttribute("class", "left");
            right.InnerHtml = "<div>差异结果</div><div><img style='display: block; width: 100 %;' src='" + result + "'></img></div>";

            HtmlElement abc1 = doc.CreateElement("div");
            abc1.SetAttribute("class", "abc");

            all.AppendChild(left);
            all.AppendChild(center);
            all.AppendChild(right);
            all.AppendChild(abc);

            body.AppendChild(all);

            webBrowser1.DocumentText = html.OuterHtml;
        }
        private void Compare_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri("file://" + Environment.CurrentDirectory + "\\compare.html");
            //新建result目录
            //Directory.CreateDirectory(Environment.CurrentDirectory + "\\Result");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //保存html文件和比较的结果图片

        }
    }
}
