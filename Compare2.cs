using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppuimTestTools
{
    public partial class Compare2 : Form
    {
        public Compare2()
        {
            InitializeComponent();
        }

        private string path_1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                this.path_1 = this.folderBrowserDialog1.SelectedPath;
                this.lb_path1.Text = this.path_1;
            }
        }
        Dictionary<string, Filestatus> Filelist = new Dictionary<string, Filestatus>();
        private void button3_Click(object sender, EventArgs e)
        {
            string build1 = path_1.Substring(path_1.LastIndexOf("build"), 14);
            //新建保存目录
            string ressavePath = ConfigurationManager.AppSettings["ResultPath"] + "\\Result\\" + build1 + "\\";
            Directory.CreateDirectory(ressavePath);

            //加载路径1的文件列表
            string[] filelist = Directory.GetFiles(this.path_1);
            foreach (string one in filelist)
            {
                string filename = one.Substring(one.LastIndexOf("\\") + 1);
                string name = filename.Split('_')[0] + filename.Split('_')[1];
                Filestatus status = new Filestatus();
                if (Filelist.ContainsKey(name))
                {
                    status = Filelist[name];
                }
                else
                {
                    Filelist.Add(name, status);
                }
                if(null == status.filepath1)
                    status.filepath1 = one;
                else if (null == status.filepath2)
                    status.filepath2 = one;
                else if (null == status.filepath3)
                    status.filepath3 = one;
                else if (null == status.filepath4)
                    status.filepath4 = one;
                status.filename = name;
                Filelist[name] = status;
            }
            loadPIC("测试结果");
        }
        private void loadPIC(string titleS)
        {
            HtmlDocument doc = webBrowser1.Document;
            HtmlElement html = doc.GetElementById("myhtml");
            HtmlElement body = doc.GetElementById("mybody");

            //全部
            HtmlElement all = doc.CreateElement("div");
            all.SetAttribute("class", "all");

            foreach(var one in Filelist)
            {
                //标题：
                HtmlElement title = doc.CreateElement("div");
                title.SetAttribute("class", "font");
                title.InnerText = one.Value.filename;
                all.AppendChild(title);
                //左侧
                HtmlElement left = doc.CreateElement("div");
                left.SetAttribute("class", "left");
                left.InnerHtml = "<div>当时</div><div><img style='display: block; width: 100 %;' src='" + one.Value.filepath1 + "'></img></div>";
                //中间
                HtmlElement center = doc.CreateElement("div");
                center.SetAttribute("class", "left");
                center.InnerHtml = "<div>1s</div><div><img style='display: block; width: 100 %;' src='" + one.Value.filepath2 + "'></img></div>";

                HtmlElement center1 = doc.CreateElement("div");
                center1.SetAttribute("class", "left");
                center1.InnerHtml = "<div>2s</div><div><img style='display: block; width: 100 %;' src='" + one.Value.filepath3 + "'></img></div>";

                HtmlElement center2 = doc.CreateElement("div");
                center2.SetAttribute("class", "left");
                center2.InnerHtml = "<div>3s</div><div><img style='display: block; width: 100 %;' src='" + one.Value.filepath4 + "'></img></div>";

                HtmlElement abc = doc.CreateElement("div");
                abc.SetAttribute("class", "abc");

                HtmlElement abc1 = doc.CreateElement("div");
                abc1.SetAttribute("class", "abc");

                all.AppendChild(left);
                all.AppendChild(center);
                all.AppendChild(center1);
                all.AppendChild(center2);
                all.AppendChild(abc);

                body.AppendChild(all);
            }



            webBrowser1.DocumentText = html.OuterHtml;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string build1 = path_1.Substring(path_1.LastIndexOf("build"), 14);
            //保存html文件和比较的结果图片
            string htmlPath = ConfigurationManager.AppSettings["ResultPath"] + "\\Result\\" + build1  + ".html";
            string html = webBrowser1.DocumentText;
            html = html.Replace("file:///" + ConfigurationManager.AppSettings["ResultPath"].Replace("\\", "/"), "http://192.168.1.42/testpage/AndroidAPPScreen");

            StreamWriter w = new StreamWriter(htmlPath, false, Encoding.UTF8);
            w.Write(html);
            w.Flush();
            w.Close();
            MessageBox.Show("保存完成");
        }

        private void Compare2_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri("file://" + Environment.CurrentDirectory + "\\compare.html");
        }
    }
    public class Filestatus
    {
        public string filepath1 { get; set; }
        public string filepath2 { get; set; }
        public string filepath3 { get; set; }
        public string filepath4 { get; set; }
        public string filename { get; set; }
    }
}
