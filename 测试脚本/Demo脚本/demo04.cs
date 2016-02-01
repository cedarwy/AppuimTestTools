using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;

namespace AppuimTestTools.测试脚本.Demo脚本
{
    public class demo04 : BaseClass
    {
        public demo04()
        {
            Name = "测试04";
            seqID = 4F;
            Desc = "113213123";
        }
        public override void Run()
        {
           
            android.driver.LaunchApp();
            SaveScreenSnap("启动完成");
            Log("启动完成");
            android.sleep();
          

            var list = android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title");
            for (int i = 0; i < list.Count; i++)
            //foreach(var a in list)
            {
                if (list[i].Text.IndexOf("我的")>-1)  //返回值在字符串的位置
                {
                    // Log("看：" + list[i].Text);
                    list[i].Click();
                    //单击 我的d
                    Log("单击我的");
                    SaveScreenSnap("我的界面");
                }
            }
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

                var f = android.driver.FindElementById("com.lthealth.iwo:id/my_info_wallet");
                    f.Click();
                Log("进入我的钱包");
                SaveScreenSnap("我的钱包");
                var y = android.driver.FindElementById("com.lthealth.iwo:id/tv_accounts");
                   Log("余额 " +y.Text+ "元");
                                  
                var z = android.driver.FindElementById("com.lthealth.iwo:id/tv_zhengfu_accounts");
               
                  Log("政府补贴"+z.Text+"元");
                var h = android.driver.FindElementById("com.lthealth.iwo:id/income_details");
                h.Click();
                Log("收支明细");
                SaveScreenSnap("收支明细");
        
        
           



           



            

            //com.lthealth.iwo:id / my_info_name 登陆
            //com.lthealth.iwo:id/et_login_activity_username 用户名
            //com.lthealth.iwo:id/edit_login_activity_password 密码
            //com.lthealth.iwo:id/btn_login_activity_login 登陆
            //com.lthealth.iwo:id/my_info_wallet 钱包
            //com.lthealth.iwo:id / wall_linear 余额
            //com.lthealth.iwo:id / tv_zhengfu_linear 补贴明细
            //com.lthealth.iwo:id/income_details 收支明细


        }
    }
}

