using QGF.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGF
{
    public partial class Form3 : Form
    {
        private const int CS_dropshadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_dropshadow;
                return cp;
            }
        }


        public Form3()
        {
            InitializeComponent();
            panel1.Select();
            timer1.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e) // identifiant
        {
            if(bunifuTextBox1.Text.Length == 0)
            {
                bunifuTextBox1.IconRight = Properties.Resources.erreur;
            }
            else
            {
                bunifuTextBox1.IconRight = Properties.Resources.ok;
            }
        }

        private void bunifuTextBox3_TextChange(object sender, EventArgs e) //email
        {
            if (bunifuTextBox3.Text.Length == 0 || !bunifuTextBox3.Text.Contains('@') || !bunifuTextBox3.Text.Contains('.'))
            {
                bunifuTextBox3.IconRight = Properties.Resources.erreur;
            }
            else
            {
                bunifuTextBox3.IconRight = Properties.Resources.ok;
            }
        }

        private void bunifuTextBox2_TextChange(object sender, EventArgs e) //pass
        {
            if (bunifuTextBox2.Text.Length == 0)
            {
                bunifuTextBox2.IconRight = Properties.Resources.erreur;
            }
            else
            {
                bunifuTextBox2.IconRight = Properties.Resources.ok;
            }
        }

        private void bunifuTextBox4_TextChange(object sender, EventArgs e) //confirm
        {
            if (bunifuTextBox4.Text != bunifuTextBox2.Text)
            {
                bunifuTextBox4.IconRight = Properties.Resources.erreur;
            }
            else
            {
                bunifuTextBox4.IconRight = Properties.Resources.ok;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCheckBox2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e) //cgu
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e) // inscription
        {
            
            string identifiant = bunifuTextBox1.Text;
            string email = bunifuTextBox3.Text;
            string password = bunifuTextBox2.Text;
            string confirm = bunifuTextBox4.Text;
         
            if(bunifuCheckBox2.Checked != true)
            {
                MessageBox.Show("Veuillez accepter les CGU");
            } 
            if(bunifuTextBox1.Text.Length > 0 && bunifuTextBox3.Text.Length > 0 && bunifuTextBox2.Text.Length > 0 && bunifuTextBox4.Text == password && bunifuCheckBox2.Checked == true)
            {             
                string msg = "RegisterRequest|" + identifiant + "|" + email + "|" + password;
                byte[] bmsg = Encoding.ASCII.GetBytes(msg);
                SocketMain.SendData(bmsg, SocketMain.ns);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tout les champs !");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           

            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SocketMain.f3todo == "destroy")
            {
                MessageBox.Show("destroyed");
                this.Hide();
                this.Close();
            }
        }
    }
}
