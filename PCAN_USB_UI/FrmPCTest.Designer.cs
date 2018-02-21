namespace CAN.PC
{
    partial class FrmPCTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPCTest));
            this.LstDevices = new System.Windows.Forms.ListBox();
            this.GrpInitialize = new System.Windows.Forms.GroupBox();
            this.ChkTrace = new System.Windows.Forms.CheckBox();
            this.LstBaudRate = new System.Windows.Forms.ListBox();
            this.ButStartStop = new System.Windows.Forms.Button();
            this.LblBaudRate = new System.Windows.Forms.Label();
            this.LstStatus = new System.Windows.Forms.ListBox();
            this.TxtData7 = new System.Windows.Forms.TextBox();
            this.TxtData6 = new System.Windows.Forms.TextBox();
            this.TxtData5 = new System.Windows.Forms.TextBox();
            this.TxtData4 = new System.Windows.Forms.TextBox();
            this.TxtData3 = new System.Windows.Forms.TextBox();
            this.TxtData2 = new System.Windows.Forms.TextBox();
            this.TxtData1 = new System.Windows.Forms.TextBox();
            this.TxtData0 = new System.Windows.Forms.TextBox();
            this.NudLength = new System.Windows.Forms.NumericUpDown();
            this.LblNumBytes = new System.Windows.Forms.Label();
            this.TxtIdHex = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.LblCANId = new System.Windows.Forms.Label();
            this.ButSend = new System.Windows.Forms.Button();
            this.GrpMessage = new System.Windows.Forms.GroupBox();
            this.LblStatus = new System.Windows.Forms.Label();
            this.GrpReading = new System.Windows.Forms.GroupBox();
            this.ChkOverwrite = new System.Windows.Forms.CheckBox();
            this.LstReceivedMessages = new System.Windows.Forms.ListBox();
            this.ButClear = new System.Windows.Forms.Button();
            this.TimerCheckForDevice = new System.Windows.Forms.Timer(this.components);
            this.LblListOfDevices = new System.Windows.Forms.Label();
            this.GrpTrace = new System.Windows.Forms.GroupBox();
            this.LblMaxSize = new System.Windows.Forms.Label();
            this.NudTraceSize = new System.Windows.Forms.NumericUpDown();
            this.ChkDateFiles = new System.Windows.Forms.CheckBox();
            this.ChkMultiFile = new System.Windows.Forms.CheckBox();
            this.TxtTraceDir = new System.Windows.Forms.TextBox();
            this.LblTraceDir = new System.Windows.Forms.Label();
            this.ButChooseFile = new System.Windows.Forms.Button();
            this.ButLogging = new System.Windows.Forms.Button();
            this.GrpInitialize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLength)).BeginInit();
            this.GrpMessage.SuspendLayout();
            this.GrpReading.SuspendLayout();
            this.GrpTrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTraceSize)).BeginInit();
            this.SuspendLayout();
            // 
            // LstDevices
            // 
            this.LstDevices.FormattingEnabled = true;
            this.LstDevices.Location = new System.Drawing.Point(8, 23);
            this.LstDevices.Margin = new System.Windows.Forms.Padding(2);
            this.LstDevices.Name = "LstDevices";
            this.LstDevices.Size = new System.Drawing.Size(153, 95);
            this.LstDevices.TabIndex = 2;
            this.LstDevices.SelectedIndexChanged += new System.EventHandler(this.LstDevices_SelectedIndexChanged);
            // 
            // GrpInitialize
            // 
            this.GrpInitialize.Controls.Add(this.ChkTrace);
            this.GrpInitialize.Controls.Add(this.LstBaudRate);
            this.GrpInitialize.Controls.Add(this.ButStartStop);
            this.GrpInitialize.Controls.Add(this.LblBaudRate);
            this.GrpInitialize.Enabled = false;
            this.GrpInitialize.Location = new System.Drawing.Point(165, 9);
            this.GrpInitialize.Name = "GrpInitialize";
            this.GrpInitialize.Size = new System.Drawing.Size(163, 112);
            this.GrpInitialize.TabIndex = 3;
            this.GrpInitialize.TabStop = false;
            this.GrpInitialize.Text = "Initialize";
            // 
            // ChkTrace
            // 
            this.ChkTrace.AutoSize = true;
            this.ChkTrace.Enabled = false;
            this.ChkTrace.Location = new System.Drawing.Point(107, 65);
            this.ChkTrace.Name = "ChkTrace";
            this.ChkTrace.Size = new System.Drawing.Size(54, 17);
            this.ChkTrace.TabIndex = 28;
            this.ChkTrace.Text = "Trace";
            this.ChkTrace.UseVisualStyleBackColor = true;
            this.ChkTrace.CheckedChanged += new System.EventHandler(this.ChkTrace_CheckedChanged);
            // 
            // LstBaudRate
            // 
            this.LstBaudRate.FormattingEnabled = true;
            this.LstBaudRate.Location = new System.Drawing.Point(5, 39);
            this.LstBaudRate.Name = "LstBaudRate";
            this.LstBaudRate.Size = new System.Drawing.Size(97, 69);
            this.LstBaudRate.TabIndex = 5;
            // 
            // ButStartStop
            // 
            this.ButStartStop.Location = new System.Drawing.Point(107, 39);
            this.ButStartStop.Name = "ButStartStop";
            this.ButStartStop.Size = new System.Drawing.Size(50, 20);
            this.ButStartStop.TabIndex = 6;
            this.ButStartStop.Text = "Start";
            this.ButStartStop.UseVisualStyleBackColor = true;
            this.ButStartStop.Click += new System.EventHandler(this.ButStartStop_Click);
            // 
            // LblBaudRate
            // 
            this.LblBaudRate.Location = new System.Drawing.Point(5, 16);
            this.LblBaudRate.Name = "LblBaudRate";
            this.LblBaudRate.Size = new System.Drawing.Size(96, 20);
            this.LblBaudRate.TabIndex = 4;
            this.LblBaudRate.Text = "Select Baud Rate:";
            // 
            // LstStatus
            // 
            this.LstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstStatus.FormattingEnabled = true;
            this.LstStatus.Location = new System.Drawing.Point(8, 275);
            this.LstStatus.Name = "LstStatus";
            this.LstStatus.Size = new System.Drawing.Size(567, 69);
            this.LstStatus.TabIndex = 26;
            // 
            // TxtData7
            // 
            this.TxtData7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData7.Location = new System.Drawing.Point(215, 66);
            this.TxtData7.MaxLength = 2;
            this.TxtData7.Name = "TxtData7";
            this.TxtData7.Size = new System.Drawing.Size(24, 20);
            this.TxtData7.TabIndex = 20;
            this.TxtData7.Text = "00";
            this.TxtData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData6
            // 
            this.TxtData6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData6.Location = new System.Drawing.Point(185, 66);
            this.TxtData6.MaxLength = 2;
            this.TxtData6.Name = "TxtData6";
            this.TxtData6.Size = new System.Drawing.Size(24, 20);
            this.TxtData6.TabIndex = 19;
            this.TxtData6.Text = "00";
            this.TxtData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData5
            // 
            this.TxtData5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData5.Location = new System.Drawing.Point(155, 66);
            this.TxtData5.MaxLength = 2;
            this.TxtData5.Name = "TxtData5";
            this.TxtData5.Size = new System.Drawing.Size(24, 20);
            this.TxtData5.TabIndex = 18;
            this.TxtData5.Text = "00";
            this.TxtData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData4
            // 
            this.TxtData4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData4.Location = new System.Drawing.Point(125, 66);
            this.TxtData4.MaxLength = 2;
            this.TxtData4.Name = "TxtData4";
            this.TxtData4.Size = new System.Drawing.Size(24, 20);
            this.TxtData4.TabIndex = 17;
            this.TxtData4.Text = "00";
            this.TxtData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData3
            // 
            this.TxtData3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData3.Location = new System.Drawing.Point(95, 66);
            this.TxtData3.MaxLength = 2;
            this.TxtData3.Name = "TxtData3";
            this.TxtData3.Size = new System.Drawing.Size(24, 20);
            this.TxtData3.TabIndex = 16;
            this.TxtData3.Text = "00";
            this.TxtData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData2
            // 
            this.TxtData2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData2.Location = new System.Drawing.Point(66, 66);
            this.TxtData2.MaxLength = 2;
            this.TxtData2.Name = "TxtData2";
            this.TxtData2.Size = new System.Drawing.Size(24, 20);
            this.TxtData2.TabIndex = 15;
            this.TxtData2.Text = "00";
            this.TxtData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData1
            // 
            this.TxtData1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData1.Location = new System.Drawing.Point(36, 66);
            this.TxtData1.MaxLength = 2;
            this.TxtData1.Name = "TxtData1";
            this.TxtData1.Size = new System.Drawing.Size(24, 20);
            this.TxtData1.TabIndex = 14;
            this.TxtData1.Text = "00";
            this.TxtData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtData0
            // 
            this.TxtData0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtData0.Location = new System.Drawing.Point(5, 66);
            this.TxtData0.MaxLength = 2;
            this.TxtData0.Name = "TxtData0";
            this.TxtData0.Size = new System.Drawing.Size(24, 20);
            this.TxtData0.TabIndex = 13;
            this.TxtData0.Text = "00";
            this.TxtData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NudLength
            // 
            this.NudLength.BackColor = System.Drawing.Color.White;
            this.NudLength.Location = new System.Drawing.Point(125, 42);
            this.NudLength.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NudLength.Name = "NudLength";
            this.NudLength.ReadOnly = true;
            this.NudLength.Size = new System.Drawing.Size(41, 20);
            this.NudLength.TabIndex = 12;
            this.NudLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NudLength.ValueChanged += new System.EventHandler(this.NudLength_ValueChanged);
            // 
            // LblNumBytes
            // 
            this.LblNumBytes.AutoSize = true;
            this.LblNumBytes.Location = new System.Drawing.Point(2, 45);
            this.LblNumBytes.Name = "LblNumBytes";
            this.LblNumBytes.Size = new System.Drawing.Size(111, 13);
            this.LblNumBytes.TabIndex = 11;
            this.LblNumBytes.Text = "Number of data bytes:";
            // 
            // TxtIdHex
            // 
            this.TxtIdHex.Location = new System.Drawing.Point(123, 16);
            this.TxtIdHex.MaxLength = 3;
            this.TxtIdHex.Name = "TxtIdHex";
            this.TxtIdHex.Size = new System.Drawing.Size(73, 20);
            this.TxtIdHex.TabIndex = 10;
            this.TxtIdHex.Text = "F";
            this.TxtIdHex.TextChanged += new System.EventHandler(this.TxtIdHex_TextChanged);
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(44, 16);
            this.TxtId.MaxLength = 4;
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(73, 20);
            this.TxtId.TabIndex = 9;
            this.TxtId.Text = "15";
            this.TxtId.TextChanged += new System.EventHandler(this.TxtId_TextChanged);
            // 
            // LblCANId
            // 
            this.LblCANId.AutoSize = true;
            this.LblCANId.Location = new System.Drawing.Point(2, 19);
            this.LblCANId.Name = "LblCANId";
            this.LblCANId.Size = new System.Drawing.Size(41, 13);
            this.LblCANId.TabIndex = 8;
            this.LblCANId.Text = "CAN Id";
            // 
            // ButSend
            // 
            this.ButSend.Location = new System.Drawing.Point(5, 88);
            this.ButSend.Margin = new System.Windows.Forms.Padding(2);
            this.ButSend.Name = "ButSend";
            this.ButSend.Size = new System.Drawing.Size(50, 19);
            this.ButSend.TabIndex = 21;
            this.ButSend.Text = "Send";
            this.ButSend.UseVisualStyleBackColor = true;
            this.ButSend.Click += new System.EventHandler(this.ButSend_Click);
            // 
            // GrpMessage
            // 
            this.GrpMessage.Controls.Add(this.LblCANId);
            this.GrpMessage.Controls.Add(this.ButSend);
            this.GrpMessage.Controls.Add(this.TxtData0);
            this.GrpMessage.Controls.Add(this.TxtIdHex);
            this.GrpMessage.Controls.Add(this.TxtData1);
            this.GrpMessage.Controls.Add(this.TxtId);
            this.GrpMessage.Controls.Add(this.TxtData2);
            this.GrpMessage.Controls.Add(this.TxtData3);
            this.GrpMessage.Controls.Add(this.LblNumBytes);
            this.GrpMessage.Controls.Add(this.TxtData4);
            this.GrpMessage.Controls.Add(this.NudLength);
            this.GrpMessage.Controls.Add(this.TxtData5);
            this.GrpMessage.Controls.Add(this.TxtData7);
            this.GrpMessage.Controls.Add(this.TxtData6);
            this.GrpMessage.Enabled = false;
            this.GrpMessage.Location = new System.Drawing.Point(333, 9);
            this.GrpMessage.Name = "GrpMessage";
            this.GrpMessage.Size = new System.Drawing.Size(245, 112);
            this.GrpMessage.TabIndex = 7;
            this.GrpMessage.TabStop = false;
            this.GrpMessage.Text = "Transmit Message";
            // 
            // LblStatus
            // 
            this.LblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(5, 259);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(95, 13);
            this.LblStatus.TabIndex = 25;
            this.LblStatus.Text = "System Messages:";
            // 
            // GrpReading
            // 
            this.GrpReading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpReading.Controls.Add(this.ChkOverwrite);
            this.GrpReading.Controls.Add(this.LstReceivedMessages);
            this.GrpReading.Controls.Add(this.ButClear);
            this.GrpReading.Enabled = false;
            this.GrpReading.Location = new System.Drawing.Point(8, 177);
            this.GrpReading.Name = "GrpReading";
            this.GrpReading.Size = new System.Drawing.Size(567, 77);
            this.GrpReading.TabIndex = 22;
            this.GrpReading.TabStop = false;
            this.GrpReading.Text = "Received Messages";
            // 
            // ChkOverwrite
            // 
            this.ChkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkOverwrite.AutoSize = true;
            this.ChkOverwrite.Checked = true;
            this.ChkOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkOverwrite.Location = new System.Drawing.Point(59, 53);
            this.ChkOverwrite.Margin = new System.Windows.Forms.Padding(2);
            this.ChkOverwrite.Name = "ChkOverwrite";
            this.ChkOverwrite.Size = new System.Drawing.Size(71, 17);
            this.ChkOverwrite.TabIndex = 30;
            this.ChkOverwrite.Text = "Overwrite";
            this.ChkOverwrite.UseVisualStyleBackColor = true;
            this.ChkOverwrite.CheckedChanged += new System.EventHandler(this.ChkOverwrite_CheckedChanged);
            // 
            // LstReceivedMessages
            // 
            this.LstReceivedMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstReceivedMessages.FormattingEnabled = true;
            this.LstReceivedMessages.Location = new System.Drawing.Point(7, 20);
            this.LstReceivedMessages.Name = "LstReceivedMessages";
            this.LstReceivedMessages.Size = new System.Drawing.Size(555, 30);
            this.LstReceivedMessages.TabIndex = 29;
            // 
            // ButClear
            // 
            this.ButClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButClear.Enabled = false;
            this.ButClear.Location = new System.Drawing.Point(5, 53);
            this.ButClear.Margin = new System.Windows.Forms.Padding(2);
            this.ButClear.Name = "ButClear";
            this.ButClear.Size = new System.Drawing.Size(50, 19);
            this.ButClear.TabIndex = 24;
            this.ButClear.Text = "Clear";
            this.ButClear.UseVisualStyleBackColor = true;
            this.ButClear.Click += new System.EventHandler(this.ButClear_Click);
            // 
            // TimerCheckForDevice
            // 
            this.TimerCheckForDevice.Interval = 500;
            this.TimerCheckForDevice.Tick += new System.EventHandler(this.TimerCheckForDevice_Tick);
            // 
            // LblListOfDevices
            // 
            this.LblListOfDevices.AutoSize = true;
            this.LblListOfDevices.Location = new System.Drawing.Point(8, 8);
            this.LblListOfDevices.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblListOfDevices.Name = "LblListOfDevices";
            this.LblListOfDevices.Size = new System.Drawing.Size(106, 13);
            this.LblListOfDevices.TabIndex = 1;
            this.LblListOfDevices.Text = "PCAN USB Devices:";
            // 
            // GrpTrace
            // 
            this.GrpTrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpTrace.Controls.Add(this.LblMaxSize);
            this.GrpTrace.Controls.Add(this.NudTraceSize);
            this.GrpTrace.Controls.Add(this.ChkDateFiles);
            this.GrpTrace.Controls.Add(this.ChkMultiFile);
            this.GrpTrace.Controls.Add(this.TxtTraceDir);
            this.GrpTrace.Controls.Add(this.LblTraceDir);
            this.GrpTrace.Controls.Add(this.ButChooseFile);
            this.GrpTrace.Controls.Add(this.ButLogging);
            this.GrpTrace.Enabled = false;
            this.GrpTrace.Location = new System.Drawing.Point(8, 123);
            this.GrpTrace.Name = "GrpTrace";
            this.GrpTrace.Size = new System.Drawing.Size(567, 48);
            this.GrpTrace.TabIndex = 31;
            this.GrpTrace.TabStop = false;
            this.GrpTrace.Text = "Trace Settings";
            // 
            // LblMaxSize
            // 
            this.LblMaxSize.AutoSize = true;
            this.LblMaxSize.Location = new System.Drawing.Point(192, 20);
            this.LblMaxSize.Name = "LblMaxSize";
            this.LblMaxSize.Size = new System.Drawing.Size(54, 13);
            this.LblMaxSize.TabIndex = 32;
            this.LblMaxSize.Text = "Max. MBs";
            // 
            // NudTraceSize
            // 
            this.NudTraceSize.Location = new System.Drawing.Point(252, 18);
            this.NudTraceSize.Name = "NudTraceSize";
            this.NudTraceSize.Size = new System.Drawing.Size(45, 20);
            this.NudTraceSize.TabIndex = 31;
            this.NudTraceSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // ChkDateFiles
            // 
            this.ChkDateFiles.AutoSize = true;
            this.ChkDateFiles.Checked = true;
            this.ChkDateFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDateFiles.Location = new System.Drawing.Point(96, 19);
            this.ChkDateFiles.Name = "ChkDateFiles";
            this.ChkDateFiles.Size = new System.Drawing.Size(89, 17);
            this.ChkDateFiles.TabIndex = 30;
            this.ChkDateFiles.Text = "Date in name";
            this.ChkDateFiles.UseVisualStyleBackColor = true;
            // 
            // ChkMultiFile
            // 
            this.ChkMultiFile.AutoSize = true;
            this.ChkMultiFile.Checked = true;
            this.ChkMultiFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMultiFile.Location = new System.Drawing.Point(6, 19);
            this.ChkMultiFile.Name = "ChkMultiFile";
            this.ChkMultiFile.Size = new System.Drawing.Size(83, 17);
            this.ChkMultiFile.TabIndex = 29;
            this.ChkMultiFile.Text = "Multiple files";
            this.ChkMultiFile.UseVisualStyleBackColor = true;
            // 
            // TxtTraceDir
            // 
            this.TxtTraceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTraceDir.Location = new System.Drawing.Point(324, 17);
            this.TxtTraceDir.Name = "TxtTraceDir";
            this.TxtTraceDir.Size = new System.Drawing.Size(145, 20);
            this.TxtTraceDir.TabIndex = 25;
            this.TxtTraceDir.Text = "\\Temp";
            // 
            // LblTraceDir
            // 
            this.LblTraceDir.AutoSize = true;
            this.LblTraceDir.Location = new System.Drawing.Point(303, 20);
            this.LblTraceDir.Name = "LblTraceDir";
            this.LblTraceDir.Size = new System.Drawing.Size(23, 13);
            this.LblTraceDir.TabIndex = 28;
            this.LblTraceDir.Text = "Dir:";
            // 
            // ButChooseFile
            // 
            this.ButChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButChooseFile.Location = new System.Drawing.Point(475, 17);
            this.ButChooseFile.Name = "ButChooseFile";
            this.ButChooseFile.Size = new System.Drawing.Size(30, 20);
            this.ButChooseFile.TabIndex = 26;
            this.ButChooseFile.Text = "...";
            this.ButChooseFile.UseVisualStyleBackColor = true;
            this.ButChooseFile.Click += new System.EventHandler(this.ButChooseFile_Click);
            // 
            // ButLogging
            // 
            this.ButLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButLogging.Location = new System.Drawing.Point(511, 17);
            this.ButLogging.Name = "ButLogging";
            this.ButLogging.Size = new System.Drawing.Size(50, 20);
            this.ButLogging.TabIndex = 7;
            this.ButLogging.Text = "Start";
            this.ButLogging.UseVisualStyleBackColor = true;
            this.ButLogging.Click += new System.EventHandler(this.ButLogging_Click);
            // 
            // FrmPCTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 346);
            this.Controls.Add(this.GrpTrace);
            this.Controls.Add(this.LblListOfDevices);
            this.Controls.Add(this.GrpReading);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.GrpMessage);
            this.Controls.Add(this.LstStatus);
            this.Controls.Add(this.GrpInitialize);
            this.Controls.Add(this.LstDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(584, 385);
            this.Name = "FrmPCTest";
            this.Text = "PCAN USB Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPCTest_FormClosing);
            this.Load += new System.EventHandler(this.FrmPCTest_Load);
            this.GrpInitialize.ResumeLayout(false);
            this.GrpInitialize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLength)).EndInit();
            this.GrpMessage.ResumeLayout(false);
            this.GrpMessage.PerformLayout();
            this.GrpReading.ResumeLayout(false);
            this.GrpReading.PerformLayout();
            this.GrpTrace.ResumeLayout(false);
            this.GrpTrace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTraceSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox LstDevices;
        private System.Windows.Forms.GroupBox GrpInitialize;
        private System.Windows.Forms.Button ButStartStop;
        private System.Windows.Forms.Label LblBaudRate;
        private System.Windows.Forms.ListBox LstBaudRate;
        private System.Windows.Forms.ListBox LstStatus;
        private System.Windows.Forms.TextBox TxtData7;
        private System.Windows.Forms.TextBox TxtData6;
        private System.Windows.Forms.TextBox TxtData5;
        private System.Windows.Forms.TextBox TxtData4;
        private System.Windows.Forms.TextBox TxtData3;
        private System.Windows.Forms.TextBox TxtData2;
        private System.Windows.Forms.TextBox TxtData1;
        private System.Windows.Forms.TextBox TxtData0;
        private System.Windows.Forms.NumericUpDown NudLength;
        private System.Windows.Forms.Label LblNumBytes;
        private System.Windows.Forms.TextBox TxtIdHex;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label LblCANId;
        private System.Windows.Forms.Button ButSend;
        private System.Windows.Forms.GroupBox GrpMessage;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox GrpReading;
        private System.Windows.Forms.Button ButClear;
        private System.Windows.Forms.ListBox LstReceivedMessages;
        private System.Windows.Forms.Timer TimerCheckForDevice;
        private System.Windows.Forms.Label LblListOfDevices;
        private System.Windows.Forms.CheckBox ChkOverwrite;
        private System.Windows.Forms.CheckBox ChkTrace;
        private System.Windows.Forms.GroupBox GrpTrace;
        private System.Windows.Forms.Label LblMaxSize;
        private System.Windows.Forms.NumericUpDown NudTraceSize;
        private System.Windows.Forms.CheckBox ChkDateFiles;
        private System.Windows.Forms.CheckBox ChkMultiFile;
        private System.Windows.Forms.TextBox TxtTraceDir;
        private System.Windows.Forms.Label LblTraceDir;
        private System.Windows.Forms.Button ButChooseFile;
        private System.Windows.Forms.Button ButLogging;
    }
}

