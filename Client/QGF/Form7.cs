using QGF.Network;
using QGF.Network.Users;
using QGF.Traitement;
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
    public partial class Form7 : Form
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

                public Form7()
                {
                    InitializeComponent();
                  int i = 0;

            chat1.Visible = false;
            room_title.Text = Me.currentroomname;
            room_desc.Text = Me.currentroomdesc;
            timer1.Start();
                }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if(Me.currentroomadmin == Me.username)
            {
                SocketMain.SendData(Encoding.ASCII.GetBytes("RemoveRoom|" + Me.currentroom.ToString()), SocketMain.ns);
            }
            SocketMain.EndSession();
           //Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int curtop = 10;
        chat c_old = new chat();
        bool first = true;
        public void addIncomingMessage(string message, string auteur)
        {
            chat c = new chat(message, auteur, chat.msgtype.In);
            if (first == true)
            {
                c.Top = curtop;
                curtop = c.Bottom + 10;
                first = false;
            }
            else
            {
                c.Top = c_old.Bottom + 10;

            }
            c.Left = c.Left + 20;
            flowLayoutPanel1.Controls.Add(c);
            c_old = c;
            flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
        }
        public void addOutMessage(string message, string auteur)
        {
            chat c = new chat(message, auteur, chat.msgtype.Out);
            if (first == true)
            {
                c.Top = curtop;
                curtop = c.Bottom + 10;
                first = false;
            }
            else
            {
                c.Top = c_old.Bottom + 10;

            }
     
          //  c.Location = chat1.Location;
            c.Left +=400;
         
            flowLayoutPanel1.Controls.Add(c);
            c_old = c;
            flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
        }
        private void chat1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            byte[] b = Encoding.ASCII.GetBytes("SendMessageRequest|"+bunifuMaterialTextbox2.Text + "|" + Me.username + "|" + Me.currentroom.ToString());
            SocketMain.SendData(b, SocketMain.ns);
              flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
            bunifuMaterialTextbox2.Text = "";
        }

        private void flowlayoutpanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void room_title_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int i = 0;
        int j = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (SocketMain.f7todo == "destroy")
                {
                    this.Hide();

                }

                if (i != User.users.Count)
                {
                    try
                    {
                        flowLayoutPanel2.Controls.Clear();
                        foreach (User u in User.users)
                        {
                            bool t = false;
                            if (u.usernem == Me.currentroomadmin)
                            {
                                t = true;
                            }

                                user_profil p = new user_profil(u.usernem, t);
                                flowLayoutPanel2.Controls.Add(p);
                         
                        }
                        i = User.users.Count;
                    }

                    catch
                    {

                    }
                }
                if (j != ChatMessage.mlist.Count)
                {
                    //flowLayoutPanel1.Controls.Clear();
                    //foreach(ChatMessage m in ChatMessage.mlist)
                    //{
                    ChatMessage m = ChatMessage.mlist[ChatMessage.mlist.Count - 1];
                    if (m.pauteur == Me.username)
                    {
                        addOutMessage(m.pcontent, m.pauteur);
                    }
                    else
                    {
                        addIncomingMessage(m.pcontent, m.pauteur);
                    }
                    //}

                    flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
                    j = ChatMessage.mlist.Count;
                }
            }
            catch
            {

            }
            if (flowLayoutPanel2.Controls.Count > User.users.Count)
            {
                flowLayoutPanel2.Controls.Clear();
                try
                {
                    foreach (User u in User.users)
                    {
                        bool t = false;
                        if (u.usernem == Me.currentroomadmin)
                        {
                            t = true;
                        }

                        user_profil p = new user_profil(u.usernem, t);
                        flowLayoutPanel2.Controls.Add(p);
                        i = User.users.Count;
                       
                    }
                }
                catch
                {

                }
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text.Contains("|"))
            {
                MessageBox.Show("Pas de caractère spéciaux !");
                bunifuMaterialTextbox2.Text.Replace('|',' ');
            }

        }

        private void bunifuMaterialTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                byte[] b = Encoding.ASCII.GetBytes("SendMessageRequest|" + bunifuMaterialTextbox2.Text + "|" + Me.username + "|" + Me.currentroom.ToString());
                SocketMain.SendData(b, SocketMain.ns);
                flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
                bunifuMaterialTextbox2.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void chat1_Load_1(object sender, EventArgs e)
        {

        }

        private void disconnect_button_Click(object sender, EventArgs e)
        {
            if(Me.username == Me.currentroomadmin)
            {
                byte[] b = Encoding.ASCII.GetBytes("RemoveRoom|" + Me.currentroom.ToString());
                SocketMain.SendData(b, SocketMain.ns);
            }
            else
            {
                byte[] b = Encoding.ASCII.GetBytes("LeaveRoom|" + Me.currentroom.ToString());
                SocketMain.SendData(b, SocketMain.ns);
            }
        }
    }
}
