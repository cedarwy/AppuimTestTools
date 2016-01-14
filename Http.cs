using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Globalization;
using Ivony.Html.Web;
using Ivony.Html.Parser;
using Ivony.Html;

namespace AppuimTestTools
{
    public static class Http
    {
        public static string CheckAPK(ref string url)
        {
            string downloadurl = "http://192.168.1.40/iwu_android/";
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            Byte[] pageData = MyWebClient.DownloadData(downloadurl);
            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            var htmlSource = new JumonyParser().Parse(pageHtml);
            var one = htmlSource.Find("img[src=/icons/folder.gif]").Last();
            string releaseUrl = one.Parent().Parent().Find("a[href]").First().InnerText();
            string time = one.Parent().Parent().Find("td[align=right]").ElementAt(0).InnerText();

            url = downloadurl + releaseUrl + "apk/app-release.apk";
            return "最新版本号：" + releaseUrl + "\n 版本时间：" + time +"\n是否确定下载？";
        }
        public static void DownloadAPK(string url,string savepath)
        {
            //string path = savepath.Substring(0, savepath.LastIndexOf("\\") + 1) + "app-release.apk";
            string path = savepath + "\\app-release.apk";
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            Byte[] pageData = MyWebClient.DownloadData(url);
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(pageData, 0, pageData.Length);
            fs.Flush();
            fs.Close();
        }
        //
        //<tr><td valign="top"><img src="/icons/folder.gif" alt="[DIR]"></td><td><a href="01CreateScreen/">01CreateScreen/</a></td><td align="right">2016-01-11 10:23  </td><td align="right">  - </td><td>&nbsp;</td></tr>
        //<tr><td valign="top"><img src="/icons/text.gif" alt="[TXT]"></td><td><a href="Test_money.py">Test_money.py</a></td><td align="right">2016-01-08 15:53  </td><td align="right">1.1K</td><td>&nbsp;</td></tr>
        //
        public static List<Resource> GetDirectoryContents(string url)
        {
            List<Resource> Rlist = new List<Resource>();
            //url = "http://192.168.1.42/testpage/Script";
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            Byte[] pageData = MyWebClient.DownloadData(url); 
            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            var htmlSource = new JumonyParser().Parse(pageHtml);

            var list = htmlSource.Find("img[src=/icons/folder.gif]");
            foreach(var one in list)
            {
                /*if(one.Attribute("href").Value() == one.InnerText())
                {
                    string s = one.InnerText();
                }*/
                Resource a = new Resource();
                a.Name = one.Parent().Parent().Find("a").ElementAt(0).InnerText();
                a.Url = url  + a.Name;
                a.IsFolder = true;
                Rlist.Add(a);
            }
            list = htmlSource.Find("img[src=/icons/text.gif]");
            foreach (var one in list)
            {
                Resource a = new Resource();
                a.Name = one.Parent().Parent().Find("a").ElementAt(0).InnerText();
                a.Url = url  + a.Name;
                a.IsFolder = false;
                string t1 = one.Parent().Parent().Find("td[align=right]").ElementAt(0).InnerText();
                a.LastModified = DateTime.Parse(t1);
                Rlist.Add(a);
            }
            return Rlist;
        }
        public static List<Resource> CheckLocalFile(string path, List<Resource> list)
        {
            foreach (var one in list)
            {
                if(one.IsFolder == false)
                {
                    FileInfo file = new FileInfo(path + "\\" + one.Name);
                    if (file.Exists && file.LastWriteTime.Ticks >= one.LastModified.Ticks)
                    {
                        one.path = file.FullName;
                        one.isLocal = true;
                        one.status = 2;
                    }
                    else if (file.Exists && file.LastWriteTime.Ticks < one.LastModified.Ticks)
                    {
                        one.path = file.FullName;
                        one.isLocal = true;
                        one.status = 1;
                    }
                    else
                    {
                        one.isLocal = false;
                        one.status = 0;
                    }
                }
            }
            return list;
        }
        public static Byte[] GetFile(string url)
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            Byte[] pageData = MyWebClient.DownloadData(url);
            //string pageHtml = Encoding.UTF8.GetString(pageData);
            return pageData;
        }
    }
    public class Resource
    {
        public string Name;
        public bool IsFolder;
        public string Url;
        public DateTime LastModified;
        public bool isLocal;
        public string path;
        public int status;//0=服务器文件;1=服务器较新;2=本地文件较新
    }
    
}
