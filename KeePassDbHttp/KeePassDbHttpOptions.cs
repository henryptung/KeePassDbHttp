using KeePass.App.Configuration;
using System;

namespace KeePassDbHttp
{
    public sealed class KeePassDbHttpOptions
    {
        private const string PORT_PARAM = "KeePassDbHttp_Port";
        private const string FILENAME_PARAM = "KeePassDbHttp_Filename";

        private readonly AceCustomConfig m_config;

        public KeePassDbHttpOptions(AceCustomConfig config)
        {
            InitConfig(config);
            m_config = config;
        }

        private static void InitConfig(AceCustomConfig config)
        {
            if (config.GetString(FILENAME_PARAM) == null)
            {
                config.SetString(FILENAME_PARAM, Guid.NewGuid().ToString());
            }
        }

        public string Filename
        {
            get
            {
                return m_config.GetString(FILENAME_PARAM);
            }
            set
            {
                m_config.SetString(FILENAME_PARAM, value);
            }
        }

        public uint Port
        {
            get
            {
                return (uint) m_config.GetULong(PORT_PARAM, 20136);
            }
            set
            {
                m_config.SetULong(PORT_PARAM, value);
            }
        }
    }
}
