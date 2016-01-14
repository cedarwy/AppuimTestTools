using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appium.Interfaces.Generic.SearchContext;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Enums;

namespace AppuimTestTools
{
    public class Android
    {
        public AppiumDriver<AndroidElement> driver;
        private Uri serverUri = new Uri("http://127.0.0.1:4723/wd/hub/");
        public Android(string deviceID,string apkPath)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.4.2");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, deviceID);
            capabilities.SetCapability(MobileCapabilityType.App, apkPath);
            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, TimeSpan.FromSeconds(180));
        }
    }
}
