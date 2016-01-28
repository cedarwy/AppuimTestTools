using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools.测试功能点
{
    public class yunOS选择对话框 : funPoint
    {
        public yunOS选择对话框(BaseClass b, string id):base(b, id)
        {
            //编写前置条件
        }
        public override void init(TestCaseStatus status)
        {
            //编写前置条件
            //判断该Id的控件是否存在
            if(TC.android.isExit2(objectID))
            {
                //加载页面中其它元素
                List.Add("提示文字",TC.android.driver.FindElementById("com.aliyun.mobile.permission:id/mc_pm_textView"));
                List.Add("单选按钮", TC.android.driver.FindElementById("com.aliyun.mobile.permission:id/mc_pm_check"));
                List.Add("拒绝按钮", TC.android.driver.FindElementById("android:id/button2"));
                List.Add("允许按钮", TC.android.driver.FindElementById("android:id/button1"));
                //存在
                base.init(status);
            }
            else
            {

            }
            
        }
        public override void Pass()
        {
            List["允许按钮"].Click();
            //base.Pass();
        }
        public override void Error()
        {
            //base.Error();
        }
    }
}
