using System;
using System.Windows.Forms;

namespace KeePassDbHttp
{
    public partial class KeePassDbHttpOptionsForm : Form
    {
        private uint m_port;
        private string m_filename;

        public KeePassDbHttpOptionsForm(KeePassDbHttpOptions options)
        {
            InitializeComponent();
            m_port = options.Port;
            m_filename = options.Filename;

            portField.Value = m_port;
            filenameField.Text = m_filename;
            UpdateUrl();
        }

        private void portField_ValueChanged(object sender, EventArgs e)
        {
            m_port = (uint)portField.Value;
            UpdateUrl();
        }

        private void filenameField_TextChanged(object sender, EventArgs e)
        {
            m_filename = filenameField.Text;
            UpdateUrl();
        }

        private void UpdateUrl()
        {
            urlDisplay.Text = String.Format("http://localhost:{0}/{1}.kdbx", m_port, m_filename);
        }

        public void Update(KeePassDbHttpOptions options)
        {
            options.Port = m_port;
            options.Filename = m_filename;
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(urlDisplay.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
