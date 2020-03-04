namespace Timecube_GUI
{
    partial class Userinfos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHeuresEff = new System.Windows.Forms.Label();
            this.lblHeuresThe = new System.Windows.Forms.Label();
            this.lblStatut = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TempsRestant = new System.Windows.Forms.Timer(this.components);
            this.pbxExit = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsername.Location = new System.Drawing.Point(86, 31);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(167, 33);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "lblUsername";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(29, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Heures effectives ce mois";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(29, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heures théoriques ce mois";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(29, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Statut";
            // 
            // lblHeuresEff
            // 
            this.lblHeuresEff.AutoSize = true;
            this.lblHeuresEff.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeuresEff.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHeuresEff.Location = new System.Drawing.Point(312, 124);
            this.lblHeuresEff.Name = "lblHeuresEff";
            this.lblHeuresEff.Size = new System.Drawing.Size(129, 26);
            this.lblHeuresEff.TabIndex = 5;
            this.lblHeuresEff.Text = "lblHeuresEff";
            // 
            // lblHeuresThe
            // 
            this.lblHeuresThe.AutoSize = true;
            this.lblHeuresThe.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeuresThe.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHeuresThe.Location = new System.Drawing.Point(311, 163);
            this.lblHeuresThe.Name = "lblHeuresThe";
            this.lblHeuresThe.Size = new System.Drawing.Size(137, 26);
            this.lblHeuresThe.TabIndex = 6;
            this.lblHeuresThe.Text = "lblHeuresThe";
            // 
            // lblStatut
            // 
            this.lblStatut.AutoSize = true;
            this.lblStatut.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatut.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStatut.Location = new System.Drawing.Point(311, 208);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(93, 26);
            this.lblStatut.TabIndex = 7;
            this.lblStatut.Text = "lblStatut";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(161, 552);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Revenir au menu";
            this.label7.Click += new System.EventHandler(this.PbxExit_Click);
            // 
            // TempsRestant
            // 
            this.TempsRestant.Interval = 60000;
            this.TempsRestant.Tick += new System.EventHandler(this.TempsRestant_Tick);
            // 
            // pbxExit
            // 
            this.pbxExit.Image = global::Timecube_GUI.Properties.Resources.exit_white;
            this.pbxExit.Location = new System.Drawing.Point(191, 482);
            this.pbxExit.Name = "pbxExit";
            this.pbxExit.Size = new System.Drawing.Size(62, 67);
            this.pbxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxExit.TabIndex = 8;
            this.pbxExit.TabStop = false;
            this.pbxExit.Click += new System.EventHandler(this.PbxExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Timecube_GUI.Properties.Resources.user_white;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Userinfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(468, 604);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbxExit);
            this.Controls.Add(this.lblStatut);
            this.Controls.Add(this.lblHeuresThe);
            this.Controls.Add(this.lblHeuresEff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Userinfos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Userinfos";
            this.Load += new System.EventHandler(this.Userinfos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHeuresEff;
        private System.Windows.Forms.Label lblHeuresThe;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.PictureBox pbxExit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer TempsRestant;
    }
}