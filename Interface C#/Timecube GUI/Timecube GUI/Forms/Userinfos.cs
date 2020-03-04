using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Timecube_GUI
{
    public partial class Userinfos : Form
    {
        public string USERNAME = "";
        public string HEURES_THEORIQUES = "";
        public string HEURES_EFFECTIVES = "";
        public string STATUT = "";
        public int TEMPS_RESTANT = 5;
        public Userinfos(string _username, string _heurestheoriques, string _heureseffectives, string _statut)
        {
            USERNAME = _username;
            HEURES_EFFECTIVES = _heureseffectives;
            HEURES_THEORIQUES = _heurestheoriques;
            STATUT = _statut;
            InitializeComponent();
        }

        private void Userinfos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Screen currentScreen = Screen.FromHandle(this.Handle);
            this.Size = new System.Drawing.Size(currentScreen.Bounds.Width, currentScreen.Bounds.Height);

            lblUsername.Text = USERNAME;
            lblHeuresEff.Text = HEURES_EFFECTIVES;
            lblHeuresThe.Text = HEURES_THEORIQUES;
            lblStatut.Text = STATUT;

        }

        private void PbxExit_Click(object sender, EventArgs e)
        {
            File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json", string.Empty);
            File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info.txt", string.Empty);
            this.Close();
        }

        private void TempsRestant_Tick(object sender, EventArgs e)
        {
            if (TEMPS_RESTANT == 0)
            {
                this.Close();
            }
            else
            {
                TEMPS_RESTANT--;
            }
        }
    }
}
