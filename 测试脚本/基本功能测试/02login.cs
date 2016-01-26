using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppuimTestTools.测试功能点;

namespace AppuimTestTools.测试脚本.基本功能测试
{
    public class _02login : BaseClass
    {
        public _02login()
        {
            Name = "用户登录下的测试";
            seqID = 11F;
            Desc = "用户登录下对手机各个功能的浏览界面收集";
        }
        public override void Run()
        {
            Log("启动app");
            android.driver.LaunchApp();
            Log("启动完成");
            //android.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse("5"));
            yunOS选择对话框 dialog = new yunOS选择对话框(this, "com.aliyun.mobile.permission:id/mc_pm_textView");
            dialog.init(TestCaseStatus.通过测试);

            if (android.isExit2("com.lthealth.iwo:id/viewGroup"))
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

            android.Exit();
            Log("完成测试");
        }
    }
}
