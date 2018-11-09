using System;
using System.Windows.Forms;

namespace KeePassDbHttp
{
    public partial class KeePassDbHttpOptionsForm : Form
    {
        private KeePassDbHttpOptions.Transaction m_options;

        public KeePassDbHttpOptionsForm(KeePassDbHttpOptions.Transaction options)
        {
            InitializeComponent();

            m_options = options;
            portField.Value = options.Port;
            filenameField.Text = options.Filename;
            UpdateUrl();
        }

        private void portField_ValueChanged(object sender, EventArgs e)
        {
            m_options.Port = (uint)portField.Value;
            UpdateUrl();
        }

        private void filenameField_TextChanged(object sender, EventArgs e)
        {
            m_options.Filename = filenameField.Text;
            UpdateUrl();
        }

        private void UpdateUrl()
        {
            urlDisplay.Text = String.Format("http://localhost:{0}/{1}.kdbx", portField.Value, filenameField.Text);
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
