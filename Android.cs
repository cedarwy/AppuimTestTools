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
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium;

namespace AppuimTestTools
{
    public class Android
    {
        public AndroidDriver<AppiumWebElement> driver;
        private Uri serverUri = new Uri("http://127.0.0.1:4723/wd/hub/");
        public Android(string deviceID, string apkPath)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.AppiumVersion, "1.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "4.4.2");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, deviceID);
            capabilities.SetCapability("autoLaunch", false);
            capabilities.SetCapability(MobileCapabilityType.AppPackage, "com.lthealth.iwo");
            capabilities.SetCapability(MobileCapabilityType.AppActivity, "com.lthealth.iwo.ui.activity.other.SplashActivity");
            //capabilities.SetCapability(MobileCapabilityType.AppActivity, "com.lthealth.iwo.ui.activity.user.info.UserReadActivity");
            //capabilities.SetCapability(MobileCapabilityType.App, apkPath);
            driver = new AndroidDriver<AppiumWebElement>(serverUri, capabilities, TimeSpan.FromSeconds(60));
        }
        public void sleep()
        {
            Thread.Sleep(500);
        }
        public void Exit()
        {
            driver.Quit();
        }
        public bool isExit2(string ID)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.Id(ID));
                    return true;
                }
                catch (WebDriverException)
                {
                    return false;
                }
            });
            return false;
        }
        public bool isExit(string ID)
        {
            try
            {
                driver.FindElementById(ID);
                return true;
            }
            catch(WebDriverException e)
            {
                return false;
            }
            /*catch (NoSuchElementException e)
            {
                return false;
            }*/
        }
    }

}
