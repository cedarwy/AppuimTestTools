using Ionic.Zip;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AndroidXml;

namespace AppuimTestTools
{
    public class apkreader
    {
        public List<AndroidInfo> androidInfos = new List<AndroidInfo>();
        public apkreader(string path)
        {
            var manifest = "AndroidManifest.xml";

            //读取apk,通过解压的方式读取
            using (var zip = ZipFile.Read(path))
            {
                using (Stream zipstream = zip[manifest].OpenReader())
                {
                    //将解压出来的文件保存到一个路径（必须这样）
                    using (var fileStream = File.Create(manifest, (int)zipstream.Length))
                    {
                        // Initialize the bytes array with the stream length and then fill it with data
                        byte[] bytesInStream = new byte[zipstream.Length];
                        zipstream.Read(bytesInStream, 0, bytesInStream.Length);
                        // Use write method to write to the file specified above
                        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                    }
                }
            }

            //读取解压文件的字节数
            byte[] data = File.ReadAllBytes(manifest);
            if (data.Length == 0)
            {
                throw new IOException("Empty file");
            }

            #region 读取文件内容
            using (var stream = new MemoryStream(data))
            {
                var reader = new AndroidXmlReader(stream);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                AndroidInfo info = new AndroidInfo();
                                androidInfos.Add(info);
                                info.Name = reader.Name;
                                info.Settings = new List<AndroidSetting>();
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);

                                    AndroidSetting setting = new AndroidSetting() { Name = reader.Name, Value = reader.Value };
                                    info.Settings.Add(setting);
                                }
                                reader.MoveToElement();
                                break;
                            }
                    }
                }
            }
            #endregion

            File.Delete(manifest);

            StringBuilder builder = new StringBuilder();
            foreach (var androidInfo in androidInfos)
            {
                builder.Append(string.Format("{0}:", androidInfo.Name));
                foreach (var setting in androidInfo.Settings)
                {
                    builder.Append("{");
                    builder.Append(string.Format("'{0}':'{1}'", setting.Name, setting.Value));
                    builder.Append("},");
                }
                builder.Append("\n\n");
            }
            Console.WriteLine(builder.ToString());
        
        }
    }
    class NamespaceInfo
    {
        public string Prefix { get; set; }
        public string Uri { get; set; }
    }/// <summary>
     /// android应用程序信息
     /// </summary>
    public class AndroidInfo
    {
        public string Name { get; set; }

        public List<AndroidSetting> Settings { get; set; }
    }

    /// <summary>
    /// 设置
    /// </summary>
    public class AndroidSetting
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
