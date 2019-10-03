using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QGF.Network;

namespace QGF
{
    public partial class user_profil : UserControl
    {
        public  string profil;
        public user_profil(string username, bool admin)
        {
           
            InitializeComponent();
            userprofil.Text = username;
            if(admin == true)
            {
                userprofil.ForeColor = Color.Orange;
                userprofil.Font = new Font(userprofil.Font, FontStyle.Bold);
            }
            if (Me.username == Me.currentroomadmin)
            {
                bunifuImageButton1.Visible = true;
            }
            else
            {
                bunifuImageButton1.Visible = false;
            }
            profil = username;
        }

        private void user_profil_Load(object sender, EventArgs e)
        {

        }

        private void userprofil_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            byte[] b = Encoding.ASCII.GetBytes("RoomKick|" + userprofil.Text + "|" + Me.currentroomadmin);
            SocketMain.SendData(b, SocketMain.ns);
        }
    }
}
