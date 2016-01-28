using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools.测试脚本.界面跳转测试
{
    public class mytest : BaseClass
    {
        public mytest()
        {
            Name = "用户登录下的不同页面的跳转";
            seqID = 30F;
            Desc = "不同页面的跳转收集";
        }
        public override void Run()
        {
            Log("启动app");
            android.driver.LaunchApp();
            Log("启动完成");
            android.sleep();
            android.sleep();
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                foreach (var one in android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title"))
                {
                    Log("发现按钮" + one.Text);
                    if (one.Text == "我的")
                    {
                        Log("单击我的按钮");
                        one.Click();
                        break;
                    }
                }
            }
            //单击姓名
            if (android.driver.FindElementById("com.lthealth.iwo:id/my_info_relate").Displayed)
            {
                Log("个人资料界面");
                android.driver.FindElementById("com.lthealth.iwo:id/my_info_relate").Click();
                Save4ScreenSnap("个人资料界面");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_my_wallet").Displayed)
            {
                Log("我的钱包界面");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_my_wallet").Click();
                Save4ScreenSnap("我的钱包界面");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_smart_card").Displayed)
            {
                Log("我的智能卡界面");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_smart_card").Click();
                Save4ScreenSnap("我的智能卡界面");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_schedule").Displayed)
            {
                Log("我的日程界面");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_schedule").Click();
                Save4ScreenSnap("我的日程界面");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/tv_back").Click();
            }
            //返回首页
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                foreach (var one in android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title"))
                {
                    Log("发现按钮" + one.Text);
                    if (one.Text == "首页")
                    {
                        Log("单击首页按钮");
                        one.Click();
                        break;
                    }
                }
            }
            Dictionary<string, AppiumWebElement> Btn_List = new Dictionary<string, AppiumWebElement>();
            var main = android.driver.FindElementById("com.lthealth.iwo:id/gview");
            var list_txt = main.FindElementsById("com.lthealth.iwo:id/text");
            var list_btn = main.FindElementsById("com.lthealth.iwo:id/shapeColor");
            for (int i = 0; i < list_txt.Count; i++)
            {
                Btn_List.Add(list_txt[i].Text, list_btn[i]);
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("健康监测界面");
                Btn_List["健康监测"].Click();
                Save4ScreenSnap("健康监测界面");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击亲情关注按钮");
                Btn_List["亲情关注"].Click();
                Save4ScreenSnap("亲情关注");
                android.driver.FindElementById("com.lthealth.iwo:id/top_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("吾家讲堂界面");
                Btn_List["吾家讲堂"].Click();
                Save4ScreenSnap("吾家讲堂界面");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("营养餐界面");
                Btn_List["营养餐"].Click();
                Save4ScreenSnap("营养餐界面");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("特惠商城界面");
                Btn_List["特惠商城"].Click();
                Save4ScreenSnap("特惠商城界面");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("上门服务界面");
                Btn_List["上门服务"].Click();
                Save4ScreenSnap("上门服务界面");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
        }
    }
}
