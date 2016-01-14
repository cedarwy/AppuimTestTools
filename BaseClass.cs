﻿using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AppuimTestTools
{
    public class BaseClass : IComparable<BaseClass>
    {
        public string Name;
        public float seqID;
        public string Desc;
        protected Android android;
        public BaseClass()
        {

        }
        public void init(string deviceID, string apkpath)
        {
            android = new Android(deviceID, apkpath);
            
        }

        public virtual void Run()
        {
            
        }
        public int CompareTo(BaseClass obj)
        {
            int result;
            try
            {
                //JsonBaseClass info = obj as JsonBaseClass;
                if (this.seqID > obj.seqID)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
