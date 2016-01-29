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
        public Android android;
        private RichTextBox rt;
        private string ResultPath;
        private float Pic_Count;
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
            ResultPath += "\\" + Name + "_" + DateTime.Now.ToString("yyyyMMddHHmm") + "\\";
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
        public void Save4ScreenSnap(string name)
        {
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
            //截图,基本需要消耗1秒
            DateTime dt = DateTime.Now;
            var pic1 = android.driver.GetScreenshot();
            TimeSpan span = DateTime.Now - dt;
            Log("截图耗时：" + span.TotalMilliseconds);
            //Thread.Sleep(100);
            var pic2 = android.driver.GetScreenshot();
            //Thread.Sleep(300);
            var pic3 = android.driver.GetScreenshot();
            //Thread.Sleep(500);
            var pic4 = android.driver.GetScreenshot();


            //分开截图，统一保存
            int count = 1;
            Pic_Count++;
            string savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name + "_" + String.Format("{0:000}", count) + ".png";
            pic1.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);

            
            count++;
            savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name + "_" + String.Format("{0:000}", count) + ".png";
            pic2.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);


            
            count++;
            savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name + "_" + String.Format("{0:000}", count) + ".png";
            pic3.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);


            count++;
            savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name + "_" + String.Format("{0:000}", count) + ".png";
            pic4.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);
            
        }
        private static void SaveScreen(object android)
        {
            threadforsave temp = (threadforsave)android;
            var pic1 = temp.android.driver.GetScreenshot();
            pic1.SaveAsFile(temp.filepath, System.Drawing.Imaging.ImageFormat.Png);
        }
        public void SaveTempScreenSnap(string name)
        {
            Thread.Sleep(300);
            Pic_Count = Pic_Count + 0.1F;
            string savename = ResultPath + String.Format("{0:000}", Pic_Count) + "_" + name + ".png";
            var pic = android.driver.GetScreenshot();
            if (!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
            pic.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);
        }
        public void SaveScreenSnap(string name)
        {
            Thread.Sleep(300);
            Pic_Count++;
            string savename = ResultPath + String.Format("{0:000}", System.Math.Abs(Pic_Count)) + "_" + name +".png";
            var pic = android.driver.GetScreenshot();
            if(!Directory.Exists(ResultPath))
            {
                Directory.CreateDirectory(ResultPath);
            }
            pic.SaveAsFile(savename, System.Drawing.Imaging.ImageFormat.Png);
        }
        public void SaveScreenSnap(string name,int time)
        {
            Thread.Sleep(time - 300);
            SaveScreenSnap(name);
        }
        #endregion

        #region 显示日志的处理
        private delegate void SetLogdeltegate(string text);
        public void Log(string text)
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
    public class threadforsave
    {
        public Android android { get; set; }
        public string filepath { get; set; }
    }
}
