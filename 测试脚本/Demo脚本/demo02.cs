using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools.Demo脚本
{
    public class demo02 : BaseClass
    {
        public demo02()
        {
            Name = "测试02";
            seqID = 2F;
            Desc = "初次进入移动屏幕并选择城市";
        }
        public override void Run()
        {
            Log("启动app");
            android.driver.LaunchApp();
            Log("启动完成");
            android.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse("10000"));
            if (android.driver.FindElementById("com.lthealth.iwo:id/viewGroup").Displayed)
            {
                SaveScreenSnap("启动屏幕");
                Log("平移屏幕");
                android.driver.Swipe(700, 500, 200, 500, 500);
                SaveScreenSnap("欢迎屏幕2");
                android.driver.Swipe(700, 500, 200, 500, 500);
                SaveScreenSnap("欢迎屏幕3");
                //android.driver.Swipe(700, 500, 200, 500, 500);

                Log("单击欢迎按钮");
                android.driver.FindElementById("com.lthealth.iwo:id/bt_welcome").Click();
                SaveScreenSnap("选择城市界面");
                foreach (var one in android.driver.FindElementsById("com.lthealth.iwo:id/name"))
                {
                    if(one.Text == "北京市")
                    {
                        Log("单击选择北京市");
                        one.Click();
                        break;
                    }
                }
                SaveScreenSnap("首界面");
            }
            //android.driver.CloseApp();

            //android.driver.Close();
        }
    }
}
