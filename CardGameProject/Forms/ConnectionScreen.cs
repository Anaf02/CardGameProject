using System;
using System.Windows.Forms;

namespace CardGameProject.Forms
{
    public partial class ConnectionScreen : Form
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string PlayerName { get; set; }

        public ConnectionScreen()
        {
            InitializeComponent();
        }

        private void confirmIP_btn_Click(object sender, EventArgs e)
        {
            IpAddress = textBoxIp.Text;
            Port = Convert.ToInt32(textBoxPort.Text);
            PlayerName = textBoxName.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}