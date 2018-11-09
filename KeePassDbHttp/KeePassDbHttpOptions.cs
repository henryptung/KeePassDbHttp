using KeePass.App.Configuration;
using KeePass.Forms;
using KeePass.Plugins;
using System;

namespace KeePassDbHttp
{
    public sealed class KeePassDbHttpOptions
    {
        private const string PORT_PARAM = "KeePassDbHttp_Port";
        private const string FILENAME_PARAM = "KeePassDbHttp_Filename";
        
        private readonly IPluginHost m_host;

        private KeePassDbHttpOptions(IPluginHost host)
        {
            this.m_host = host;
        }

        public static KeePassDbHttpOptions Initialize(IPluginHost host)
        {
            var options = new KeePassDbHttpOptions(host);
            options.Modify(transaction =>
            {
                if (transaction.Filename == null)
                {
                    transaction.Filename = Guid.NewGuid().ToString();
                    return true;
                }
                return false;
            });

            return options;
        }

        private AceCustomConfig config
        {
            get
            {
                return m_host.CustomConfig;
            }
        }

        public string Filename
        {
            get
            {
                return config.GetString(FILENAME_PARAM);
            }
        }

        public uint Port
        {
            get
            {
                return (uint) config.GetULong(PORT_PARAM, 20136);
            }
        }

        public bool Modify(Func<Transaction, bool> modifier)
        {
            var transaction = new TransactionInstance(this);
            if (!modifier.Invoke(transaction))
            {
                return false;
            }

            config.SetString(FILENAME_PARAM, transaction.Filename);
            config.SetULong(PORT_PARAM, transaction.Port);

            m_host.MainWindow.SaveConfig();
            return true;
        }

        private sealed class TransactionInstance : Transaction
        {
            public string Filename { get; set; }
            public uint Port { get; set; }

            public TransactionInstance(KeePassDbHttpOptions options)
            {
                this.Filename = options.Filename;
                this.Port = options.Port;
            }
        }

        public interface Transaction
        {
            string Filename { get; set; }
            uint Port { get; set; }
        }
    }
}
