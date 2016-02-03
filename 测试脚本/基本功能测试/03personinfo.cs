using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
namespace AppuimTestTools.测试脚本.基本功能测试
{
    public class _03personinfo : BaseClass
    {
        public _03personinfo()
        {
            Name = "个人设置页面";
            seqID = 12F;
            Desc = "设置各页面";
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
            var a = android.driver.FindElementById("com.lthealth.iwo:id/my_info_name");
            
            a.Click();
            Log("我的个人页面");
            SaveScreenSnap("个人页面");

            var e = android.driver.FindElementById("com.lthealth.iwo:id/info_modify_said");
            e.Click();
            Log("称呼页面");
            SaveScreenSnap("修改称呼页面");

            var b = android.driver.FindElementById("com.lthealth.iwo:id/et_nick_name");
            b.SendKeys("JackJones");
            Log("修改昵称为JackJones");
            SaveScreenSnap("修改昵称");
            var c = android.driver.FindElementById("com.lthealth.iwo:id/rb_complete_info_activity_lady");
            c.Click();
            Log("修改性别");
            SaveScreenSnap("修改为女性");

            var d = android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_right");
            d.Click();
            Log("保存昵称");
            SaveScreenSnap("修改昵称");

            var f = android.driver.FindElementById("com.lthealth.iwo:id/info_modify_address");
            f.Click();
            Log("进入家庭地址");
            SaveScreenSnap("家庭地址");

            var g = android.driver.FindElementById("com.lthealth.iwo:id/tv_city_address");
            g.Click();
            Log("点选省市");
            SaveScreenSnap("城市选择");

            var h = android.driver.FindElementById("com.lthealth.iwo:id/done");
            h.Click();
            Log("选定城市");

            var j = android.driver.FindElementById("com.lthealth.iwo:id/et_complete_info_activity_name");
            j.SendKeys("111");
            Log("输入地址");

            var k = android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_right");
            k.Click();
            Log("保存");

            var l = android.driver.FindElementById("com.lthealth.iwo:id/info_modify_contact");
            l.Click();
            Log("点击紧急联系人");

            var m = android.driver.FindElementById("com.lthealth.iwo:id/contact_add");
            m.Click();
            Log("点击添加紧急联系人");

            var n = android.driver.FindElementById("com.lthealth.iwo:id/contact_name");
            n.SendKeys("abcc");
            Log("输入姓名");

            var o = android.driver.FindElementById("com.lthealth.iwo:id/contact_phone");
            o.SendKeys("13412345678");
            Log("输入电话");

            var p = android.driver.FindElementById("com.lthealth.iwo:id/contact_relation");
            p.SendKeys("w");
            Log("输入关系");

            var q = android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_right");
            q.Click();
            Log("单击保存");
            android.driver.KeyEvent(AndroidKeyCode.Back);
            var r = android.driver.FindElementById("com.lthealth.iwo:id/info_modify_pwd");
            r.Click();
            Log("点击修改登录密码");

            var s = android.driver.FindElementById("com.lthealth.iwo:id/et_set_password_activity_password_old");
            s.SendKeys("111111");
               Log("输入原密码");
            var t = android.driver.FindElementById("com.lthealth.iwo:id/et_set_password_activity_password1");
            t.SendKeys("111111");
            Log("输入新密码");

            var u = android.driver.FindElementById("com.lthealth.iwo:id/et_set_password_activity_password2");
            u.SendKeys("111111");
            Log("再次输入新密码");

            var v = android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_right");
            v.Click();
            Log("保存");
            // android.driver.KeyEvent(AndroidKeyCode.Back);
        }
    }

 }



/*com.lthealth.iwo:id/info_modify_pwd 修改密码
    com.lthealth.iwo:id/et_set_password_activity_password_old
     com.lthealth.iwo:id/et_set_password_activity_password1
         com.lthealth.iwo:id/et_set_password_activity_password2
        com.lthealth.iwo:id/tv_base_activity_right*/