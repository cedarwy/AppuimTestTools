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
            android.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.Parse("10000"));
            if (android.driver.FindElementById("com.lthealth.iwo:id/viewGroup").Displayed)
            {
                android.driver.Swipe(700, 500, 200, 500, 500);
                android.driver.Swipe(700, 500, 200, 500, 500);
                android.driver.Swipe(700, 500, 200, 500, 500);
                android.driver.FindElementById("com.lthealth.iwo:id/bt_welcome").Click();
                foreach(var one in android.driver.FindElementsById("com.lthealth.iwo:id/name"))
                {
                    if(one.Text == "北京市")
                    {
                        one.Click();
                        break;
                    }
                }
            }
            //android.driver.CloseApp();

            
        }
    }
}
