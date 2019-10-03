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
    public partial class Room : UserControl
    {
        int room = 0;
        int max = 0;
        public Room(string author, int currentplayer, int maxplayer, string isprivate, string roomname, string roomdesc, string game, int RoomID, string rank)
        {
            InitializeComponent();
            if(rank == "free")
            {
                rankpic.Image = Properties.Resources.free;
                bunifuLabel2.ForeColor = Color.Gray;
                bunifuLabel2.Text = "Free";
            }
            else
            {
                rankpic.Image = Properties.Resources.premium;
                bunifuLabel2.ForeColor = Color.Goldenrod;
                bunifuLabel2.Text = "Premium";
            }
            string ispublic = isprivate;
            if(isprivate == "public")
            {
                ispublic = "Public";
            }
            else
            {
                ispublic = "Privé";
            }
            max = currentplayer;
          
            bunifuLabel1.Text = "Jeu: " + game + "\r\n" + max.ToString() + "/" + maxplayer.ToString() + " joueurs - " + ispublic ;
           
            room = RoomID;
            switch (game)
            {
                case "ARMA 3":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_ARMA_3;
                    break;
                case "BATTLEFIELD 4":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BATTLEFIELD4;
                    break;
                case "BATTLEFIELD 5":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BATTLEFIELD5;
                    break;
                case "BLACK OPS 2":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BO2;
                    break;
                case "BLACK OPS 3":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BO3;
                    break;
                case "BLACK OPS 4":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BO4;
                    break;
                case "BUSINESS TOUR": // business tour
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_BUSINESS_TOUR;
                    break;
                case "COUNTER STRIKE: GLOBAL OFFENSIVE": // CSGO
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_CSGO;
                    break;
                case "DESTINY 2": // DESTINY 2
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_DESTINY_2;
                    break;
                case "DIABLO 3": // Diablo 3
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_DIABLO;
                    break;
                case "DOOM": // DOOM
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_DOOM;
                    break;
                case "FALLOUT4":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_FALLOUT_4;
                    break;
                case "FIFA 18":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_FIFA18;
                    break;
                case "FIFA 19":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_FIFA19;
                    break;
                case "FORTNITE":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_FORTNITE;
                    break;
                case "GARRY'S MOD":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_GMOD;
                    break;
                case "GRAND THEFT AUTO 5":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_GTA5;
                    break;
                case "LEAGUE OF LEGEND":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_LEAGUE_OF_LEGEND;
                    break;
                case "MINECRAFT":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_MINECRAFT;
                    break;
                case "NBA 2K18":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_NBA_2K18;
                    break;
                case "OVERWATCH":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_OVERWTACH;
                    break;
                case "PAYDAY 2":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_PAYDAY2;
                    break;
                case "PLAYER UNKNOWN'S BATLLEGROUNDS":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_PUBG;
                    break;
                case "RED DEAD REDEMPTION 2":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_RDR2;
                    break;
                case "ROCKET LEAGUE":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_ROCKET_LEAUGE;
                    break;
                case "SPEEDRUNNERS":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_SPEED_RUNNERS;
                    break;
                case "THE CREW 2":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_THE_CREW2;
                    break;
                case "TOM CLANCY'S RAINBOW SIX SIEGE":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_RAINBOW6SIEGE;
                    break;
                case "WORLD OF WARCRAFT":
                    bunifuPictureBox1.Image = Properties.Resources.LOGO_WORLD_OF_WARCRAFT;
                    break;
            }
            
        }
        public static string gameID;
        public static int currentplayers;
        public static int maxplayers;
        public bool isPremium;
        
        public string isPublic;

        private void Room_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {          
            byte[] b = Encoding.ASCII.GetBytes("JoinRoomRequest|" + room.ToString() + "|" + Me.username);
            Me.currentroom = room;
            SocketMain.f7todo = "keep";
            SocketMain.SendData(b, SocketMain.ns);
     
        }

        private void rank_Click(object sender, EventArgs e)
        {

        }
    }
}
