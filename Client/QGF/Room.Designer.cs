namespace QGF
{
    partial class Room
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            this.join_button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.rankpic = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankpic)).BeginInit();
            this.SuspendLayout();
            // 
            // join_button
            // 
            this.join_button.BackColor = System.Drawing.Color.Transparent;
            this.join_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("join_button.BackgroundImage")));
            this.join_button.ButtonText = "Rejoindre";
            this.join_button.ButtonTextMarginLeft = 0;
            this.join_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.join_button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.join_button.DisabledFillColor = System.Drawing.Color.Gray;
            this.join_button.DisabledForecolor = System.Drawing.Color.White;
            this.join_button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_button.ForeColor = System.Drawing.Color.White;
            this.join_button.IconLeftCursor = System.Windows.Forms.Cursors.Arrow;
            this.join_button.IconPadding = 10;
            this.join_button.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.join_button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(58)))));
            this.join_button.IdleBorderRadius = 25;
            this.join_button.IdleBorderThickness = 1;
            this.join_button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(58)))));
            this.join_button.IdleIconLeftImage = null;
            this.join_button.IdleIconRightImage = null;
            this.join_button.Location = new System.Drawing.Point(742, 39);
            this.join_button.Name = "join_button";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(101)))), ((int)(((byte)(141)))));
            stateProperties1.BorderRadius = 25;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(101)))), ((int)(((byte)(141)))));
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.join_button.onHoverState = stateProperties1;
            this.join_button.Size = new System.Drawing.Size(175, 33);
            this.join_button.TabIndex = 1;
            this.join_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.join_button.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("UniSansLight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.Location = new System.Drawing.Point(171, 14);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(280, 82);
            this.bunifuLabel1.TabIndex = 8;
            this.bunifuLabel1.Text = "Jeu : CSGO \r\n4/15 joueurs  - Public";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.Click += new System.EventHandler(this.bunifuLabel1_Click);
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.BorderRadius = 47;
            this.bunifuPictureBox1.Image = global::QGF.Properties.Resources.LOGO_DIABLO;
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(17, 8);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(94, 94);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 10;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            this.bunifuPictureBox1.Click += new System.EventHandler(this.bunifuPictureBox1_Click);
            // 
            // rankpic
            // 
            this.rankpic.AllowFocused = false;
            this.rankpic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rankpic.BorderRadius = 25;
            this.rankpic.Image = global::QGF.Properties.Resources.premium;
            this.rankpic.IsCircle = true;
            this.rankpic.Location = new System.Drawing.Point(460, 52);
            this.rankpic.Name = "rankpic";
            this.rankpic.Size = new System.Drawing.Size(50, 50);
            this.rankpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rankpic.TabIndex = 11;
            this.rankpic.TabStop = false;
            this.rankpic.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Square;
            this.rankpic.Click += new System.EventHandler(this.rank_Click);
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.AutoSize = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Font = new System.Drawing.Font("UniSansLight", 2.25F);
            this.bunifuLabel2.ForeColor = System.Drawing.Color.Goldenrod;
            this.bunifuLabel2.Location = new System.Drawing.Point(535, 54);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(126, 42);
            this.bunifuLabel2.TabIndex = 12;
            this.bunifuLabel2.Text = "Premium";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.rankpic);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.join_button);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Room";
            this.Size = new System.Drawing.Size(932, 112);
            this.Load += new System.EventHandler(this.Room_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rankpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton join_button;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.UI.WinForms.BunifuPictureBox rankpic;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
    }
}
