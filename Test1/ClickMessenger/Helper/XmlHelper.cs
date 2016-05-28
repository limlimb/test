using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace ClickMessenger.Helper
{
    static class XmlHelper
    {
        static readonly string ConfigFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "UserConfig.xml");

        public static void Load(out Config config)
        {
            config = null;
            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Config));
                    using (var xr = XmlReader.Create(ConfigFilePath))
                    {
                        config = (Config)serializer.ReadObject(xr);
                        return;
                    }
                }
                catch { }
            }
            if (config == null)
            {
                config = new Config();
                return;
            }
        }

        public static void Update(Config config)
        {
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(Config));
            var xmlSettings = new XmlWriterSettings()
            {
                Encoding = new UTF8Encoding(false),
                Indent = true
            };
            using (var xw = XmlWriter.Create(ConfigFilePath, xmlSettings))
            {
                serializer.WriteObject(xw, config);
                xw.Flush();
            }
        }
    }
}
