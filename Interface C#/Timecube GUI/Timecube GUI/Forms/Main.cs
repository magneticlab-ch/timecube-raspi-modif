


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
using Newtonsoft.Json;

namespace Timecube_GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //1 = Mode espace personnel
        //2 = Mode espace admin
        //3 = Mode pointage

        public int USERINFO_TIMELEFT = 10000; // 10 secondes

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Screen currentScreen = Screen.FromHandle(this.Handle);
            this.Size = new System.Drawing.Size(currentScreen.Bounds.Width, currentScreen.Bounds.Height);

            pbxResult.Visible = false;
            lblResult.Visible = false;
            Heure.Start();        
            Timbrage.Start();
            int minutes = DateTime.Now.Minute;
            string minutes_formatted = minutes.ToString();
            if (minutes < 10)
            {
                minutes_formatted = "0" + minutes.ToString();
            }

            lblHeure.Text = DateTime.Now.Hour.ToString() + ":" + minutes_formatted;
            lblDate.Text = DateTime.Now.ToShortDateString().ToString();
        }

        private void Heure_Tick(object sender, EventArgs e)
        {

            int minutes = DateTime.Now.Minute;
            string minutes_formatted = minutes.ToString();
            if (minutes < 10)
            {
                minutes_formatted = "0" + minutes.ToString();
            }

            lblHeure.Text = DateTime.Now.Hour.ToString() + ":" + minutes_formatted;
            if (lblHeure.Text == "0:00")
            {
                lblDate.Text = DateTime.Now.ToShortDateString().ToString();
            }
        }

        public async void WaitSomeTime()
        {
            await Task.Delay(3000);
            this.Enabled = true;
        }

        public void WriteLog(string message)
        {
            File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/logs.txt", Environment.NewLine + DateTime.Now.ToLongDateString() + " " + message);
        }

        private void Timbrage_Tick(object sender, EventArgs e)
        {
            try
            {
                string[] infos_timbrage = File.ReadAllLines("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json");

                string[] col_timbrage = infos_timbrage[0].Split(';');

            if (Convert.ToInt32(col_timbrage[0]) == 3)
            {
                    if (File.ReadAllText("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json") != string.Empty)
                    {
                        Affichage.Stop();
                        Affichage.Start();

                        lblHeure.Visible = false;
                        lblDate.Visible = false;
                        lblResult.Visible = true;
                        pbxResult.Visible = true;

                        if (col_timbrage[1] == "1")
                        {
                            if (col_timbrage[3] == "Au revoir")
                            {
                                lblResult.ForeColor = Color.Red;
                                lblResult.Text = col_timbrage[2] + " " + col_timbrage[3] + Environment.NewLine + "Pointage effectué avec succès";
                                pbxResult.Image = Properties.Resources._out;
                            }
                            else
                            {
                                lblResult.ForeColor = Color.Green;
                                lblResult.Text = col_timbrage[2] + " " + col_timbrage[3] + Environment.NewLine + "Pointage effectué avec succès";
                                pbxResult.Image = Properties.Resources._in;
                            }
                        }
                        else
                        {
                            lblResult.ForeColor = Color.Red;
                            lblResult.Text = "Une erreur est survenue, veuillez réessayez";
                            pbxResult.Image = Properties.Resources.error;
                        }

                        File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json", string.Empty);


                    }
                }
            
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }

        }

        private void Affichage_Tick(object sender, EventArgs e)
        {
            lblHeure.Visible = true;
            lblDate.Visible = true;
            lblResult.Visible = false;
            pbxResult.Visible = false;
        }

        private void PbxInformations_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info.txt", "1");

                Messagebox msgbox = new Messagebox();
                msgbox.Show();

                Informations.Stop();
                Informations.Start();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message);
            }
        }

        private void Informations_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
