using QGF.Network;
using QGF.Traitement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QGF
{
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            bunifuProgressBar1.Value = 0;
        }

        
        int opacity = 0;
        bool inout = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuProgressBar1.Value = SocketMain.loadingstate;


            if (inout == false)
            {
                FadeIn();
            }
            if(inout == true)
            {
                FadeOut();
            }
        }
        int fadingSpeed = 4;

        public void FadeIn()
        {
            label1.ForeColor = Color.FromArgb(label1.ForeColor.R + fadingSpeed, label1.ForeColor.G + fadingSpeed, label1.ForeColor.B + fadingSpeed);
            label2.ForeColor = Color.FromArgb(label1.ForeColor.R + fadingSpeed, label1.ForeColor.G + fadingSpeed, label1.ForeColor.B + fadingSpeed);
            if (label1.ForeColor.R >= this.BackColor.R && inout == false)
            {

                label1.ForeColor = this.BackColor;
                label2.ForeColor = this.BackColor;
                inout = true;
            }
        }
        public void FadeOut()
        {
           try
            {
                label1.ForeColor = Color.FromArgb(label1.ForeColor.R - fadingSpeed, label1.ForeColor.G - fadingSpeed, label1.ForeColor.B - fadingSpeed);
                label2.ForeColor = Color.FromArgb(label1.ForeColor.R - fadingSpeed, label1.ForeColor.G - fadingSpeed, label1.ForeColor.B - fadingSpeed);
            }
            catch
            {
                //label1.ForeColor = this.BackColor;
                //label2.ForeColor = this.BackColor;

                inout = false;
            }
            if (label1.ForeColor.R >= this.BackColor.R && inout == false)
            {
                label1.ForeColor = this.BackColor;
                label2.ForeColor = this.BackColor;
                FadeIn();
                inout = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
                
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (SocketMain.connected == true && bunifuProgressBar1.Value == 100)
            {
                this.Hide();
                timer1.Stop();
                timer2.Stop();
                Form1 frm = new Form1();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SocketMain sock = new SocketMain();
            new Thread(() =>
            {
                sock.Connect();
            }).Start();
            timer3.Stop();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuProgressBar1_onValueChange(object sender, EventArgs e)
        {

        }
    }
}
