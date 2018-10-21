using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

using KeePass.Plugins;
using System.Windows.Forms;
using KeePass.UI;
using System.Threading;

namespace KeePassDbHttp
{
    public sealed class KeePassDbHttpExt : Plugin
    {
        private IPluginHost m_host;
        private KeePassDbHttpOptions m_options;
        private ToolStripMenuItem m_optionsItem;

        private CancellationTokenSource m_listenerCancel;
        private Task m_listenerTask;
        
        public override bool Initialize(IPluginHost host)
        {
            m_host = host;
            m_options = new KeePassDbHttpOptions(m_host.CustomConfig);
            m_optionsItem = NewOptionsMenuItem();
            m_host.MainWindow.ToolsMenu.DropDownItems.Add(m_optionsItem);

            StartServer();

            return base.Initialize(host);
        }

        private ToolStripMenuItem NewOptionsMenuItem()
        {
            var item = new ToolStripMenuItem();
            item.Text = "KeePassDbHttp Options...";
            item.Click += (sender, e) =>
            {
                var form = new KeePassDbHttpOptionsForm(m_options);
                if (UIUtil.ShowDialogAndDestroy(form) == DialogResult.OK)
                {
                    form.Update(m_options);
                    try
                    {
                        StopServer();
                        StartServer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            };

            return item;
        }

        private async Task HandleRequest(HttpListenerContext ctx, CancellationToken token)
        {
            using (var response = ctx.Response)
            {
                if (ctx.Request.UserHostName != String.Format("localhost:{0}", m_options.Port)
                    || ctx.Request.Url.AbsolutePath != String.Format("/{0}.kdbx", m_options.Filename))
                {
                    response.StatusCode = 500;
                    return;
                }

                byte[] db = await ReadDbAsync(token);
                if (db == null)
                {
                    response.StatusCode = 500;
                    return;
                }

                response.StatusCode = 200;
                response.ContentLength64 = db.LongLength;
                response.OutputStream.Write(db, 0, db.Length);
            }
        }

        private void StartServer()
        {
            m_listenerCancel = new CancellationTokenSource();
            m_listenerTask = HttpUtil.Listen(m_options.Port, HandleRequest, m_listenerCancel.Token);
        }

        private void StopServer()
        {
            m_listenerCancel.Cancel();
            m_listenerTask.Wait();

            m_listenerCancel = null;
            m_listenerTask = null;
        }

        private async Task<byte[]> ReadDbAsync(CancellationToken token)
        {
            var mruList = m_host.MainWindow.FileMruList;
            if (mruList.ItemCount < 1)
            {
                return null;
            }

            var info = mruList.GetItem(0).Value as KeePassLib.Serialization.IOConnectionInfo;
            if (info == null || !info.IsLocalFile())
            {
                return null;
            }

            try
            {
                using (FileStream dbStream = File.OpenRead(info.Path))
                using (MemoryStream memory = new MemoryStream(4096))
                {
                    await dbStream.CopyToAsync(memory, 1024, token);
                    return memory.ToArray();
                }
            }
            catch (IOException)
            {
                return null;
            }
        }

        public override void Terminate()
        {
            StopServer();

            m_host.MainWindow.ToolsMenu.DropDownItems.Remove(m_optionsItem);
            m_optionsItem = null;
            m_options = null;
            m_host = null;

            base.Terminate();
        }
    }
}
