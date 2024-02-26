using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mitsubishi_PLC
{
    public partial class Form1 : Form
    {

        int TotalRegisterInPLC = 24;
        int StringLength = 16;


        bool[] WriteBooleanData = new bool[] { true, false };
        short[] WriteIntData = new short[] { 1, 1, 434 };
        float[] WriteFloatData = new float[] { 23.323f, 234.5f };
        string[] WriteStringData = new string[] { "Barcode", "Serial Number" };

        bool[] ReadBooleanData;
        short[] ReadIntData = new short[3];
        float[] ReadFloatData = new float[2];
        string[] ReadStringData = new string[2];

        private Socket socket;
        public Form1()
        {
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveBufferSize = 256;
            socket.SendBufferSize = 256;
        }

        #region Command
        private string getWriteCommand()
        {
            int address = int.Parse(addressTb.Text);

            string subheader = "5000";
            string NetworkNo = "00";
            string StationNo = "FF";
            string ModuleNo = "03FF";
            string MultidropStNo = "00";
            string RequestDataLength = "0078"; // 24 + lenght of hex (76) = 100 => 64H
            string monitoringtime = "000A";
            string command = "1401";
            string subcommand = "0000";
            string deviceCode = "D*";
            string startingAddress = (address).ToString("0####0");
            string numberOfRegister = DecimalToHex(TotalRegisterInPLC.ToString());
            string booleanValues = GetBooleanValues();
            string intValues = GetIntValues();
            string floatValues = GetFloatValues();
            string stringValues = GetStringValues();

            string writeCommand = subheader + NetworkNo + StationNo + ModuleNo + MultidropStNo
                + RequestDataLength + monitoringtime + command + subcommand + deviceCode + startingAddress
                + numberOfRegister + booleanValues + intValues + floatValues + stringValues;

            return writeCommand;
        }
        private string getReadCommand()
        {
            int address = int.Parse(addressTb.Text);

            string subheader = "5000";
            string NetworkNo = "00";
            string StationNo = "FF";
            string ModuleNo = "03FF";
            string MultidropStNo = "00";
            string RequestDataLength = "0018";
            string monitoringtime = "000A";
            string command = "0401";
            string subcommand = "0000";
            string deviceCode = "D*";
            string startingAddress = (address).ToString("0####0");
            string numberOfRegister = DecimalToHex(TotalRegisterInPLC.ToString());

            string readCommand = subheader + NetworkNo + StationNo + ModuleNo + MultidropStNo
                + RequestDataLength + monitoringtime + command + subcommand + deviceCode
                + startingAddress + numberOfRegister;
            return readCommand;

        }
        #endregion



        #region Boolean
        private string GetBooleanValues()
        {
            string binaryString = "";
            string HexaBool = "";
            int k = 0;
            foreach (bool b in WriteBooleanData)
            {
                k++;
                binaryString += b ? "1" : "0";
            }
            int len = binaryString.Length;
            if (len % 16 != 0)
            {
                for (int i = 0; i < (16 - len); i++)
                {
                    binaryString = "0" + binaryString;
                }
            }
            for (int i = 0; i < (binaryString.Length / 16); i++)
            {
                HexaBool += Convert.ToInt32(binaryString.Substring(i * 16, 16), 2).ToString("x4");
            }
            return HexaBool;
        }
        private void SetBooleanValues(string res)
        {
            for (int i = 0; i < (res.Length / 4); i++)
            {
                string boolStr = (Convert.ToString(Convert.ToInt32(res.Substring(i * 4, 4), 16), 2));
                ReadBooleanData = boolStr.Select(c => c == '1').ToArray();
            }
        }
        #endregion

        #region Integer
        public string DecimalToHex(string Value)
        {
            return Convert.ToInt32(Value).ToString("X4");
        }
        private string GetIntValues()
        {
            string HexaInt = "";
            for (int i = 0; i < WriteIntData.Length; i++)
            {
                HexaInt += DecimalToHex(WriteIntData[i].ToString());
            }
            return HexaInt;
        }
        private void SetIntValues(string res)
        {
            for (int i = 0; i < (res.Length / 4); i++)
            {
                ReadIntData[i] = (short)Convert.ToInt32(res.Substring(i * 4, 4), 16);
            }
        }
        #endregion

        #region Float
        public string FloatToHex(float fValue)
        {
            byte[] floatBytes = BitConverter.GetBytes(fValue);
            string hexValue = BitConverter.ToString(floatBytes).Replace("-", "").PadLeft(8, '0');
            string RhexValue = "";
            for (int i = 0; i < hexValue.Length; i = i + 2)
                RhexValue = hexValue.Substring(i, 2) + RhexValue;
            return RhexValue;
        }
        public float HexToFloat(string hexValue)
        {
            byte[] hexBytes = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                hexBytes[i] = Convert.ToByte(hexValue.Substring(i * 2, 2), 16);
            }
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(hexBytes);
            }
            float reversedFloatValue = BitConverter.ToSingle(hexBytes, 0);
            return reversedFloatValue;

        }
        private string GetFloatValues()
        {
            string HexaFloat = "";
            for (int i = 0; i < WriteFloatData.Length; i++)
            {
                HexaFloat += FloatToHex(WriteFloatData[i]);
            }
            return HexaFloat;
        }
        private void SetFloatValues(string res)
        {
            for (int i = 0; i < (res.Length / 8); i++)
            {
                ReadFloatData[i] = HexToFloat(res.Substring(i * 8, 8));
            }
        }

        #endregion

        #region String
        public static string StringToHex(string input)
        {
            StringBuilder hex = new StringBuilder();

            foreach (char ch in input)
            {
                hex.Append(((int)ch).ToString("X2"));
            }

            return hex.ToString();
        }
        public string HexToString(string hexValue)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < hexValue.Length; i += 2)
            {
                string hexChar = hexValue.Substring(i, 2);
                int asciiValue = Convert.ToInt32(hexChar, 16);
                char c = (char)asciiValue;
                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
        private string GetStringValues()
        {
            string Temp = "";
            for (int i = 0; i < WriteStringData.Length; i++)
            {
                if (WriteStringData[i].Length < StringLength)
                {
                    for (int p = 0; p < (StringLength - WriteStringData[i].Length); p++)
                    {
                        Temp = Temp + "0";
                    }
                    WriteStringData[i] += Temp;
                    Temp = "";
                }
            }

            string HexaString = "";
            for (int i = 0; i < WriteStringData.Length; i++)
            {
                HexaString += StringToHex(WriteStringData[i]);
            }
            return HexaString;
        }
        public void SetStringValues(string res)
        {
            string Str1 = HexToString(res);
            string stringStr = "";
            int k = 0;
            for (int i = 0; i < Str1.Length; i++)
            {
                if (Str1[i] != '0')
                    stringStr += Str1[i];
                else if (Str1[i] == '0' && Str1[i - 1] != '0')
                {
                    ReadStringData[k] = stringStr;
                    stringStr = "";
                    k++;
                }
            }
        }
        #endregion

        #region Read_Write

        private void Read_Click_1(object sender, EventArgs e)
        {
            byte[] array;
            byte[] bytes;
            array = new byte[22 + (TotalRegisterInPLC * 4)];
            string res = "";
            string command = getReadCommand();
            bytes = Encoding.ASCII.GetBytes(command);
            socket.Send(bytes);
            Thread.Sleep(50);
            socket.Receive(array);
            string arr = Encoding.ASCII.GetString(array);
            arr = arr.Trim();
            res = arr.Substring(22);


            SetBooleanValues(res.Substring(0, 4));
            SetIntValues(res.Substring(4, 12));
            SetFloatValues(res.Substring(16, 16));
            SetStringValues(res.Substring(32));

            for (int i = 0; i < ReadBooleanData.Length; i++)
                Console.WriteLine(ReadBooleanData[i]);
            for (int i = 0; i < ReadIntData.Length; i++)
                Console.WriteLine(ReadIntData[i]);
            for (int i = 0; i < ReadFloatData.Length; i++)
                Console.WriteLine(ReadFloatData[i]);
            for (int i = 0; i < ReadStringData.Length; i++)
                Console.WriteLine(ReadStringData[i]);

            MessageBox.Show("Read Successfully");
        }
        private void Write_Click_1(object sender, EventArgs e)
        {
            string @string;
            int num = 22;
            byte[] array = new byte[checked(num - 1 + 1)];
            byte[] bytes;
            string command = getWriteCommand();
            bytes = Encoding.ASCII.GetBytes(command);
            socket.Send(bytes);
            Thread.Sleep(50);
            socket.Receive(array);
            @string = Encoding.ASCII.GetString(array);

            MessageBox.Show("Written Sucessfull");

        }
        #endregion

        #region Connection
        private void ConnectBtn_Click(object sender, EventArgs e)
        {

            if (socket != null && socket.Connected)
                return;
            string ipAddress = ipaddressTb.Text;
            int port = Convert.ToInt32(portTb.Text);

            try
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                StatusTb.Text = "Connected";
                StatusTb.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message);
            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (socket == null)
                    return;
                socket.Close();
                StatusTb.Text = "Disconnected";
                StatusTb.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while disconnecting: " + ex.Message);
            }
        }
        #endregion

    }
}
