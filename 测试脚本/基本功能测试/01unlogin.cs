using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium;

namespace AppuimTestTools.测试脚本.基本功能测试
{
    class _01unlogin : BaseClass
    {
        public _01unlogin()
        {
            Name = "用户未登录下的测试";
            seqID = 10F;
            Desc = "用户未登录下对手机各个功能的浏览界面收集";
        }
        public override void Run()
        {
            Log("启动app");
            android.driver.LaunchApp();
            Log("启动完成");
            //android.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            /*出现初次启动页处理*/
            if (android.isExit("com.lthealth.iwo:id/viewGroup"))
            {
                Log("平移屏幕");
                android.driver.Swipe(700, 500, 200, 500, 500);
                android.sleep();
                android.driver.Swipe(700, 500, 200, 500, 500);
                Log("单击欢迎按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/bt_welcome").Click();
                foreach (var one in android.driver.FindElementsById("com.lthealth.iwo:id/name"))
                {
                    if (one.Text == "北京市")
                    {
                        Log("单击选择北京市");
                        one.Click();
                        break;
                    }
                }
            }


            /*
                单击我的
                resource id: com.lthealth.iwo:id/tab_btn_title
                text: 我的
            */
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
            SaveScreenSnap("我的界面");

            /*
                单击登录
                resource id: com.lthealth.iwo:id/my_info_relate
                text: 点击登录
                resource id: com.lthealth.iwo:id/my_info_name
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/my_info_relate").Displayed)
            {
                Log("单击登录按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/my_info_relate").Click();
                SaveScreenSnap("单击登录按钮");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }


            /*
                单击我的钱包 - 〉返回
                resource id: com.lthealth.iwo:id/rl_my_wallet
                resource id: com.lthealth.iwo:id/my_info_wallet
                text: 我的钱包
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_my_wallet").Displayed)
            {
                Log("单击我的钱包按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_my_wallet").Click();
                SaveScreenSnap("单击我的钱包按钮");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            /*
                单击智能卡 - 〉返回
                //resource id: com.lthealth.iwo:id/rl_smart_card
                //resource id: com.lthealth.iwo:id / tv_smart_cardt
                //text: 智能卡
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_smart_card").Displayed)
            {
                Log("单击智能卡按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_smart_card").Click();
                SaveScreenSnap("单击智能卡按钮");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            /*
                单击我的日程 - 〉返回
                //resource id: com.lthealth.iwo:id/rl_schedule
                //resource id: com.lthealth.iwo:id/my_info_schedule
                //text: 我的日程
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_schedule").Displayed)
            {
                Log("单击我的日程按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_schedule").Click();
                SaveScreenSnap("单击我的日程按钮");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            //返回按钮
            //resource id: com.lthealth.iwo:id/ll_base_activity_left
            //resource id: com.lthealth.iwo:id/tv_base_activity_left
            //text: 返回

            /*
            单击设置
            resource id: com.lthealth.iwo:id/rl_setting
            text: 设置
            resource id: com.lthealth.iwo:id/my_info_setting
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_setting").Displayed)
            {
                Log("单击设置按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_setting").Click();
                SaveScreenSnap("单击设置按钮");
            }
            /*
                //单击意见返回
                //text: 意见反馈
                //resource id: com.lthealth.iwo:id/rl_user_advice
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_user_advice").Displayed)
            {
                Log("单击意见反馈按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_user_advice").Click();
                SaveScreenSnap("单击意见反馈按钮");
            }
            /*
                //输入内容
                //resource id: com.lthealth.iwo:id/et_advice_content
                //resource id: com.lthealth.iwo:id / feedback_name
                //resource id: com.lthealth.iwo:id/feedback_phone
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/et_advice_content").Displayed)
            {
                Log("输入意见");
                var one = android.driver.FindElementById("com.lthealth.iwo:id/et_advice_content");
                one.SendKeys("AutoTesting:HelloWorld");
                SaveScreenSnap("输入意见");
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/feedback_name").Displayed)
            {
                Log("输入姓名");
                var one = android.driver.FindElementById("com.lthealth.iwo:id/feedback_name");
                one.SendKeys("AutoRabbit");
                SaveScreenSnap("输入姓名");
            }
            if (android.driver.FindElementById("com.lthealth.iwo:id/feedback_phone").Displayed)
            {
                Log("输入电话");
                android.driver.FindElementById("com.lthealth.iwo:id/feedback_phone").SendKeys("13466327537");
                SaveScreenSnap("输入电话");
            }
            /*
                单击提交
                resource id: com.lthealth.iwo:id/ll_base_activity_right
                resource id: com.lthealth.iwo:id/tv_base_activity_right
                text: 提交
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_right").Displayed)
            {
                Log("单击提交意见反馈按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_right").Click();
                SaveScreenSnap("单击提交意见反馈按钮");
                /*if (android.isExit("com.lthealth.iwo:id/feedback_phone"))
                {
                    //返回按钮
                    android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
                }*/
            }
            /*
                //单击关于我们
                //text: 关于我们
                //resource id: com.lthealth.iwo:id/rl_about_us
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_about_us").Displayed)
            {
                Log("单击关于我们按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_about_us").Click();
                SaveScreenSnap("单击关于我们按钮");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            //返回到上一个页面
            android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            /*
                //单击用户必读
                text: 用户必读
                resource id: com.lthealth.iwo:id/rl_user_must_read
                resource id: com.lthealth.iwo:id/my_info_reading
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/rl_user_must_read").Displayed)
            {
                Log("单击用户必读按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/rl_user_must_read").Click();
                SaveScreenSnap("单击用户必读按钮");
            }
            /*
                //单击常见问题
                //resource id: com.lthealth.iwo:id/layout_question
                //text: 常见问题
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/layout_question").Displayed)
            {
                Log("单击常见问题按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/layout_question").Click();
                SaveScreenSnap("单击常见问题按钮",2000);
            }
            /*
                //滚动3次
                //resource id: com.lthealth.iwo:id/tv_base_view
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/tv_base_view").Displayed)
            {
                Log("滚动常见问题文档");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动常见问题文档1");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动常见问题文档2");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动常见问题文档3");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            /*
                //单击法律声明
                //text: 法律声明
                //resource id: com.lthealth.iwo:id/layout_law
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/layout_law").Displayed)
            {
                Log("单击法律声明按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/layout_law").Click();
                SaveScreenSnap("单击法律声明按钮", 2000);
            }
            /*
                滚动5次
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/tv_base_view").Displayed)
            {
                Log("滚动法律声明文档");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动法律声明文档1");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动法律声明文档2");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动法律声明文档3");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动法律声明文档4");
                android.driver.Swipe(200, 700, 200, 200, 500);
                SaveScreenSnap("滚动法律声明文档5");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            //再次返回
            android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            //单击分享app给好友 - 〉返回
            /*
            text: 分享app给好友
            resource id: com.lthealth.iwo:id/tv_share
            resource id: com.lthealth.iwo:id/rl_share
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/tv_share").Displayed)
            {
                Log("单击分享app给好友按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/tv_share").Click();
                SaveScreenSnap("单击分享app给好友按钮");
                android.driver.KeyEvent(AndroidKeyCode.Back);
            }
            /*
            单击热线服务电话
            resource id: com.lthealth.iwo:id/tab_btn_title
            text: 服务热线
            */
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                foreach (var one in android.driver.FindElementsById("com.lthealth.iwo:id/tab_btn_title"))
                {
                    Log("发现按钮" + one.Text);
                    if (one.Text == "服务热线")
                    {
                        Log("单击服务热线按钮");
                        one.Click();
                        break;
                    }
                }
            }
            SaveScreenSnap("服务热线");

            /*
            //单击首页
            resource id: com.lthealth.iwo:id/tab_btn_default
            resource id: com.lthealth.iwo:id/tab_btn_title
            text: 首页
            */
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
            SaveScreenSnap("首页");

            Dictionary<string ,AppiumWebElement> Btn_List = new Dictionary<string, AppiumWebElement>();
            var main = android.driver.FindElementById("com.lthealth.iwo:id/gview");
            var list_txt = main.FindElementsById("com.lthealth.iwo:id/text");
            var list_btn = main.FindElementsById("com.lthealth.iwo:id/shapeColor");
            for (int i = 0; i < list_txt.Count; i++)
            {
                Btn_List.Add(list_txt[i].Text, list_btn[i]);
            }
            //单击健康数据（现在报错）
            /*
            resource id: com.lthealth.iwo:id/gview
            resource id: com.lthealth.iwo:id/shapeColor
            resource id: com.lthealth.iwo:id/text
            text: 健康监测
            */
            //单击亲情关注
            //text: 亲情关注
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击亲情关注按钮");
                Btn_List["亲情关注"].Click();
                SaveScreenSnap("亲情关注");
            }
            //单击增加按钮
            // com.lthealth.iwo:id/iv_add_relation
            if (android.driver.FindElementById("com.lthealth.iwo:id/iv_add_relation").Displayed)
            {
                Log("单击亲情关注增加按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/iv_add_relation").Click();
                SaveScreenSnap("亲情关注增加");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击关注我
            // com.lthealth.iwo:id/top_right_click
            //关注我
            if (android.driver.FindElementById("com.lthealth.iwo:id/top_right_click").Displayed)
            {
                Log("单击关注我按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/top_right_click").Click();
                SaveScreenSnap("关注我");
                //返回按钮
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            android.sleep();

            android.driver.FindElementById("com.lthealth.iwo:id/top_left").Click();

            //单击吾家讲堂
            //text: 吾家讲堂
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击吾家讲堂按钮");
                Btn_List["吾家讲堂"].Click();
                SaveScreenSnap("吾家讲堂1");
            }

            //单击确认按钮
            //com.lthealth.iwo:id/tv_cxy_dialog_pos
            //切换按钮: com.lthealth.iwo:id/tv_cxy_dialog_neg
            if(android.isExit("com.lthealth.iwo:id/tv_cxy_dialog_pos"))
            {
                Log("单击确认按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/tv_cxy_dialog_pos").Click();
            }
            SaveScreenSnap("吾家讲堂2");
            //单击活动
            //list id com.lthealth.iwo:id/lv_center_activity_recommendation
            //二级: android.widget.RelativeLayout
            //介绍:com.lthealth.iwo:id/tv_item_series_course_introduction
            if (android.driver.FindElementById("com.lthealth.iwo:id/lv_center_activity_recommendation").Displayed)
            {
                Log("单击某一个活动");
                var list = android.driver.FindElementById("com.lthealth.iwo:id/lv_center_activity_recommendation").FindElementsByClassName("android.widget.RelativeLayout");
                list[0].Click();
                SaveScreenSnap("单击活动", 2000);
            }
            //单击立即报名
            //com.lthealth.iwo:id/btn_activity_details_registration
            Log("单击报名");
            android.driver.FindElementById("com.lthealth.iwo:id/btn_activity_details_registration").Click();
            SaveScreenSnap("单击报名");
            //返回按钮
            android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();

            //返回按钮
            android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();



            //单击日照活动中心
            //com.lthealth.iwo:id/tv_base_activity_title
            if (android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_title").Displayed)
            {
                Log("单击日照活动中心");
                android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_title").Click();
                SaveScreenSnap("日照活动中心", 2000);
            }

            //单击选择 后 单击完成
            //com.lthealth.iwo:id/rb_select
            //com.lthealth.iwo:id/tv_base_activity_right
            if (android.driver.FindElementById("com.lthealth.iwo:id/rb_select").Displayed)
            {
                int i = 0;
                foreach(var one in android.driver.FindElementsById("com.lthealth.iwo:id/rb_select"))
                {
                    i++;
                    Log("选择一个:"+i.ToString());
                    one.Click();
                    SaveScreenSnap("选项" + i.ToString());
                }
                android.driver.FindElementById("com.lthealth.iwo:id/tv_base_activity_right").Click();
            }
            //返回按钮
            android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            //单击营养餐
            //text: 营养餐
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击营养餐按钮");
                Btn_List["营养餐"].Click();
                SaveScreenSnap("营养餐", 2000);
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击特惠商城
            //text: 特惠商城
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击特惠商城按钮");
                Btn_List["特惠商城"].Click();
                SaveScreenSnap("特惠商城", 4000);
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击上门服务
            //text: 上门服务
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击上门服务按钮");
                Btn_List["上门服务"].Click();
                SaveScreenSnap("上门服务", 2000);
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击新闻资讯
            //text: 新闻资讯
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击新闻资讯按钮");
                Btn_List["新闻资讯"].Click();
                SaveScreenSnap("新闻资讯", 2000);
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击音频娱乐
            //text: 音频娱乐
            if (android.driver.FindElementById("com.lthealth.iwo:id/tab_btn_title").Displayed)
            {
                Log("单击音频娱乐按钮");
                Btn_List["音频娱乐"].Click();
                SaveScreenSnap("音频娱乐", 2000);
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }
            //单击我的消息
            //resource id: com.lthealth.iwo:id/iv_notice_message
            if (android.driver.FindElementById("com.lthealth.iwo:id/iv_notice_message").Displayed)
            {
                Log("单击我的消息按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/iv_notice_message").Click();
                SaveScreenSnap("我的消息");
                android.driver.FindElementById("com.lthealth.iwo:id/ll_base_activity_left").Click();
            }

            android.Exit();
            Log("完成测试");
        }
    }
}
