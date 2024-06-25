using System;/////////
using System.Collections; //arylist için gerekli
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.IO.Ports;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTab;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using DevExpress.XtraReports.UI;

namespace MedicalGasPlantAutomation
{
    public partial class MainForm : Form
    {
        #region DEĞİŞKENLER
       
        const int _alarmSayac = 60;
        public  int language,af=1;
        int[] oto1 = new int[255];
        int[] oto2 = new int[255];
        int[] oto3 = new int[255];
        int[] oto4 = new int[255];
        int[] oto5 = new int[255];
        int[] oto6 = new int[255];
        int[] oto7 = new int[255];
        int[] oto8 = new int[255];
        int[] oto9 = new int[255];
        int[] oto10 = new int[255];
        int[] oto11 = new int[255];
        int[] oto12 = new int[255];
        int[] oto13 = new int[255];
        int[] oto14 = new int[255];
        int[] oto15 = new int[255];
        int[] oto16 = new int[255];

        bool[] openCloseCheck = new bool[300];
        bool[] IsAlarm = new bool[300];
        bool[] mute = new bool[300];
        int openPopUpCnt;
        bool systemMute,alarm;
        int[] plantType = new int[255];
        int[] compCount = new int[255];
        int[] pumpCount = new int[255];
        int[] panelID = new int[255];
        int[] tankNo = new int[255];      
        int[] tankAlarmLevel = new int[255];
        int[] popUpTimerCnt = new int[255];
        SoundPlayer player = new SoundPlayer();
        XtraTabPage[] tabPage = new XtraTabPage[100];
        PictureBox[] plantPictureBox = new PictureBox[300];
        Panel[] plantPanel = new Panel[300];
        Label[] plantNameLabel = new Label[300];
        //Label[] _StateCOMLabel = new Label[15];
        PictureBox[] logoPicturebox = new PictureBox[15];
        // Label _StateCOMLabel = new Label();

        Label SantralAdı = new Label();
        Label SantralID = new Label();
        Label SantralAlarm = new Label();
        Label SaatLabel = new Label();
        Label TarihLabel = new Label();

        //O2 değişkenleri
        Label[] leftBankPressLabelO2 = new Label[300];
        Label[] rightBankPressLabelO2 = new Label[300];
        Label[] leftInDutyLabelO2 = new Label[300];
        Label[] rightInDutyLabelO2 = new Label[300];
        Label[] linePressLabelO2 = new Label[300];
        //VAC değişkenleri
        Label[] pump1StateLabelVAC = new Label[300];
        Label[] pump2StateLabelVAC = new Label[300];
        Label[] pump3StateLabelVAC = new Label[300];
        Label[] pump4StateLabelVAC = new Label[300];
        Label[] pump1InDutyTimeLabelVAC = new Label[300];
        Label[] pump2InDutyTimeLabelVAC = new Label[300];
        Label[] pump3InDutyTimeLabelVAC = new Label[300];
        Label[] pump4InDutyTimeLabelVAC = new Label[300];
        Label[] tankPressLabelVAC = new Label[300];
        Label[] linePressLabelVAC = new Label[300];
        //AIR değişkenleri
        Label[] comp1StateLabelAIR = new Label[300];
        Label[] comp2StateLabelAIR = new Label[300];
        Label[] comp3StateLabelAIR = new Label[300];
        Label[] comp4StateLabelAIR = new Label[300];

        Label[] comp1InDutyTimeLabelAIR = new Label[300];
        Label[] comp2InDutyTimeLabelAIR = new Label[300];
        Label[] comp3InDutyTimeLabelAIR = new Label[300];
        Label[] comp4InDutyTimeLabelAIR = new Label[300];

        Label[] tankPressLabelAIR = new Label[300];
        Label[] linePressLabelAIR = new Label[300];
        Label[] dewPointLabelAIR = new Label[300];

        Label[] cylinder1StateLabelAIR = new Label[300];
        Label[] cylinder2StateLabelAIR = new Label[300];
        Label[] cylinder3StateLabelAIR = new Label[300];
        Label[] cylinder4StateLabelAIR = new Label[300];

        //AGSS değişkenleri
        Label[] pump1StateLabelAGSS = new Label[300];
        Label[] pump2StateLabelAGSS = new Label[300];
   
        Label[] pump2InDutyTimeLabelAGSS = new Label[300];
        Label[] vakumPressLabelAGSS = new Label[300];

        Label[] levelLabelLKD = new Label[300];
        DataTable tablo = new DataTable();
        //POP UP değişkenleri
        Form[] plantPopUpForm = new Form[300];
        PictureBox[] plantPopUpLogoPictureBox = new PictureBox[300];
        Button[] popUpFormExitButton = new Button[300];
        Button[] popUpFormMinimizeButton = new Button[300];
        Button[] popUpFormMuteButton = new Button[300];
        Button[] popUpButtonKayıt = new Button[300];     

        Label[] popUpPlantNameLabel = new Label[300];
        //O2
        Label[] popUpLeftBankPressLabelO2 = new Label[300];
        Label[] popUpRightBankPressLabelO2 = new Label[300];
        Label[] popUpLeftInDutyLabelO2 = new Label[300];
        Label[] popUpRightInDutyLabelO2 = new Label[300];
        Label[] popUpLeftChangeCylindersLabelO2 = new Label[300];
        Label[] popUpRightChangeCylindersLabelO2 = new Label[300];
        Label[] popUpLeftReserveLowLabelO2 = new Label[300];
        Label[] popUpRightReserveLowLabelO2 = new Label[300];
        Label[] popUpLeftChangeCylindersImmLabelO2 = new Label[300];
        Label[] popUpRightChangeCylindersImmLabelO2 = new Label[300];
        Label[] popUpLinePressLabelO2 = new Label[300];
        Label[] popUpLowPressureLabelO2 = new Label[300];
        Label[] popUpPressureFaultLabelO2 = new Label[300];
        Label[] popUpHighPressureLabelO2 = new Label[300];    
        Label[] popUpChangeLabelO2 = new Label[300];
        Label[] popUpPlantFaultLabelO2 = new Label[300];
        PictureBox[] popUpLeftBankPictureBoxO2 = new PictureBox[300];
        PictureBox[] popUpRightBankPictureBoxO2 = new PictureBox[300];
        //VAC
        Label[] popUpPump1StateLabelVAC = new Label[300];
        Label[] popUpPump2StateLabelVAC = new Label[300];
        Label[] popUpPump3StateLabelVAC = new Label[300];
        Label[] popUpPump4StateLabelVAC = new Label[300];
        Label[] popUpTankPressLabelVAC = new Label[300];
        Label[] popUpLinePressLabelVAC = new Label[300];
        Label[] popUpPlantEmergencyLabelVAC = new Label[300];
        Label[] popUpPlantFaultLabelVAC = new Label[300];
        Label[] popUpLinePressFaultLabelVAC = new Label[300];
        Label[] popUpFilterFaultLabelVAC = new Label[300];
        PictureBox[] popUpPump1StatePictureBoxVAC = new PictureBox[300];
        PictureBox[] popUpPump2StatePictureBoxVAC = new PictureBox[300];
        PictureBox[] popUpPump3StatePictureBoxVAC = new PictureBox[300];
        PictureBox[] popUpPump4StatePictureBoxVAC = new PictureBox[300];
        //AIR
        Label[] popUpPump1StateLabelAIR = new Label[300];
        Label[] popUpPump2StateLabelAIR = new Label[300];
        Label[] popUpPump3StateLabelAIR = new Label[300];
        Label[] popUpPump4StateLabelAIR = new Label[300];
        Label[] popUpTankPressLabelAIR = new Label[300];
        Label[] popUpLinePressLabelAIR = new Label[300];
        Label[] popUpDewPointLabelAIR = new Label[300];
        Label[] popUpPlantEmergencyLabelAIR = new Label[300];
        Label[] popUpPlantFaultLabelAIR = new Label[300];
        Label[] popUpLinePressFaultLabelAIR = new Label[300];
        Label[] popUpDewPointFaultLabelAIR = new Label[300];
        PictureBox[] popUpPump1StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpPump2StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpPump3StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpPump4StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpDryer1StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpDryer2StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpDryer3StatePictureBoxAIR = new PictureBox[300];
        PictureBox[] popUpDryer4StatePictureBoxAIR = new PictureBox[300];

        //AGSS
        Label[] popUppump1CutinAGSSLabelAGSS = new Label[300];
        Label[] popUppump2CutinAGSSLabelAGSS = new Label[300];
        Label[] popUppump1CutOutAGSSLabelAGSS = new Label[300];
        Label[] popUppump2CutOutAGSSLabelAGSS = new Label[300];
        Label[] popUpcontactFault1AGSSLabelAGSS = new Label[300];
        Label[] popUpcontactFault2AGSSLabelAGSS = new Label[300];
        Label[] popUpthermicFault1AGSSLabelAGSS = new Label[300];
        Label[] popUpthermicFault2AGSSLabelAGSS = new Label[300];
        Label[] popUpPassive1AGSSLabelAGSS = new Label[300];   
        Label[] popUpPassive2AGSSLabelAGSS = new Label[300];
  

        Label[] popUpvakumPressLabelAGSS = new Label[300];
        Label[] popUpPlantEmergencyLabelAGSS = new Label[300];
        Label[] popUpPlantFaultLabelAGSS = new Label[300];
        Label[] popUpairflowLabelAGSS = new Label[300];
        Label[] ŞifreYanlış = new Label[300];
        Label[] ŞifreGirişi = new Label[300];
        PictureBox[] popUpPump1StatePictureBoxAGSS = new PictureBox[300];
        PictureBox[] popUpPump2StatePictureBoxAGSS = new PictureBox[300];
  
        TextBox[] ŞifreTextBox = new TextBox[300];

        String[] oku = new string[300];
        TextBox[,] AGSSButtonTextBox = new TextBox[300,300];

        Label[] popUpLevelFaultLabelLKD = new Label[300]; 
        Label[] popUpLevelLabelLKD = new Label[300];
        PictureBox[] popUpPumpTankPictureBoxLKD = new PictureBox[300];

        #endregion

        public MainForm()
        {
            InitializeComponent();

        }       

        public void databaseyaz()
        {
            OleDbCommand komut1;
            OleDbDataAdapter kayit1;
            //DataTable tablo;
            string path = @"Provider=Microsoft.ACE.OleDb.12.0;Data Source = " + Application.StartupPath + "/DatabaseMGPA.accdb";
            OleDbConnection connection = new OleDbConnection(path);
            connection.Open();
            OleDbCommand yazmaKomutu = new OleDbCommand();
            yazmaKomutu.Connection = connection;
            string sorgu1 = "Select * from veritabani";
            komut1 = new OleDbCommand(sorgu1, connection);
            tablo = new DataTable();
            kayit1 = new OleDbDataAdapter(komut1);
            kayit1.Fill(tablo);
            yazmaKomutu.CommandText = "update veritabani set DIL = @language";
            yazmaKomutu.Parameters.AddWithValue("@language", language);
            yazmaKomutu.ExecuteNonQuery();
            connection.Close();
        }
        public void databasealarmyaz()
        {

            string path = @"Provider=Microsoft.ACE.OleDb.12.0;Data Source = " + Application.StartupPath + "/DatabaseAlarm.accdb";
            OleDbConnection connection = new OleDbConnection(path);
            connection.Open();
          //  TarihLabel.Text = DateTime.Now.ToLongDateString();
           // SaatLabel.Text = DateTime.Now.ToLongTimeString();
            OleDbCommand Kaydet = new OleDbCommand("insert into DatabaseAlarm(Tarih,Saat,ID,SANTRAL,ALARM) values(?,?,?,?,?)", connection);
            Kaydet.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString("dd.MM.yyyy"));
            Kaydet.Parameters.AddWithValue("@Saat", DateTime.Now.ToLongTimeString());
            Kaydet.Parameters.AddWithValue("@ID", SantralID.Text);
            Kaydet.Parameters.AddWithValue("@SANTRAL", SantralAdı.Text);
            Kaydet.Parameters.AddWithValue("@ALARM", SantralAlarm.Text);
            Kaydet.ExecuteNonQuery();
            connection.Close();

        }

        private void MainForm_reload(object sender, EventArgs e)
        {
            tablo = Class.Database.GetDataTable();
            createPlantCentral();
            for (int k=0; k < Class.Database.plantCount; k++) createPopUp(k);
            timerCOM.Enabled = true;
            Class.Communication.COMName = tablo.Rows[0]["COMPORT"].ToString();
            
            for (int i = 0; i < Class.Database.plantCount; i++) 
            {
                panelID[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL ID"]);
                plantType[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR
                tankNo[i] = Convert.ToInt32(tablo.Rows[i]["LİKİT TANK NO"]);
                tankAlarmLevel[i] = Convert.ToInt32(tablo.Rows[i]["TANK ALARM SEVİYESİ"]);

                if (language == 0) deneme[i] = 1;
                else if (language == 1) deneme[i] = 1;
                else if (language == 2) deneme[i] = 1;
            }

                if (af == 1)
                {
                    af = 2;
                    Class.Communication._Main();
                }
            Class.Communication._Main1();
        }
        
        #region FORM EVENTS

        private void mainFormExitButton_Click(object sender, EventArgs e)
        {
            
            Class.Communication.readThread.Abort();
            if (label3.Text == "BAĞLANTI KURULDU!")
            {
                Class.Communication._serialPort.Close();
            }
            Environment.Exit(0);
        }

        private void mainFormMinimizeButton_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }
        private void mainFormMuteButton_Click(object sender, EventArgs e)
        {
            //Class.Communication.readThread.Start();
            if (!systemMute)
            {
                systemMute = true;
                mainFormMuteButton.BackgroundImage = Properties.Resources.muteRed;
            }
            else
            {
                systemMute = false;
                mainFormMuteButton.BackgroundImage = Properties.Resources.muteGreen;
            }
        }

        private void CONNECTButton_Click(object sender, EventArgs e)
        {
             //Class.Communication.COMName = comboBoxCOM.Text;
            //Class.Communication.COMName = "COM3";
            /* if (Class.Communication._serialPortli.IsOpen)*/
           // Class.Communication._Main();
            //timerCOM.Enabled = true;
        }

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            
            Class.Communication.COMName = tablo.Rows[0]["COMPORT"].ToString();
            if (language == 0)
            {
                if (Class.Communication.COMState) label3.Text = "BAĞLANDI!";
                else label3.Text = "BAĞLANTI YOK!";

            }
            if (language==1)
            {
                if (Class.Communication.COMState) label3.Text = "CONNECTED!";
                else label3.Text = "NO CONNECTION!";

            }
            if (language == 2)
            {
                if (Class.Communication.COMState) label3.Text = "VERBUNDEN!";
                else label3.Text = "KEINE VERBINDUNG!";

            }
            for (int i = 0; i < Class.Database.plantCount; i++)
            {               
                               
                string[] timeStr = { "saat", "hours", "stunden" };
                string[] unitO2Str = { "", "kPa", "psi","","bar" };
                string[] unitVACStr = { "mmHg", "mBar" };
                string[] unitAIRStr = { "bar", "kPa", "psi" };
                string[] unitAGSSStr = { "mmHg" };

                switch (plantType[i])
                {
                    case 1://O2
                        #region O2
                        if (Class.Communication.COMErr[i])
                        {
                            leftBankPressLabelO2[i].Text = "COM_ERR";
                            rightBankPressLabelO2[i].Text = "COM_ERR";
                            linePressLabelO2[i].Text = "COM_ERR";
                            leftInDutyLabelO2[i].Text = "COM_ERR";
                            rightInDutyLabelO2[i].Text = "COM_ERR";

                            leftInDutyLabelO2[i].ForeColor = Color.White;
                            rightBankPressLabelO2[i].ForeColor = Color.White;
                            linePressLabelO2[i].ForeColor = Color.White;
                            rightInDutyLabelO2[i].ForeColor = Color.White;
                            leftInDutyLabelO2[i].ForeColor = Color.White;
                        }
                        else if (Class.Communication.OkCOM[panelID[i]])
                        {
                            leftBankPressLabelO2[i].Text = Convert.ToString(Class.Communication.cylinderPressLeftO2[panelID[i]]) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];
                            rightBankPressLabelO2[i].Text = Convert.ToString(Class.Communication.cylinderPressRightO2[panelID[i]]) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];
                            linePressLabelO2[i].Text = Convert.ToString((float)(Class.Communication.linePressO2[panelID[i]] / 100)) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];

                            if (Class.Communication.inDutyLeftO2[panelID[i]])
                            {
                                if (language == 0) leftInDutyLabelO2[i].Text = "AKTİF";
                                if (language == 1) leftInDutyLabelO2[i].Text = "IN DUTY";
                                if (language == 2) leftInDutyLabelO2[i].Text = "IN BETRIEB";
                                leftInDutyLabelO2[i].ForeColor = Color.Green;
                                
                            }

                            else
                            {
                                if (language == 0) leftInDutyLabelO2[i].Text = "PASİF"; //err eklenecek
                                if (language == 1) leftInDutyLabelO2[i].Text = "PASSIVE"; //err eklenecek
                                if (language == 2) leftInDutyLabelO2[i].Text = "PASSIV"; //err eklenecek
                                leftInDutyLabelO2[i].ForeColor = Color.White;
                            }


                            if (Class.Communication.inDutyRightO2[panelID[i]])
                            {
                                if (language == 0) rightInDutyLabelO2[i].Text = "AKTİF";
                                if (language == 1) rightInDutyLabelO2[i].Text = "IN DUTY";
                                if (language == 2) rightInDutyLabelO2[i].Text = "IN BETRIEB";
                                rightInDutyLabelO2[i].ForeColor = Color.Green;
                            }

                            else
                            {
                                if (language == 0) rightInDutyLabelO2[i].Text = "PASİF"; //err eklenecek
                                if (language == 1) rightInDutyLabelO2[i].Text = "PASSIVE"; //err eklenecek
                                if (language == 2) rightInDutyLabelO2[i].Text = "PASSIV"; //err eklenecek
                                rightInDutyLabelO2[i].ForeColor = Color.White;
                            }

                            if (Class.Communication.changeCylinderLeftO2[panelID[i]])
                            {
                                if (language == 0) leftInDutyLabelO2[i].Text = "DEĞİŞTİR";
                                if (language == 1) leftInDutyLabelO2[i].Text = "CHANGE";
                                if (language == 2) leftInDutyLabelO2[i].Text = "Verändern";
                                leftInDutyLabelO2[i].ForeColor = Color.Red;
                            }

                            if (Class.Communication.changeCylinderRightO2[panelID[i]])
                            {
                                if (language == 0) rightInDutyLabelO2[i].Text = "DEĞİŞTİR";
                                if (language == 1) rightInDutyLabelO2[i].Text = "CHANGE";
                                if (language == 2) rightInDutyLabelO2[i].Text = "Verändern";
                                rightInDutyLabelO2[i].ForeColor = Color.Red;
                            }

                            #region alarm kontrol
                            if (Class.Communication.pressureFaultO2[panelID[i]] || Class.Communication.plantFaultLeftO2[panelID[i]] || Class.Communication.plantFaultRightO2[panelID[i]] || Class.Communication.changeImmediatelyLeftO2[panelID[i]] ) IsAlarm[i] = true;
                            else IsAlarm[i] = false;
                            #endregion
                        }
                        #endregion
                        break;
                    case 2://VAC
                        #region VAC
                        if (Class.Communication.COMErr[i])
                        {
                            pump1InDutyTimeLabelVAC[i].Text = "COM_ERR";
                            pump2InDutyTimeLabelVAC[i].Text = "COM_ERR";
                            pump1StateLabelVAC[i].Text = "COM_ERR";
                            pump2StateLabelVAC[i].Text = "COM_ERR";
                            pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                            switch (pumpCount[i])
                            {
                                case 2:

                                    break;

                                case 3:
                                    pump3InDutyTimeLabelVAC[i].Text = "COM_ERR";
                                    pump3StateLabelVAC[i].Text = "COM_ERR";
                                    break;

                                case 4:
                                    pump3InDutyTimeLabelVAC[i].Text = "COM_ERR";
                                    pump4InDutyTimeLabelVAC[i].Text = "COM_ERR";
                                    pump3StateLabelVAC[i].Text = "COM_ERR";
                                    pump4StateLabelVAC[i].Text = "COM_ERR";
                                    break;
                            }
                            tankPressLabelVAC[i].Text = "COM_ERR";
                            linePressLabelVAC[i].Text = "COM_ERR";
                        }
                        else if (Class.Communication.OkCOM[panelID[i]])
                        {
                            pump1InDutyTimeLabelVAC[i].Text = Convert.ToString(Class.Communication.saatPompa1VAC[panelID[i]]) + " " + timeStr[language];
                            pump2InDutyTimeLabelVAC[i].Text = Convert.ToString(Class.Communication.saatPompa2VAC[panelID[i]]) + " " + timeStr[language];
                            string[,] pumpStateVACStr = new string[3, 4] { { "DURUYOR","ÇALIŞIYOR","ARIZA","PASİF"} ,
                                                                           { "CUT OUT", "CUT IN" ,"DEFECTIVE","PASSIVE" },
                                                                           { "AUSSCHALTEN" ,"EINSCHALTEN","STÖRUNG ","PASSIV" }};
                            pump1StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP1VAC[panelID[i]]];
                            pump2StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP2VAC[panelID[i]]];

                            pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);

                            switch (pumpCount[i])
                            {
                                case 2:

                                    break;

                                case 3:
                                    pump3InDutyTimeLabelVAC[i].Text = Convert.ToString(Class.Communication.saatPompa3VAC[panelID[i]]) + " " + timeStr[language];
                                    pump3StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP3VAC[panelID[i]]];
                                    break;

                                case 4:
                                    pump3InDutyTimeLabelVAC[i].Text = Convert.ToString(Class.Communication.saatPompa3VAC[panelID[i]]) + " " + timeStr[language];
                                    pump4InDutyTimeLabelVAC[i].Text = Convert.ToString(Class.Communication.saatPompa4VAC[panelID[i]]) + " " + timeStr[language];
                                    pump3StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP3VAC[panelID[i]]];
                                    pump4StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP4VAC[panelID[i]]];
                                    break;
                            }

                            tankPressLabelVAC[i].Text = Convert.ToString(Class.Communication.vakumTankVAC[panelID[i]]) + " " + unitVACStr[Class.Communication.birimVAC[panelID[i]]];
                            linePressLabelVAC[i].Text = Convert.ToString(Class.Communication.vakumHatVAC[panelID[i]]) + " " + unitVACStr[Class.Communication.birimVAC[panelID[i]]];
                            #region alarm kontrol
                            if (Class.Communication.AlarmVAC[panelID[i]]) IsAlarm[i] = true;
                            else IsAlarm[i] = false;
                            #endregion
                        }

                        #endregion
                        break;
                    case 3:
                        #region AIR
                        if (Class.Communication.COMErr[i])
                        {
                            comp1InDutyTimeLabelAIR[i].Text = "COM_ERR";
                            comp2InDutyTimeLabelAIR[i].Text = "COM_ERR";
                            comp1StateLabelAIR[i].Text = "COM_ERR";
                            comp2StateLabelAIR[i].Text = "COM_ERR";
                            cylinder1StateLabelAIR[i].Text = "COM_ERR";
                            cylinder2StateLabelAIR[i].Text = "COM_ERR";
                            cylinder3StateLabelAIR[i].Text = "COM_ERR";
                            cylinder4StateLabelAIR[i].Text = "COM_ERR";
                            tankPressLabelAIR[i].Text = "COM_ERR";
                            linePressLabelAIR[i].Text = "COM_ERR";
                            dewPointLabelAIR[i].Text = "COM_ERR";
                            pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                            switch (pumpCount[i])
                            {
                                case 2:

                                    break;
                                case 3:
                                    comp3InDutyTimeLabelAIR[i].Text = "COM_ERR";
                                    comp3StateLabelAIR[i].Text = "COM_ERR";
                                    break;
                                case 4:
                                    comp3InDutyTimeLabelAIR[i].Text = "COM_ERR";
                                    comp4InDutyTimeLabelAIR[i].Text = "COM_ERR";
                                    comp3StateLabelAIR[i].Text = "COM_ERR";
                                    comp4StateLabelAIR[i].Text = "COM_ERR";

                                    break;
                            }
                        }
                        else if (Class.Communication.OkCOM[panelID[i]])
                        {
                            string[,] compStateAIRStr = new string[3, 4] { { "DURUYOR","ÇALIŞIYOR","ARIZA","PASİF"} ,
                                                                       { "CUT OUT", "CUT IN" ,"DEFECTIVE","PASSIVE" },
                                                                       { "AUSSCHALTEN" ,"EINSCHALTEN","STÖRUNG ","PASSIV" }};
                            

                            /*
                                                        string[,] dryerStateAIRStr = new string[3, 2] { { "PASİF","AKTİF"} ,
                                                                                                        { "CUT OUT", "CUT IN" },
                                                                                                        { "PASSIV" ,"AKTIV"}};
                                                                                                        */

                            try { 
                            string[,] dryerStateAIRStr = new string[3, 4] { { "PASİF","AKTİF","ARIZA","NEMLİ"} ,
                                                                       { "PASSIVE", "ACTIVE" ,"DEFECTIVE","HUMID" },
                                                                       { "PASSIV" ,"AKTIV","STÖRUNG ","DAMP" }};  
                            cylinder1StateLabelAIR[i].Text = dryerStateAIRStr[language, Class.Communication.statDrayer1[panelID[i]]];
                            cylinder2StateLabelAIR[i].Text = dryerStateAIRStr[language, Class.Communication.statDrayer2[panelID[i]]];
                            cylinder3StateLabelAIR[i].Text = dryerStateAIRStr[language, Class.Communication.statDrayer3[panelID[i]]];
                            cylinder4StateLabelAIR[i].Text = dryerStateAIRStr[language, Class.Communication.statDrayer4[panelID[i]]];
                            }
                            catch { }

                            tankPressLabelAIR[i].Text = Convert.ToString((float)Class.Communication.basıncTankAIR[panelID[i]]/100) + " " + unitAIRStr[Class.Communication.birimAIR[panelID[i]]];
                            linePressLabelAIR[i].Text = Convert.ToString((float)Class.Communication.basıncHatAIR[panelID[i]]/100) + " " + unitAIRStr[Class.Communication.birimAIR[panelID[i]]];
                            dewPointLabelAIR[i].Text = "-" + Convert.ToString((float)(65537 - Class.Communication.dewPoint[panelID[i]])/100) + " " + "° Td";
                            pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                            try
                            {
                                switch (pumpCount[i])
                                {
                                    case 2:
                                        comp1InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa1AIR[panelID[i]]) + " " + timeStr[language];
                                        comp2InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa2AIR[panelID[i]]) + " " + timeStr[language];

                                        comp1StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP1AIR[panelID[i]]];
                                        comp2StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP2AIR[panelID[i]]];

                                        break;
                                    case 3:
                                        comp1InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa1AIR[panelID[i]]) + " " + timeStr[language];
                                        comp2InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa2AIR[panelID[i]]) + " " + timeStr[language];

                                        comp1StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP1AIR[panelID[i]]];
                                        comp2StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP2AIR[panelID[i]]];

                                        comp3InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa3AIR[panelID[i]]) + " " + timeStr[language];
                                        comp3StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP3AIR[panelID[i]]];
                                        break;
                                    case 4:
                                        comp1InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa1AIR[panelID[i]]) + " " + timeStr[language];
                                        comp2InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa2AIR[panelID[i]]) + " " + timeStr[language];

                                        comp1StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP1AIR[panelID[i]]];
                                        comp2StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP2AIR[panelID[i]]];

                                        comp3InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa3AIR[panelID[i]]) + " " + timeStr[language];
                                        comp4InDutyTimeLabelAIR[i].Text = Convert.ToString(Class.Communication.saatPompa4AIR[panelID[i]]) + " " + timeStr[language];
                                        comp3StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP3AIR[panelID[i]]];
                                        comp4StateLabelAIR[i].Text = compStateAIRStr[language, Class.Communication.StatP4AIR[panelID[i]]];
                                        break;
                                }
                            }
                            catch {}
                            #region alarm kontrol
                            if (Class.Communication.AlarmAIR[panelID[i]]) IsAlarm[i] = true;
                            else IsAlarm[i] = false;
                            #endregion
                        }
                        #endregion
                        break;
                    case 4:
                        #region LIKID
                      
                                      
                         if (Class.Communication.COMErrLKD[panelID[i]])
                         {
                             levelLabelLKD[i].Text = "COM_ERR";
                         }
                        else if (Class.Communication.OkCOM[panelID[i]])
                        {
                             levelLabelLKD[i].Text = "%" + Convert.ToString((Class.Communication.tankLevel[panelID[i], tankNo[i]-1])/100);

                            if (Class.Communication.tankLevel[panelID[i], 0] == 10000) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN100.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 8000) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN90.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 6000) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN70.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 4000) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN50.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] > 3000) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN40.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 1500) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN30.png");
                            else plantPictureBox[i].ImageLocation = (Application.StartupPath + "/miniLikid_EN10.png");
                        }
                        #region alarm kontrol
                        if(((Class.Communication.tankLevel[panelID[i], tankNo[i] - 1])/100) <= tankAlarmLevel[i]) IsAlarm[i] = true;
                        else IsAlarm[i] = false;
                        #endregion

                        #endregion
                        break;
                    case 5://AGSS
                        #region AGSS

                        

                        if (Class.Communication.COMErr[i])
                        {
                            pump1StateLabelAGSS[i].Text = "COM_ERR";
                            pump2StateLabelAGSS[i].Text = "COM_ERR";
                            vakumPressLabelAGSS[i].Text = "COM_ERR";

                            pump1StateLabelAGSS[i].ForeColor = Color.White;
                            pump2StateLabelAGSS[i].ForeColor = Color.White;
                            vakumPressLabelAGSS[i].ForeColor = Color.White;
                          
                        }
                        else if (Class.Communication.OkCOM[panelID[i]])
                        {
                               vakumPressLabelAGSS[i].Text = Convert.ToString(Class.Communication.vakumAGSS[panelID[i]]) + " " + unitAGSSStr[Class.Communication.birimAGSS[panelID[i]]];

                            if (Class.Communication.pump1CutinAGSS[panelID[i]])
                            {
                                if (language == 0) pump1StateLabelAGSS[i].Text = "ÇALIŞIYOR";
                                if (language == 1) pump1StateLabelAGSS[i].Text = "CUT IN";
                                if (language == 2) pump1StateLabelAGSS[i].Text = "EINSCHALTEN";
                                pump1StateLabelAGSS[i].ForeColor = Color.FromArgb(136, 242, 185); 

                            }
                            if (!Class.Communication.Passive1AGSS[panelID[i]])         
                            {
                                if (language == 0) pump1StateLabelAGSS[i].Text = "PASİF"; //err eklenecek
                                if (language == 1) pump1StateLabelAGSS[i].Text = "PASSIVE"; //err eklenecek
                                if (language == 2) pump1StateLabelAGSS[i].Text = "PASSIV"; //err eklenecek
                                pump1StateLabelAGSS[i].ForeColor = Color.White;
                            }

                            if (Class.Communication.pump1CutOutAGSS[panelID[i]])
                            {
                                if (language == 0) pump1StateLabelAGSS[i].Text = "DURUYOR";
                                if (language == 1) pump1StateLabelAGSS[i].Text = "CUT OUT";
                                if (language == 2) pump1StateLabelAGSS[i].Text = "AUSSCHALTEN";
                                pump1StateLabelAGSS[i].ForeColor = Color.Orange;

                            }


                            if (Class.Communication.pump2CutinAGSS[panelID[i]])
                            {
                                if (language == 0) pump2StateLabelAGSS[i].Text = "ÇALIŞIYOR";
                                if (language == 1) pump2StateLabelAGSS[i].Text = "CUT IN";
                                if (language == 2) pump2StateLabelAGSS[i].Text = "EINSCHALTEN";
                                pump2StateLabelAGSS[i].ForeColor = Color.FromArgb(136, 242, 185);
                            }
                            if (!Class.Communication.Passive2AGSS[panelID[i]])
                            {
                                if (language == 0) pump2StateLabelAGSS[i].Text = "PASİF"; //err eklenecek
                                if (language == 1) pump2StateLabelAGSS[i].Text = "PASSIVE"; //err eklenecek
                                if (language == 2) pump2StateLabelAGSS[i].Text = "PASSIV"; //err eklenecek
                                pump2StateLabelAGSS[i].ForeColor = Color.White;
                            }

                            if (Class.Communication.pump2CutOutAGSS[panelID[i]])
                            {
                                if (language == 0) pump2StateLabelAGSS[i].Text = "DURUYOR";
                                if (language == 1) pump2StateLabelAGSS[i].Text = "CUT OUT";
                                if (language == 2) pump2StateLabelAGSS[i].Text = "AUSSCHALTEN";
                                pump2StateLabelAGSS[i].ForeColor = Color.Orange;
                            }

                            if (Class.Communication.contactFault1AGSS[panelID[i]])
                            {
                                if (language == 0) pump1StateLabelAGSS[i].Text = "KONTAKTÖR";
                                if (language == 1) pump1StateLabelAGSS[i].Text = "CONTACTOR";
                                if (language == 2) pump1StateLabelAGSS[i].Text = "SCHÜTZ";
                                pump1StateLabelAGSS[i].ForeColor = Color.Red;

                            }


                            if (Class.Communication.contactFault2AGSS[panelID[i]])
                            {
                                if (language == 0) pump2StateLabelAGSS[i].Text = "KONTAKTÖR";
                                if (language == 1) pump2StateLabelAGSS[i].Text = "CONTACTOR";
                                if (language == 2) pump2StateLabelAGSS[i].Text = "SCHÜTZ";
                                pump2StateLabelAGSS[i].ForeColor = Color.Red;
                            }

                            if (Class.Communication.thermicFault1AGSS[panelID[i]])
                            {
                                if (language == 0) pump1StateLabelAGSS[i].Text = "TERMİK";
                                if (language == 1) pump1StateLabelAGSS[i].Text = "THERMIC";
                                if (language == 2) pump1StateLabelAGSS[i].Text = "THERMIK";
                                pump1StateLabelAGSS[i].ForeColor = Color.Red;

                            }


                            if (Class.Communication.thermicFault2AGSS[panelID[i]])
                            {
                                if (language == 0) pump2StateLabelAGSS[i].Text = "TERMİK";
                                if (language == 1) pump2StateLabelAGSS[i].Text = "THERMIC";
                                if (language == 2) pump2StateLabelAGSS[i].Text = "THERMIK";
                                pump2StateLabelAGSS[i].ForeColor = Color.Red;
                            }


                            #region alarm kontrol
                            if (Class.Communication.AlarmAGSS[panelID[i]]) IsAlarm[i] = true;
                            else IsAlarm[i] = false;
                            #endregion
                        }

                        #endregion
                        break;
                }

                popUp(i);

            /*    #region ALARM VARSA POPUP AÇ
                if (IsAlarm[i])
                {
                    if (openPopUpCnt < 15)
                    {
                        if (!openCloseCheck[i])//eger açık değilse
                        {
                            openCloseCheck[i] = true;
                            openPopUpCnt++;
                            plantPopUpForm[i].Show();
                        }
                    }
                }*/
                
            }
            /*
            #region ALARM KONTROL
            alarm = false;
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                if (IsAlarm[i]) { alarm = true; }
            }
            if (alarm && !systemMute)
            {
                string path = Application.StartupPath + "/siren.wav";
                player.SoundLocation = path;
                player.Play();
            }
            if (openPopUpCnt != 0)
            {
                if (!IsAlarm[Class.Communication.panelCnt])
                {
                    if (openCloseCheck[Class.Communication.panelCnt])
                    {
                        openCloseCheck[Class.Communication.panelCnt] = false;
                        openPopUpCnt--;
                        plantPopUpForm[Class.Communication.panelCnt].Hide();
                    }
                }
            }

            #endregion
            */
        }
        #endregion

        #region POP UP DATALARI YAZDIR

        public void popUp(int i)
        {

            plantType[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR

            string[] unitO2Str = { "bar", "kPa", "psi","aa"};
            string[] unitVACStr = { "mmHg", "mBar" };
            string[] unitAIRStr = { "bar", "kPa", "psi" };
            string[] unitAGSSStr = { "mmHg" };
            switch (plantType[i])
            {
                case 1:
                    #region O2
                    if (Class.Communication.COMErr[i])
                    {
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";
                        popUpLeftBankPressLabelO2[i].Text = " ";

                    }
                    else if (Class.Communication.OkCOM[panelID[i]])
                    {
                        popUpLeftBankPressLabelO2[i].Text = Convert.ToString(Class.Communication.cylinderPressLeftO2[panelID[i]]) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];
                        popUpRightBankPressLabelO2[i].Text = Convert.ToString(Class.Communication.cylinderPressRightO2[panelID[i]]) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];
                        popUpLinePressLabelO2[i].Text = Convert.ToString((float)Class.Communication.linePressO2[panelID[i]] / 100) + " " + unitO2Str[Class.Communication.birimO2[panelID[i]]];

                        if (Class.Communication.inDutyLeftO2[panelID[i]]) popUpLeftInDutyLabelO2[i].ForeColor = Color.Green;
                        else popUpLeftInDutyLabelO2[i].ForeColor = Color.White;
                        if (Class.Communication.inDutyRightO2[panelID[i]]) popUpRightInDutyLabelO2[i].ForeColor = Color.Green;
                        else popUpRightInDutyLabelO2[i].ForeColor = Color.White;

                        if (Class.Communication.changeCylinderLeftO2[panelID[i]]) popUpLeftChangeCylindersLabelO2[i].ForeColor = Color.Yellow;
                        else popUpLeftChangeCylindersLabelO2[i].ForeColor = Color.White;
                        if (Class.Communication.changeCylinderRightO2[panelID[i]]) popUpRightChangeCylindersLabelO2[i].ForeColor = Color.Yellow;
                        else popUpRightChangeCylindersLabelO2[i].ForeColor = Color.White;

                        if (Class.Communication.reserveLowLeftO2[panelID[i]]) popUpLeftReserveLowLabelO2[i].ForeColor = Color.Yellow;
                        else popUpLeftReserveLowLabelO2[i].ForeColor = Color.White;
                        if (Class.Communication.reserveLowRightO2[panelID[i]]) popUpRightReserveLowLabelO2[i].ForeColor = Color.Yellow;
                        else popUpRightReserveLowLabelO2[i].ForeColor = Color.White;

                        if (Class.Communication.changeImmediatelyLeftO2[panelID[i]]) popUpLeftChangeCylindersImmLabelO2[i].ForeColor = Color.Red;
                        else popUpLeftChangeCylindersImmLabelO2[i].ForeColor = Color.White;
                        if (Class.Communication.changeImmediatelyRightO2[panelID[i]]) popUpRightChangeCylindersImmLabelO2[i].ForeColor = Color.Red;
                        else popUpRightChangeCylindersImmLabelO2[i].ForeColor = Color.White;

                        if (Class.Communication.linePressLowO2[panelID[i]])
                        {
                            popUpLowPressureLabelO2[i].Visible = true;
                            oto12[i]++;                                     //Alarmların Raporlanması için                             
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpLowPressureLabelO2[i].Text;
                            if (oto12[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpLowPressureLabelO2[i].Visible = false;
                            oto12[i] = 0;
                        }
                        if (Class.Communication.pressureFaultO2[panelID[i]])
                        {
                            popUpPressureFaultLabelO2[i].Visible = true;
                            oto13[i]++;                                     //Alarmların Raporlanması için                             
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPressureFaultLabelO2[i].Text;
                            if (oto13[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPressureFaultLabelO2[i].Visible = false;
                            oto13[i] = 0;
                        }
                        if (Class.Communication.linePressHighO2[panelID[i]])
                        {
                            popUpHighPressureLabelO2[i].Visible = true;
                            oto14[i]++;                                     //Alarmların Raporlanması için                             
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpHighPressureLabelO2[i].Text;
                            if (oto14[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpHighPressureLabelO2[i].Visible = false;
                            oto14[i] = 0;
                        }
                        if (Class.Communication.plantFaultLeftO2[panelID[i]] || Class.Communication.plantFaultRightO2[panelID[i]])
                        {
                            popUpPlantFaultLabelO2[i].Visible = true;
                            oto15[i]++;                                     //Alarmların Raporlanması için                             
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantFaultLabelO2[i].Text;
                            if (oto15[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantFaultLabelO2[i].Visible = false;
                            oto15[i] = 0;
                        }
                        if (Class.Communication.changeImmediatelyLeftO2[panelID[i]])
                        {
                            popUpChangeLabelO2[i].Visible = true;
                            oto16[i]++;                                     //Alarmların Raporlanması için                             
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpChangeLabelO2[i].Text;
                            if (oto16[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpChangeLabelO2[i].Visible = false;
                            oto16[i] = 0;
                        }
                    }

                    #endregion
                    break;
                case 2:
                    #region VAC
                    if (Class.Communication.COMErr[i])
                    {
                        popUpTankPressLabelVAC[i].Text = " ";
                        popUpLinePressLabelVAC[i].Text = " ";
                        popUpPump1StateLabelVAC[i].Text = " ";
                        popUpPump2StateLabelVAC[i].Text = " ";
                        pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                        if (pumpCount[i] > 2)
                        {
                            popUpPump3StateLabelVAC[i].Text = " ";
                        }
                        if (pumpCount[i] > 3)
                        {
                            popUpPump4StateLabelVAC[i].Text = " ";
                        }
                    }
                    else if (Class.Communication.OkCOM[panelID[i]])
                    {
                        string[,] pumpStateVACStr = new string[3, 4] { { "DURUYOR","ÇALIŞIYOR","ARIZA","PASİF"} ,
                                                                       { "CUT OUT", "CUT IN" ,"DEFECTIVE","PASSIVE" },
                                                                       { "AUSSCHALTEN" ,"EINSCHALTEN","STÖRUNG ","PASSIV" }};
                        popUpTankPressLabelVAC[i].Text = Convert.ToString(Class.Communication.vakumTankVAC[panelID[i]]) + " " + unitVACStr[Class.Communication.birimVAC[panelID[i]]];
                        popUpLinePressLabelVAC[i].Text = Convert.ToString(Class.Communication.vakumHatVAC[panelID[i]]) + " " + unitVACStr[Class.Communication.birimVAC[panelID[i]]];
                        popUpPump1StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP1VAC[panelID[i]]];
                        popUpPump2StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP2VAC[panelID[i]]];

                        pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                        if (pumpCount[i] > 2)
                        {
                            popUpPump3StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP3VAC[panelID[i]]];
                        }
                        if (pumpCount[i] > 3)
                        {
                            popUpPump4StateLabelVAC[i].Text = pumpStateVACStr[language, Class.Communication.StatP4VAC[panelID[i]]];
                        }
                        if (Class.Communication.faultPlantEmergencyVAC[panelID[i]])
                        {
                            oto1[i]++;                                     //Alarmların Raporlanması için 
                            popUpPlantEmergencyLabelVAC[i].Visible = true;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantEmergencyLabelVAC[i].Text;

                            if (oto1[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantEmergencyLabelVAC[i].Visible = false;
                            oto1[i] = 0;
                        }

                        if (Class.Communication.faultPlantVAC[panelID[i]])
                        {
                            oto2[i]++;
                            popUpPlantFaultLabelVAC[i].Visible = true;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantFaultLabelVAC[i].Text;
                            if (oto2[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantFaultLabelVAC[i].Visible = false;
                            oto2[i] = 0;
                        }
                        if (Class.Communication.faultPlantPressureVAC[panelID[i]])
                        {
                            oto3[i] = oto3[i] + 1;
                            popUpLinePressFaultLabelVAC[i].Visible = true;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpLinePressFaultLabelVAC[i].Text;
                            if (oto3[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpLinePressFaultLabelVAC[i].Visible = false;
                            oto3[i] = 0;
                        }
                        if (Class.Communication.faultFilterVAC[panelID[i]])
                        {
                            oto4[i] = oto4[i] + 1;
                            popUpFilterFaultLabelVAC[i].Visible = true;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpFilterFaultLabelVAC[i].Text;
                            if (oto4[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpFilterFaultLabelVAC[i].Visible = false;
                            oto4[i] = 0;
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region AIR
                    if (Class.Communication.COMErr[i])
                    {
                        popUpTankPressLabelAIR[i].Text = " ";
                        popUpLinePressLabelAIR[i].Text = " ";
                        popUpDewPointLabelAIR[i].Text = " ";

                        popUpPump1StateLabelAIR[i].Text = " ";
                        popUpPump2StateLabelAIR[i].Text = " ";
                        pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                        if (pumpCount[i] > 2)
                        {
                            popUpPump3StateLabelAIR[i].Text = " ";
                        }
                        if (pumpCount[i] > 3)
                        {
                            popUpPump4StateLabelAIR[i].Text = " ";
                        }
                    } 
                    else if (Class.Communication.OkCOM[panelID[i]])
                    {
                        string[,] pumpStateAIRStr = new string[3, 4] { { "DURUYOR","ÇALIŞIYOR","ARIZA","PASİF"} ,
                                                                   { "CUT OUT", "CUT IN" ,"DEFECTIVE","PASSIVE" },
                                                                   { "AUSSCHALTEN" ,"EINSCHALTEN","STÖRUNG ","PASSIV" }};
                        popUpTankPressLabelAIR[i].Text = Convert.ToString((float)Class.Communication.basıncTankAIR[panelID[i]]/100) + " " + unitAIRStr[Class.Communication.birimAIR[panelID[i]]];
                        popUpLinePressLabelAIR[i].Text = Convert.ToString((float)Class.Communication.basıncHatAIR[panelID[i]]/100) + " " + unitAIRStr[Class.Communication.birimAIR[panelID[i]]];
                        popUpDewPointLabelAIR[i].Text = "-" + Convert.ToString((float)(65537 - Class.Communication.dewPoint[panelID[i]]) / 100) + " " + "° Td";

                        popUpPump1StateLabelAIR[i].Text = pumpStateAIRStr[language, Class.Communication.StatP1AIR[panelID[i]]];
                        popUpPump2StateLabelAIR[i].Text = pumpStateAIRStr[language, Class.Communication.StatP2AIR[panelID[i]]];

                        pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                        if (pumpCount[i] > 2)
                        {
                            popUpPump3StateLabelAIR[i].Text = pumpStateAIRStr[language, Class.Communication.StatP3AIR[panelID[i]]];
                        }
                        if (pumpCount[i] > 3)
                        {
                            popUpPump4StateLabelAIR[i].Text = pumpStateAIRStr[language, Class.Communication.StatP4AIR[panelID[i]]];
                        }
                        if (Class.Communication.faultPlantEmergencyAIR[panelID[i]])
                        {
                            popUpPlantEmergencyLabelAIR[i].Visible = true;
                            oto5[i] = oto5[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantEmergencyLabelAIR[i].Text;
                            if (oto5[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantEmergencyLabelAIR[i].Visible = false;
                            oto5[i] = 0;
                        }
                        if (Class.Communication.faultPlantAIR[panelID[i]])
                        {
                            popUpPlantFaultLabelAIR[i].Visible = true;
                            oto6[i] = oto6[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantFaultLabelAIR[i].Text;
                            if (oto6[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantFaultLabelAIR[i].Visible = false;
                            oto6[i] = 0;
                        }
                        if (Class.Communication.faultPlantPressureAIR[panelID[i]])
                        {
                            popUpLinePressFaultLabelAIR[i].Visible = true;
                            oto7[i] = oto7[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpLinePressFaultLabelAIR[i].Text;
                            if (oto7[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpLinePressFaultLabelAIR[i].Visible = false;
                            oto7[i] = 0;
                        }
                        if (Class.Communication.faultDewPointAIR[panelID[i]])
                        {
                            popUpDewPointFaultLabelAIR[i].Visible = true;
                            oto8[i] = oto8[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpDewPointFaultLabelAIR[i].Text;
                            if (oto8[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpDewPointFaultLabelAIR[i].Visible = false;
                            oto8[i] = 0;
                        }
                    }

                    #endregion
                    break;
                case 4:
                    #region LIKID

                    if (Class.Communication.COMErr[i])
                    {
                        popUpLevelLabelLKD[i].Text = " ";
                    }
                    else if (Class.Communication.OkCOM[panelID[i]])
                    {
                        if (IsAlarm[i])
                        {
                            popUpLevelFaultLabelLKD[i].Visible = true;
                            oto9[i] = oto9[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpLevelFaultLabelLKD[i].Text;
                            if (oto9[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpLevelFaultLabelLKD[i].Visible = false;
                            oto9[i] = 0;
                        }
                        popUpLevelLabelLKD[i].Text = "%" + Convert.ToString((Class.Communication.tankLevel[panelID[i], tankNo[i] - 1]) / 100);
                    }

                    #endregion
                    break;
                case 5:
                    #region AGSS

                    

                    if (Class.Communication.COMErr[i])
                    {
                        popUpvakumPressLabelAGSS[i].Text = " "; 
                   

                    }
                    else if (Class.Communication.OkCOM[panelID[i]])   //AGSSButton35TextBox[k].BackColor = System.Drawing.Color.FromArgb(77, 133, 170);
                    {
                        
                        popUpvakumPressLabelAGSS[i].Text = Convert.ToString(Class.Communication.vakumAGSS[panelID[i]]) + " " + unitAGSSStr[Class.Communication.birimAGSS[panelID[i]]];
                        for (int y = 1; y < 50; y++)
                        {
                            if (Class.Communication.ButtonAGSS[panelID[i], y]) AGSSButtonTextBox[i, y].ForeColor = Color.White;
                            else AGSSButtonTextBox[i, y].ForeColor = Color.FromArgb(87, 155, 193);
                        }
                       
                        if (Class.Communication.pump1CutinAGSS[panelID[i]]) popUppump1CutinAGSSLabelAGSS[i].Visible = true; 
                        else popUppump1CutinAGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.pump2CutinAGSS[panelID[i]]) popUppump2CutinAGSSLabelAGSS[i].Visible = true;
                        else popUppump2CutinAGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.pump1CutOutAGSS[panelID[i]]) popUppump1CutOutAGSSLabelAGSS[i].Visible = true;
                        else popUppump1CutOutAGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.pump2CutOutAGSS[panelID[i]]) popUppump2CutOutAGSSLabelAGSS[i].Visible = true;
                        else popUppump2CutOutAGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.contactFault1AGSS[panelID[i]]) popUpcontactFault1AGSSLabelAGSS[i].Visible = true;
                        else popUpcontactFault1AGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.contactFault2AGSS[panelID[i]]) popUpcontactFault2AGSSLabelAGSS[i].Visible = true;
                        else popUpcontactFault2AGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.thermicFault1AGSS[panelID[i]]) popUpthermicFault1AGSSLabelAGSS[i].Visible = true;
                        else popUpthermicFault1AGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.thermicFault2AGSS[panelID[i]]) popUpthermicFault2AGSSLabelAGSS[i].Visible = true;
                        else popUpthermicFault2AGSSLabelAGSS[i].Visible = false;
                        if (Class.Communication.Passive1AGSS[panelID[i]]) popUpPassive1AGSSLabelAGSS[i].Visible = false;
                        else popUpPassive1AGSSLabelAGSS[i].Visible = true;
                        if (Class.Communication.Passive2AGSS[panelID[i]]) popUpPassive2AGSSLabelAGSS[i].Visible = false;
                        else popUpPassive2AGSSLabelAGSS[i].Visible = true;

                        if (Class.Communication.faultPlantEmergencyAGSS[panelID[i]])
                        {
                            popUpPlantEmergencyLabelAGSS[i].Visible = true;
                            oto10[i] = oto10[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantEmergencyLabelAGSS[i].Text;
                            if (oto10[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantEmergencyLabelAGSS[i].Visible = false;
                            oto10[i] = 0;
                        }
                        if (Class.Communication.faultPlantAGSS[panelID[i]])
                        {
                            popUpPlantFaultLabelAGSS[i].Visible = true;
                            oto11[i] = oto11[i] + 1;
                            SantralAdı.Text = tablo.Rows[i]["SANTRAL ADI"].ToString();
                            SantralID.Text = tablo.Rows[i]["SANTRAL ID"].ToString();
                            SantralAlarm.Text = popUpPlantFaultLabelAGSS[i].Text;
                            if (oto11[i] == 1) button5_Click(this, null);
                        }
                        else
                        {
                            popUpPlantFaultLabelAGSS[i].Visible = false;
                            oto11[i] = 0;
                        }
                        if (Class.Communication.airflowAGSS[panelID[i]]) popUpairflowLabelAGSS[i].Visible = true;
                        else popUpairflowLabelAGSS[i].Visible = false;
                    }
                    
                    #endregion
                    break;
            }
        }

        #endregion

        #region GIF OLUŞTUR
        int[] CntO2 = new int[300];
        int[] deneme = new int[300];
        private void timerGIF_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                plantType[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR
                pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                panelID[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL ID"]);
                switch (plantType[i])
                {
                    case 1:
                        #region O2
                        if (openCloseCheck[i])
                        {
                            if (Class.Communication.plantFaultLeftO2[panelID[i]] || Class.Communication.plantFaultRightO2[panelID[i]])
                            {
                                if (Class.Communication.plantFaultLeftO2[panelID[i]] && !(Class.Communication.plantFaultRightO2[panelID[i]])) plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpOxygenLeftFault.jpg");
                                else if (!(Class.Communication.plantFaultLeftO2[panelID[i]]) && Class.Communication.plantFaultRightO2[panelID[i]]) plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpOxygenRightFault.jpg");
                                else if (Class.Communication.plantFaultLeftO2[panelID[i]] && Class.Communication.plantFaultRightO2[panelID[i]]) plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpOxygenLeftAndRightFault.jpg");
                            }
                            else plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpOxygenNormal.jpg");
                            if (Class.Communication.changeImmediatelyLeftO2[panelID[i]])//change Im var
                            {
                                popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ChangeImmediately.png");
                            }
                            else//change Im yok
                            {
                                if (Class.Communication.changeCylinderLeftO2[panelID[i]]) //change cyl var mı
                                {
                                    popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ChangeCylinder.png");
                                }
                                else //change cyl yoksa
                                {
                                    if (Class.Communication.reserveLowLeftO2[panelID[i]]) //reserve low varsa
                                    {
                                        if (Class.Communication.inDutyLeftO2[panelID[i]]) //reservelow ve aktifse
                                        {
                                            popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ReserveLow.gif");
                                        }
                                        else
                                        {
                                            popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ReserveLow.png");
                                        }

                                    } 
                                    else//reserve low yok
                                    {
                                        if (Class.Communication.inDutyLeftO2[panelID[i]]) // aktifse
                                        {
                                            popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/InDuty.gif");
                                        }
                                        else
                                        {
                                            popUpLeftBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/BankFull.png");
                                        }
                                    }
                                }
                            }

                            if (Class.Communication.changeImmediatelyRightO2[panelID[i]])//change Im var
                            {
                                popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ChangeImmediately.png");
                            }
                            else//change Im yok
                            {
                                if (Class.Communication.changeCylinderRightO2[panelID[i]]) //change cyl var mı
                                {
                                    popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ChangeCylinder.png");
                                }
                                else //change cyl yoksa
                                {
                                    if (Class.Communication.reserveLowRightO2[panelID[i]]) //reserve low varsa
                                    {
                                        if (Class.Communication.inDutyRightO2[panelID[i]]) //reservelow ve aktifse
                                        {
                                            popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ReserveLow.gif");
                                        }
                                        else
                                        {
                                            popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/ReserveLow.png");
                                        }

                                    }
                                    else//reserve low yok
                                    {
                                        if (Class.Communication.inDutyRightO2[panelID[i]]) // aktifse
                                        {
                                            popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/InDuty.gif");
                                        }
                                        else
                                        {
                                            popUpRightBankPictureBoxO2[i].Image = Image.FromFile(Application.StartupPath + "/BankFull.png");
                                        }
                                    }
                                }
                            }
                        }

                        #endregion
                        break;
                    case 2:
                        #region VAC
                        if (openCloseCheck[i])
                        {
                            switch (Class.Communication.StatP1VAC[panelID[i]])
                            {
                                case 0://duruyor
                                    popUpPump1StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.png");//duruyor
                                    break;
                                case 1://çalışıyor
                                    popUpPump1StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.gif");//çalışıyor
                                    break;
                                case 2://arıza
                                    popUpPump1StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump.png");//arızalı
                                    break;
                                case 3://pasif
                                    popUpPump1StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");//pasif
                                    break;
                            }
                            switch (Class.Communication.StatP2VAC[panelID[i]])
                            {
                                case 0:
                                    popUpPump2StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.png");
                                    break;
                                case 1:
                                    popUpPump2StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.gif");
                                    break;
                                case 2:
                                    popUpPump2StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump.png");
                                    break;
                                case 3:
                                    popUpPump2StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                                    break;
                            }
                            if (pumpCount[i] > 2)
                            {
                                switch (Class.Communication.StatP3VAC[panelID[i]])
                                {
                                    case 0:
                                        popUpPump3StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.png");
                                        break;
                                    case 1:
                                        popUpPump3StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.gif");
                                        break;
                                    case 2:
                                        popUpPump3StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump.png");
                                        break;
                                    case 3:
                                        popUpPump3StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                                        break;
                                }
                            }
                            if (pumpCount[i] > 3)
                            {
                                switch (Class.Communication.StatP4VAC[panelID[i]])
                                {
                                    case 0:
                                        popUpPump4StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.png");
                                        break;
                                    case 1:
                                        popUpPump4StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/Pump.gif");
                                        break;
                                    case 2:
                                        popUpPump4StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump.png");
                                        break;
                                    case 3:
                                        popUpPump4StatePictureBoxVAC[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                                        break;
                                }
                            }
                        }

                        #endregion
                        break;
                    case 3:
                        #region AIR
                        if (openCloseCheck[i])
                        {
                            switch (Class.Communication.StatP1AIR[panelID[i]])
                            {
                                case 0:
                                    popUpPump1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.png");
                                    break;
                                case 1:
                                    popUpPump1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.gif");
                                    break;
                                case 2:
                                    popUpPump1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompFault.png");
                                    break;
                                case 3:  
                                    popUpPump1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                                    break;
                            }
                            switch (Class.Communication.StatP2AIR[panelID[i]])
                            {
                                case 0:
                                    popUpPump2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.png");
                                    break;
                                case 1:
                                    popUpPump2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.gif");
                                    break;
                                case 2:
                                    popUpPump2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompFault.png");
                                    break;
                                case 3:
                                    popUpPump2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                                    break;
                            }
                            if (pumpCount[i] > 2)
                            {
                                switch (Class.Communication.StatP3AIR[panelID[i]])
                                {
                                    case 0:
                                        popUpPump3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.png");
                                        break;
                                    case 1:
                                        popUpPump3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.gif");
                                        break;
                                    case 2:
                                        popUpPump3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompFault.png");
                                        break;
                                    case 3:
                                        popUpPump3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                                        break;
                                }
                            }
                            if (pumpCount[i] > 3)
                            {
                                switch (Class.Communication.StatP4AIR[panelID[i]])
                                {
                                    case 0:
                                        popUpPump4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.png");
                                        break;
                                    case 1:
                                        popUpPump4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/Compressor.gif");
                                        break;
                                    case 2:
                                        popUpPump4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompFault.png");
                                        break;
                                    case 3:
                                        popUpPump4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                                        break;
                                }
                            }

                            if (Class.Communication.drayerGrup[panelID[i]] == 1) //sol grup kurutucular aktif
                            {
                                switch (Class.Communication.statDrayer1[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifKirmizi.gif");
                                        break;
                                    case 1://aktif
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifMavi.gif");
                                        break;
                                    case 2://arızalı
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }

                                switch (Class.Communication.statDrayer2[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifKirmizi.gif");
                                        break;
                                    case 1://aktif
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifMavi.gif");
                                        break;
                                    case 2://arızalı
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }

                                switch (Class.Communication.statDrayer3[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 1://aktif
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 2://arızalı
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }

                                switch (Class.Communication.statDrayer4[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 1://aktif
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 2://arızalı
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }
                            }
                            else if (Class.Communication.drayerGrup[panelID[i]] == 2) //sağ grup kurutucular aktif
                            {
                                switch (Class.Communication.statDrayer1[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 1://aktif
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 2://arızalı
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer1StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }
                                switch (Class.Communication.statDrayer2[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 1://aktif
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                                        break;
                                    case 2://arızalı
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer2StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }
                                switch (Class.Communication.statDrayer3[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifKirmizi.gif");
                                        break;
                                    case 1://aktif
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifMavi.gif");
                                        break;
                                    case 2://arızalı
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    case 3://nemli
                                        popUpDryer3StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }
                                switch (Class.Communication.statDrayer4[panelID[i]])
                                {
                                    case 0://pasif
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifKirmizi.gif");
                                        break;
                                    case 1://aktif
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/kurutucuGifMavi.gif");
                                        break;
                                    case 2://arızalı
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                    
                                    case 3://nemli
                                        popUpDryer4StatePictureBoxAIR[i].Image = Image.FromFile(Application.StartupPath + "/DryerFault.png");
                                        break;
                                }
                            }
                        }
                        #endregion
                        break;
                    case 4:
                        #region LIKID
                        if (openCloseCheck[i])
                        {
                            /* if (IsAlarm[i]) plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/likidBosaliyor.jpg");
                             else plantPopUpForm[i].BackgroundImage = Image.FromFile(Application.StartupPath + "/likidNormal.jpg");*/

                            if (Class.Communication.tankLevel[panelID[i], 0] == 10000) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%100.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 8000) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%90.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 6000) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%70.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 4000) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%50.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] > 3000) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%40.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] >= 1500) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%30.png");
                            else if (Class.Communication.tankLevel[panelID[i], 0] == 0) popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%0.png");
                            else popUpPumpTankPictureBoxLKD[i].Image = Image.FromFile(Application.StartupPath + "/%10.png");
                        }
                        #endregion
                        break;
                           case 5:
                        #region AGSS
                        if (openCloseCheck[i])
                        {
                            StreamReader okuma = new StreamReader("C:/Plant Automation/AGSSB.txt"); 
                            tankNo[i] = Convert.ToInt32(tablo.Rows[i]["LİKİT TANK NO"]);
                            if (deneme[i] == 1)
                            {
                                ŞifreYanlış[i].Visible = false;                                

                                if (tankNo[i] == 1) okuma = new StreamReader("C:/Plant Automation/AGSS1.txt");
                                if (tankNo[i] == 2) okuma = new StreamReader("C:/Plant Automation/AGSS2.txt");
                                if (tankNo[i] == 3) okuma = new StreamReader("C:/Plant Automation/AGSS3.txt");
                                if (tankNo[i] == 4) okuma = new StreamReader("C:/Plant Automation/AGSS4.txt");
                                if (tankNo[i] == 5) okuma = new StreamReader("C:/Plant Automation/AGSS5.txt");
                                if (tankNo[i] == 6) okuma = new StreamReader("C:/Plant Automation/AGSS6.txt");
                                if (tankNo[i] == 7) okuma = new StreamReader("C:/Plant Automation/AGSS7.txt");
                                if (tankNo[i] == 8) okuma = new StreamReader("C:/Plant Automation/AGSS8.txt");
                                if (tankNo[i] == 9) okuma = new StreamReader("C:/Plant Automation/AGSS9.txt");
                                if (tankNo[i] == 10) okuma = new StreamReader("C:/Plant Automation/AGSS10.txt");
                                if (tankNo[i] == 11) okuma = new StreamReader("C:/Plant Automation/AGSS11.txt");
                                if (tankNo[i] == 12) okuma = new StreamReader("C:/Plant Automation/AGSS12.txt");
                                if (tankNo[i] == 13) okuma = new StreamReader("C:/Plant Automation/AGSS13.txt");
                                if (tankNo[i] == 14) okuma = new StreamReader("C:/Plant Automation/AGSS14.txt");
                                if (tankNo[i] == 15) okuma = new StreamReader("C:/Plant Automation/AGSS15.txt");

                                for (int y = 1; y < 50; y++)
                                {
                                    oku[y] = okuma.ReadLine();

                                    AGSSButtonTextBox[i, y].Text = oku[y];

                                }
                                okuma.Close();
                                deneme[i] = 0;
                            }

                            //  1.POMPA
                            if (Class.Communication.pump1CutinAGSS[panelID[i]])
                            {
                                popUpPump1StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/Pump_agss.gif");//çalışıyor
                            }
                            if (!Class.Communication.Passive1AGSS[panelID[i]])              
                            {
                                popUpPump1StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump_agss.png");//pasif
                            }

                            if (Class.Communication.pump1CutOutAGSS[panelID[i]])
                            {
                                popUpPump1StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/Pump_agss.png");//duruyor
                            }                            

                            if (Class.Communication.contactFault1AGSS[panelID[i]])
                            {
                                popUpPump1StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump_agss.png");//arızalı
                            }

                            if (Class.Communication.thermicFault1AGSS[panelID[i]])
                            {
                                popUpPump1StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump_agss.png");//arızalı
                            }
                            
                            // 2.POMPA 
                            if (Class.Communication.pump2CutinAGSS[panelID[i]])
                            {
                                popUpPump2StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/Pump_agss.gif");//çalışıyor
                            }
                            if (!Class.Communication.Passive2AGSS[panelID[i]])
                            {
                                popUpPump2StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/PassivePump_agss.png");//pasif
                            }

                            if (Class.Communication.pump2CutOutAGSS[panelID[i]])
                            {
                                popUpPump2StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/Pump_agss.png");//duruyor
                            }

                            if (Class.Communication.contactFault2AGSS[panelID[i]])
                            {
                                popUpPump2StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump_agss.png");//arızalı
                            }

                            if (Class.Communication.thermicFault2AGSS[panelID[i]])
                            {
                                popUpPump2StatePictureBoxAGSS[i].Image = Image.FromFile(Application.StartupPath + "/FaultPump_agss.png");//arızalı
                            }                          
                        }

                         #endregion
                         break;
                }
                #region ALARM VARSA POPUP AÇ

                if (IsAlarm[i])
                {
                    if (openPopUpCnt < Class.Database.plantCount)
                    {
                        if (!openCloseCheck[i])//eger açık değilse
                        {
                            openCloseCheck[i] = true;
                            openPopUpCnt++;
                            plantPopUpForm[i].Show();
                        }
                    }
                }
                #endregion

                #region ALARM KONTROL

                alarm = false;
                if (IsAlarm[i]) alarm = true;

                if (alarm && !systemMute)
                {
                    string path = Application.StartupPath + "/siren.wav";
                    player.SoundLocation = path;
                    player.Play();
                }
                #endregion
            }
            for (int k = 0; k < Class.Database.plantCount; k++)
            {
                if (!IsAlarm[k] && openCloseCheck[k])
                {
                    popUpTimerCnt[k]--;
                    if (popUpTimerCnt[k] == 0)
                    {
                        if (openCloseCheck[k])
                        {
                            openCloseCheck[k] = false;
                            openPopUpCnt--;
                            plantPopUpForm[k].Hide();
                        }
                    }

                }
                else
                {
                    popUpTimerCnt[k] = _alarmSayac;
                }
            }
        }

        #endregion

        #region SANTRAL OLUŞTUR
        void createPlantCentral()
        {           

            int pageCount = Convert.ToInt32(tablo.Rows[0]["SAYFA SAYISI"]);
            language = Convert.ToInt32(tablo.Rows[0]["DIL"]);  

            for (int k = 0; k < pageCount; k++)
            {
                tabPage[k] = new XtraTabPage();
                tabPage[k].Size = new Size(1920, 959);
                tabPage[k].Name = tablo.Rows[k]["SAYFA ADI"].ToString();
                tabPage[k].Text = tablo.Rows[k]["SAYFA ADI"].ToString();
                tabPage[k].Appearance.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
                tabPage[k].Appearance.HeaderActive.Options.UseBackColor = true;
                tabPage[k].Appearance.PageClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(43)))), ((int)(((byte)(61)))));
                tabPage[k].Appearance.PageClient.Options.UseBackColor = true;
                plantTabControl.Controls.Add(tabPage[k]);
                tabPage[k].BringToFront();

              /*  logoPicturebox[k] = new PictureBox();
                logoPicturebox[k].BackColor = System.Drawing.Color.Transparent;
                logoPicturebox[k].Image = Properties.Resources.logomedikarkırmızı;
                logoPicturebox[k].Location = new System.Drawing.Point(1564, 675);
                logoPicturebox[k].Name = "logoPicturebox";
                logoPicturebox[k].Size = new System.Drawing.Size(343, 300);
                logoPicturebox[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                logoPicturebox[k].TabIndex = 0;
                logoPicturebox[k].TabStop = false;
                tabPage[k].Controls.Add(logoPicturebox[k]);
                logoPicturebox[k].BringToFront();*/

            }
           /*
            _StateCOMLabel.AutoSize = true;
            _StateCOMLabel.Location = new System.Drawing.Point(1670, 873);
            _StateCOMLabel.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            _StateCOMLabel.Name = "_StateCOMLabel";
            _StateCOMLabel.Size = new System.Drawing.Size(82, 13);
            _StateCOMLabel.ForeColor = Color.Red;
            _StateCOMLabel.TabIndex = 5;
            _StateCOMLabel.Text = "_StateCOMLabel";
            tabPage[0].Controls.Add(_StateCOMLabel);
            _StateCOMLabel.BringToFront();*/

            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                plantPanel[i] = new Panel();
                int xLocation = Convert.ToInt32(tablo.Rows[i]["X KOORDINAT"]);
                int yLocation = Convert.ToInt32(tablo.Rows[i]["Y KOORDINAT"]);
                int _tabPage = Convert.ToInt32(tablo.Rows[i]["SAYFA"]);
                plantPanel[i].Location = new Point(xLocation, yLocation);
                plantPanel[i].Size = new System.Drawing.Size(505, 307);
                tabPage[_tabPage-1].Controls.Add(plantPanel[i]);
                plantPanel[i].BringToFront();

                #region SANTRAL TİPİNE GÖRE RESİM YÜKLE

                plantPictureBox[i] = new PictureBox();
                plantType[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR 4:LİKİD
                switch (plantType[i])
                {
                    case 1: //O2
                        
                        if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniOxygen_TR.png");
                        if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniOxygen_EN.png");
                        if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniOxygen_DE.png");
                        

                        break;
                    case 2: //VAC

                        pumpCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                       
                        switch (pumpCount[i])
                        {
                            case 2:
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum2Pumps_TR.png"); 
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum2Pumps_EN.png"); 
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum2Pumps_DE.png");
                                break;
                            case 3:
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum3Pumps_TR.png"); 
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum3Pumps_EN.png"); 
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum3Pumps_DE.png");
                                break;
                            case 4:
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum4Pumps_TR.png");
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum4Pumps_EN.png");
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniVacuum4Pumps_DE.png");
                                break;
                        }
                        break;
                    case 3: //AIR

                        compCount[i] = Convert.ToInt32(tablo.Rows[i]["POMPA SAYISI"]);
                        switch (compCount[i])
                        {
                            case 2:
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir2Comp_TR.png");
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir2Comp_EN.png");
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir2Comp_DE.png");
                                break;
                            case 3:
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir3Comp_TR.png");
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir3Comp_EN.png");
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir3Comp_DE.png");
                                break;
                            case 4:
                                language = Convert.ToInt32(tablo.Rows[0]["DIL"]);
                                if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir4Comp_TR.png");
                                if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir4Comp_EN.png");
                                if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniAir4Comp_DE.png");
                                break;
                        }
                        break;

                    case 4://LİKİD
                        if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniLikid_TR.png");
                        if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniLikid_EN.png");
                        if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/MiniLikid_DE.png");
                        break;


                    case 5://AGSS
                        if (language == 0) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/agss_TR.png");
                        if (language == 1) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/agss_EN.png");
                        if (language == 2) plantPictureBox[i].ImageLocation = (Application.StartupPath + "/agss_DE.png");
                        break;


                }
                    
                plantPictureBox[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                plantPictureBox[i].Location = new Point(0, 0);
                plantPictureBox[i].Size = new System.Drawing.Size(505, 307);
                plantPanel[i].Controls.Add(plantPictureBox[i]);
                plantPictureBox[i].BringToFront();

                #endregion

                #region SANTRAL LABELLARINI OLUŞTUR

                plantNameLabel[i] = new Label();
                plantNameLabel[i].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                plantNameLabel[i].ForeColor = System.Drawing.Color.White;
                plantNameLabel[i].Name = "plantNameLabel" + i.ToString();
                plantNameLabel[i].Location = new System.Drawing.Point(77, 20);
                plantNameLabel[i].Size = new System.Drawing.Size(338, 23);
                plantNameLabel[i].Text = tablo.Rows[i]["SANTRAL ADI"].ToString() + "  ID:" + tablo.Rows[i]["SANTRAL ID"].ToString();
                plantNameLabel[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                plantNameLabel[i].Click += new System.EventHandler(plantNameLabel_Click);
                plantPanel[i].Controls.Add(plantNameLabel[i]);
                plantNameLabel[i].BringToFront();

                switch(plantType[i])
                {
                    #region O2 LABEL

                    case 1:
                        leftInDutyLabelO2[i] = new Label();
                        leftInDutyLabelO2[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        leftInDutyLabelO2[i].ForeColor = System.Drawing.Color.White;
                        leftInDutyLabelO2[i].Location = new System.Drawing.Point(113, 108);
                        leftInDutyLabelO2[i].Size = new System.Drawing.Size(75, 23);
                        leftInDutyLabelO2[i].Text = "-";
                        leftInDutyLabelO2[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(leftInDutyLabelO2[i]);
                        leftInDutyLabelO2[i].BringToFront();

                        rightInDutyLabelO2[i] = new Label();
                        rightInDutyLabelO2[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        rightInDutyLabelO2[i].ForeColor = System.Drawing.Color.White;
                        rightInDutyLabelO2[i].Location = new System.Drawing.Point(361, 108);
                        rightInDutyLabelO2[i].Size = new System.Drawing.Size(75, 23);
                        rightInDutyLabelO2[i].Text = "-";
                        rightInDutyLabelO2[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(rightInDutyLabelO2[i]);
                        rightInDutyLabelO2[i].BringToFront();

                        leftBankPressLabelO2[i] = new Label();
                        leftBankPressLabelO2[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        leftBankPressLabelO2[i].ForeColor = System.Drawing.Color.White;
                        leftBankPressLabelO2[i].Location = new System.Drawing.Point(113, 176);
                        leftBankPressLabelO2[i].Size = new System.Drawing.Size(75, 23);
                        leftBankPressLabelO2[i].Text = "-";
                        leftBankPressLabelO2[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(leftBankPressLabelO2[i]);
                        leftBankPressLabelO2[i].BringToFront();

                        rightBankPressLabelO2[i] = new Label();
                        rightBankPressLabelO2[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        rightBankPressLabelO2[i].ForeColor = System.Drawing.Color.White;
                        rightBankPressLabelO2[i].Location = new System.Drawing.Point(361, 176);
                        rightBankPressLabelO2[i].Size = new System.Drawing.Size(75, 23);
                        rightBankPressLabelO2[i].Text = "-";
                        rightBankPressLabelO2[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(rightBankPressLabelO2[i]);
                        rightBankPressLabelO2[i].BringToFront();

                        linePressLabelO2[i] = new Label();
                        linePressLabelO2[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        linePressLabelO2[i].ForeColor = System.Drawing.Color.White;
                        linePressLabelO2[i].Location = new System.Drawing.Point(239, 259);
                        linePressLabelO2[i].Size = new System.Drawing.Size(75, 23);
                        linePressLabelO2[i].Text = "-";
                        linePressLabelO2[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(linePressLabelO2[i]);
                        linePressLabelO2[i].BringToFront();
                        break;

                    #endregion

                    #region VAC LABEL

                    case 2:
                        pump1StateLabelVAC[i] = new Label();
                        pump1StateLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump1StateLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        pump1StateLabelVAC[i].Location = new System.Drawing.Point(73, 156);
                        pump1StateLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        pump1StateLabelVAC[i].Text = "-";
                        pump1StateLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump1StateLabelVAC[i]);
                        pump1StateLabelVAC[i].BringToFront();

                        pump1InDutyTimeLabelVAC[i] = new Label();
                        pump1InDutyTimeLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump1InDutyTimeLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        pump1InDutyTimeLabelVAC[i].Location = new System.Drawing.Point(163, 156);
                        pump1InDutyTimeLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        pump1InDutyTimeLabelVAC[i].Text = "-";
                        pump1InDutyTimeLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump1InDutyTimeLabelVAC[i]);
                        pump1InDutyTimeLabelVAC[i].BringToFront();

                        pump2StateLabelVAC[i] = new Label();
                        pump2StateLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump2StateLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        pump2StateLabelVAC[i].Location = new System.Drawing.Point(73, 192);
                        pump2StateLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        pump2StateLabelVAC[i].Text = "-";
                        pump2StateLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump2StateLabelVAC[i]);
                        pump2StateLabelVAC[i].BringToFront();

                        pump2InDutyTimeLabelVAC[i] = new Label();
                        pump2InDutyTimeLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump2InDutyTimeLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        pump2InDutyTimeLabelVAC[i].Location = new System.Drawing.Point(163, 192);
                        pump2InDutyTimeLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        pump2InDutyTimeLabelVAC[i].Text = "-";
                        pump2InDutyTimeLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump2InDutyTimeLabelVAC[i]);
                        pump2InDutyTimeLabelVAC[i].BringToFront();

                        if (pumpCount[i] > 2)
                        {
                            pump3StateLabelVAC[i] = new Label();
                            pump3StateLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            pump3StateLabelVAC[i].ForeColor = System.Drawing.Color.White;
                            pump3StateLabelVAC[i].Location = new System.Drawing.Point(73, 226);
                            pump3StateLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                            pump3StateLabelVAC[i].Text = "-";
                            pump3StateLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(pump3StateLabelVAC[i]);
                            pump3StateLabelVAC[i].BringToFront();

                            pump3InDutyTimeLabelVAC[i] = new Label();
                            pump3InDutyTimeLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            pump3InDutyTimeLabelVAC[i].ForeColor = System.Drawing.Color.White;
                            pump3InDutyTimeLabelVAC[i].Location = new System.Drawing.Point(163, 226);
                            pump3InDutyTimeLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                            pump3InDutyTimeLabelVAC[i].Text = "-";
                            pump3InDutyTimeLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(pump3InDutyTimeLabelVAC[i]);
                            pump3InDutyTimeLabelVAC[i].BringToFront();
                        }

                        if (pumpCount[i] > 3)
                        {
                            pump4StateLabelVAC[i] = new Label();
                            pump4StateLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            pump4StateLabelVAC[i].ForeColor = System.Drawing.Color.White;
                            pump4StateLabelVAC[i].Location = new System.Drawing.Point(73, 260);
                            pump4StateLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                            pump4StateLabelVAC[i].Text = "-";
                            pump4StateLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(pump4StateLabelVAC[i]);
                            pump4StateLabelVAC[i].BringToFront();

                            pump4InDutyTimeLabelVAC[i] = new Label();
                            pump4InDutyTimeLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            pump4InDutyTimeLabelVAC[i].ForeColor = System.Drawing.Color.White;
                            pump4InDutyTimeLabelVAC[i].Location = new System.Drawing.Point(163, 260);
                            pump4InDutyTimeLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                            pump4InDutyTimeLabelVAC[i].Text = "-";
                            pump4InDutyTimeLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(pump4InDutyTimeLabelVAC[i]);
                            pump4InDutyTimeLabelVAC[i].BringToFront();
                        }

                        tankPressLabelVAC[i] = new Label();
                        tankPressLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        tankPressLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        tankPressLabelVAC[i].Location = new System.Drawing.Point(382, 112);
                        tankPressLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        tankPressLabelVAC[i].Text = "-";
                        tankPressLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(tankPressLabelVAC[i]);
                        tankPressLabelVAC[i].BringToFront();

                        linePressLabelVAC[i] = new Label();
                        linePressLabelVAC[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        linePressLabelVAC[i].ForeColor = System.Drawing.Color.White;
                        linePressLabelVAC[i].Location = new System.Drawing.Point(382, 224);
                        linePressLabelVAC[i].Size = new System.Drawing.Size(75, 23);
                        linePressLabelVAC[i].Text = "-";
                        linePressLabelVAC[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(linePressLabelVAC[i]);
                        linePressLabelVAC[i].BringToFront();
                        break;

                    #endregion

                    #region AIR LABEL

                    case 3:
                        comp1StateLabelAIR[i] = new Label();
                        comp1StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        comp1StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        comp1StateLabelAIR[i].Location = new System.Drawing.Point(143, 61);
                        comp1StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        comp1StateLabelAIR[i].Text = "-";
                        comp1StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(comp1StateLabelAIR[i]);
                        comp1StateLabelAIR[i].BringToFront();

                        comp1InDutyTimeLabelAIR[i] = new Label();
                        comp1InDutyTimeLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        comp1InDutyTimeLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        comp1InDutyTimeLabelAIR[i].Location = new System.Drawing.Point(226, 61);
                        comp1InDutyTimeLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        comp1InDutyTimeLabelAIR[i].Text = "-";
                        comp1InDutyTimeLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(comp1InDutyTimeLabelAIR[i]);
                        comp1InDutyTimeLabelAIR[i].BringToFront();

                        comp2StateLabelAIR[i] = new Label();
                        comp2StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        comp2StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        comp2StateLabelAIR[i].Location = new System.Drawing.Point(143, 96);
                        comp2StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        comp2StateLabelAIR[i].Text = "-";
                        comp2StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(comp2StateLabelAIR[i]);
                        comp2StateLabelAIR[i].BringToFront();

                        comp2InDutyTimeLabelAIR[i] = new Label();
                        comp2InDutyTimeLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        comp2InDutyTimeLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        comp2InDutyTimeLabelAIR[i].Location = new System.Drawing.Point(226, 96);
                        comp2InDutyTimeLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        comp2InDutyTimeLabelAIR[i].Text = "-";
                        comp2InDutyTimeLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(comp2InDutyTimeLabelAIR[i]);
                        comp2InDutyTimeLabelAIR[i].BringToFront();

                        if (compCount[i] > 2)
                        {
                            comp3StateLabelAIR[i] = new Label();
                            comp3StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            comp3StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                            comp3StateLabelAIR[i].Location = new System.Drawing.Point(143, 131);
                            comp3StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                            comp3StateLabelAIR[i].Text = "-";
                            comp3StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(comp3StateLabelAIR[i]);
                            comp3StateLabelAIR[i].BringToFront();

                            comp3InDutyTimeLabelAIR[i] = new Label();
                            comp3InDutyTimeLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            comp3InDutyTimeLabelAIR[i].ForeColor = System.Drawing.Color.White;
                            comp3InDutyTimeLabelAIR[i].Location = new System.Drawing.Point(226, 131);
                            comp3InDutyTimeLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                            comp3InDutyTimeLabelAIR[i].Text = "-";
                            comp3InDutyTimeLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(comp3InDutyTimeLabelAIR[i]);
                            comp3InDutyTimeLabelAIR[i].BringToFront();
                        }

                        if (compCount[i] > 3)
                        {
                            comp4StateLabelAIR[i] = new Label();
                            comp4StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            comp4StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                            comp4StateLabelAIR[i].Location = new System.Drawing.Point(143, 165);
                            comp4StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                            comp4StateLabelAIR[i].Text = "-";
                            comp4StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(comp4StateLabelAIR[i]);
                            comp4StateLabelAIR[i].BringToFront();

                            comp4InDutyTimeLabelAIR[i] = new Label();
                            comp4InDutyTimeLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                            comp4InDutyTimeLabelAIR[i].ForeColor = System.Drawing.Color.White;
                            comp4InDutyTimeLabelAIR[i].Location = new System.Drawing.Point(226, 165);
                            comp4InDutyTimeLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                            comp4InDutyTimeLabelAIR[i].Text = "-";
                            comp4InDutyTimeLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            plantPanel[i].Controls.Add(comp4InDutyTimeLabelAIR[i]);
                            comp4InDutyTimeLabelAIR[i].BringToFront();
                        }

                        tankPressLabelAIR[i] = new Label();
                        tankPressLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        tankPressLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        tankPressLabelAIR[i].Location = new System.Drawing.Point(104, 251);
                        tankPressLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        tankPressLabelAIR[i].Text = "-";
                        tankPressLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(tankPressLabelAIR[i]);
                        tankPressLabelAIR[i].BringToFront();

                        linePressLabelAIR[i] = new Label();
                        linePressLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        linePressLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        linePressLabelAIR[i].Location = new System.Drawing.Point(244, 251);
                        linePressLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        linePressLabelAIR[i].Text = "-";
                        linePressLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(linePressLabelAIR[i]);
                        linePressLabelAIR[i].BringToFront();

                        dewPointLabelAIR[i] = new Label();
                        dewPointLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        dewPointLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        dewPointLabelAIR[i].Location = new System.Drawing.Point(386, 251);
                        dewPointLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        dewPointLabelAIR[i].Text = "-";
                        dewPointLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(dewPointLabelAIR[i]);
                        dewPointLabelAIR[i].BringToFront();

                        cylinder1StateLabelAIR[i] = new Label();
                        cylinder1StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        cylinder1StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        cylinder1StateLabelAIR[i].Location = new System.Drawing.Point(415, 61);
                        cylinder1StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        cylinder1StateLabelAIR[i].Text = "-";
                        cylinder1StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(cylinder1StateLabelAIR[i]);
                        cylinder1StateLabelAIR[i].BringToFront();

                        cylinder2StateLabelAIR[i] = new Label();
                        cylinder2StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        cylinder2StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        cylinder2StateLabelAIR[i].Location = new System.Drawing.Point(415, 96);
                        cylinder2StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        cylinder2StateLabelAIR[i].Text = "-";
                        cylinder2StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(cylinder2StateLabelAIR[i]);
                        cylinder2StateLabelAIR[i].BringToFront();

                        cylinder3StateLabelAIR[i] = new Label();
                        cylinder3StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        cylinder3StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        cylinder3StateLabelAIR[i].Location = new System.Drawing.Point(415, 131);
                        cylinder3StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        cylinder3StateLabelAIR[i].Text = "-";
                        cylinder3StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(cylinder3StateLabelAIR[i]);
                        cylinder3StateLabelAIR[i].BringToFront();

                        cylinder4StateLabelAIR[i] = new Label();
                        cylinder4StateLabelAIR[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        cylinder4StateLabelAIR[i].ForeColor = System.Drawing.Color.White;
                        cylinder4StateLabelAIR[i].Location = new System.Drawing.Point(415, 165);
                        cylinder4StateLabelAIR[i].Size = new System.Drawing.Size(75, 23);
                        cylinder4StateLabelAIR[i].Text = "-";
                        cylinder4StateLabelAIR[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(cylinder4StateLabelAIR[i]);
                        cylinder4StateLabelAIR[i].BringToFront();
                        break;

                    #endregion

                    #region LIKID

                    case 4:
                        levelLabelLKD[i] = new Label();
                        levelLabelLKD[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        levelLabelLKD[i].ForeColor = System.Drawing.Color.White;
                        levelLabelLKD[i].Location = new System.Drawing.Point(285, 160);
                        levelLabelLKD[i].Size = new System.Drawing.Size(75, 23);
                        levelLabelLKD[i].Text = "-";
                        levelLabelLKD[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(levelLabelLKD[i]);
                        levelLabelLKD[i].BringToFront();
                        break;

                    #endregion

                    #region AGSS LABEL

                    case 5:
                        pump1StateLabelAGSS[i] = new Label();
                        pump1StateLabelAGSS[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump1StateLabelAGSS[i].ForeColor = System.Drawing.Color.White;
                        pump1StateLabelAGSS[i].Location = new System.Drawing.Point(352, 90);
                        pump1StateLabelAGSS[i].Size = new System.Drawing.Size(75, 23);
                        pump1StateLabelAGSS[i].Text = "-";
                        pump1StateLabelAGSS[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump1StateLabelAGSS[i]);
                        pump1StateLabelAGSS[i].BringToFront();


                        pump2StateLabelAGSS[i] = new Label();
                        pump2StateLabelAGSS[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        pump2StateLabelAGSS[i].ForeColor = System.Drawing.Color.White;
                        pump2StateLabelAGSS[i].Location = new System.Drawing.Point(352, 148);
                        pump2StateLabelAGSS[i].Size = new System.Drawing.Size(75, 23);
                        pump2StateLabelAGSS[i].Text = "-";
                        pump2StateLabelAGSS[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(pump2StateLabelAGSS[i]);
                        pump2StateLabelAGSS[i].BringToFront();

             

                        vakumPressLabelAGSS[i] = new Label();
                        vakumPressLabelAGSS[i].Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        vakumPressLabelAGSS[i].ForeColor = System.Drawing.Color.White;
                        vakumPressLabelAGSS[i].Location = new System.Drawing.Point(215, 252);
                        vakumPressLabelAGSS[i].Size = new System.Drawing.Size(75, 23);
                        vakumPressLabelAGSS[i].Text = "-";
                        vakumPressLabelAGSS[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPanel[i].Controls.Add(vakumPressLabelAGSS[i]);
                        vakumPressLabelAGSS[i].BringToFront();

                        break;

                        #endregion
                }

                #endregion

            }
            
        }

        #endregion

        #region POPUP OLUŞTUR        
        bool dragging;
        Point firstLocation;      
        public void createPopUp(int k)
        {
            ArrayList pictureArrayListPOPUP = new ArrayList(); //resim dosyaları bu diziye atılacak.
            pictureArrayListPOPUP.Add(Application.StartupPath + "/schonnImage.png");            
            plantPopUpForm[k] = new Form();
            plantPopUpForm[k].Location = new Point(0, 0);
            plantPopUpForm[k].Size = new Size(1102, 698);
            plantPopUpForm[k].MaximumSize = new Size(1102, 698);
            plantPopUpForm[k].FormBorderStyle = FormBorderStyle.None;
            plantPopUpForm[k].BackgroundImageLayout = ImageLayout.Tile;
            plantPopUpForm[k].BackColor = Color.White;
            plantPopUpForm[k].Name = "plantPopUpForm" + k.ToString();
            plantPopUpForm[k].Text = tablo.Rows[k]["SANTRAL ADI"].ToString() + "  ID:" + tablo.Rows[k]["SANTRAL ID"].ToString();
            plantPopUpForm[k].MouseDown += new System.Windows.Forms.MouseEventHandler(plantPopUpForm_MouseDown);
            plantPopUpForm[k].MouseMove += new System.Windows.Forms.MouseEventHandler(plantPopUpForm_MouseMove);
            plantPopUpForm[k].MouseUp += new System.Windows.Forms.MouseEventHandler(plantPopUpForm_MouseUp);

            plantPopUpLogoPictureBox[k] = new PictureBox();
            plantPopUpLogoPictureBox[k].BackColor = System.Drawing.Color.Transparent;
            plantPopUpLogoPictureBox[k].ImageLocation = (string)pictureArrayListPOPUP[0];
            plantPopUpLogoPictureBox[k].Location = new System.Drawing.Point(12, 17);
            plantPopUpLogoPictureBox[k].Size = new System.Drawing.Size(58, 58);
            plantPopUpLogoPictureBox[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            plantPopUpForm[k].Controls.Add(plantPopUpLogoPictureBox[k]);
            plantPopUpLogoPictureBox[k].BringToFront();

            popUpFormExitButton[k] = new Button();
            popUpFormExitButton[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
            popUpFormExitButton[k].BackgroundImage = global::MedicalGasPlantAutomation.Properties.Resources.exit;
            popUpFormExitButton[k].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            popUpFormExitButton[k].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            popUpFormExitButton[k].ForeColor = System.Drawing.Color.FromArgb(3, 88, 145);
            popUpFormExitButton[k].Location = new System.Drawing.Point(1059, 8);
            popUpFormExitButton[k].Size = new System.Drawing.Size(35, 35);
            popUpFormExitButton[k].UseVisualStyleBackColor = false;
            popUpFormExitButton[k].Name = "popUpFormExitButton" + k.ToString();
            plantPopUpForm[k].Controls.Add(popUpFormExitButton[k]);
            popUpFormExitButton[k].BringToFront();
            popUpFormExitButton[k].Click += new System.EventHandler(popUpFormExitButton_Click);

            popUpFormMinimizeButton[k] = new Button();
            popUpFormMinimizeButton[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
            popUpFormMinimizeButton[k].BackgroundImage = global::MedicalGasPlantAutomation.Properties.Resources.minimize;
            popUpFormMinimizeButton[k].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            popUpFormMinimizeButton[k].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            popUpFormMinimizeButton[k].ForeColor = System.Drawing.Color.FromArgb(3, 88, 145);
            popUpFormMinimizeButton[k].Location = new System.Drawing.Point(1018, 8);
            popUpFormMinimizeButton[k].Size = new System.Drawing.Size(35, 35);
            popUpFormMinimizeButton[k].UseVisualStyleBackColor = false;
            popUpFormMinimizeButton[k].Name = "popUpFormMinimizeButton" + k.ToString(); 
            plantPopUpForm[k].Controls.Add(popUpFormMinimizeButton[k]);
            popUpFormMinimizeButton[k].BringToFront();
            popUpFormMinimizeButton[k].Click += new System.EventHandler(popUpFormMinimizeButton_Click);

        
            popUpPlantNameLabel[k] = new Label();
            popUpPlantNameLabel[k].BackColor = System.Drawing.Color.Transparent;
            popUpPlantNameLabel[k].Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            popUpPlantNameLabel[k].ForeColor = System.Drawing.Color.White;
            popUpPlantNameLabel[k].Location = new System.Drawing.Point(116, 39);
            popUpPlantNameLabel[k].Size = new System.Drawing.Size(400, 19);
            popUpPlantNameLabel[k].Text = tablo.Rows[k]["SANTRAL ADI"].ToString() + "  ID:" + tablo.Rows[k]["SANTRAL ID"].ToString(); 
            popUpPlantNameLabel[k].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            plantPopUpForm[k].Controls.Add(popUpPlantNameLabel[k]);
            popUpPlantNameLabel[k].BringToFront();
            plantType[k] = Convert.ToInt32(tablo.Rows[k]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR
            pumpCount[k] = Convert.ToInt32(tablo.Rows[k]["POMPA SAYISI"]);

            switch (plantType[k])
            {
                case 1:
                    language = Convert.ToInt32(tablo.Rows[0]["DIL"]);
                    #region O2
                    plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpOxygenNormal.jpg");
                    popUpLeftBankPressLabelO2[k] = new Label();
                    popUpLeftBankPressLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftBankPressLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLeftBankPressLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLeftBankPressLabelO2[k].Location = new System.Drawing.Point(208, 246);
                    popUpLeftBankPressLabelO2[k].Size = new System.Drawing.Size(100, 47);
                    popUpLeftBankPressLabelO2[k].Text = "-";
                    popUpLeftBankPressLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLeftBankPressLabelO2[k]);
                    popUpLeftBankPressLabelO2[k].BringToFront();

                    popUpRightBankPressLabelO2[k] = new Label();
                    popUpRightBankPressLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightBankPressLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpRightBankPressLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpRightBankPressLabelO2[k].Location = new System.Drawing.Point(570, 249);
                    popUpRightBankPressLabelO2[k].Size = new System.Drawing.Size(100, 47);
                    popUpRightBankPressLabelO2[k].Text = "-";
                    popUpRightBankPressLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpRightBankPressLabelO2[k]);
                    popUpRightBankPressLabelO2[k].BringToFront();

                    popUpLeftInDutyLabelO2[k] = new Label();
                    popUpLeftInDutyLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftInDutyLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLeftInDutyLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLeftInDutyLabelO2[k].Location = new System.Drawing.Point(96, 342);
                    popUpLeftInDutyLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpLeftInDutyLabelO2[k].Text = "AKTİF";
                    if (language == 1) popUpLeftInDutyLabelO2[k].Text = "IN DUTY";
                    if(language == 2) popUpLeftInDutyLabelO2[k].Text = "İn Betrieb";
                    popUpLeftInDutyLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLeftInDutyLabelO2[k]);
                    popUpLeftInDutyLabelO2[k].BringToFront();

                    popUpRightInDutyLabelO2[k] = new Label();
                    popUpRightInDutyLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightInDutyLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpRightInDutyLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpRightInDutyLabelO2[k].Location = new System.Drawing.Point(676, 342);
                    popUpRightInDutyLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpRightInDutyLabelO2[k].Text = "AKTİF";
                    if (language == 1) popUpRightInDutyLabelO2[k].Text = "IN DUTY";
                    if (language == 2) popUpRightInDutyLabelO2[k].Text = "İn Betrieb";
                    popUpRightInDutyLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpRightInDutyLabelO2[k]);
                    popUpRightInDutyLabelO2[k].BringToFront();

                    popUpLeftChangeCylindersLabelO2[k] = new Label();
                    popUpLeftChangeCylindersLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftChangeCylindersLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLeftChangeCylindersLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLeftChangeCylindersLabelO2[k].Location = new System.Drawing.Point(97, 396);
                    popUpLeftChangeCylindersLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpLeftChangeCylindersLabelO2[k].Text = "TÜPLERİ DEĞİŞTİR";
                    if (language == 1) popUpLeftChangeCylindersLabelO2[k].Text = "CHANGE CYLINDERS";
                    if (language == 2) popUpLeftChangeCylindersLabelO2[k].Text = "Gasflaschen Wechseln";
                    popUpLeftChangeCylindersLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLeftChangeCylindersLabelO2[k]);
                    popUpLeftChangeCylindersLabelO2[k].BringToFront();

                    popUpRightChangeCylindersLabelO2[k] = new Label();
                    popUpRightChangeCylindersLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightChangeCylindersLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpRightChangeCylindersLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpRightChangeCylindersLabelO2[k].Location = new System.Drawing.Point(677, 396);
                    popUpRightChangeCylindersLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpRightChangeCylindersLabelO2[k].Text = "TÜPLERİ DEĞİŞTİR";
                    if (language == 1) popUpRightChangeCylindersLabelO2[k].Text = "CHANGE CYLINDERS";
                    if (language == 2) popUpRightChangeCylindersLabelO2[k].Text = "Gasflaschen Wechseln";
                    popUpRightChangeCylindersLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpRightChangeCylindersLabelO2[k]);
                    popUpRightChangeCylindersLabelO2[k].BringToFront();

                    popUpLeftReserveLowLabelO2[k] = new Label();
                    popUpLeftReserveLowLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftReserveLowLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLeftReserveLowLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLeftReserveLowLabelO2[k].Location = new System.Drawing.Point(95, 451);
                    popUpLeftReserveLowLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpLeftReserveLowLabelO2[k].Text = "DÜŞÜK RESERV";
                    if (language == 1) popUpLeftReserveLowLabelO2[k].Text = "RESERVE LOW";
                    if (language == 2) popUpLeftReserveLowLabelO2[k].Text = "Geringer Reservestand";
                    popUpLeftReserveLowLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLeftReserveLowLabelO2[k]);
                    popUpLeftReserveLowLabelO2[k].BringToFront();

                    popUpRightReserveLowLabelO2[k] = new Label();
                    popUpRightReserveLowLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightReserveLowLabelO2[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpRightReserveLowLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpRightReserveLowLabelO2[k].Location = new System.Drawing.Point(675, 451);
                    popUpRightReserveLowLabelO2[k].Size = new System.Drawing.Size(100, 37);
                    if (language == 0) popUpRightReserveLowLabelO2[k].Text = "DÜŞÜK RESERV";
                    if (language == 1) popUpRightReserveLowLabelO2[k].Text = "RESERVE LOW";
                    if (language == 2) popUpRightReserveLowLabelO2[k].Text = "Geringer Reservestand";
                    popUpRightReserveLowLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpRightReserveLowLabelO2[k]);
                    popUpRightReserveLowLabelO2[k].BringToFront();

                    popUpLeftChangeCylindersImmLabelO2[k] = new Label();
                    popUpLeftChangeCylindersImmLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftChangeCylindersImmLabelO2[k].Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLeftChangeCylindersImmLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLeftChangeCylindersImmLabelO2[k].Location = new System.Drawing.Point(88, 504);
                    popUpLeftChangeCylindersImmLabelO2[k].Size = new System.Drawing.Size(120, 40);
                    if (language == 0) popUpLeftChangeCylindersImmLabelO2[k].Text = "TÜPLERİ ACİL DEĞİŞTİR";
                    if (language == 1) popUpLeftChangeCylindersImmLabelO2[k].Text = "CHANGE CYLINDER IMMEDIATELY";
                    if (language == 2) popUpLeftChangeCylindersImmLabelO2[k].Text = "Sofort Gasflaschen";
                    popUpLeftChangeCylindersImmLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLeftChangeCylindersImmLabelO2[k]);
                    popUpLeftChangeCylindersImmLabelO2[k].BringToFront();

                    popUpRightChangeCylindersImmLabelO2[k] = new Label();
                    popUpRightChangeCylindersImmLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightChangeCylindersImmLabelO2[k].Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpRightChangeCylindersImmLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpRightChangeCylindersImmLabelO2[k].Location = new System.Drawing.Point(667, 504);
                    popUpRightChangeCylindersImmLabelO2[k].Size = new System.Drawing.Size(120, 40);
                    if (language == 0) popUpRightChangeCylindersImmLabelO2[k].Text = "TÜPLERİ ACİL DEĞİŞTİR";
                    if (language == 1) popUpRightChangeCylindersImmLabelO2[k].Text = "CHANGE CYLINDER IMMEDIATELY";
                    if (language == 2) popUpRightChangeCylindersImmLabelO2[k].Text = "Sofort Gasflaschen";
                    popUpRightChangeCylindersImmLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpRightChangeCylindersImmLabelO2[k]);
                    popUpRightChangeCylindersImmLabelO2[k].BringToFront();

                    popUpLinePressLabelO2[k] = new Label();
                    popUpLinePressLabelO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLinePressLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLinePressLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLinePressLabelO2[k].Location = new System.Drawing.Point(662, 128);
                    popUpLinePressLabelO2[k].Size = new System.Drawing.Size(169, 56);
                    popUpLinePressLabelO2[k].Text = "-";
                    popUpLinePressLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLinePressLabelO2[k]);
                    popUpLinePressLabelO2[k].BringToFront();

                    popUpPlantFaultLabelO2[k] = new Label();
                    popUpPlantFaultLabelO2[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantFaultLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantFaultLabelO2[k].ForeColor = System.Drawing.Color.White;   
                    popUpPlantFaultLabelO2[k].Location = new System.Drawing.Point(878, 292);
                    popUpPlantFaultLabelO2[k].Size = new System.Drawing.Size(177, 62);
                    if (language == 0) popUpPlantFaultLabelO2[k].Text = "SİSTEM HATASI";
                    if (language == 1) popUpPlantFaultLabelO2[k].Text = "PLANT FAULT";
                    if (language == 2) popUpPlantFaultLabelO2[k].Text = "BETRİEBS-STÖRUNG";
                    popUpPlantFaultLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantFaultLabelO2[k]);
                    popUpPlantFaultLabelO2[k].BringToFront();

                    popUpChangeLabelO2[k] = new Label();
                    popUpChangeLabelO2[k].BackColor = System.Drawing.Color.Red;
                    popUpChangeLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpChangeLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpChangeLabelO2[k].Location = new System.Drawing.Point(340, 100);
                    popUpChangeLabelO2[k].Size = new System.Drawing.Size(200, 100);
                    if (language == 0) popUpChangeLabelO2[k].Text = "SİLİNDİRLERİ ACİL DEĞİŞTİR";
                    if (language == 1) popUpChangeLabelO2[k].Text = "CHANGE CYLINDER IMMEDIATELY";
                    if (language == 2) popUpChangeLabelO2[k].Text = "Sofort Gasflaschen Wechseln";
                    popUpChangeLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpChangeLabelO2[k]);
                    popUpChangeLabelO2[k].BringToFront();

                    popUpHighPressureLabelO2[k] = new Label();
                    popUpHighPressureLabelO2[k].BackColor = System.Drawing.Color.Red;
                    popUpHighPressureLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpHighPressureLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpHighPressureLabelO2[k].Location = new System.Drawing.Point(878, 372);
                    popUpHighPressureLabelO2[k].Size = new System.Drawing.Size(177, 62);
                    if (language == 0) popUpHighPressureLabelO2[k].Text = "YÜKSEK BASINÇ";
                    if (language == 1) popUpHighPressureLabelO2[k].Text = "HIGH PRESSURE";
                    if (language == 2) popUpHighPressureLabelO2[k].Text = "HOCHDRUCK";
                    popUpHighPressureLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpHighPressureLabelO2[k]);
                    popUpHighPressureLabelO2[k].BringToFront();

                    popUpPressureFaultLabelO2[k] = new Label();
                    popUpPressureFaultLabelO2[k].BackColor = System.Drawing.Color.Red;
                    popUpPressureFaultLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPressureFaultLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpPressureFaultLabelO2[k].Location = new System.Drawing.Point(878, 452);
                    popUpPressureFaultLabelO2[k].Size = new System.Drawing.Size(177, 62);
                    if (language == 0) popUpPressureFaultLabelO2[k].Text = "BASINÇ HATASI";
                    if (language == 1) popUpPressureFaultLabelO2[k].Text = "PRESSURE FAULT";
                    if (language == 2) popUpPressureFaultLabelO2[k].Text = "DRUCKSTÖRUNG";
                    popUpPressureFaultLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPressureFaultLabelO2[k]);
                    popUpPressureFaultLabelO2[k].BringToFront();

                    popUpLowPressureLabelO2[k] = new Label();
                    popUpLowPressureLabelO2[k].BackColor = System.Drawing.Color.Red;
                    popUpLowPressureLabelO2[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLowPressureLabelO2[k].ForeColor = System.Drawing.Color.White;
                    popUpLowPressureLabelO2[k].Location = new System.Drawing.Point(878, 531);
                    popUpLowPressureLabelO2[k].Size = new System.Drawing.Size(177, 62);
                    if (language == 0) popUpLowPressureLabelO2[k].Text = "DÜŞÜK BASINÇ";
                    if (language == 1) popUpLowPressureLabelO2[k].Text = "LOW PRESSURE";
                    if (language == 2) popUpLowPressureLabelO2[k].Text = "NİEDERDRUCK";
                    popUpLowPressureLabelO2[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLowPressureLabelO2[k]);
                    popUpLowPressureLabelO2[k].BringToFront();

                    popUpLeftBankPictureBoxO2[k] = new PictureBox();
                    popUpLeftBankPictureBoxO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLeftBankPictureBoxO2[k].Image = Image.FromFile(Application.StartupPath + "/BankFull.png");
                    popUpLeftBankPictureBoxO2[k].Location = new System.Drawing.Point(215, 304);
                    popUpLeftBankPictureBoxO2[k].Name = "popUpLeftBankPictureBoxO2";
                    popUpLeftBankPictureBoxO2[k].Size = new System.Drawing.Size(85, 361);
                    popUpLeftBankPictureBoxO2[k].TabIndex = 2;
                    popUpLeftBankPictureBoxO2[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpLeftBankPictureBoxO2[k]);
                    popUpLeftBankPictureBoxO2[k].BringToFront();

                    popUpRightBankPictureBoxO2[k] = new PictureBox();
                    popUpRightBankPictureBoxO2[k].BackColor = System.Drawing.Color.Transparent;
                    popUpRightBankPictureBoxO2[k].Image = Image.FromFile(Application.StartupPath + "/BankFull.png");
                    popUpRightBankPictureBoxO2[k].Location = new System.Drawing.Point(577, 304);
                    popUpRightBankPictureBoxO2[k].Name = "popUpRightBankPictureBoxO2";
                    popUpRightBankPictureBoxO2[k].Size = new System.Drawing.Size(85, 361);
                    popUpRightBankPictureBoxO2[k].TabIndex = 2;
                    popUpRightBankPictureBoxO2[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpRightBankPictureBoxO2[k]);
                    popUpRightBankPictureBoxO2[k].BringToFront();
                    break;
                #endregion
                case 2:
                    #region VAC
                    
                    switch (pumpCount[k])
                    {
                        case 2:

                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopupVacuum2Pumps.jpg");
                            break;
                        case 3:

                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopupVacuum3Pumps.jpg");
                            break;
                        case 4:

                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopupVacuum4Pumps.jpg");
                            break;
                    }

                    popUpTankPressLabelVAC[k] = new Label();
                    popUpTankPressLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpTankPressLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpTankPressLabelVAC[k].ForeColor = System.Drawing.Color.Black;
                    popUpTankPressLabelVAC[k].Location = new System.Drawing.Point(36, 215);
                    popUpTankPressLabelVAC[k].Size = new System.Drawing.Size(110, 55);
                    popUpTankPressLabelVAC[k].Text = "-";
                    popUpTankPressLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpTankPressLabelVAC[k]);
                    popUpTankPressLabelVAC[k].BringToFront();

                    popUpLinePressLabelVAC[k] = new Label();
                    popUpLinePressLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLinePressLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLinePressLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpLinePressLabelVAC[k].Location = new System.Drawing.Point(606, 162);
                    popUpLinePressLabelVAC[k].Size = new System.Drawing.Size(182, 55);
                    popUpLinePressLabelVAC[k].Text = "-";
                    popUpLinePressLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLinePressLabelVAC[k]);
                    popUpLinePressLabelVAC[k].BringToFront();

                    popUpPlantEmergencyLabelVAC[k] = new Label();
                    popUpPlantEmergencyLabelVAC[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantEmergencyLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantEmergencyLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantEmergencyLabelVAC[k].Location = new System.Drawing.Point(621, 297);
                    popUpPlantEmergencyLabelVAC[k].Name = "plantEmergencyVAC";
                    popUpPlantEmergencyLabelVAC[k].Size = new System.Drawing.Size(177, 62);
                    popUpPlantEmergencyLabelVAC[k].TabIndex = 1;
                    if (language == 0) popUpPlantEmergencyLabelVAC[k].Text = "ACİL DURUM UYARISI";
                    if (language == 1) popUpPlantEmergencyLabelVAC[k].Text = "PLANT EMERGENCY";
                    if (language == 2) popUpPlantEmergencyLabelVAC[k].Text = "NOTFALL İM SYSTEM";
                    popUpPlantEmergencyLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantEmergencyLabelVAC[k]);
                    popUpPlantEmergencyLabelVAC[k].BringToFront();

                    popUpLinePressFaultLabelVAC[k] = new Label();
                    popUpLinePressFaultLabelVAC[k].BackColor = System.Drawing.Color.Red;
                    popUpLinePressFaultLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLinePressFaultLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpLinePressFaultLabelVAC[k].Location = new System.Drawing.Point(621, 375);
                    popUpLinePressFaultLabelVAC[k].Name = "linePressFaultVAC";
                    popUpLinePressFaultLabelVAC[k].Size = new System.Drawing.Size(177, 62);
                    popUpLinePressFaultLabelVAC[k].TabIndex = 1;
                    if (language == 0) popUpLinePressFaultLabelVAC[k].Text = "HAT BASINÇ HATASI";
                    if (language == 1) popUpLinePressFaultLabelVAC[k].Text = "LINE PRESSURE FAULT"; 
                    if (language == 2) popUpLinePressFaultLabelVAC[k].Text = "LEİTUNGSDRUCK-FEHLER"; 
                    popUpLinePressFaultLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLinePressFaultLabelVAC[k]);
                    popUpLinePressFaultLabelVAC[k].BringToFront();

                    popUpPlantFaultLabelVAC[k] = new Label();
                    popUpPlantFaultLabelVAC[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantFaultLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantFaultLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantFaultLabelVAC[k].Location = new System.Drawing.Point(818, 297);
                    popUpPlantFaultLabelVAC[k].Name = "plantFaultVAC";
                    popUpPlantFaultLabelVAC[k].Size = new System.Drawing.Size(177, 62);
                    popUpPlantFaultLabelVAC[k].TabIndex = 1;
                    if (language == 0) popUpPlantFaultLabelVAC[k].Text = "SİSTEM HATASI";
                    if (language == 1) popUpPlantFaultLabelVAC[k].Text = "PLANT FAULT";
                    if (language == 2) popUpPlantFaultLabelVAC[k].Text = "BETRİEBSSTÖRUNG";
                    popUpPlantFaultLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantFaultLabelVAC[k]);
                    popUpPlantFaultLabelVAC[k].BringToFront();

                    popUpFilterFaultLabelVAC[k] = new Label();
                    popUpFilterFaultLabelVAC[k].BackColor = System.Drawing.Color.Red;
                    popUpFilterFaultLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpFilterFaultLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpFilterFaultLabelVAC[k].Location = new System.Drawing.Point(818, 375);
                    popUpFilterFaultLabelVAC[k].Name = "filterFaultVAC";
                    popUpFilterFaultLabelVAC[k].Size = new System.Drawing.Size(177, 62);
                    popUpFilterFaultLabelVAC[k].TabIndex = 1;
                    if (language == 0) popUpFilterFaultLabelVAC[k].Text = "FİLTRE HATASI";
                    if (language == 1) popUpFilterFaultLabelVAC[k].Text = "FILTER FAULT";
                    if (language == 2) popUpFilterFaultLabelVAC[k].Text = "FİLTER WECHSELN";
                    popUpFilterFaultLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpFilterFaultLabelVAC[k]);
                    popUpFilterFaultLabelVAC[k].BringToFront();

                    popUpPump1StateLabelVAC[k] = new Label();
                    popUpPump1StateLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump1StateLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPump1StateLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpPump1StateLabelVAC[k].Location = new System.Drawing.Point(118, 618);
                    popUpPump1StateLabelVAC[k].Name = "popUpPump1StateLabelVAC";
                    popUpPump1StateLabelVAC[k].Size = new System.Drawing.Size(167, 38);
                    popUpPump1StateLabelVAC[k].TabIndex = 1;
                    popUpPump1StateLabelVAC[k].Text = "-";
                    popUpPump1StateLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPump1StateLabelVAC[k]);
                    popUpPump1StateLabelVAC[k].BringToFront();

                    popUpPump2StateLabelVAC[k] = new Label();
                    popUpPump2StateLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump2StateLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPump2StateLabelVAC[k].ForeColor = System.Drawing.Color.White;
                    popUpPump2StateLabelVAC[k].Location = new System.Drawing.Point(355, 618);
                    popUpPump2StateLabelVAC[k].Name = "popUpPump2StateLabelVAC";
                    popUpPump2StateLabelVAC[k].Size = new System.Drawing.Size(167, 38);
                    popUpPump2StateLabelVAC[k].TabIndex = 1;
                    popUpPump2StateLabelVAC[k].Text = "-";
                    popUpPump2StateLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPump2StateLabelVAC[k]);
                    popUpPump2StateLabelVAC[k].BringToFront();

                    popUpPump1StatePictureBoxVAC[k] = new PictureBox();
                    popUpPump1StatePictureBoxVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump1StatePictureBoxVAC[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                    popUpPump1StatePictureBoxVAC[k].Location = new System.Drawing.Point(115, 496);
                    popUpPump1StatePictureBoxVAC[k].Name = "popUpPump1StatePictureBoxVAC";
                    popUpPump1StatePictureBoxVAC[k].Size = new System.Drawing.Size(170, 110);
                    popUpPump1StatePictureBoxVAC[k].TabIndex = 2;
                    popUpPump1StatePictureBoxVAC[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    popUpPump1StatePictureBoxVAC[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpPump1StatePictureBoxVAC[k]);
                    popUpPump1StatePictureBoxVAC[k].BringToFront();

                    popUpPump2StatePictureBoxVAC[k] = new PictureBox();
                    popUpPump2StatePictureBoxVAC[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump2StatePictureBoxVAC[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                    popUpPump2StatePictureBoxVAC[k].Location = new System.Drawing.Point(352, 496);
                    popUpPump2StatePictureBoxVAC[k].Name = "popUpPump2StatePictureBoxVAC";
                    popUpPump2StatePictureBoxVAC[k].Size = new System.Drawing.Size(170, 110);
                    popUpPump2StatePictureBoxVAC[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    popUpPump2StatePictureBoxVAC[k].TabIndex = 2;
                    popUpPump2StatePictureBoxVAC[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpPump2StatePictureBoxVAC[k]);
                    popUpPump2StatePictureBoxVAC[k].BringToFront();

                    if (pumpCount[k] > 2)
                    {
                        popUpPump3StateLabelVAC[k] = new Label();
                        popUpPump3StateLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump3StateLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        popUpPump3StateLabelVAC[k].ForeColor = System.Drawing.Color.White;
                        popUpPump3StateLabelVAC[k].Location = new System.Drawing.Point(586, 618);
                        popUpPump3StateLabelVAC[k].Name = "popUpPump3StateLabelVAC";
                        popUpPump3StateLabelVAC[k].Size = new System.Drawing.Size(167, 38);
                        popUpPump3StateLabelVAC[k].TabIndex = 1;
                        popUpPump3StateLabelVAC[k].Text = "-";
                        popUpPump3StateLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPopUpForm[k].Controls.Add(popUpPump3StateLabelVAC[k]);
                        popUpPump3StateLabelVAC[k].BringToFront();


                        popUpPump3StatePictureBoxVAC[k] = new PictureBox();
                        popUpPump3StatePictureBoxVAC[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump3StatePictureBoxVAC[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                        popUpPump3StatePictureBoxVAC[k].Location = new System.Drawing.Point(584, 496);
                        popUpPump3StatePictureBoxVAC[k].Name = "popUpPump3StatePictureBoxVAC";
                        popUpPump3StatePictureBoxVAC[k].Size = new System.Drawing.Size(170, 110);
                        popUpPump3StatePictureBoxVAC[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        popUpPump3StatePictureBoxVAC[k].TabIndex = 2;
                        popUpPump3StatePictureBoxVAC[k].TabStop = false;
                        plantPopUpForm[k].Controls.Add(popUpPump3StatePictureBoxVAC[k]);
                        popUpPump3StatePictureBoxVAC[k].BringToFront();
                    }
                    if (pumpCount[k] > 3)
                    {
                        popUpPump4StateLabelVAC[k] = new Label();
                        popUpPump4StateLabelVAC[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump4StateLabelVAC[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        popUpPump4StateLabelVAC[k].ForeColor = System.Drawing.Color.White;
                        popUpPump4StateLabelVAC[k].Location = new System.Drawing.Point(817, 618);
                        popUpPump4StateLabelVAC[k].Name = "popUpPump4StateLabelVAC";
                        popUpPump4StateLabelVAC[k].Size = new System.Drawing.Size(167, 38);
                        popUpPump4StateLabelVAC[k].TabIndex = 1;
                        popUpPump4StateLabelVAC[k].Text = "-";
                        popUpPump4StateLabelVAC[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPopUpForm[k].Controls.Add(popUpPump4StateLabelVAC[k]);
                        popUpPump4StateLabelVAC[k].BringToFront();

                        popUpPump4StatePictureBoxVAC[k] = new PictureBox();
                        popUpPump4StatePictureBoxVAC[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump4StatePictureBoxVAC[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump.png");
                        popUpPump4StatePictureBoxVAC[k].Location = new System.Drawing.Point(810, 496);
                        popUpPump4StatePictureBoxVAC[k].Name = "popUpPump4StatePictureBoxVAC";
                        popUpPump4StatePictureBoxVAC[k].Size = new System.Drawing.Size(170, 110);
                        popUpPump4StatePictureBoxVAC[k].TabIndex = 2;
                        popUpPump4StatePictureBoxVAC[k].TabStop = false;
                        popUpPump4StatePictureBoxVAC[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        plantPopUpForm[k].Controls.Add(popUpPump4StatePictureBoxVAC[k]);
                        popUpPump4StatePictureBoxVAC[k].BringToFront();
                    }

                    #endregion
                    break;
                case 3:
                    
                    #region AIR  
                    switch (pumpCount[k])
                    {
                        case 2:
                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpAir2Comp.jpg");
                            break;
                        case 3:
                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpAir3Comp.jpg");
                            break;
                        case 4:
                            plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/PopUpAir4Comp.jpg");
                            break;
                    }

                    popUpDewPointLabelAIR[k] = new Label();
                    popUpDewPointLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpDewPointLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpDewPointLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpDewPointLabelAIR[k].Location = new System.Drawing.Point(415, 122);
                    popUpDewPointLabelAIR[k].Name = "popUpDewPointLabelAIR";
                    popUpDewPointLabelAIR[k].Size = new System.Drawing.Size(118, 45);
                    popUpDewPointLabelAIR[k].TabIndex = 0;
                    popUpDewPointLabelAIR[k].Text = "-";
                    popUpDewPointLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpDewPointLabelAIR[k]);
                    popUpDewPointLabelAIR[k].BringToFront();

                    popUpLinePressLabelAIR[k] = new Label();
                    popUpLinePressLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLinePressLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLinePressLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpLinePressLabelAIR[k].Location = new System.Drawing.Point(653, 122);
                    popUpLinePressLabelAIR[k].Name = "popUpLinePressLabelAIR";
                    popUpLinePressLabelAIR[k].Size = new System.Drawing.Size(118, 45);
                    popUpLinePressLabelAIR[k].TabIndex = 0;
                    popUpLinePressLabelAIR[k].Text = "-";
                    popUpLinePressLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLinePressLabelAIR[k]);
                    popUpLinePressLabelAIR[k].BringToFront();

                    popUpTankPressLabelAIR[k] = new Label();
                    popUpTankPressLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpTankPressLabelAIR[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpTankPressLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpTankPressLabelAIR[k].Location = new System.Drawing.Point(60, 312);
                    popUpTankPressLabelAIR[k].Name = "popUpTankPressLabelAIR";
                    popUpTankPressLabelAIR[k].Size = new System.Drawing.Size(78, 45);
                    popUpTankPressLabelAIR[k].TabIndex = 0;
                    popUpTankPressLabelAIR[k].Text = "-";
                    popUpTankPressLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpTankPressLabelAIR[k]);
                    popUpTankPressLabelAIR[k].BringToFront();

                    popUpDewPointFaultLabelAIR[k] = new Label();
                    popUpDewPointFaultLabelAIR[k].BackColor = System.Drawing.Color.Red;
                    popUpDewPointFaultLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpDewPointFaultLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpDewPointFaultLabelAIR[k].Location = new System.Drawing.Point(873, 238);
                    popUpDewPointFaultLabelAIR[k].Name = "popUpDewPointFaultLabelAIR";
                    popUpDewPointFaultLabelAIR[k].Size = new System.Drawing.Size(177, 62);
                    popUpDewPointFaultLabelAIR[k].TabIndex = 3;
                    if (language == 0) popUpDewPointFaultLabelAIR[k].Text = "DEWPOİNT HATASI";
                    if (language == 1) popUpDewPointFaultLabelAIR[k].Text = "DEWPOINT FAULT";
                    if (language == 2) popUpDewPointFaultLabelAIR[k].Text = "DRUCKTAUPUNKT";
                    popUpDewPointFaultLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpDewPointFaultLabelAIR[k]);
                    popUpDewPointFaultLabelAIR[k].BringToFront();

                    popUpPlantEmergencyLabelAIR[k] = new Label();
                    popUpPlantEmergencyLabelAIR[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantEmergencyLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantEmergencyLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantEmergencyLabelAIR[k].Location = new System.Drawing.Point(873, 312);
                    popUpPlantEmergencyLabelAIR[k].Name = "popUpPlantEmergencyLabelAIR";
                    popUpPlantEmergencyLabelAIR[k].Size = new System.Drawing.Size(177, 62);
                    popUpPlantEmergencyLabelAIR[k].TabIndex = 3;
                    if (language == 0) popUpPlantEmergencyLabelAIR[k].Text = "ACİL DURUM UYARISI";
                    if (language == 1) popUpPlantEmergencyLabelAIR[k].Text = "PLANT EMERGENCY";
                    if (language == 2) popUpPlantEmergencyLabelAIR[k].Text = "NOTTFAL İM SYSTEM";
                    popUpPlantEmergencyLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantEmergencyLabelAIR[k]);
                    popUpPlantEmergencyLabelAIR[k].BringToFront();

                    popUpLinePressFaultLabelAIR[k] = new Label();
                    popUpLinePressFaultLabelAIR[k].BackColor = System.Drawing.Color.Red;
                    popUpLinePressFaultLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLinePressFaultLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpLinePressFaultLabelAIR[k].Location = new System.Drawing.Point(873, 389);
                    popUpLinePressFaultLabelAIR[k].Name = "popUpLinePressFaultLabelAIR";
                    popUpLinePressFaultLabelAIR[k].Size = new System.Drawing.Size(177, 62);
                    popUpLinePressFaultLabelAIR[k].TabIndex = 3;
                    if (language == 0) popUpLinePressFaultLabelAIR[k].Text = "HAT BASINÇ HATASI";
                    if (language == 1) popUpLinePressFaultLabelAIR[k].Text = "LINE PRESSURE FAULT";
                    if (language == 2) popUpLinePressFaultLabelAIR[k].Text = "LEİTUNGSDRUCKFEHLER";
                    popUpLinePressFaultLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLinePressFaultLabelAIR[k]);
                    popUpLinePressFaultLabelAIR[k].BringToFront();

                    popUpPlantFaultLabelAIR[k] = new Label();
                    popUpPlantFaultLabelAIR[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantFaultLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantFaultLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantFaultLabelAIR[k].Location = new System.Drawing.Point(873, 464);
                    popUpPlantFaultLabelAIR[k].Name = "popUpPlantEmergencyLabelAIR";
                    popUpPlantFaultLabelAIR[k].Size = new System.Drawing.Size(177, 62);
                    popUpPlantFaultLabelAIR[k].TabIndex = 3;
                    if (language == 0) popUpPlantFaultLabelAIR[k].Text = "SİSTEM HATASI";
                    if (language == 1) popUpPlantFaultLabelAIR[k].Text = "PLANT FAULT";
                    if(language == 2) popUpPlantFaultLabelAIR[k].Text = "BETRİEBSTÖRUNG";
                    popUpPlantFaultLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantFaultLabelAIR[k]);
                    popUpPlantFaultLabelAIR[k].BringToFront();

                    popUpPump1StateLabelAIR[k] = new Label();
                    popUpPump1StateLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump1StateLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
                    popUpPump1StateLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpPump1StateLabelAIR[k].Location = new System.Drawing.Point(128, 628);
                    popUpPump1StateLabelAIR[k].Name = "popUpPump1StateLabelAIR";
                    popUpPump1StateLabelAIR[k].Size = new System.Drawing.Size(130, 40);
                    popUpPump1StateLabelAIR[k].TabIndex = 0;
                    popUpPump1StateLabelAIR[k].Text = "-";
                    popUpPump1StateLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPump1StateLabelAIR[k]);
                    popUpPump1StateLabelAIR[k].BringToFront();

                    popUpPump2StateLabelAIR[k] = new Label();
                    popUpPump2StateLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPump2StateLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
                    popUpPump2StateLabelAIR[k].ForeColor = System.Drawing.Color.White;
                    popUpPump2StateLabelAIR[k].Location = new System.Drawing.Point(331, 628);
                    popUpPump2StateLabelAIR[k].Name = "popUpPump2StateLabelAIR";
                    popUpPump2StateLabelAIR[k].Size = new System.Drawing.Size(130, 40);
                    popUpPump2StateLabelAIR[k].TabIndex = 0;
                    popUpPump2StateLabelAIR[k].Text = "-";
                    popUpPump2StateLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPump2StateLabelAIR[k]);
                    popUpPump2StateLabelAIR[k].BringToFront();

                    popUpPump1StatePictureBoxAIR[k] = new PictureBox();
                    popUpPump1StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                    popUpPump1StatePictureBoxAIR[k].Location = new System.Drawing.Point(151, 505);
                    popUpPump1StatePictureBoxAIR[k].Name = "popUpPump1StatePictureBoxAIR";
                    popUpPump1StatePictureBoxAIR[k].Size = new System.Drawing.Size(90, 115);
                    popUpPump1StatePictureBoxAIR[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    popUpPump1StatePictureBoxAIR[k].TabIndex = 1;
                    popUpPump1StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpPump1StatePictureBoxAIR[k]);
                    popUpPump1StatePictureBoxAIR[k].BringToFront();

                    popUpPump2StatePictureBoxAIR[k] = new PictureBox();
                    popUpPump2StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                    popUpPump2StatePictureBoxAIR[k].Location = new System.Drawing.Point(354, 505);
                    popUpPump2StatePictureBoxAIR[k].Name = "popUpPump2StatePictureBoxAIR";
                    popUpPump2StatePictureBoxAIR[k].Size = new System.Drawing.Size(90, 115);
                    popUpPump2StatePictureBoxAIR[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    popUpPump2StatePictureBoxAIR[k].TabIndex = 1;
                    popUpPump2StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpPump2StatePictureBoxAIR[k]);
                    popUpPump2StatePictureBoxAIR[k].BringToFront();

                    if (pumpCount[k] > 2)
                    {
                        popUpPump3StateLabelAIR[k] = new Label();
                        popUpPump3StateLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump3StateLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
                        popUpPump3StateLabelAIR[k].ForeColor = System.Drawing.Color.White;
                        popUpPump3StateLabelAIR[k].Location = new System.Drawing.Point(536, 628);
                        popUpPump3StateLabelAIR[k].Name = "popUpPump3StateLabelAIR";
                        popUpPump3StateLabelAIR[k].Size = new System.Drawing.Size(130, 40);
                        popUpPump3StateLabelAIR[k].TabIndex = 0;
                        popUpPump3StateLabelAIR[k].Text = "-";
                        popUpPump3StateLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPopUpForm[k].Controls.Add(popUpPump3StateLabelAIR[k]);
                        popUpPump3StateLabelAIR[k].BringToFront();

                        popUpPump3StatePictureBoxAIR[k] = new PictureBox();
                        popUpPump3StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                        popUpPump3StatePictureBoxAIR[k].Location = new System.Drawing.Point(556, 505);
                        popUpPump3StatePictureBoxAIR[k].Name = "popUpPump3StatePictureBoxAIR";
                        popUpPump3StatePictureBoxAIR[k].Size = new System.Drawing.Size(90, 115);
                        popUpPump3StatePictureBoxAIR[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        popUpPump3StatePictureBoxAIR[k].TabIndex = 1;
                        popUpPump3StatePictureBoxAIR[k].TabStop = false;
                        plantPopUpForm[k].Controls.Add(popUpPump3StatePictureBoxAIR[k]);
                        popUpPump3StatePictureBoxAIR[k].BringToFront();
                    }
                    if (pumpCount[k] > 3)
                    {
                        popUpPump4StateLabelAIR[k] = new Label();
                        popUpPump4StateLabelAIR[k].BackColor = System.Drawing.Color.Transparent;
                        popUpPump4StateLabelAIR[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
                        popUpPump4StateLabelAIR[k].ForeColor = System.Drawing.Color.White;
                        popUpPump4StateLabelAIR[k].Location = new System.Drawing.Point(740, 628);
                        popUpPump4StateLabelAIR[k].Name = "popUpPump4StateLabelAIR";
                        popUpPump4StateLabelAIR[k].Size = new System.Drawing.Size(130, 40);
                        popUpPump4StateLabelAIR[k].TabIndex = 0;
                        popUpPump4StateLabelAIR[k].Text = "-";
                        popUpPump4StateLabelAIR[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        plantPopUpForm[k].Controls.Add(popUpPump4StateLabelAIR[k]);
                        popUpPump4StateLabelAIR[k].BringToFront();

                        popUpPump4StatePictureBoxAIR[k] = new PictureBox();
                        popUpPump4StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/CompPassive.png");
                        popUpPump4StatePictureBoxAIR[k].Location = new System.Drawing.Point(758, 505);
                        popUpPump4StatePictureBoxAIR[k].Name = "popUpPump4StatePictureBoxAIR";
                        popUpPump4StatePictureBoxAIR[k].Size = new System.Drawing.Size(90, 115);
                        popUpPump4StatePictureBoxAIR[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        popUpPump4StatePictureBoxAIR[k].TabIndex = 1;
                        popUpPump4StatePictureBoxAIR[k].TabStop = false;
                        plantPopUpForm[k].Controls.Add(popUpPump4StatePictureBoxAIR[k]);
                        popUpPump4StatePictureBoxAIR[k].BringToFront();
                    }

                    popUpDryer1StatePictureBoxAIR[k] = new PictureBox();
                    popUpDryer1StatePictureBoxAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpDryer1StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png"); 
                    popUpDryer1StatePictureBoxAIR[k].Location = new System.Drawing.Point(273, 237);
                    popUpDryer1StatePictureBoxAIR[k].Name = "popUpDryer1StatePictureBoxAIR";
                    popUpDryer1StatePictureBoxAIR[k].Size = new System.Drawing.Size(32, 134);
                    popUpDryer1StatePictureBoxAIR[k].TabIndex = 1;
                    popUpDryer1StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpDryer1StatePictureBoxAIR[k]);
                    popUpDryer1StatePictureBoxAIR[k].BringToFront();

                    popUpDryer2StatePictureBoxAIR[k] = new PictureBox();
                    popUpDryer2StatePictureBoxAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpDryer2StatePictureBoxAIR[k].Image = Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                    popUpDryer2StatePictureBoxAIR[k].Location = new System.Drawing.Point(392, 237);
                    popUpDryer2StatePictureBoxAIR[k].Name = "popUpDryer2StatePictureBoxAIR";
                    popUpDryer2StatePictureBoxAIR[k].Size = new System.Drawing.Size(32, 134);
                    popUpDryer2StatePictureBoxAIR[k].TabIndex = 1;
                    popUpDryer2StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpDryer2StatePictureBoxAIR[k]);
                    popUpDryer2StatePictureBoxAIR[k].BringToFront();

                    popUpDryer3StatePictureBoxAIR[k] = new PictureBox();
                    popUpDryer3StatePictureBoxAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpDryer3StatePictureBoxAIR[k].Image =  Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                    popUpDryer3StatePictureBoxAIR[k].Location = new System.Drawing.Point(542, 237);
                    popUpDryer3StatePictureBoxAIR[k].Name = "popUpDryer3StatePictureBoxAIR";
                    popUpDryer3StatePictureBoxAIR[k].Size = new System.Drawing.Size(32, 134);
                    popUpDryer3StatePictureBoxAIR[k].TabIndex = 1;
                    popUpDryer3StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpDryer3StatePictureBoxAIR[k]);
                    popUpDryer3StatePictureBoxAIR[k].BringToFront();

                    popUpDryer4StatePictureBoxAIR[k] = new PictureBox();
                    popUpDryer4StatePictureBoxAIR[k].BackColor = System.Drawing.Color.Transparent;
                    popUpDryer4StatePictureBoxAIR[k].Image =  Image.FromFile(Application.StartupPath + "/DryerPassive.png");
                    popUpDryer4StatePictureBoxAIR[k].Location = new System.Drawing.Point(662, 237);
                    popUpDryer4StatePictureBoxAIR[k].Name = "popUpDryer4StatePictureBoxAIR";
                    popUpDryer4StatePictureBoxAIR[k].Size = new System.Drawing.Size(32, 134);
                    popUpDryer4StatePictureBoxAIR[k].TabIndex = 1;
                    popUpDryer4StatePictureBoxAIR[k].TabStop = false;
                    plantPopUpForm[k].Controls.Add(popUpDryer4StatePictureBoxAIR[k]);
                    popUpDryer4StatePictureBoxAIR[k].BringToFront();
                    #endregion
                    break;
                case 4:
                    #region LİKİT
                    plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/likidNormal.jpg");
                    popUpLevelFaultLabelLKD[k] = new Label();
                    popUpLevelFaultLabelLKD[k].BackColor = System.Drawing.Color.Red;
                    popUpLevelFaultLabelLKD[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLevelFaultLabelLKD[k].ForeColor = System.Drawing.Color.White;
                    popUpLevelFaultLabelLKD[k].Location = new System.Drawing.Point(785, 338);
                    popUpLevelFaultLabelLKD[k].Name = "popUpLevelFaultLabelLKD";
                    popUpLevelFaultLabelLKD[k].Size = new System.Drawing.Size(177, 62);
                    popUpLevelFaultLabelLKD[k].TabIndex = 3;
                    if (language == 0) popUpLevelFaultLabelLKD[k].Text = "DÜŞÜK LİKİT SEVİYESİ";
                    if (language == 1) popUpLevelFaultLabelLKD[k].Text = "LOW LIQUID LEVEL";
                    if(language == 2) popUpLevelFaultLabelLKD[k].Text = "NIEDRIGER FLÜSSIGKEITSSTAND";
                    popUpLevelFaultLabelLKD[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLevelFaultLabelLKD[k]);
                    popUpLevelFaultLabelLKD[k].BringToFront();

                    popUpLevelLabelLKD[k] = new Label();
                    popUpLevelLabelLKD[k].BackColor = System.Drawing.Color.Transparent;
                    popUpLevelLabelLKD[k].Font = new System.Drawing.Font("Arial", 36.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpLevelLabelLKD[k].ForeColor = System.Drawing.Color.White;
                    popUpLevelLabelLKD[k].Location = new System.Drawing.Point(50, 280);
                    popUpLevelLabelLKD[k].Name = "popUpLevelLabelLKD";
                    popUpLevelLabelLKD[k].Size = new System.Drawing.Size(167, 167);
                    popUpLevelLabelLKD[k].TabIndex = 1;
                    popUpLevelLabelLKD[k].Text = "% - ";
                    popUpLevelLabelLKD[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpLevelLabelLKD[k]);
                    popUpLevelLabelLKD[k].BringToFront();

                    popUpPumpTankPictureBoxLKD[k] = new PictureBox();
                    popUpPumpTankPictureBoxLKD[k].Image = Image.FromFile(Application.StartupPath + "/%100.png");
                    popUpPumpTankPictureBoxLKD[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPumpTankPictureBoxLKD[k].Location = new System.Drawing.Point(194, 160);
                    popUpPumpTankPictureBoxLKD[k].Name = "popUpPumpTankPictureBoxAIR";
                    popUpPumpTankPictureBoxLKD[k].Size = new System.Drawing.Size(600, 426);
                    popUpPumpTankPictureBoxLKD[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    popUpPumpTankPictureBoxLKD[k].TabIndex = 1;
                    popUpPumpTankPictureBoxLKD[k].TabStop = false;  
                    plantPopUpForm[k].Controls.Add(popUpPumpTankPictureBoxLKD[k]);
                    popUpPumpTankPictureBoxLKD[k].BringToFront();
                    #endregion
                    break;

                case 5:
                    #region AGSS

                    plantPopUpForm[k].BackgroundImage = Image.FromFile(Application.StartupPath + "/agss_normal.jpg");

                    popUpvakumPressLabelAGSS[k] = new Label();
                    popUpvakumPressLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpvakumPressLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpvakumPressLabelAGSS[k].ForeColor = System.Drawing.Color.Black;
                    popUpvakumPressLabelAGSS[k].Location = new System.Drawing.Point(848, 620);
                    popUpvakumPressLabelAGSS[k].Size = new System.Drawing.Size(110, 55);
                    popUpvakumPressLabelAGSS[k].Text = "-";
                    popUpvakumPressLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpvakumPressLabelAGSS[k]);
                    popUpvakumPressLabelAGSS[k].BringToFront();

                    popUpPlantEmergencyLabelAGSS[k] = new Label();
                    popUpPlantEmergencyLabelAGSS[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantEmergencyLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantEmergencyLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantEmergencyLabelAGSS[k].Location = new System.Drawing.Point(710, 225);
                    popUpPlantEmergencyLabelAGSS[k].Name = "faultPlantEmergencyAGSS";
                    popUpPlantEmergencyLabelAGSS[k].Size = new System.Drawing.Size(167, 62);
                    //popUpPlantEmergencyLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpPlantEmergencyLabelAGSS[k].Text = "ACİL DURUM UYARISI";
                    if (language == 1) popUpPlantEmergencyLabelAGSS[k].Text = "PLANT EMERGENCY";
                    if (language == 2) popUpPlantEmergencyLabelAGSS[k].Text = "NOTFALL İM SYSTEM";
                    popUpPlantEmergencyLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantEmergencyLabelAGSS[k]);
                    popUpPlantEmergencyLabelAGSS[k].BringToFront();

                    popUpairflowLabelAGSS[k] = new Label();
                    popUpairflowLabelAGSS[k].BackColor = System.Drawing.Color.Green;
                    popUpairflowLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpairflowLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpairflowLabelAGSS[k].Location = new System.Drawing.Point(710, 125);
                    popUpairflowLabelAGSS[k].Name = "airflowAGSS";
                    popUpairflowLabelAGSS[k].Size = new System.Drawing.Size(167, 62);
                    //popUpairflowLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpairflowLabelAGSS[k].Text = "HAVA AKIŞI";
                    if (language == 1) popUpairflowLabelAGSS[k].Text = "AIR FLOW";
                    if (language == 2) popUpairflowLabelAGSS[k].Text = "LUFTMENGE";
                    popUpairflowLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpairflowLabelAGSS[k]);
                    popUpairflowLabelAGSS[k].BringToFront();

                    popUpPlantFaultLabelAGSS[k] = new Label();
                    popUpPlantFaultLabelAGSS[k].BackColor = System.Drawing.Color.Red;
                    popUpPlantFaultLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPlantFaultLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpPlantFaultLabelAGSS[k].Location = new System.Drawing.Point(710, 325);
                    popUpPlantFaultLabelAGSS[k].Name = "faultPlantAGSS";
                    popUpPlantFaultLabelAGSS[k].Size = new System.Drawing.Size(167, 62);
                    //popUpPlantFaultLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpPlantFaultLabelAGSS[k].Text = "SİSTEM HATASI";
                    if (language == 1) popUpPlantFaultLabelAGSS[k].Text = "PLANT FAULT";
                    if (language == 2) popUpPlantFaultLabelAGSS[k].Text = "BETRİEBSSTÖRUNG";
                    popUpPlantFaultLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPlantFaultLabelAGSS[k]);
                    popUpPlantFaultLabelAGSS[k].BringToFront();

                    popUppump1CutinAGSSLabelAGSS[k] = new Label();
                    popUppump1CutinAGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUppump1CutinAGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUppump1CutinAGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUppump1CutinAGSSLabelAGSS[k].Location = new System.Drawing.Point(716, 551);
                    popUppump1CutinAGSSLabelAGSS[k].Name = "pump1CutinAGSS";
                    popUppump1CutinAGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUppump1CutinAGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUppump1CutinAGSSLabelAGSS[k].Text = "ÇALIŞIYOR";
                    if (language == 1) popUppump1CutinAGSSLabelAGSS[k].Text = "CUT IN";
                    if (language == 2) popUppump1CutinAGSSLabelAGSS[k].Text = "EINSCHALTEN";
                    popUppump1CutinAGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUppump1CutinAGSSLabelAGSS[k]);
                    popUppump1CutinAGSSLabelAGSS[k].BringToFront();

                    popUppump2CutinAGSSLabelAGSS[k] = new Label();
                    popUppump2CutinAGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUppump2CutinAGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUppump2CutinAGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUppump2CutinAGSSLabelAGSS[k].Location = new System.Drawing.Point(920, 551);
                    popUppump2CutinAGSSLabelAGSS[k].Name = "pump2CutinAGSS";
                    popUppump2CutinAGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUppump2CutinAGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUppump2CutinAGSSLabelAGSS[k].Text = "ÇALIŞIYOR";
                    if (language == 1) popUppump2CutinAGSSLabelAGSS[k].Text = "CUT IN";
                    if (language == 2) popUppump2CutinAGSSLabelAGSS[k].Text = "EINSCHALTEN";
                    popUppump2CutinAGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUppump2CutinAGSSLabelAGSS[k]);
                    popUppump2CutinAGSSLabelAGSS[k].BringToFront();

                    popUppump1CutOutAGSSLabelAGSS[k] = new Label();
                    popUppump1CutOutAGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUppump1CutOutAGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUppump1CutOutAGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUppump1CutOutAGSSLabelAGSS[k].Location = new System.Drawing.Point(716, 551);
                    popUppump1CutOutAGSSLabelAGSS[k].Name = "pump1CutOutAGSS";
                    popUppump1CutOutAGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUppump1CutOutAGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUppump1CutOutAGSSLabelAGSS[k].Text = "DURUYOR";
                    if (language == 1) popUppump1CutOutAGSSLabelAGSS[k].Text = "CUT OUT";
                    if (language == 2) popUppump1CutOutAGSSLabelAGSS[k].Text = "AUSSCHALTEN";
                    popUppump1CutOutAGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUppump1CutOutAGSSLabelAGSS[k]);
                    popUppump1CutOutAGSSLabelAGSS[k].BringToFront();

                    popUppump2CutOutAGSSLabelAGSS[k] = new Label();
                    popUppump2CutOutAGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUppump2CutOutAGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUppump2CutOutAGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUppump2CutOutAGSSLabelAGSS[k].Location = new System.Drawing.Point(920, 551);
                    popUppump2CutOutAGSSLabelAGSS[k].Name = "pump2CutOutAGSS";
                    popUppump2CutOutAGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUppump2CutOutAGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUppump2CutOutAGSSLabelAGSS[k].Text = "DURUYOR";
                    if (language == 1) popUppump2CutOutAGSSLabelAGSS[k].Text = "CUT OUT";
                    if (language == 2) popUppump2CutOutAGSSLabelAGSS[k].Text = "AUSSCHALTEN";
                    popUppump2CutOutAGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUppump2CutOutAGSSLabelAGSS[k]);
                    popUppump2CutOutAGSSLabelAGSS[k].BringToFront();
                    
                    popUpcontactFault1AGSSLabelAGSS[k] = new Label();
                    popUpcontactFault1AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpcontactFault1AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpcontactFault1AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpcontactFault1AGSSLabelAGSS[k].Location = new System.Drawing.Point(716, 551);
                    popUpcontactFault1AGSSLabelAGSS[k].Name = "contactFault1AGSS";
                    popUpcontactFault1AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpcontactFault1AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpcontactFault1AGSSLabelAGSS[k].Text = "KONTAKTÖR";
                    if (language == 1) popUpcontactFault1AGSSLabelAGSS[k].Text = "CONTACTOR";
                    if (language == 2) popUpcontactFault1AGSSLabelAGSS[k].Text = "SCHÜTZ";
                    popUpcontactFault1AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpcontactFault1AGSSLabelAGSS[k]);
                    popUpcontactFault1AGSSLabelAGSS[k].BringToFront();

                    popUpcontactFault2AGSSLabelAGSS[k] = new Label();
                    popUpcontactFault2AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpcontactFault2AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpcontactFault2AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpcontactFault2AGSSLabelAGSS[k].Location = new System.Drawing.Point(920, 551);
                    popUpcontactFault2AGSSLabelAGSS[k].Name = "contactFault2AGSS";
                    popUpcontactFault2AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpcontactFault2AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpcontactFault2AGSSLabelAGSS[k].Text = "KONTAKTÖR";
                    if (language == 1) popUpcontactFault2AGSSLabelAGSS[k].Text = "CONTACTOR";
                    if (language == 2) popUpcontactFault2AGSSLabelAGSS[k].Text = "SCHÜTZ";
                    popUpcontactFault2AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpcontactFault2AGSSLabelAGSS[k]);
                    popUpcontactFault2AGSSLabelAGSS[k].BringToFront();
                   
                    popUpthermicFault1AGSSLabelAGSS[k] = new Label();
                    popUpthermicFault1AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpthermicFault1AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpthermicFault1AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpthermicFault1AGSSLabelAGSS[k].Location = new System.Drawing.Point(716, 551);
                    popUpthermicFault1AGSSLabelAGSS[k].Name = "thermicFault1AGSS";
                    popUpthermicFault1AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpthermicFault1AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpthermicFault1AGSSLabelAGSS[k].Text = "TERMİK";
                    if (language == 1) popUpthermicFault1AGSSLabelAGSS[k].Text = "THERMIC";
                    if (language == 2) popUpthermicFault1AGSSLabelAGSS[k].Text = "THERMIK";
                    popUpthermicFault1AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpthermicFault1AGSSLabelAGSS[k]);
                    popUpthermicFault1AGSSLabelAGSS[k].BringToFront();

                    popUpthermicFault2AGSSLabelAGSS[k] = new Label();
                    popUpthermicFault2AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpthermicFault2AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpthermicFault2AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpthermicFault2AGSSLabelAGSS[k].Location = new System.Drawing.Point(920, 551);
                    popUpthermicFault2AGSSLabelAGSS[k].Name = "thermicFault2AGSS";
                    popUpthermicFault2AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpthermicFault2AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpthermicFault2AGSSLabelAGSS[k].Text = "TERMİK";
                    if (language == 1) popUpthermicFault2AGSSLabelAGSS[k].Text = "THERMIC";
                    if (language == 2) popUpthermicFault2AGSSLabelAGSS[k].Text = "THERMIK";
                    popUpthermicFault2AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpthermicFault2AGSSLabelAGSS[k]);
                    popUpthermicFault2AGSSLabelAGSS[k].BringToFront();

                    popUpPassive1AGSSLabelAGSS[k] = new Label();
                    popUpPassive1AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPassive1AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPassive1AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpPassive1AGSSLabelAGSS[k].Location = new System.Drawing.Point(716, 551);
                    popUpPassive1AGSSLabelAGSS[k].Name = "Passive1AGSS";
                    popUpPassive1AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpPassive1AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpPassive1AGSSLabelAGSS[k].Text = "PASİF";
                    if (language == 1) popUpPassive1AGSSLabelAGSS[k].Text = "PASSIVE";
                    if (language == 2) popUpPassive1AGSSLabelAGSS[k].Text = "PASSIV";
                    popUpPassive1AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPassive1AGSSLabelAGSS[k]);
                    popUpPassive1AGSSLabelAGSS[k].BringToFront();

                    popUpPassive2AGSSLabelAGSS[k] = new Label();
                    popUpPassive2AGSSLabelAGSS[k].BackColor = System.Drawing.Color.Transparent;
                    popUpPassive2AGSSLabelAGSS[k].Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    popUpPassive2AGSSLabelAGSS[k].ForeColor = System.Drawing.Color.White;
                    popUpPassive2AGSSLabelAGSS[k].Location = new System.Drawing.Point(920, 551);
                    popUpPassive2AGSSLabelAGSS[k].Name = "Passive2AGSS";
                    popUpPassive2AGSSLabelAGSS[k].Size = new System.Drawing.Size(167, 38);
                    //popUpPassive2AGSSLabelAGSS[k].TabIndex = 1;
                    if (language == 0) popUpPassive2AGSSLabelAGSS[k].Text = "PASİF";
                    if (language == 1) popUpPassive2AGSSLabelAGSS[k].Text = "PASSIVE";
                    if (language == 2) popUpPassive2AGSSLabelAGSS[k].Text = "PASSIV";
                    popUpPassive2AGSSLabelAGSS[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpPassive2AGSSLabelAGSS[k]);
                    popUpPassive2AGSSLabelAGSS[k].BringToFront();

                    ŞifreGirişi[k] = new Label();
                    ŞifreGirişi[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
                    ŞifreGirişi[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    ŞifreGirişi[k].ForeColor = System.Drawing.Color.White;
                    ŞifreGirişi[k].Location = new System.Drawing.Point(880, 50);
                    ŞifreGirişi[k].Name = "ŞifreGirişi";
                    ŞifreGirişi[k].Size = new System.Drawing.Size(167, 38);
                    ŞifreGirişi[k].Text = "Şifreyi Giriniz";
                    if (language == 0) ŞifreGirişi[k].Text = "Şifreyi Giriniz";
                    if (language == 1) ŞifreGirişi[k].Text = "Enter Password";
                    if (language == 2) ŞifreGirişi[k].Text = "Passwort Eingeben";
                    ŞifreGirişi[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(ŞifreGirişi[k]);
                    ŞifreGirişi[k].BringToFront();

                    for (int y = 1; y < 50; y++)
                    {
                        AGSSButtonTextBox[k,y] = new TextBox();
                        AGSSButtonTextBox[k,y].BackColor = System.Drawing.Color.FromArgb(77, 133, 170);
                        AGSSButtonTextBox[k,y].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                        AGSSButtonTextBox[k,y].BorderStyle = BorderStyle.None;

                        if(y <= 17) AGSSButtonTextBox[k, y].Location = new System.Drawing.Point(50, 100 + ((y-1) * 35));
                        else if (y <= 34) AGSSButtonTextBox[k, y].Location = new System.Drawing.Point(270, 100 + ((y-18) * 35));
                        else AGSSButtonTextBox[k, y].Location = new System.Drawing.Point(490, 100 + ((y - 35) * 35));

                      //  if (y == 16) AGSSButtonTextBox[k, y].Location = new System.Drawing.Point(270, 100 );
                        AGSSButtonTextBox[k,y].Name = "AGSSButtonTextBox";
                        AGSSButtonTextBox[k,y].Size = new System.Drawing.Size(167, 38);
                        AGSSButtonTextBox[k,y].BringToFront();
                        plantPopUpForm[k].Controls.Add(AGSSButtonTextBox[k,y]);
                        AGSSButtonTextBox[k,y].Enter += new System.EventHandler(AGSSButton1TextBox_Enter);
                    }


                    popUpPump1StatePictureBoxAGSS[k] = new PictureBox(); 
                           popUpPump1StatePictureBoxAGSS[k].BackColor = System.Drawing.Color.Transparent;
                           popUpPump1StatePictureBoxAGSS[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump_agss.png");
                           popUpPump1StatePictureBoxAGSS[k].Location = new System.Drawing.Point(713, 420);
                           popUpPump1StatePictureBoxAGSS[k].Name = "popUpPump1StatePictureBoxAGSS";
                           popUpPump1StatePictureBoxAGSS[k].Size = new System.Drawing.Size(170, 110);
                           popUpPump1StatePictureBoxAGSS[k].TabIndex = 2;
                           popUpPump1StatePictureBoxAGSS[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                           popUpPump1StatePictureBoxAGSS[k].TabStop = false;
                           plantPopUpForm[k].Controls.Add(popUpPump1StatePictureBoxAGSS[k]);
                           popUpPump1StatePictureBoxAGSS[k].BringToFront();

                           popUpPump2StatePictureBoxAGSS[k] = new PictureBox();
                           popUpPump2StatePictureBoxAGSS[k].BackColor = System.Drawing.Color.Transparent;
                           popUpPump2StatePictureBoxAGSS[k].Image = Image.FromFile(Application.StartupPath + "/PassivePump_agss.png");
                           popUpPump2StatePictureBoxAGSS[k].Location = new System.Drawing.Point(917, 420);
                           popUpPump2StatePictureBoxAGSS[k].Name = "popUpPump2StatePictureBoxAGSS";
                           popUpPump2StatePictureBoxAGSS[k].Size = new System.Drawing.Size(170, 110);
                           popUpPump2StatePictureBoxAGSS[k].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                           popUpPump2StatePictureBoxAGSS[k].TabIndex = 2;
                           popUpPump2StatePictureBoxAGSS[k].TabStop = false;
                           plantPopUpForm[k].Controls.Add(popUpPump2StatePictureBoxAGSS[k]);
                           popUpPump2StatePictureBoxAGSS[k].BringToFront();


                    popUpButtonKayıt[k] = new Button();
                    popUpButtonKayıt[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
                    //  popUpButtonKayıt[k].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    popUpButtonKayıt[k].ForeColor = System.Drawing.Color.White;
                    popUpButtonKayıt[k].Location = new System.Drawing.Point(745, 20);
                    popUpButtonKayıt[k].Size = new System.Drawing.Size(75, 35);
                    popUpButtonKayıt[k].UseVisualStyleBackColor = false;
                    popUpButtonKayıt[k].Name = "popUpButtonKayıt"+ k.ToString();
                    popUpButtonKayıt[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(popUpButtonKayıt[k]);
                    popUpButtonKayıt[k].BringToFront();
                    popUpButtonKayıt[k].Click += new System.EventHandler(popUpButtonKayıt_Click);
                    if (language == 0) popUpButtonKayıt[k].Text = "Kayıt Et";
                    else  if (language == 1) popUpButtonKayıt[k].Text = "Save";
                    else  if (language == 2) popUpButtonKayıt[k].Text = "Speichern";

                    ŞifreTextBox[k] = new TextBox();
                    ŞifreTextBox[k].BackColor = System.Drawing.Color.FromArgb(77, 133, 170);
                    ŞifreTextBox[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    ŞifreTextBox[k].Location = new System.Drawing.Point(700, 58);
                    ŞifreTextBox[k].Name = "ŞifreTextBox";
                    ŞifreTextBox[k].Size = new System.Drawing.Size(167, 38);
                    ŞifreTextBox[k].BringToFront();
                    plantPopUpForm[k].Controls.Add(ŞifreTextBox[k]);
                    ŞifreTextBox[k].Enter += new System.EventHandler(AGSSButton1TextBox_Enter);

                    ŞifreYanlış[k] = new Label();
                    ŞifreYanlış[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
                    ŞifreYanlış[k].Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    ŞifreYanlış[k].ForeColor = System.Drawing.Color.White;
                    ŞifreYanlış[k].Location = new System.Drawing.Point(880, 50);
                    ŞifreYanlış[k].Name = "ŞifreYanlış";
                    ŞifreYanlış[k].Size = new System.Drawing.Size(167, 38);
                    if (language == 0) ŞifreYanlış[k].Text = "Şifre Yanlış";
                    else if (language == 1) ŞifreYanlış[k].Text = "Wrong Password";
                    else if (language == 2) ŞifreYanlış[k].Text = "Falsches Passwort";
                    ŞifreYanlış[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    plantPopUpForm[k].Controls.Add(ŞifreYanlış[k]);
                    ŞifreYanlış[k].BringToFront();


                    /*        popUpButtonOku[k] = new Button();
                             popUpButtonOku[k].BackColor = System.Drawing.Color.FromArgb(3, 88, 145);
                             //  popUpButtonKayıt[k].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                             popUpButtonOku[k].ForeColor = System.Drawing.Color.FromArgb(3, 88, 145);
                             popUpButtonOku[k].Location = new System.Drawing.Point(400, 8);
                             popUpButtonOku[k].Size = new System.Drawing.Size(35, 35);
                             popUpButtonOku[k].UseVisualStyleBackColor = false;
                             popUpButtonOku[k].Name = "popUpButtonKayıt" + k.ToString();
                             popUpButtonOku[k].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                             plantPopUpForm[k].Controls.Add(popUpButtonOku[k]);
                             popUpButtonOku[k].BringToFront();
                             popUpButtonOku[k].Click += new System.EventHandler(popUpButtonOku_Click);  */

                    #endregion
                    break;
            }
        }

        #endregion

        #region Minimize Etmek İçin Şifre

        private void AGSSButton1TextBox_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");//ekran klavyesini başlatır.
            //Process.Start("osk.exe");
        }    
                    #endregion

        #region DİNAMİK METOTLAR

        private void popUpFormExitButton_Click(object sender, EventArgs e)
        {
            //e.Cancel = true;
            Button _popUpFormExitButton = (Button)sender;
            for (int k = 0; k < Class.Database.plantCount; k++)
            {                
                if (_popUpFormExitButton.Name == ("popUpFormExitButton" + k.ToString()))
                {
                    openPopUpCnt--;
                    openCloseCheck[k] = false;
                    plantPopUpForm[k].Hide();                    
                    return;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AlarmReport report = new AlarmReport();
            ReportPrintTool printTool = new ReportPrintTool(report);

            printTool.ShowPreviewDialog();

         //   printTool.Print();
        }

        private void popUpFormMinimizeButton_Click(object sender, EventArgs e)
        {
            Button _popUpFormMinimizeButton = (Button)sender;
            for (int k = 0; k < Class.Database.plantCount; k++)
            {
                if (_popUpFormMinimizeButton.Name == ("popUpFormMinimizeButton" + k.ToString()))
                {
                    plantPopUpForm[k].WindowState = FormWindowState.Minimized;
                    return;
                }
            }
        }
                

        private void popUpButtonKayıt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                plantType[i] = Convert.ToInt32(tablo.Rows[i]["SANTRAL TİPİ"]); //1:O2 2:VAC, 3:AIR
                tankNo[i] = Convert.ToInt32(tablo.Rows[i]["LİKİT TANK NO"]);
                if (plantType[i]==5)
                { 
                    Button _popUpButtonKayıt = (Button)sender;

                    if (ŞifreTextBox[i].Text == "3333")
                    {
                        StreamWriter yaz = new StreamWriter("C:/Plant Automation/AGSSB2.txt");
                        
                        if (tankNo[i] == 1) yaz = new StreamWriter("C:/Plant Automation/AGSS1.txt");
                        if (tankNo[i] == 2) yaz = new StreamWriter("C:/Plant Automation/AGSS2.txt");
                        if (tankNo[i] == 3) yaz = new StreamWriter("C:/Plant Automation/AGSS3.txt");
                        if (tankNo[i] == 4) yaz = new StreamWriter("C:/Plant Automation/AGSS4.txt");
                        if (tankNo[i] == 5) yaz = new StreamWriter("C:/Plant Automation/AGSS5.txt");
                        if (tankNo[i] == 6) yaz = new StreamWriter("C:/Plant Automation/AGSS6.txt");
                        if (tankNo[i] == 7) yaz = new StreamWriter("C:/Plant Automation/AGSS7.txt");
                        if (tankNo[i] == 8) yaz = new StreamWriter("C:/Plant Automation/AGSS8.txt");
                        if (tankNo[i] == 9) yaz = new StreamWriter("C:/Plant Automation/AGSS9.txt");
                        if (tankNo[i] == 10) yaz = new StreamWriter("C:/Plant Automation/AGSS10.txt");
                        if (tankNo[i] == 11) yaz = new StreamWriter("C:/Plant Automation/AGSS11.txt");
                        if (tankNo[i] == 12) yaz = new StreamWriter("C:/Plant Automation/AGSS12.txt");
                        if (tankNo[i] == 13) yaz = new StreamWriter("C:/Plant Automation/AGSS13.txt");
                        if (tankNo[i] == 14) yaz = new StreamWriter("C:/Plant Automation/AGSS14.txt");
                        if (tankNo[i] == 15) yaz = new StreamWriter("C:/Plant Automation/AGSS15.txt");

                        for (int y = 1; y < 50; y++)
                        {

                            ŞifreYanlış[i].Visible = false;
                            ŞifreGirişi[i].Visible = false;

                            yaz.WriteLine(AGSSButtonTextBox[i, y].Text);

                            ŞifreTextBox[i].Text = null;
                        }
                        yaz.Close();
                    }
                    else
                    {
                       ŞifreYanlış[i].Visible = true;
                    }
                }
            }
        }

        private void plantPopUpForm_MouseUp(object sender, MouseEventArgs e)
        {
            Form formUp = (Form)sender;
            for (int k = 0; k < Class.Database.plantCount; k++)
            {
                if (formUp.Name == ("plantPopUpForm" + k.ToString()))
                {
                    dragging = false;
                    popUpTimerCnt[k]=_alarmSayac;
                    return;
                }
            }
        }

        private void plantPopUpForm_MouseMove(object sender, MouseEventArgs e)
        {
            Form formMoved = (Form)sender;
            for (int k = 0; k < Class.Database.plantCount; k++)
            {
                if(formMoved.Name == ("plantPopUpForm" + k.ToString()))
                {
                    if (dragging)
                    {
                        plantPopUpForm[k].Left = e.X + plantPopUpForm[k].Left - (firstLocation.X);
                        plantPopUpForm[k].Top = e.Y + plantPopUpForm[k].Top - (firstLocation.Y);
                        //popUpTimerCnt[k] = _alarmSayac;
                    }
                    return;
                }
            }

        }

        private void plantPopUpForm_MouseDown(object sender, MouseEventArgs e)
        {
            Form formDown = (Form)sender;
            for(int k = 0; k < Class.Database.plantCount; k++)
            {
                if (formDown.Name == ("plantPopUpForm" + k.ToString()))
                {
                    dragging = true;
                    firstLocation = e.Location;
                    //popUpTimerCnt[k] = _alarmSayac;
                    return;
                }
            }               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                openPopUpCnt--;
                openCloseCheck[i] = false;
                plantPopUpForm[i].Hide();
            }
            language = 0;
            databaseyaz();
            this.Controls.Clear();
            this.InitializeComponent();
            MainForm_reload(this, null); 
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            language = 1;            
            databaseyaz();            
            this.Controls.Clear();
            
            this.InitializeComponent();            
            MainForm_reload(this,null);
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                openPopUpCnt--;
                openCloseCheck[i] = false;
                plantPopUpForm[i].Hide();
            }
        }

        private void plantTabControl_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            databasealarmyaz();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void logoMiniPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            language = 2;        
            databaseyaz();
            this.Controls.Clear();            
            this.InitializeComponent();
            MainForm_reload(this, null);
            for (int i = 0; i < Class.Database.plantCount; i++)
            {
                openPopUpCnt--;
                openCloseCheck[i] = false;
                plantPopUpForm[i].Hide();
            }

        }
        private void plantNameLabel_Click(object sender, EventArgs e)
        {
            Label _plantNameLabel = (Label)sender;
            for (int k = 0; k < Class.Database.plantCount; k++)
            {
                if (_plantNameLabel.Name == ("plantNameLabel" + k.ToString())) 
                {
                    if(openCloseCheck[k])
                    {
                        plantPopUpForm[k].WindowState = FormWindowState.Normal;
                        Application.OpenForms["plantPopUpForm" + k.ToString()].BringToFront();
                    }
                    else
                    {
                        if (openPopUpCnt < Class.Database.plantCount)
                       {
                            if (!openCloseCheck[k])
                            {
                                openCloseCheck[k] = true;
                                openPopUpCnt++;
                                plantPopUpForm[k].Show();
                                popUpTimerCnt[k] = _alarmSayac;
                            }
                            
                       }
                    }
                    return;
                }
            }
        }
        #endregion

    }
}
