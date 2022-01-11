using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KickStarter
{
    public partial class KickStartForm : Form
    {
        private static string _Input = "";
        public static NameValueCollection ConfigurationSettings = new NameValueCollection();
        public static int lineHeadLenght = 50;
        public KickStartForm()
        {
            Lo.g($"KickStarter.log:{Environment.NewLine}" +
                 $"{DateTime.Now.ToString("s", DateTimeFormatInfo.InvariantInfo).Replace("T", " ")}{Environment.NewLine}", true);
            ConfigurationSettings = System.Configuration.ConfigurationSettings.AppSettings;
            InitializeComponent();
        }
        public string AddOutput(string str)
        {
            this.Output_txt.AppendText(str);
            return str;
        }
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            this.input_File_txt.Text = this.openFileDialog.FileName;
        }

        private void Input_File_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            openFileDialog.ShowDialog();
        }


        private void Reload_Data_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            List<string> readText = new List<string>();

            string inputFilePath = this.input_File_txt.Text;
            if (!File.Exists(inputFilePath))
            {
                MessageBox.Show("Please select the Input file.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                readText = File.ReadAllLines(inputFilePath).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open the file.\nPlease select the ATS config file.\n\n {ex.Message}", "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Input_txt.Text = "";
            foreach (string line in readText)
            {
                if (Input_txt.Text == "")
                    Input_txt.Text = line.Trim();
                else
                    Input_txt.Text += Environment.NewLine + line.Trim();
                
                Console.WriteLine(Lo.g(line.Trim()));
            }
        }
        private Boolean LineConains(string line, string str2find, out string Addr)
        {
            string tempLine = (line.Replace(" ", "")).Replace("\t", "");
            if (tempLine.Contains($"<addkey=\"{str2find}\"value"))
            {
                Addr = (tempLine.Replace($"<addkey=\"{str2find}\"value=\"", "")).Replace("\"/>", "");
                return true;
            }
            Addr = "";
            return false;
        }
        private void Save_to_File_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));

            List<string> readText = new List<string>();

            string inputFilePath = input_File_txt.Text;
            if (inputFilePath == "")
            {
                MessageBox.Show("Please select file to write the input data to.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(inputFilePath))
                File.AppendAllText(inputFilePath, Environment.NewLine);

            readText = Input_txt.Lines.ToList();

            foreach (string line in readText)
                Console.WriteLine(Lo.g(line));

            File.WriteAllLines(inputFilePath, readText);
        }
        private void Input_txt_TextChanged(object sender, EventArgs e)
        {
            _Input = Input_txt.Text;
        }
        private void Islands_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            Islands myIslands = new Islands(this);
            myIslands.LaunchInput(Input_txt.Lines.ToList());
            Console.WriteLine(Lo.g($"~~~~~~~~~~~~~~~~~~~~~~~~~{Environment.NewLine}"));
        }
        private void Input_File_txt_LostFocus(object sender, EventArgs e)
        {
            if (!File.Exists(input_File_txt.Text))
            {
                //MessageBox.Show($"Cannot find file:  {input_File_txt.Text}.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Launch_UDP_btn_Click(object sender, EventArgs e)
        {
            Go_UDP myUDP = new Go_UDP(this, UDP_IP_txt.Text, UDP_Port_txt.Text, input_File_txt.Text);

            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));

            myUDP.LaunchInput(Input_txt.Lines.ToList());
            Console.WriteLine(Lo.g($":~~~~~~~~~~~~~~~~~~~~~~~~~{Environment.NewLine}"));
            Thread.Sleep(Int16.Parse(UDP_Delay_txt.Text));
        }

        private void Regions_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            int[][] intArr2d = Input_txt.Lines.Select(x => (x.Split(' ').Select(Int32.Parse).ToArray())).ToArray();

            Regions myRegions = new Regions(this);
            myRegions.LaunchInput(intArr2d);
            Console.WriteLine(Lo.g($"~~~~~~~~~~~~~~~~~~~~~~~~~{Environment.NewLine}"));
        }

        private void Rerions2_btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Lo.g($"In: {System.Reflection.MethodBase.GetCurrentMethod().Name}"));
            int[][] intArr2d2 = Input_txt.Lines.Select(x => (x.Split(' ').Select(Int32.Parse).ToArray())).ToArray();

            Regions2 myRegions2 = new Regions2(this);
            myRegions2.LaunchInput2(intArr2d2);
            Console.WriteLine(Lo.g($"~~~~~~~~~~~~~~~~~~~~~~~~~{Environment.NewLine}"));
        }
    }
    public static class Lo
    {
        private static string _logFile = Directory.GetCurrentDirectory() + "\\KickStarter.log";

        public static string g(string str)
        {
            try
            {
                File.AppendAllText(_logFile, str + Environment.NewLine);
                return str;
            }
            catch
            {
                Console.WriteLine(Lo.g($"IO collision"));
                return "";
            }
        }
        public static string g(KickStartForm form, string str)
        {
            try
            {
                //File.AppendAllText(_logFile, str + Environment.NewLine);
                form.AddOutput(str + Environment.NewLine);
                return str;
            }
            catch
            {
                Console.WriteLine(Lo.g($"IO collision2"));
                return "IO collision2";
            }
        }
        public static string g(string str, bool bOverride)
        {
            if (bOverride)
                File.WriteAllText(_logFile, str + Environment.NewLine);
            else
                File.AppendAllText(_logFile, str + Environment.NewLine);

            return str;
        }
    }
    public static class Print
    {
        public static string Matrix(KickStartForm parentForm, int[][] matrix, string name)
        {
            string outMat = "";
            string line = "";
            int i_y = matrix[0].Length;
            int i_x = matrix[1].Length;
            if ((i_y == 0) || (i_x == 0))
                Console.WriteLine(Lo.g("Cant print empty matrix"));

            Console.WriteLine(Lo.g(name));

            for (int y = 0; y < i_y; ++y)
            {
                for (int x = 0; x < i_x; ++x)
                {
                    line += $"{matrix[y][x]} ";
                }
                Console.WriteLine(Lo.g(line));
                outMat += line + Environment.NewLine;
                line = "";
            }
            Console.WriteLine(Lo.g(""));
            outMat += line + Environment.NewLine;
            return outMat;
        }
        public static string Matrix(int[][] matrix, string name)
        {
            string outMat = "";
            string line = "";
            int i_y = matrix.Length;
            int i_x = matrix[0].Length;
            if ((i_y == 0) || (i_x == 0))
                Console.WriteLine(Lo.g("Cant print empty matrix"));

            Console.WriteLine(Lo.g(name));

            for (int y = 0; y < i_y; ++y)
            {
                for (int x = 0; x < i_x; ++x)
                {
                    line += $"{matrix[y][x]} "/*+"\t"*/;
                }
                Console.WriteLine(Lo.g(line));
                outMat += line + Environment.NewLine;
                line = "";
            }
            Console.WriteLine(Lo.g(""));
            outMat += line + Environment.NewLine;
            return outMat;
        }
        public static string Matrix(int[,] matrix, string name)
        {
            string outMat = "";
            string line = "";
            int i_y = matrix.GetLength(0);
            int i_x = matrix.GetLength(1);
            if ((i_y == 0) || (i_x == 0))
                Console.WriteLine(Lo.g("Cant print empty matrix"));

            Console.WriteLine(Lo.g(name));

            for (int y = 0; y < i_y; ++y)
            {
                for (int x = 0; x < i_x; ++x)
                {
                    line += $"{matrix[y, x]} ";
                }
                Console.WriteLine(Lo.g(line));
                outMat += line + Environment.NewLine;
                line = "";
            }
            Console.WriteLine(Lo.g(""));
            outMat += line + Environment.NewLine;
            return outMat;
        }
    }
}
