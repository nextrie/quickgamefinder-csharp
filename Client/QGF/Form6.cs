using QGF.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGF
{
    public partial class Form6 : Form

    {
        private const int CS_dropshadow = 0x00020000;
        public List<Room> roomlist = new List<Room>();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_dropshadow;
                return cp;
            }
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            byte[] b = Encoding.ASCII.GetBytes("MissingGame|" + bunifuTextBox1.Text + "|" + Me.username);
            SocketMain.SendData(b, SocketMain.ns);
            MessageBox.Show("Merci pour votre rapport");
            this.Hide();
        }
    }
}
