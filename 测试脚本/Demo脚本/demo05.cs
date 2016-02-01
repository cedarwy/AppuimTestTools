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
            
        }
    }
}
