﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace CAN.PC
{
    //PEAK handle data type
    using PCANHandle = UInt16;

    /// <summary>
    /// Used to provide a DLL to link from a C# program to the PEAK PCAN USB Devices.
    /// Requires the PCANBasic.cs file from the PEAK PCAN samples.
    /// Some code is derived from the PCAN C# sample.
    /// The PEAK PCAN drivers musts be installed on the target machine.
    /// </summary>
    public class PCAN_USB
    {
        #region PEAK USB devices, and handle definition and storage
        /// <summary>
        /// Define handles for PEAK USB devices 
        /// </summary>
        static PCANHandle[] handlesArray = new PCANHandle[]
        {
            PCANBasic.PCAN_USBBUS1,
            PCANBasic.PCAN_USBBUS2,
            PCANBasic.PCAN_USBBUS3,
            PCANBasic.PCAN_USBBUS4,
            PCANBasic.PCAN_USBBUS5,
            PCANBasic.PCAN_USBBUS6,
            PCANBasic.PCAN_USBBUS7,
            PCANBasic.PCAN_USBBUS8,
            PCANBasic.PCAN_USBBUS9,
            PCANBasic.PCAN_USBBUS10,
            PCANBasic.PCAN_USBBUS11,
            PCANBasic.PCAN_USBBUS12,
            PCANBasic.PCAN_USBBUS13,
            PCANBasic.PCAN_USBBUS14,
            PCANBasic.PCAN_USBBUS15,
            PCANBasic.PCAN_USBBUS16
        };
        /// <summary>
        /// The handled of the selected PEAK USB device
        /// </summary>
        public PCANHandle PeakCANHandle { get; set; } = 0;
        /// <summary>
        /// Get a list of connected devices
        /// </summary>
        /// <returns>List of devices</returns>
        public static List<string> GetUSBDevices()
        {
            //Uses the PEAK System USB1 to USB16 handles for the PCAN-USB devices
            TPCANStatus dllRet = TPCANStatus.PCAN_ERROR_UNKNOWN;    //Assume unknown state to start
            UInt32 iBuffer; //Passed to PCAN dll in GetValue call
            List<string> PCANDevices = null;    //The list of devices to return

            bool isFD;  //CAN Flexible Data Rate (not currently supported by PCAN_USB)

            for (int i = 0; i < handlesArray.Length; i++)
            {
                // Checks for a Plug&Play Handle and, depending upon the return value, include it
                // into the list of available hardware channels.
                dllRet = PCANBasic.GetValue(handlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                if ((dllRet == TPCANStatus.PCAN_ERROR_OK) && ((iBuffer & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE || (iBuffer & PCANBasic.PCAN_CHANNEL_PCANVIEW) == PCANBasic.PCAN_CHANNEL_PCANVIEW))
                {
                    dllRet = PCANBasic.GetValue(handlesArray[i], TPCANParameter.PCAN_CHANNEL_FEATURES, out iBuffer, sizeof(UInt32));
                    isFD = (dllRet == TPCANStatus.PCAN_ERROR_OK) && ((iBuffer & PCANBasic.FEATURE_FD_CAPABLE) == PCANBasic.FEATURE_FD_CAPABLE);
                    if (PCANDevices == null)
                        PCANDevices = new List<string>();
                    PCANDevices.Add(FormatChannelName(handlesArray[i], isFD));
                }
            }
            return PCANDevices;
        }
        /// <summary>
        /// PEAK format text for a PCAN-Basic channel handle
        /// </summary>
        /// <param name="handle">PCAN-Basic Handle to format</param>
        /// <param name="isFD">If the channel is FD capable</param>
        /// <returns>The formatted text for a channel</returns>
        private static string FormatChannelName(PCANHandle handle, bool isFD)
        {
            TPCANDevice devDevice;
            byte byChannel;

            // Gets the owner device and channel for a 
            // PCAN-Basic handle
            if (handle < 0x100)
            {
                devDevice = (TPCANDevice)(handle >> 4);
                byChannel = (byte)(handle & 0xF);
            }
            else
            {
                devDevice = (TPCANDevice)(handle >> 8);
                byChannel = (byte)(handle & 0xFF);
            }
            // Constructs the PCAN-Basic Channel name and return it
            if (isFD)
                return string.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle);
            else
                return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
        }
        /// <summary>
        /// Returns the PCAN USB handle for a given PEAK displayed handle
        /// </summary>
        /// <param name="PEAKListHandle">Displayed handle string</param>
        /// <returns>PCAN USB handle, 0 if no string provided or if string incorrect</returns>
        public static PCANHandle DecodePEAKHandle(string PEAKListHandle)
        {
            if(!(string.IsNullOrEmpty(PEAKListHandle) || PEAKListHandle.Trim()==string.Empty))
            {
                // Get the handle from the text being shown
                PEAKListHandle = PEAKListHandle.Substring(PEAKListHandle.IndexOf('(') + 1, 3);
                PEAKListHandle = PEAKListHandle.Replace('h', ' ').Trim(' ');
                PCANHandle handle = 0;
                if (!PCANHandle.TryParse(PEAKListHandle, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out handle))
                    handle = 0;
                return handle;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Identify device (flashes LED if supported)
        /// <summary>
        /// Get identify setting from PCAN USB device
        /// </summary>
        /// <param name="PCANUSBHandle">PCAN USB device handle</param>
        /// <returns>true if identifying is on for the device, else false</returns>
        public static bool IsIdentifyOn(PCANHandle PCANUSBHandle)
        {
            TPCANStatus dllRet = TPCANStatus.PCAN_ERROR_UNKNOWN;    //Assume unknown state to start
            UInt32 iBuffer; //Passed to PCAN dll in GetValue call

            dllRet = PCANBasic.GetValue(PCANUSBHandle, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, out iBuffer, sizeof(UInt32));
            if (dllRet == TPCANStatus.PCAN_ERROR_OK && ((iBuffer & PCANBasic.PCAN_PARAMETER_ON) == PCANBasic.PCAN_PARAMETER_ON))
                return true;
            else
                return false;
            
        }

        /// <summary>
        /// Set the identify setting for a PCAN USB device
        /// </summary>
        /// <param name="PCANUSBHandle">PCAN USB device handle</param>
        /// <param name="OnOff">identify on or off</param>
        /// <returns>true if setting was made correctly, else false if it failed</returns>
        public static bool SetIdentify(PCANHandle PCANUSBHandle, bool OnOff)
        {
            TPCANStatus dllRet = TPCANStatus.PCAN_ERROR_UNKNOWN;    //Assume unknown state to start
            UInt32 iBuffer; //Passed to PCAN dll in GetValue call

            if (OnOff)
                iBuffer = PCANBasic.PCAN_PARAMETER_ON;
            else
                iBuffer = PCANBasic.PCAN_PARAMETER_OFF;

            dllRet = PCANBasic.SetValue(PCANUSBHandle, TPCANParameter.PCAN_CHANNEL_IDENTIFYING, ref iBuffer, sizeof(UInt32));
            if (dllRet == TPCANStatus.PCAN_ERROR_OK)
                return true;
            else
                return false;

        }
        #endregion

        #region Set the user defined device number (not the PEAK id)
        //PCAN_DEVICE_NUMBER
        #endregion

        #region The UI list boxes for UI message and CAN message rx updates
        /// <summary>
        /// Feeback any status messages to a UI
        /// </summary>
        public ListBox Feedback { get; set; } = null;
        /// <summary>
        /// For showing the received messages
        /// </summary>
        public ListBox ReceivedMessages { get; set; } = null;

        //First packet read
        public Packet DiffPacket { get; set; } = null;
        
        /// <summary>
        /// Add a message to a UI listbox
        /// </summary>
        /// <param name="AddTo">Use this list box</param>
        /// <param name="MessageToAdd">Add this message</param>
        /// <returns>Index of the added item or -1</returns>
        private static int AddMessage(ListBox AddTo, string MessageToAdd)
        {
            int ret = -1;

            if (AddTo != null)
            {
                //Limit number of items
                if (AddTo.Items.Count >= 60000)
                    AddTo.Items.RemoveAt(0);
                ret=AddTo.Items.Add(MessageToAdd);
                //ensure new item is visible
                AddTo.TopIndex = AddTo.Items.Count - 1;
                return ret; 
            }
 
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AddTo">Use this list box</param>
        /// <param name="MessageToAdd">Add this message</param>
        /// <param name="IndexToReplace">Index of item to replace</param>
        /// <returns>Index of the replaced item or -1</returns>
        private int AddMessage(ListBox AddTo, string MessageToAdd, int IndexToReplace)
        {
            if (AddTo != null)
            {
                if (IndexToReplace > -1 && IndexToReplace < AddTo.Items.Count)
                {
                    //Replace item
                    AddTo.Items[IndexToReplace] = MessageToAdd;
                    return IndexToReplace;
                }
                else
                {
                    //Limit number of items
                    if (AddTo.Items.Count >= 60000)
                        AddTo.Items.RemoveAt(0);
                    //Replacing so no need to move current view.
                    return AddTo.Items.Add(MessageToAdd);
                }
            }
            else
                return -1;
        }
        #endregion

        #region Hardware status
        /// <summary>
        /// Store the last PEAK PCAN USB operation status result
        /// </summary>
        public TPCANStatus LastOperationStatus = TPCANStatus.PCAN_ERROR_UNKNOWN;
        /// <summary>
        /// Help Function used to get an error as text
        /// </summary>
        /// <param name="error">Error code to be translated</param>
        /// <returns>A text with the translated error</returns>
        public string PeakCANStatusErrorString(TPCANStatus error)
        {
            // Creates a buffer big enough for a error-text
            StringBuilder strTemp = new StringBuilder(256);

            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            else
            {
                return strTemp.ToString();
            }
        }
        /// <summary>
        /// If possible display the last operation result message if required
        /// </summary>
        private void LastOperationErrorMessage()
        {
            if (Feedback != null)
            {
                AddMessage(Feedback, PeakCANStatusErrorString(LastOperationStatus));
            }
        }
        #endregion
               
        #region Valid Baud Rates
        /// <summary>
        /// PCAN USB supported baud rates
        /// </summary>
        public static string[] CANBaudRates = {"5 kbit/s", "10 kbit/s", "20 kbit/s", "33.333 kbit/s", "47.619 kbit/s", "50 kbit/s", "83.333 kbit/s",
                                               "95.238 kbit/s", "100 kbit/s", "125 kbit/s", "250 kbit/s", "500 kbit/s", "800 kbit/s", "1 Mbit/s" };
        /// <summary>
        /// Convert as readable baud rate to a PCAN USB baud rate.
        /// See CANBaudRates for values.
        /// </summary>
        /// <param name="CANBaudRate">Baud rate x kbit/s or Mbit/s</param>
        /// <returns>PEAK baud rate value, 5 kbit/s setting if string not recognised</returns>
        TPCANBaudrate CANBaudRateToPeakCANBaudRate(string CANBaudRate)
        {
            if (CANBaudRate == "1 Mbit/s")
                return TPCANBaudrate.PCAN_BAUD_1M;
            else if (CANBaudRate == "800 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_800K;
            else if (CANBaudRate == "500 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_500K;
            else if (CANBaudRate == "250 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_250K;
            else if (CANBaudRate == "125 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_125K;
            else if (CANBaudRate == "100 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_100K;
            else if (CANBaudRate == "95.238 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_95K;
            else if (CANBaudRate == "83.333 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_83K;
            else if (CANBaudRate == "50 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_50K;
            else if (CANBaudRate == "47.619 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_47K;
            else if (CANBaudRate == "33.333 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_33K;
            else if (CANBaudRate == "20 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_20K;
            else if (CANBaudRate == "10 kbit/s")
                return TPCANBaudrate.PCAN_BAUD_10K;
            else return TPCANBaudrate.PCAN_BAUD_5K;
        }
        #endregion

        #region Storage for captured packets
        /// <summary>
        /// A CAN data packet class
        /// </summary>
        public class Packet
        {
            //PEAK uses a struct for passing to the PEAK dll
            public ulong Microseconds { set; get; }
            public uint Id { set; get; }
            public byte Length { set; get; }
            public byte[] Data { set; get; }
            //Index for displaying in list boxes
            public int DisplayIndex { get; set; } = -1;

            public static Packet Clone(Packet PacketToClone)
            {
                Packet pkt = new Packet();
                pkt.Microseconds = PacketToClone.Microseconds;
                pkt.Id = PacketToClone.Id;
                pkt.Length = PacketToClone.Length;
                pkt.Data = PacketToClone.Data.Clone() as byte[];
                pkt.DisplayIndex = PacketToClone.DisplayIndex;

                return pkt;
            }

        }
        /// <summary>
        /// List of all packets
        /// </summary>
        public List<Packet> Packets { get; set; } = new List<Packet>();
        /// <summary>
        /// Current packet being operated on
        /// </summary>
        Packet CurrentPacket { get; set; }
        //local StringBuilder for the packet to string function
        static StringBuilder sb;
        /// <summary>
        /// Convert a CAN packet to a displayable string
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public static string PacketToString(Packet ThisPacket)
        {
            sb = new StringBuilder();

            sb.Append((ThisPacket.Microseconds / 1000000.0d).ToString("F6", CultureInfo.InvariantCulture));
            sb.Append(' ');
            sb.Append(ThisPacket.Id);
            sb.Append(' ');
            sb.Append(ThisPacket.Length);
            sb.Append(' ');
            for (int i = 0; i < ThisPacket.Length; i++)
            {
                sb.Append(" " + ThisPacket.Data[i].ToString("X2"));
            }

            return sb.ToString();
        }
        //Local for the capture mode
        bool overwriteLastPacket;
        /// <summary>
        /// Either overwrite packets of same id or add to end of storage
        /// </summary>
        public bool OverwriteLastPacket
        {
            get { return overwriteLastPacket; }
            set
            {
                if (value != overwriteLastPacket)
                {
                    overwriteLastPacket = value;
                    Packets = new List<Packet>();
                }
            }
        }
        /// <summary>
        /// Store a captured CAN packet
        /// </summary>
        /// <param name="TimeInMicroseconds">Time registered by PEAK device</param>
        /// <param name="CANId">Id of the packet</param>
        /// <param name="DataLength">Length of data</param>
        /// <param name="Data">Captured data</param>
        /// <returns>Reference to the packet</returns>
        Packet UpdatePackets(ulong TimeInMicroseconds, uint CANId, byte DataLength, byte[] Data)
        {
            Packet packet;

            if (overwriteLastPacket)
            {
                //Update packet list by overwriting last value
                packet = Packets.Find(x => x.Id == CANId);
                if (packet == null)
                {
                    packet = new Packet();
                    Packets.Add(packet);
                }
            }
            else
            {
                //store as new values
                packet = new Packet();
                Packets.Add(packet);
            }
            //add/update values
            packet.Microseconds = TimeInMicroseconds;
            packet.Id = CANId;
            packet.Length = DataLength;
            packet.Data = Data;

            //remember first packet for diff calc
            if (DiffPacket==null)
            {
                AddMessage(Feedback, "First packet received " + PacketToString(packet));
                DiffPacket = Packet.Clone(packet);
            }
            return packet;
        }
        #endregion

        #region Specific Packet Monitoring
        public bool WatchForPackets = false;
        /// <summary>
        /// List of packets to watch out for
        /// </summary>
        public List<Packet> WatchPackets { get; set; } = new List<Packet>();

        public void SetWatchPackets()
        {
            Packet aPacket = new Packet();
            byte[] data = { 1 };
            aPacket.Id = 534;
            aPacket.Length = 1;
            aPacket.Data = data;
            WatchPackets.Add(aPacket);
/*
            aPacket = new Packet();
            data = new byte[]{ 1 };
            aPacket.Id = 534;
            aPacket.Length = 1;
            aPacket.Data = data;
            WatchPackets.Add(aPacket);
 */       }

        public bool FoundPacket()
        {
            bool ret = false;

            foreach (Packet packet in WatchPackets)
            {
                if (packet.Id == CurrentPacket.Id)
                {
                    if (packet.Length == CurrentPacket.Length)
                    {
                        for (int i = 0; i < packet.Length && i < CurrentPacket.Length; i++)
                        {
                            if (packet.Data[i] == CurrentPacket.Data[i])
                                ret = true;
                            else
                                ret = false;
                        }
                        if (ret)
                            //found exact match, exit
                            break;
                    }
                }
            }

            return ret;
        }
        #endregion

        #region The background CAN message reading thread
        /// <summary>
        /// Thread for message reading (using events)
        /// </summary>
        private Thread ReadThread;
        /// <summary>
        /// Read-Delegate Handler
        /// </summary>
        private delegate void ReadDelegateHandler();
        /// <summary>
        /// Local control of read thread.
        /// Set on call to SetCANMessageRead.
        /// </summary>
        bool RxMessages { get; set; } = false;    //Set true to read messages                
        /// <summary>
        /// Read Delegate for calling the function "ReadMessage"
        /// </summary>
        private ReadDelegateHandler ReadDelegate;
        /// <summary>
        /// Receive-Event
        /// </summary>
        private AutoResetEvent ReceiveEvent;
        /// <summary>
        /// The form for CAN read delegate invoke
        /// </summary>
        public Form ControlForm { get; set; } = null;
        /// <summary>
        /// Function for reading CAN messages on normal CAN devices
        /// Set to the ReadDelegate
        /// </summary>
        /// <returns>A TPCANStatus error code</returns>
        private void ReadMessage()
        {
            //TODO move to moduel level for performance
            TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;
            ulong timeInMicroseconds;

            //Read till buffer empty
            do
            {
                // The "Read" function of PCANBasic                
                stsResult = PCANBasic.Read(PeakCANHandle, out CANMsg, out CANTimeStamp);
                if (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY)
                {
                    //Get the PEAK packet time in 
                    timeInMicroseconds = Convert.ToUInt64(CANTimeStamp.micros + 1000 * CANTimeStamp.millis + 0x100000000 * 1000 * CANTimeStamp.millis_overflow);
                    //Store the read in packet and get a reference to it.
                    CurrentPacket = UpdatePackets(timeInMicroseconds, CANMsg.ID, CANMsg.LEN, CANMsg.DATA);
                    //Display it if possible, either over existing line to new line
                    if (CurrentPacket.DisplayIndex > -1)
                        AddMessage(ReceivedMessages, PacketToString(CurrentPacket), CurrentPacket.DisplayIndex);
                    else
                        CurrentPacket.DisplayIndex = AddMessage(ReceivedMessages, PacketToString(CurrentPacket));
                    if (WatchForPackets)
                    {
                        if (FoundPacket())
                        {
                            AddMessage(Feedback, "Found " + PacketToString(CurrentPacket) + " " + DateTime.Now.ToLocalTime());
                            if(DiffPacket!=null)
                            {
                                ulong diff = CurrentPacket.Microseconds - DiffPacket.Microseconds;
                                AddMessage(Feedback, "Diff: " + (Convert.ToDouble(diff) / 1000000.0d).ToString("F6", CultureInfo.InvariantCulture) + " " + DateTime.Now.ToLocalTime());
                            }
                            else
                            {
                                AddMessage(Feedback, "First Packet");
                            }
                            Console.Beep();
                            DiffPacket = Packet.Clone(CurrentPacket);
                        }
                            

                    }
                }
                if (stsResult == TPCANStatus.PCAN_ERROR_ILLOPERATION)
                    break;
            } while (PeakCANHandle > 0 && (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY)));
        }
        /// <summary>
        /// Thread-Function used for reading PCAN-Basic messages
        /// </summary>
        private void CANReadThreadFunc()
        {
            UInt32 iBuffer;

            iBuffer = Convert.ToUInt32(ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
            // Sets the handle of the Receive-Event.
            LastOperationStatus = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));

            if (LastOperationStatus != TPCANStatus.PCAN_ERROR_OK)
            {
                //throw new Exception(PeakCANStatusErrorString(LastOperationStatus));
            }

            if (ControlForm != null)
            {
                while (RxMessages)
                {
                    // Waiting for Receive-Event
                    if (ReceiveEvent.WaitOne(50))
                        // Process Receive-Event using .NET Invoke function
                        // in order to interact with Winforms UI (calling the 
                        // function ReadMessage)
                        if (RxMessages)  //Double check reading is still required
                            ControlForm.Invoke(ReadDelegate);
                }
            }
            else
                 throw new Exception("No control form set.");
        }
        /// <summary>
        /// Set up the CAN Rx thread
        /// </summary>
        public void SetCANMessageRead()
        {
            // Create and start the tread to read CAN Message using SetRcvEvent()
            ThreadStart threadDelegate = new ThreadStart(CANReadThreadFunc);
            ReadThread = new Thread(threadDelegate);
            ReadThread.IsBackground = true;
            RxMessages = true;  //allow rx
            ReadThread.Start();
        }
        #endregion

        #region Logging

        /// <summary>
        /// Configures the PCAN-Trace file for a PCAN-Basic Channel
        /// </summary>
        private void ConfigureTraceFile(string TraceDirectory, bool MultipleFiles, bool TimeStampName, UInt32 MaxMegabytes)
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            // Configure the size of a trace file (max 100 MBs)
            stsResult = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_TRACE_SIZE, ref MaxMegabytes, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                AddMessage(Feedback, GetFormatedError(stsResult));

            //Configure trace location
            stsResult = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_TRACE_LOCATION, TraceDirectory, (uint) TraceDirectory.Length);
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                AddMessage(Feedback, GetFormatedError(stsResult));

            //Single or multiple files
            if(MultipleFiles)
                iBuffer = PCANBasic.TRACE_FILE_SEGMENTED | PCANBasic.TRACE_FILE_OVERWRITE;
            else
                iBuffer = PCANBasic.TRACE_FILE_SINGLE | PCANBasic.TRACE_FILE_OVERWRITE;
            
            if(TimeStampName)
                iBuffer = iBuffer | PCANBasic.TRACE_FILE_DATE | PCANBasic.TRACE_FILE_TIME;
 
            stsResult = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
            if (stsResult != TPCANStatus.PCAN_ERROR_OK)
                AddMessage(Feedback, GetFormatedError(stsResult));
        }

        /// <summary>
        /// Help Function used to get an error as text
        /// </summary>
        /// <param name="error">Error code to be translated</param>
        /// <returns>A text with the translated error</returns>
        private string GetFormatedError(TPCANStatus error)
        {
            StringBuilder strTemp;

            // Creates a buffer big enough for a error-text
            //
            strTemp = new StringBuilder(256);
            // Gets the text using the GetErrorText API function
            // If the function success, the translated error is returned. If it fails,
            // a text describing the current error is returned.
            //
            if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
                return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
            else
                return strTemp.ToString();
        }


        bool logging;

        public bool StartLogging(string DirectoryForLogFile, bool MultipleFiles, bool TimestampName, UInt32 MaxMegabytes)
        {
            TPCANStatus stsResult;  //result of call to PEAK
            UInt32 iBuffer; //Int buffer to send to peak
            logging = false;    //true is logging turned on 9return value)

            if(Directory.Exists(DirectoryForLogFile))
            {
                ConfigureTraceFile(DirectoryForLogFile, MultipleFiles, TimestampName, MaxMegabytes);
            }
            else
            {
                ConfigureTraceFile("", MultipleFiles, TimestampName, MaxMegabytes);
                AddMessage(Feedback, "Directory for trace file: " + DirectoryForLogFile + ", not set (doesn't exist), default is exe location.");
            }

            iBuffer = (uint)PCANBasic.PCAN_PARAMETER_ON;
            stsResult = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_TRACE_STATUS, ref iBuffer, sizeof(UInt32));
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
            {
                AddMessage(Feedback, "Trace log on");
                logging = true;
            }
            return logging;
        }

        public bool StopLogging()
        {
            UInt32 iBuffer = (uint)PCANBasic.PCAN_PARAMETER_OFF;
            TPCANStatus stsResult = PCANBasic.SetValue(PeakCANHandle, TPCANParameter.PCAN_TRACE_STATUS, ref iBuffer, sizeof(UInt32));
            if (stsResult == TPCANStatus.PCAN_ERROR_OK)
            {
                AddMessage(Feedback, "Trace log off");
                logging = false;
            }
            return logging;
        }

        #endregion

        #region Construction
        public PCAN_USB()
        {
            Initialise();
        }
        public PCAN_USB(Form ReadInvoker)
        {
            //set the form invoking the read delegate
            ControlForm = ReadInvoker;
            Initialise();
        }
        private void Initialise()
        {
            //Delegate for reading messages on a Thread
            ReadDelegate = new ReadDelegateHandler(ReadMessage);
            // Creates the event used for signalize incomming messages 
            ReceiveEvent = new AutoResetEvent(false);
            //default capture mode to overwrite messages in the packet list (messages of same id)
            overwriteLastPacket = true;
        }
        #endregion

        #region PEAK device initialization and release
        /// <summary>
        /// Initialise the given PEAK USB device
        /// </summary>
        /// <param name="CANHandle">PEAK USB handle</param>
        /// <param name="CANBaudRate">Baud rate as displayed</param>
        /// <returns>Device operation status</returns>
        public TPCANStatus InitializeCAN(PCANHandle CANHandle, string CANBaudRate, bool EnableRead)
        {
            LastOperationStatus = PCANBasic.Initialize(CANHandle, CANBaudRateToPeakCANBaudRate(CANBaudRate), (TPCANType)0, 0, 0);
            InitializeMessage();
            //Setup receive
            if(EnableRead) SetCANMessageRead();
            return LastOperationStatus;
        }
        /// <summary>
        /// On initialise update the UI list box (if set)
        /// </summary>
        private void InitializeMessage()
        {
            if (LastOperationStatus != TPCANStatus.PCAN_ERROR_OK)
            {
                if (LastOperationStatus != TPCANStatus.PCAN_ERROR_CAUTION)
                {
                    LastOperationErrorMessage();
                }
                else
                {
                    AddMessage(Feedback, "The bitrate being used is different than the given one.");
                }
            }
            else
            {
                AddMessage(Feedback, "Initialised.");
            }
        }
        /// <summary>
        /// Release the PEAK CAN USB device
        /// </summary>
        /// <returns></returns>
        public TPCANStatus Uninitialize()
        {
            TPCANStatus ret = TPCANStatus.PCAN_ERROR_UNKNOWN;
            //Stop reading
            RxMessages = false;
            if (PeakCANHandle != 0)
            {
                ret = PCANBasic.Uninitialize(PeakCANHandle);
                PeakCANHandle = 0;
            }
            if (ReadThread != null)
            {
                ReadThread.Abort();
                ReadThread.Join();
                ReadThread = null;
            }
            AddMessage(Feedback, "Uninitialised.");
            LastOperationStatus = ret;
            return ret;
        }
        #endregion

        #region Write a CAN packet
        public TPCANStatus WriteFrame(UInt32 Id, int DataLength, byte[] Data)
        {
            TPCANMsg CANMsg;

            // Create a TPCANMsg message structure 
            CANMsg = new TPCANMsg();

            // Configure the Message Type.
            CANMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
            // Message contents (ID, Length of the Data, Data)
            CANMsg.ID = Id;
            CANMsg.LEN = (byte)DataLength;
            CANMsg.DATA = Data;

            // The message is sent to the configured hardware
            LastOperationStatus = PCANBasic.Write(PeakCANHandle, ref CANMsg);
            if (LastOperationStatus != TPCANStatus.PCAN_ERROR_OK)
            {
                LastOperationErrorMessage();
            }
            return LastOperationStatus;
        }
        #endregion
    }
}
