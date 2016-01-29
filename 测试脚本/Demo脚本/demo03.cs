using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools.测试脚本.Demo脚本
{
    public class demo03 : BaseClass
    {
        public demo03()
        {
            Name = "测试03";
            seqID = 3F;
            Desc = "常见问题";
        }
        public override void Run()
        {
            Log("启动app");
            android.driver.LaunchApp();
            SaveScreenSnap("启动完成");
            Log("启动完成");
            var list = android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title");
            for (int i = 0; i < list.Count; i++)
            //foreach(var a in list)
            {
                if (list[i].Text == "我的")
                {




                   // Log("看：" + list[i].Text);
                    list[i].Click();
                    //单击 我的
                    Log("单击我的");
                    SaveScreenSnap("我的界面");
                }
            }
            Log("单击完成");
            var b = android.driver.FindElementById("com.lthealth.iwo:id/my_info_reading");

            b.Click();
            Log("单击用户必读");
            SaveScreenSnap("用户必读");
            //单击 用户必读

            //滑动
            var c = android.driver.FindElementById("com.lthealth.iwo:id/layout_question");
            c.Click();
            Log("单击常见问题");
            SaveScreenSnap("常见问题");
            //单击常见问题
            android.driver.Swipe(200, 500, 200, 100, 300);
            Log("页面滑动");
            SaveScreenSnap("常见问题页面滑动");
            android.driver.KeyEvent(AndroidKeyCode.Back);
            Log("返回");
            android.sleep();

            var d = android.driver.FindElementById("com.lthealth.iwo:id/layout_law");
            d.Click();
            Log("单击用户协议");
            SaveScreenSnap("用户协议");
            android.driver.Swipe(200,800,200,100,500);
            Log("用户协议滑动");
            SaveScreenSnap("用户协议滑动");

            


            android.driver.KeyEvent(AndroidKeyCode.Back);
            Log("返回");



        }

    }
}
