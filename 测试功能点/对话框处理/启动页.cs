using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppuimTestTools.测试功能点
{
    public class 启动页 : funPoint
    {
        public 启动页(BaseClass b, string id):base(b, id)
        {
            //编写前置条件
        }
        public override void init(TestCaseStatus status)
        {
            //编写前置条件

            base.init(status);
        }
        public override void Pass()
        {
            //base.Pass();
        }
        public override void Error()
        {
            //base.Error();
        }
    }
}
