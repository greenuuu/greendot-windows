using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using ShadowSocks.Controller;
using Newtonsoft.Json;
using ShadowSocks.Encryption;

namespace ShadowSocks.Model
{
    [Serializable]
    public class Configuration
    {
        public List<Server> configs;
        public string strategy;
        public int index;
        public bool global;
        public bool enabled;
        public bool shareOverLan;
        public bool isDefault;
        public int localPort;
        public string pacUrl;
        public bool useOnlinePac;
        public bool secureLocalPac = true;
        public bool availabilityStatistics;
        public bool autoCheckUpdate;
        public bool checkPreRelease;
        public bool isVerboseLogging;
        public LogViewerConfig logViewer;
        public ProxyConfig proxy;
        public HotkeyConfig hotkey;

        private static string CONFIG_FILE = "gui-config.json";

        public Server GetCurrentServer()
        {
            if (index >= 0 && index < configs.Count)
                return configs[index];
            else
                return GetDefaultServer();
        }

        public Configuration DeepClone()
        {
            object obj = null; 
            BinaryFormatter inputFormatter = new BinaryFormatter();
            MemoryStream inputStream;
            using (inputStream = new MemoryStream())
            {
                inputFormatter.Serialize(inputStream, this);
            } 
            using (MemoryStream outputStream = new MemoryStream(inputStream.ToArray()))
            {
                BinaryFormatter outputFormatter = new BinaryFormatter();
                obj = outputFormatter.Deserialize(outputStream);
            }
            return (Configuration)obj;
        }

        public static void CheckServer(Server server)
        {
            CheckPort(server.server_port);
            CheckPassword(server.password);
            CheckServer(server.server);
            CheckTimeout(server.timeout, Server.MaxServerTimeoutSec);
        }

        public static Configuration Load()
        {
            try
            {
                string configContent = File.ReadAllText(CONFIG_FILE);
                Configuration config = JsonConvert.DeserializeObject<Configuration>(configContent);

                Configuration decryptConfig = DecryptConfiguration(config);

                decryptConfig.isDefault = false;

                if (decryptConfig.configs == null)
                    decryptConfig.configs = new List<Server>();
                if (decryptConfig.configs.Count == 0)
                    decryptConfig.configs.Add(GetDefaultServer());
                if (decryptConfig.localPort == 0)
                    decryptConfig.localPort = 1080;
                if (decryptConfig.index == -1 && decryptConfig.strategy == null)
                    decryptConfig.index = 0;
                if (decryptConfig.logViewer == null)
                    decryptConfig.logViewer = new LogViewerConfig();
                if (decryptConfig.proxy == null)
                    decryptConfig.proxy = new ProxyConfig();
                if (decryptConfig.hotkey == null)
                    decryptConfig.hotkey = new HotkeyConfig();

                decryptConfig.proxy.CheckConfig();

                return decryptConfig;
            }
            catch (Exception e)
            {
                if (!(e is FileNotFoundException))
                    Logging.LogUsefulException(e);
                return new Configuration
                {
                    index = 0,
                    isDefault = true,
                    localPort = 1080,
                    autoCheckUpdate = true,
                    configs = new List<Server>()
                    {
                        GetDefaultServer()
                    },
                    logViewer = new LogViewerConfig(),
                    proxy = new ProxyConfig(),
                    hotkey = new HotkeyConfig()
                };
            }
        }

        public static void Save(Configuration config)
        {
            Configuration encryptConfig = EncryptConfiguration(config);

            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(CONFIG_FILE, FileMode.Create)))
                {
                    string jsonString = JsonConvert.SerializeObject(encryptConfig, Formatting.Indented);
                    sw.Write(jsonString);
                    sw.Flush();
                }
            }
            catch (IOException e)
            {
                Logging.LogUsefulException(e);
            }
        }

        public static Server GetDefaultServer()
        {
            return new Server();
        }

        private static void Assert(bool condition)
        {
            if (!condition)
                throw new Exception(I18N.GetString("assertion failure"));
        }

        public static void CheckPort(int port)
        {
            if (port <= 0 || port > 65535)
                throw new ArgumentException(I18N.GetString("Port out of range"));
        }

        public static void CheckLocalPort(int port)
        {
            CheckPort(port);
            if (port == 8123)
                throw new ArgumentException(I18N.GetString("Port can't be 8123"));
        }

        private static void CheckPassword(string password)
        {
            if (password.IsNullOrEmpty())
                throw new ArgumentException(I18N.GetString("Password can not be blank"));
        }

        public static void CheckServer(string server)
        {
            if (server.IsNullOrEmpty())
                throw new ArgumentException(I18N.GetString("Server IP can not be blank"));
        }

        public static void CheckTimeout(int timeout, int maxTimeout)
        {
            if (timeout <= 0 || timeout > maxTimeout)
                throw new ArgumentException(string.Format(
                    I18N.GetString("Timeout is invalid, it should not exceed {0}"), maxTimeout));
        }

        private static Configuration EncryptConfiguration(Configuration config) {

            Configuration encryptConfig = config.DeepClone();
            if (encryptConfig.index >= encryptConfig.configs.Count)
                encryptConfig.index = encryptConfig.configs.Count - 1;
            if (encryptConfig.index < -1)
                encryptConfig.index = -1;
            if (encryptConfig.index == -1 && encryptConfig.strategy == null)
                encryptConfig.index = 0;
            encryptConfig.isDefault = false;

            if (encryptConfig.configs!=null && encryptConfig.configs.Count>0)
            {
                for (int i = 0; i < encryptConfig.configs.Count; i++)
                {
                    Server server = encryptConfig.configs[i];
                    server.server = DES.DESEnCode(server.server);
                    server.method = DES.DESEnCode(server.method);
                    server.password = DES.DESEnCode(server.password);
                }
            }
            return encryptConfig;
        }

        private static Configuration DecryptConfiguration(Configuration config) {
            if (config.configs !=null && config.configs.Count>0)
            {
                for (int i = 0; i < config.configs.Count; i++)
                {
                    Server server = config.configs[i];
                    server.server = DES.DESDeCode(server.server);
                    server.method = DES.DESDeCode(server.method);
                    server.password = DES.DESDeCode(server.password);
                }
            }

            return config;
        }
    }
}
