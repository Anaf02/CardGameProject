using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        public Server Server { get; set; }

        public ServerForm()
        {
            InitializeComponent();
            labelIp.Text = "IP Address: " + Server.GetPcAddress().ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Server == null)
            {
                Server = new Server(Convert.ToInt32(textBoxPort.Text));
                Server.StartServer();
                labelServerOn.Text = "Server is running.";
                labelStatusColor.BackColor = Color.Green;
                btnStart.Text = "Stop Server";
                textLogs.AppendText($"\nServer is listening on port {textBoxPort.Text}");
                this.Refresh();

                for (int i = 1; i <= 2; i++)
                {
                    if (Server.AcceptConnection())
                    {
                        textLogs.AppendText($"\nPlayer {i} connected. Name: {(i == 1 ? Server.Player1Name : Server.Player2Name)}");
                    }
                    else
                    {
                        textLogs.AppendText($"\nConnection failed");
                    }
                    this.Refresh();
                }

                Server.StartGame();
                Task.Run(Server.TransferData);
            }
            else
            {
                Server.Disconnect();
                Server.StopServer();
                Server = null;
                labelServerOn.Text = "Server is stopped.";
                labelStatusColor.BackColor = Color.Red;
                btnStart.Text = "Start Server";
            }
        }
    }
}