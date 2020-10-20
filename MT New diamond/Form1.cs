using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT_New_diamond
{
    public partial class Form1 : Form
    {
        StreamWriter stdin = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void ghostButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                System.IO.File.Delete("app.apk");
                System.IO.Directory.Delete("app", true);
            }
            catch
            {

            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/00sanoj00");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/sanoj.jayathilaka1");
        }
        private void StartCmdProcess()
        {
            ProcessStartInfo pStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "start /WAIT",
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process cmdProcess = new Process
            {
                StartInfo = pStartInfo,
                EnableRaisingEvents = true,
            };

            cmdProcess.Start();
            cmdProcess.BeginErrorReadLine();
            cmdProcess.BeginOutputReadLine();
            stdin = cmdProcess.StandardInput;

            cmdProcess.OutputDataReceived += (s, evt) =>
            {
                if (evt.Data != null)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        textBox1.AppendText(evt.Data + Environment.NewLine);
                        textBox1.ScrollToCaret();
                    }));
                }
            };

            cmdProcess.ErrorDataReceived += (s, evt) =>
            {
                if (evt.Data != null)
                {
                    BeginInvoke(new Action(() =>
                    {
                        //rtbStdErr.AppendText(evt.Data + Environment.NewLine);
                        //rtbStdErr.ScrollToCaret();
                    }));
                }
            };

            cmdProcess.Exited += (s, evt) =>
            {
                // cmdProcess?.Dispose();
            };
        }

        private void ghostButton2_Click(object sender, EventArgs e)
        {
       

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select APK File";
            theDialog.Filter = "APK files|*.apk";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(theDialog.FileName.ToString());
                string filefullpath = (theDialog.FileName.ToString());
                string filename = (System.IO.Path.GetFileName(theDialog.FileName));
                string filepath = filefullpath.Replace(filename, "");
                label1.Text = filepath+filename;
                try
                {          
                    System.IO.File.Delete("app.apk");
                    System.IO.Directory.Delete("app", true);

                }
                catch
                {

                }
                finally
                {
                    File.Copy(filepath + filename,  "app.apk", true);
   
                }
                
                
            }


            
        }

        private void ghostButton3_Click(object sender, EventArgs e)
        {

            if(label1.Text.Equals("apk file path"))
            {
                MessageBox.Show("HHH");
            }
            else
            {
                string time = DateTime.Now.ToString("[HH mm ss]");
                textBox1.ForeColor = Color.GreenYellow;
                StartCmdProcess();
                stdin.WriteLine(time);
                textBox1.Text = "";
                stdin.Write("apktool d -s app.apk" + Environment.NewLine);
                stdin.Write("mkdirxml.bat" + Environment.NewLine);
                stdin.Write("apktool -f empty-framework-dir" + Environment.NewLine);
                stdin.Write("apktool b app" + Environment.NewLine);
                stdin.Write("java -jar uber.jar --apks app/dist/app.apk" + Environment.NewLine);
                stdin.Write("afterrun.bat" + Environment.NewLine);
                stdin.Write("outopen.bat" + Environment.NewLine);
                stdin.WriteLine(time);
            }

            
            
        }
        public void clean()
        {
            try
            {
                System.IO.File.Delete("app.apk");
                System.IO.Directory.Delete("app", true);
            }
            catch
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
