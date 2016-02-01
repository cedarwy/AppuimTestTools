using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;

namespace AppuimTestTools.测试脚本.Demo脚本
{
    public class demo05:BaseClass
    { 
        public demo05()
        {
                  Name = "测试05";
                  seqID = 5F;
                 Desc = "你好";
        }
        public override void Run()
        {

            android.driver.LaunchApp();
            SaveScreenSnap("启动完成");
            Log("启动完成");
            android.sleep();
            
            var a = android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title");
            foreach(var one in a)
            {
                if (one.Text == "我的")
                {
                    one.Click();

                }
            }
            var z = android.driver.FindElementById("com.lthealth.iwo:id/my_info_name");
            if (z.Text == "点击登录")

            {
                var b = android.driver.FindElementById("com.lthealth.iwo:id/my_info_name");

                b.Click();
                Log("点击登陆");
                SaveScreenSnap("登陆页面");

                var c = android.driver.FindElementById("com.lthealth.iwo:id/et_login_activity_username");
                c.SendKeys("13699260115");
                Log("输入用户名");
                SaveScreenSnap("输入用户名");
                android.sleep();
                var d = android.driver.FindElementById("com.lthealth.iwo:id/edit_login_activity_password");
                d.SendKeys("123456");
                Log("输入密码");
                SaveScreenSnap("输入密码");
                android.sleep();
                var e = android.driver.FindElementById("com.lthealth.iwo:id/btn_login_activity_login");
                e.Click();
                Log(" 点击登陆");
                SaveScreenSnap("登陆完成");
                android.sleep();
            }

            else
            {
                var x = android.driver.FindElementById("com.lthealth.iwo:id/my_info_setting");

                x.Click();
                Log("点击设置");
                SaveScreenSnap("设置");

                var y = android.driver.FindElementById("com.lthealth.iwo:id/btn_exit");

                y.Click();
                Log("退出登陆");
                SaveScreenSnap("退出登陆");

                var q = android.driver.FindElementById("com.lthealth.iwo:id/dialog_left_txt");
                q.Click();
                Log("确认退出");
                SaveScreenSnap("确认退出");
              }


        }   
    }
}
