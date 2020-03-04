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
using Newtonsoft.Json.Converters;
using System.Globalization;


namespace Timecube_GUI
{

    public partial class Messagebox : Form
    {

        public int TIME_REMAINING = 10;
        public Messagebox()
        {
            InitializeComponent();
        }

        private void Messagebox_Load(object sender, EventArgs e)
        {
            TempsRestant.Start();
            Informations.Start();
            lblSecondsRemaining.Text = TIME_REMAINING.ToString();
            this.Text = "Authentification requise";
        }

        private void TempsRestant_Tick(object sender, EventArgs e)
        {
            if (TIME_REMAINING == 1)
            {
                File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info.txt", string.Empty);
                this.Close();
            }
            else
            {
                TIME_REMAINING--;
                lblSecondsRemaining.Text = TIME_REMAINING.ToString();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            File.WriteAllText("/home/pi/Desktop/timecube-raspi-modif/user_info.txt", string.Empty);
            this.Close();
        }

        private void Informations_Tick(object sender, EventArgs e)
        {
            string strContentUserInfoData = File.ReadAllText("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json");

            if (strContentUserInfoData != string.Empty)
            {
                string json = strContentUserInfoData;
                UserDataStructure items = JsonConvert.DeserializeObject<UserDataStructure>(json);
                Userinfos frmUserInfos = new Userinfos(items.UserInfo.User,items.UserInfo.HeuresEffectives,items.UserInfo.HeuresTheoriques, items.UserInfo.Statut);
                frmUserInfos.Show();
                this.Close();

            }
        }
    }
    public partial class UserDataStructure
    {
        [JsonProperty("userInfo")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class UserInfo
    {
        [JsonProperty("statut")]
        public string Statut { get; set; }

        [JsonProperty("heures_theoriques")]
        public string HeuresTheoriques { get; set; }

        [JsonProperty("heures_effectives")]
        public string HeuresEffectives { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }

    public partial class UserData
    {
        public static UserData FromJson(string json) => JsonConvert.DeserializeObject<UserData>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this UserData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
