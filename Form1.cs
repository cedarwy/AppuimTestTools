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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectITEM.function.init(selectITEM.deviceID,selectITEM.apkPath);
            selectITEM.function.Run();
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
                d = d.Replace("List of devices attached\r\n", "");
                d = d.Replace("\tdevice\r\n\r\n", "");
                this.comboBox1.Items.Add(d);
                this.comboBox1.SelectedIndex = 0;
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
