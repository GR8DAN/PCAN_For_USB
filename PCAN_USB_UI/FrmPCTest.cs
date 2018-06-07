using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CAN.PC
{
    public partial class FrmPCTest : Form
    {
        PCAN_USB pCAN = new PCAN_USB(); //Layer between form and PEAK interface DLL
        
        #region Form functions
        public FrmPCTest()
        {
            InitializeComponent();
            pCAN.ControlForm = this;
            pCAN.Feedback = LstStatus;
            pCAN.ReceivedMessages = LstReceivedMessages;
        }
        //Configure UI on load
        private void FrmPCTest_Load(object sender, EventArgs e)
        {
            LstBaudRate.Items.AddRange(PCAN_USB.CANBaudRates);
            LstBaudRate.SelectedIndex=LstBaudRate.Items.IndexOf("500 kbit/s");
            //Start check for PCAN device
            TimerCheckForDevice.Enabled = true;
        }
        //Uninitialise connected PEAK PCAN USB device
        private void FrmPCTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Releases a current connected Peak CAN USB channel
            pCAN.Uninitialize();
        }
        #endregion

        #region Check for plugged in PCAN USB device
        static int ErrorCount = 10; //used to display and error prompt
        private void TimerCheckForDevice_Tick(object sender, EventArgs e)
        {
            TimerCheckForDevice.Enabled = false;
            List<string> PeakUSBDevices = pCAN.GetUSBDevices();
            if (PeakUSBDevices != null)
                LstDevices.Items.AddRange(PeakUSBDevices.ToArray());
            else
            {
                //display an error message every 10 counts
                //int remainder = ErrorCount % 10;
                if ((ErrorCount++ % 10) == 0)
                {
                    AddMessage(LstStatus,"Plug in a PEAK PCAN USB Adapter");
                }
                TimerCheckForDevice.Enabled = true;
            }
        }
        #endregion

        #region CAN Id display - converting between decimal and hex
        bool bChanging; //Set true when a field is changing (interfield conversion)
        //If decimal id changes update hex version
        private void TxtId_TextChanged(object sender, EventArgs e)
        {
            uint number;

            if (!bChanging && (TxtId.Text.Trim().Length > 0))
            {
                bChanging = true;
                try
                {
                    number = uint.Parse(TxtId.Text);
                    TxtIdHex.Text = number.ToString("X");
                }
                catch (Exception)
                {
                    TxtIdHex.Text = String.Empty;
                }
                bChanging = false;
            }
            else if (TxtId.Text.Trim().Length == 0)
            {
                bChanging = true;
                TxtIdHex.Text = String.Empty;
                bChanging = false;
            }
        }
        //If hex id changes update decimal version
        private void TxtIdHex_TextChanged(object sender, EventArgs e)
        {
            if (!bChanging && TxtIdHex.Text.Trim().Length > 0)
            {
                bChanging = true;
                try
                {
                    uint fromHex = uint.Parse(TxtIdHex.Text, System.Globalization.NumberStyles.HexNumber);
                    TxtId.Text = fromHex.ToString();
                }
                catch (Exception)
                {
                    TxtId.Text = String.Empty;
                }
                bChanging = false;
            }
            else if (TxtIdHex.Text.Trim().Length == 0)
            {
                bChanging = true;
                TxtId.Text = String.Empty;
                bChanging = false;
            }
        }
        #endregion

        #region UI routines
        //Selecting PEAK USB device
        private void LstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Close any open channels
            pCAN.Uninitialize();
            //If a peak device is selected allow baud rate selection and start button
            UInt16 handle = 0;
            if (LstDevices.SelectedIndex > -1)
                handle = pCAN.DecodePEAKHandle(LstDevices.Items[LstDevices.SelectedIndex].ToString());
            if (handle > 0)
            {
                GrpInitialize.Enabled = true;
            }
            else
            {
                GrpInitialize.Enabled = false;
            }
        }
        //Start or Stop the selected device
        private void ButStartStop_Click(object sender, EventArgs e)
        {
            UInt16 handle = 0;  //PCAN handles are ushorts
            if (ButStartStop.Text == "Start")
            {
                if (LstDevices.SelectedIndex > -1)
                    handle = pCAN.DecodePEAKHandle(LstDevices.Items[LstDevices.SelectedIndex].ToString());
                if(handle > 0)
                {
                    pCAN.PeakCANHandle = handle;
                    pCAN.InitializeCAN(pCAN.PeakCANHandle, LstBaudRate.Items[LstBaudRate.SelectedIndex].ToString(), true);
                    GrpMessage.Enabled = true;
                    GrpReading.Enabled = true;
                    ChkTrace.Enabled = true;
                    ButStartStop.Text = "Stop";
                }
                else
                {
                    AddMessage(LstStatus,"No device selected");
                }
            }
            else
            {
                pCAN.Uninitialize();
                GrpMessage.Enabled = false;
                ButClear.Enabled = true;
                ChkTrace.Enabled = false;
                ButStartStop.Text = "Start";
            }
        }
        //Send the defined CAN data
        private void ButSend_Click(object sender, EventArgs e)
        {
            byte[] data = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            for (int i=0; i<(int)NudLength.Value; i++)
            {
                if(!Byte.TryParse(((TextBox)GrpMessage.Controls.Find("TxtData" + i.ToString(), true)[0]).Text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out data[i]))
                    AddMessage(LstStatus,"Error converting data to send:"+ ((TextBox)GrpMessage.Controls.Find("TxtData" + i.ToString(), true)[0]).Text);
            }
            UInt32 id = UInt32.MaxValue;
            if(UInt32.TryParse(TxtId.Text, out id))
            {
                pCAN.WriteFrame(id, (int)NudLength.Value, data);
            }
            else
            {
                AddMessage(LstStatus,"Error converting message id:" + TxtId.Text);
            }
        }
        //Clear the displayed packets
        private void ButClear_Click(object sender, EventArgs e)
        {
            pCAN.Packets = new List<PCAN_USB.Packet>();
            LstReceivedMessages.Items.Clear();
        }
        #endregion

        private void NudLength_ValueChanged(object sender, EventArgs e)
        {
            if (NudLength.Value > 7)
                TxtData7.Enabled = true;
            else
                TxtData7.Enabled = false;
            if (NudLength.Value > 6)
                TxtData6.Enabled = true;
            else
                TxtData6.Enabled = false;
            if (NudLength.Value > 5)
                TxtData5.Enabled = true;
            else
                TxtData5.Enabled = false;
            if (NudLength.Value > 4)
                TxtData4.Enabled = true;
            else
                TxtData4.Enabled = false;
            if (NudLength.Value > 3)
                TxtData3.Enabled = true;
            else
                TxtData3.Enabled = false;
            if (NudLength.Value > 2)
                TxtData2.Enabled = true;
            else
                TxtData2.Enabled = false;
            if (NudLength.Value > 1)
                TxtData1.Enabled = true;
            else
                TxtData1.Enabled = false;
            if (NudLength.Value > 0)
                TxtData0.Enabled = true;
            else
                TxtData0.Enabled = false;
        }

        private void ChkOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            pCAN.OverwriteLastPacket = ChkOverwrite.Checked;
            LstReceivedMessages.Items.Clear();
        }

        #region Logging

        private void ChkTrace_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTrace.Checked)
            {
                GrpTrace.Enabled = true;
            }
            else
            {
                pCAN.StopLogging();
                GrpTrace.Enabled = false;
            }
        }

        private void ButLogging_Click(object sender, EventArgs e)
        {
            if (ChkTrace.Checked && (ButLogging.Text == "Start"))
            {
                if (pCAN.StartLogging(TxtTraceDir.Text, ChkMultiFile.Checked, ChkDateFiles.Checked, (UInt32)NudTraceSize.Value))
                {
                    AddMessage(LstStatus, "Logging started.");
                    ButLogging.Text = "Stop";
                }
                else
                {
                    AddMessage(LstStatus, "Failed to start logging.");
                }
            }
            else
            {
                if (!pCAN.StopLogging())
                {
                    AddMessage(LstStatus, "Logging stopped.");
                }
                ButLogging.Text = "Start";
            }
        }
        #endregion

        #region Utils
        private int AddMessage(ListBox AddTo, string MessageToAdd)
        {
            int ret = -1;

            if (AddTo != null)
            {
                //Limit number of items
                if (AddTo.Items.Count >= 60000)
                    AddTo.Items.RemoveAt(0);
                ret = AddTo.Items.Add(MessageToAdd);
                //ensure new item is visible
                AddTo.TopIndex = AddTo.Items.Count - 1;
                return ret;
            }

            return ret;
        }
        #endregion

        private void ButChooseFile_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select a folder for the trace file";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TxtTraceDir.Text = dlg.SelectedPath;
                }
            }
        }
    }
}
