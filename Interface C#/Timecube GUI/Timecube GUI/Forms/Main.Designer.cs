namespace Timecube_GUI
{
    partial class Main
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblHeure = new System.Windows.Forms.Label();
            this.Heure = new System.Windows.Forms.Timer(this.components);
            this.lblDate = new System.Windows.Forms.Label();
            this.Timbrage = new System.Windows.Forms.Timer(this.components);
            this.Affichage = new System.Windows.Forms.Timer(this.components);
            this.Informations = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pbxInformations = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbxResult = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInformations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblResult.Location = new System.Drawing.Point(0, 295);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(800, 25);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "Pointage réussie";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeure
            // 
            this.lblHeure.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeure.Font = new System.Drawing.Font("Open Sans", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeure.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHeure.Location = new System.Drawing.Point(12, 160);
            this.lblHeure.Name = "lblHeure";
            this.lblHeure.Size = new System.Drawing.Size(776, 131);
            this.lblHeure.TabIndex = 3;
            this.lblHeure.Text = "00:00";
            this.lblHeure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Heure
            // 
            this.Heure.Interval = 1000;
            this.Heure.Tick += new System.EventHandler(this.Heure_Tick);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDate.Font = new System.Drawing.Font("Open Sans", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDate.Location = new System.Drawing.Point(12, 125);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(776, 51);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "00/00/0000";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timbrage
            // 
            this.Timbrage.Interval = 1;
            this.Timbrage.Tick += new System.EventHandler(this.Timbrage_Tick);
            // 
            // Affichage
            // 
            this.Affichage.Interval = 3000;
            this.Affichage.Tick += new System.EventHandler(this.Affichage_Tick);
            // 
            // Informations
            // 
            this.Informations.Interval = 1;
            this.Informations.Tick += new System.EventHandler(this.Informations_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(314, 412);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(175, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Espace personnel";
            this.label1.Click += new System.EventHandler(this.PbxInformations_Click);
            // 
            // pbxInformations
            // 
            this.pbxInformations.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbxInformations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxInformations.Image = global::Timecube_GUI.Properties.Resources.user_white;
            this.pbxInformations.Location = new System.Drawing.Point(367, 345);
            this.pbxInformations.Name = "pbxInformations";
            this.pbxInformations.Size = new System.Drawing.Size(68, 64);
            this.pbxInformations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxInformations.TabIndex = 5;
            this.pbxInformations.TabStop = false;
            this.pbxInformations.Click += new System.EventHandler(this.PbxInformations_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Image = global::Timecube_GUI.Properties.Resources.timecube_logo_white;
            this.pictureBox2.Location = new System.Drawing.Point(276, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(247, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pbxResult
            // 
            this.pbxResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbxResult.Image = global::Timecube_GUI.Properties.Resources.sucess;
            this.pbxResult.Location = new System.Drawing.Point(311, 123);
            this.pbxResult.Name = "pbxResult";
            this.pbxResult.Size = new System.Drawing.Size(186, 170);
            this.pbxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxResult.TabIndex = 0;
            this.pbxResult.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxInformations);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblHeure);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.pbxResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxInformations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.Timer Heure;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer Timbrage;
        private System.Windows.Forms.Timer Affichage;
        private System.Windows.Forms.PictureBox pbxInformations;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Timer Informations;
    }
}

