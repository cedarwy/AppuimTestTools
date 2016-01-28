using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools
{
    public class funPoint
    {
        public BaseClass TC;
        public string objectID;
        public Dictionary<string, AppiumWebElement> List;
        public funPoint (BaseClass testcase,string id)
        {
            TC = testcase;
            objectID = id;
            List = new Dictionary<string, AppiumWebElement>();
        }
        public virtual void init(TestCaseStatus status)
        {
            //检查该id对象是否出现

            if(status == TestCaseStatus.验证测试)
            {
                Error();
            }
            Pass();
        }
        public virtual void Pass()
        {

        }
        public virtual void Error()
        {

        }
        



    }
}
