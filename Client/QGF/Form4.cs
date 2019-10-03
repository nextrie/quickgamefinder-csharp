using QGF.Network;
using QGF.Network.Groups;
using QGF.Traitement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGF
{
    public partial class Form4 : Form
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
        public Form4()
        {
            InitializeComponent();
            panel1.Select();
            if (Me.rank == "premium")
            {
                maxplayer_slider.MaximumValue = 15;
            }
            else
            {
                maxplayer_slider.MaximumValue = 5;
            }

            username_label.Text = Me.username;
            rank_label.Text = Me.rank;
            timer1.Start();

            // Set the vertical scroll maximum value to be at-par with the flowlayout.

            GroupCount = 0;
            
            
            // Create();
        }
        int GroupCount = Group.g.Count();
        public void Handler()
        {
            
            online_label.Text = "Joueurs en ligne : " + SocketMain.onlineplayers.ToString();
            created_label.Text = "Groupes créés : " + SocketMain.onlinegroups.ToString();
            if(GroupCount != Group.g.Count())
            {
                
                flowLayoutPanel1.Controls.Clear();
                foreach(Group group in Group.g)
                {
                    if (group.ranks == "premium")
                    {
                        Room room = new Room(group.author, group.playercounter, group.desiredplayers, group._public, group.roomname, group.roomdescription, group.gameID, group.roomIDs, group.ranks);
                        flowLayoutPanel1.Controls.Add(room);
                    
                    }
                }
                foreach (Group group in Group.g)
                {
                    if (group.ranks == "free")
                    {
                        Room room = new Room(group.author, group.playercounter, group.desiredplayers, group._public, group.roomname, group.roomdescription, group.gameID, group.roomIDs, group.ranks);
                        flowLayoutPanel1.Controls.Add(room);
                     
                    }
                }
                GroupCount = Group.g.Count();
                
            }
            if(SocketMain.f4todo == "destroy")
            {
                this.Hide();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void searchgame_button_Click(object sender, EventArgs e)
        {

        }

        private void creategroup_button_Click(object sender, EventArgs e)
        {
            create_group_panel.Visible = true;
        }

        private void username_label_Click(object sender, EventArgs e)
        {

        }

        private void rank_label_Click(object sender, EventArgs e)
        {

        }

        private void online_label_Click(object sender, EventArgs e)
        {

        }

        private void created_label_Click(object sender, EventArgs e)
        {

        }

        private void uprank_label_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void disconect_button_Click(object sender, EventArgs e)
        {
            byte[] b = Encoding.ASCII.GetBytes("DisconnectRequest");
            SocketMain.SendData(b, SocketMain.ns);
            
            Application.Exit();
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SocketMain.EndSession();
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/qgf_off");
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Process.Start("http://quickgamefinder.com/");
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/UzbmRGJ");
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            maxplayer_label.Text = maxplayer_slider.Value.ToString();
            //slidertext.Location = new Point(bunifuSlider1.HorizontalScroll.Value, slidertext.Location.Y);

        }

        private void slidertext_Click(object sender, EventArgs e)
        {

        }

        private void label_changer_Click(object sender, EventArgs e)
        {

        }

        private void bunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
            if(bunifuToggleSwitch1.Value == false)
            {
                label_changer.Text = "Groupe public";
                
            }
            else
            {
                label_changer.Text = "Groupe privé";
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            create_group_panel.Visible = false;
        }

        private void create_group_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void username_text_TextChange(object sender, EventArgs e)
        {
            if (groupname_text.Text.Contains("|"))
            {
                MessageBox.Show("Pas de caractère spéciaux !");
                groupname_text.Text.Replace('|', ' ');
            }
        }

        private void combobox_game_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string groupname = groupname_text.Text;
            string gameID = Game.GetIDByGame(gameid_combobox.Text);
            int maxplayers = maxplayer_slider.Value;
            bool ispublic = bunifuToggleSwitch1.Value;
            if(groupname == "" || groupname.Length < 4)
            {
                MessageBox.Show("Nom de groupe trop court (4 charactères minimum)");
            }
            else
            {
                if (bunifuToggleSwitch1.Value == false)
                {
                    ispublic = true;
                }
                else
                {
                    ispublic = false;
                }
                string groupdesc = groupdescription_text.Text;
                string ispb = "";
                if (ispublic == true)
                {
                    ispb = "public";
                }
                else
                {
                    ispb = "private";
                }
                if (gameID != "")
                {
                    Group.g.Clear();
                    if (maxplayers < 2)
                    {

                        MessageBox.Show("Le nombre de places minimal est de 2 joueurs");
                    }
                    if (maxplayers >= 2)
                    {
                        string msg = "CreateGroupRequest|" + Me.username + "|" + "1" + "|" + maxplayers.ToString() + "|" + ispb + "|" + gameID + "|" + groupname + "|" + groupdesc;
                        SocketMain.SendData(Encoding.ASCII.GetBytes(msg), SocketMain.ns);
                        string msgs = "JoinCreatedGroup|" + Me.username;
                        SocketMain.SendData(Encoding.ASCII.GetBytes(msgs), SocketMain.ns);
                    }
                }
                else
                {
                    MessageBox.Show("Impossible de créer un groupe pour ce jeu, merci de contacter un administrateur");
                }

            }


        }

        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Handler();
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.Value);
        }

        private void bunifuTextBox3_TextChange(object sender, EventArgs e)
        {
         
            flowLayoutPanel1.Controls.Clear();
            foreach(Group g in Group.g)
            {
                if (g.gameID.Contains(bunifuTextBox3.Text) && g.ranks == "premium") 
                {              
                            Room room = new Room(g.author, g.playercounter, g.desiredplayers, g._public, g.roomname, g.roomdescription, g.gameID, g.roomIDs, g.ranks);
                            flowLayoutPanel1.Controls.Add(room);                     
                }
                if (g.ranks == "free" && g.gameID.Contains(bunifuTextBox3.Text))
                {
                    Room room = new Room(g.author, g.playercounter, g.desiredplayers, g._public, g.roomname, g.roomdescription, g.gameID, g.roomIDs, g.ranks);
                    flowLayoutPanel1.Controls.Add(room);
                }
            }


        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.NewValue);
        }

        private void groupdescription_text_TextChanged(object sender, EventArgs e)
        {
            if (groupdescription_text.Text.Contains("|"))
            {
                MessageBox.Show("Pas de caractère spéciaux !");
                groupdescription_text.Text.Replace('|', ' ');
            }
        }
    }
}
