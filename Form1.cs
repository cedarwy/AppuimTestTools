using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace AppuimTestTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string apkpath = System.Environment.CurrentDirectory + "\\app-release.apk";
        private List<BaseClass> AllClass = new List<BaseClass>();
        private selectItem selectITEM = new selectItem();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllClass();
            AllClass.Sort();
            for (int i = 0; i < AllClass.Count; i++)
            {
                //加载功能列表
                listBox1.Items.Add(AllClass[i].Name);
                if (i + 1 < AllClass.Count)
                {
                    if (AllClass[i + 1].seqID % 10 == 0)
                    {
                        listBox1.Items.Add("-----");
                    }
                }
            }
            //this.comboBox1.Items.Add("A10ABMMVRGF2");
            refresh();
        }
        private void refresh()
        {
            this.lb_respath.Text = ConfigurationManager.AppSettings["ResultPath"];
            this.lb_sdkpath.Text = ConfigurationManager.AppSettings["androidSDKPath"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectITEM.apkPath = System.Environment.CurrentDirectory + "\\app-release.apk";
            //读版本信息//并建立目录
            apkreader reader = new apkreader(selectITEM.apkPath);
            var list = reader.androidInfos;
            //list[0].Settings[1].Value
            string buildname = "build_" + list[0].Settings[1].Value;

            selectITEM.function.init(selectITEM.deviceID,selectITEM.apkPath);
            selectITEM.function.setLogRT(this.richTextBox1);
            selectITEM.function.setResultPath(ConfigurationManager.AppSettings["ResultPath"] + "//" + buildname + "//");
            Thread t = new Thread(new ThreadStart(selectITEM.function.Run));
            t.Start();
            //selectITEM.function.Run();
        }
        private void LoadAllClass()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var baseType = typeof(BaseClass);
            AllClass = new List<BaseClass>();
            foreach (var t in types)
            {
                var tmp = t.BaseType;
                while (tmp != null)
                {
                    if (tmp == baseType)
                    {
                        BaseClass obj = MethodMaker.CreateObject(t.FullName) as BaseClass;
                        if (obj != null)
                        {
                            AllClass.Add(obj);
                        }
                        break;
                    }
                    else
                    {
                        tmp = tmp.BaseType;
                    }
                }
            }
        }
        private void 获取最新的APKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string downurl = "";
            string msg = Http.CheckAPK(ref downurl);
            if (DialogResult.Yes == MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo))
            {
                if (downurl != "")
                {
                    Http.DownloadAPK(downurl, System.Environment.CurrentDirectory);
                    MessageBox.Show("下载完成");
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                //加载服务器列表
                foreach (var one in AllClass)
                {
                    if (this.listBox1.SelectedItem.ToString().IndexOf("---") > -1)
                    {
                        break;
                    }
                    if (this.listBox1.SelectedItem.ToString() == one.Name)
                    {
                        selectITEM.function = one;
                        selectITEM.deviceID = this.comboBox1.SelectedText.ToString();
                        selectITEM.apkPath = apkpath;

                        this.label3.Text = "测试名称：" + one.Name;
                        this.label4.Text = "测试描述：" + one.Desc;
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["androidSDKPath"] != "")
            {
                this.comboBox1.Items.Clear();
                string d = Utils.GetDevice(ConfigurationManager.AppSettings["androidSDKPath"]);
                d = d.Replace("\r\n", "");
                d = d.Replace("\t", "");
                d = d.Replace("List of devices attached", "");
                d = d.Replace("device", "");
                d = d.Replace(" ", "");
                this.comboBox1.Items.Add(d);
                this.comboBox1.SelectedIndex = 0;
            }
        }

        private void 设置SDK的路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["androidSDKPath"].Value = this.folderBrowserDialog1.SelectedPath;
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                refresh();
            }
        }

        private void 设置结果保存路径ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog1.ShowDialog())
            {
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["ResultPath"].Value = this.folderBrowserDialog1.SelectedPath;
                cfa.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                refresh();
            }
        }

        private void 比较测试结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare com = new Compare();
            com.ShowDialog();
        }

        private void 相同界面时间比较ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare2 com = new Compare2();
            com.ShowDialog();
        }

        private void 连续4次截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["androidSDKPath"] != "")
            {
                string filename1 = "screenshot1.png";
                Utils.GetScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename1);
                string filename2 = "screenshot2.png";
                Utils.GetScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename2);
                string filename3 = "screenshot3.png";
                Utils.GetScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename3);
                string filename4 = "screenshot4.png";
                Utils.GetScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename4);
                if (ConfigurationManager.AppSettings["ResultPath"] != "")
                {
                    Utils.SaveScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename1, ConfigurationManager.AppSettings["ResultPath"]);
                    Utils.SaveScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename2, ConfigurationManager.AppSettings["ResultPath"]);
                    Utils.SaveScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename3, ConfigurationManager.AppSettings["ResultPath"]);
                    Utils.SaveScreenShot(ConfigurationManager.AppSettings["androidSDKPath"], filename4, ConfigurationManager.AppSettings["ResultPath"]);
                }
            }
        }
    }
    public class selectItem
    {
        public BaseClass function;
        public string deviceID;
        public string apkPath;
    }
    public class MethodMaker
    {

        /// <summary>
        /// 创建对象（当前程序集）
        /// </summary>
        /// <param name="typeName">类型名</param>
        /// <returns>创建的对象，失败返回 null</returns>
        public static object CreateObject(string typeName)
        {
            object obj = null;
            try
            {
                Type objType = Type.GetType(typeName, true);
                obj = Activator.CreateInstance(objType);
            }
            catch (Exception ex)
            {
                //Debug.Write(ex);
            }
            return obj;
        }

        /// <summary>
        /// 创建对象(外部程序集)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="typeName">类型名</param>
        /// <returns>创建的对象，失败返回 null</returns>
        public static object CreateObject(string path, string typeName)
        {
            object obj = null;
            try
            {

                obj = Assembly.Load(path).CreateInstance(typeName);
            }
            catch (Exception ex)
            {
                //Debug.Write(ex);
            }

            return obj;
        }
    }
}
