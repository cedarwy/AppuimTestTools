using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace AppuimTestTools
{
    public class BaseClass : IComparable<BaseClass>
    {
        public string Name;
        public float seqID;
        public string Desc;
        protected Android android;
        private RichTextBox rt;
        private string ResultPath;
        private int Pic_Count;
        public BaseClass()
        {

        }
        public void init(string deviceID, string apkpath)
        {
            android = new Android(deviceID, apkpath);  
        }
        public void setLogRT(RichTextBox r)
        {
            rt = r;
            rt.Text = "";
        }
        public void setResultPath(string path)
        {
            ResultPath = path;
            ResultPath += "\\" + Name + "_" + DateTime.Now.ToString("yyyyMMddhhmm") + "\\";
            Pic_Count = 0;
        }
        public virtual void Run()
        {
            
        }
        public int CompareTo(BaseClass obj)
        {
            int result;
            try
            {
                //JsonBaseClass info = obj as JsonBaseClass;
                if (this.seqID > obj.seqID)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #region 保存截图处理
        protected void SaveScreenSnap(string name)
        {
            Pic_Count++;
            string savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name +".png";
            var pic = android.driver.GetScreenshot();
            if(!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
            Thread.Sleep(200);
            pic.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);
        }

        #endregion

        #region 显示日志的处理
        private delegate void SetLogdeltegate(string text);
        protected void Log(string text)
        {
            if (rt.InvokeRequired)
                rt.Invoke(new SetLogdeltegate(SetLog), text);
            else
                SetLog(text);
        }
        private void SetLog(string s)
        {
            rt.Text = rt.Text + s + "\n";
        }
        #endregion

    }
}
