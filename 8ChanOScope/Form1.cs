using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using NationalInstruments.DAQmx;
using NationalInstruments.Restricted;

namespace _8ChanOScope
{
    public partial class Form1 : Form
    {
        AnalogMultiChannelReader reader;

        double[,] data;

        static int MAXTIME = 10;
        static int A2DMAXRATE = 250000;

        double rangeMinimum = -10;
        double rangeMaximum = 10;

        double timeint;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbDevice.Items.AddRange(DaqSystem.Local.Devices);
            cbDevice.DropDownStyle= ComboBoxStyle.DropDownList;



            nudSamNum.Maximum = 10000; //dummy maximums that will get changed later 
            nudSamRate.Maximum = 10000;

            nudSamNum.Value = 1000;     //initialize components to reasonable values
            nudSamRate.Value = 1000;
            nudLoChan.Value = 0;
            nudHiChan.Value = 0;

            cbVoltRng.SelectedIndex= 0;     //initialize drop down boxes
            cbDevice.SelectedIndex = 0;
            cbTermCon.SelectedIndex = 0;


        }

        private async void btnAcquire_Click(object sender, EventArgs e)
        {
            int lowchan = Convert.ToInt32(nudLoChan.Value);
            int hichan = Convert.ToInt32(nudHiChan.Value);

            NationalInstruments.DAQmx.Task myTask = new NationalInstruments.DAQmx.Task();
            reader = new AnalogMultiChannelReader(myTask.Stream);

            ClearGraph();

            try
            {

                int samplesPerChannel = Convert.ToInt32(nudSamNum.Value);
                double sampleRate = Convert.ToDouble(nudSamRate.Value);
                
                cbTermCon.Enabled= false;
                cbDevice.Enabled= false;
                nudHiChan.Enabled= false;
                nudLoChan.Enabled= false;
                nudSamNum.Enabled= false;
                nudSamRate.Enabled= false;
                cbVoltRng.Enabled= false;
                btnAcquire.Enabled= false;
                btnClr.Enabled= false;
                tbAcqTime.Enabled= false;
                tbAD.Enabled= false;
                

                if (cbTermCon.SelectedIndex == 0)
                {
                    for (int i = lowchan; i <= hichan; i++)
                    {
                        myTask.AIChannels.CreateVoltageChannel("Dev1/ai" + i, "aiChannel" + i, AITerminalConfiguration.Differential, rangeMinimum, rangeMaximum, AIVoltageUnits.Volts);
                    }
                }
                else if (cbTermCon.SelectedIndex == 1)
                {
                    for (int i = lowchan; i <= hichan; i++)
                    {
                        myTask.AIChannels.CreateVoltageChannel("Dev1/ai" + i, "aiChannel" + i, AITerminalConfiguration.Rse, rangeMinimum, rangeMaximum, AIVoltageUnits.Volts);
                    }
                }
                else if (cbTermCon.SelectedIndex == 2)
                {
                    for (int i = lowchan; i <= hichan; i++)
                    {
                        myTask.AIChannels.CreateVoltageChannel("Dev1/ai" + i, "aiChannel" + i, AITerminalConfiguration.Nrse, rangeMinimum, rangeMaximum, AIVoltageUnits.Volts);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error connecting to DAQ board");
                this.Close();
            }

            int samples = Convert.ToInt32(nudSamNum.Value);
            await System.Threading.Tasks.Task.Delay(1000);

            myTask.Timing.ConfigureSampleClock("", (double)nudSamRate.Value*(hichan-lowchan+1), SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, samples);

            IAsyncResult handle = reader.BeginReadMultiSample(samples, DataReady, null);

            cbTermCon.Enabled = true;
            cbDevice.Enabled = true;
            nudHiChan.Enabled = true;
            nudLoChan.Enabled = true;
            nudSamNum.Enabled = true;
            nudSamRate.Enabled = true;
            cbVoltRng.Enabled = true;
            btnClr.Enabled = true;
            btnAcquire.Enabled = true;
            tbAcqTime.Enabled = true;
            tbAD.Enabled = true;

            myTask.Dispose();
        }

        private void cbVoltRng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVoltRng.SelectedIndex == 0)
            {
                rangeMinimum = -10.0;
                rangeMaximum = 10.0;
            }
            else if (cbVoltRng.SelectedIndex == 1)
            {
                rangeMinimum = -5.0;
                rangeMaximum = 5.0;
            }
            else if (cbVoltRng.SelectedIndex == 2)
            {
                rangeMinimum = -1.0;
                rangeMaximum = 1.0;
            }
            else
            {
                rangeMinimum = -0.2;
                rangeMaximum = 0.2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void UpdateMaxMin(float samChan, float samRate)
        {
            int numChan;
            numChan = Convert.ToInt32(nudHiChan.Value - nudLoChan.Value) + 1;

            A2DMAXRATE = (Convert.ToInt32(nudHiChan.Value - nudLoChan.Value)+1) * (int)samRate;

            samRate = (int)nudSamRate.Value;
            samChan = (int)nudSamNum.Value;

            if (((samChan > 0) && (samRate > 0)) && (samChan / samRate) > 10)
            {
                nudSamNum.Maximum = 10 * (int)nudSamRate.Value;   //update the values
                nudSamRate.Maximum = (int)nudSamNum.Value / 10;
            }

            if(nudSamRate.Value > 0) tbAcqTime.Text = Convert.ToString((int)(nudSamNum.Value) / (int)(nudSamRate.Value));

            tbAD.Text = Convert.ToString(A2DMAXRATE);

        }

        private void nudSamRate_ValueChanged(object sender, EventArgs e)
        {
            float samChan = Convert.ToInt32(nudSamNum.Value);
            float samRate = Convert.ToInt32(nudSamRate.Value);
            UpdateMaxMin(samChan, samRate);
        }

        private void nudSamNum_ValueChanged(object sender, EventArgs e)
        {
            float samChan = Convert.ToInt32(nudSamNum.Value);
            float samRate = Convert.ToInt32(nudSamRate.Value);
            UpdateMaxMin(samChan, samRate);
        }

        private void nudLoChan_ValueChanged(object sender, EventArgs e)
        {
            if (nudLoChan.Value > nudHiChan.Value) nudHiChan.Value = nudLoChan.Value;
            float samChan = Convert.ToInt32(nudSamNum.Value);
            float samRate = Convert.ToInt32(nudSamRate.Value);
            UpdateMaxMin(samChan, samRate);
        }

        private void nudHiChan_ValueChanged(object sender, EventArgs e)
        {
            if (nudLoChan.Value > nudHiChan.Value) nudHiChan.Value = nudLoChan.Value;
            float samChan = Convert.ToInt32(nudSamNum.Value);
            float samRate = Convert.ToInt32(nudSamRate.Value);
            UpdateMaxMin(samChan, samRate);
        }

        public void DataReady(IAsyncResult res)
        {
            int lowchan = Convert.ToInt32(nudLoChan.Value);
            int hichan = Convert.ToInt32(nudHiChan.Value);

            for(int k = lowchan; k <= hichan; k++)
            {
                chart1.Series.Add("Channel" + k);
                chart1.Series["Channel" + k].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            data = reader.EndReadMultiSample(res);

            double[] timedat = new double[(int)nudSamNum.Value];

            timeint = ((double)(1 / nudSamRate.Value));

            for (int k = 0; k < (int)nudSamNum.Value-1; k++)
            {
                timedat[k] = k * (timeint);
            }

            if(hichan == lowchan)
            {
                for (int j = 0; j <= (int)nudSamNum.Value - 2; j++)
                {
                    chart1.Series["Channel" + hichan].Points.AddXY(timedat[j], data[0, j]);
                }
            }
            else
            {
                for (int k = lowchan; k <= hichan; k++)
                {
                    for (int j = 0; j <= (int)nudSamNum.Value - 2; j++)
                    {
                        chart1.Series["Channel" + k].Points.AddXY(timedat[j], data[k, j]);
                    }
                }
            }
 
        }

        public void ClearGraph()
        {
            int lowchan = Convert.ToInt32(nudLoChan.Value);
            int hichan = Convert.ToInt32(nudHiChan.Value);

            while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            ClearGraph();
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuHelpSel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program collects analog input samples using an NI DAQ board. " +
                "The program will collect an inputted number of samples at a user defined rate." +
                "The user can then save the data as a CSV to a currently existing or new file.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuSaveNew_Click(object sender, EventArgs e)
        {
            string fileName;

            string[] output = new string[data.Length/(int)(nudHiChan.Value - nudLoChan.Value+1) + 4];

            string datetime = Convert.ToString(DateTime.Now);



            output[0] = "date, " + DateTime.Now.ToString("d");
            output[1] = "time, " + DateTime.Now.ToString("T");
            output[2] = "# data points, " + Convert.ToString(data.Length);
            output[3] = "elapsed time";
            
            for(int i = 0; i <= nudHiChan.Value - nudLoChan.Value; i++)
            {
                output[3] = output[3] + ", " + "ch" + i;  
            }

            for(int i = 4; i < output.Length; i++)
            {
                output[i] = Convert.ToString((i-4) * timeint);
            }

            for(int i = 4; i < output.Length; i++)
            {
                for (int j = 0; j <= nudHiChan.Value - nudLoChan.Value; j++)
                {
                    output[i] = output[i] + ", " + Convert.ToString(data[j, i-4]); 
                }
            }


            saveFD.InitialDirectory = "C:\\Users\\demaysj\\Documents";
            saveFD.Title = "Save to CSV";
            saveFD.FileName = "";
            saveFD.Filter = "CSV|*.csv";

            if(saveFD.ShowDialog() != DialogResult.Cancel)
            {
                fileName = saveFD.FileName;

                System.IO.StreamWriter objWriter = new System.IO.StreamWriter(saveFD.FileName);

                for(int i = 0; i < output.Length; i++)
                {
                    objWriter.WriteLine(output[i]);
                }

                objWriter.Close();

            }


        }

        private void mnuSaveAppend_Click(object sender, EventArgs e)
        {
            string fileName;

            string[] output = new string[data.Length / (int)(nudHiChan.Value - nudLoChan.Value + 1) + 4];

            string datetime = Convert.ToString(DateTime.Now);



            output[0] = "date, " + DateTime.Now.ToString("d");
            output[1] = "time, " + DateTime.Now.ToString("T");
            output[2] = "# data points, " + Convert.ToString(data.Length);
            output[3] = "elapsed time";

            for (int i = 0; i <= nudHiChan.Value - nudLoChan.Value; i++)
            {
                output[3] = output[3] + ", " + "ch" + i;
            }

            for (int i = 4; i < output.Length; i++)
            {
                output[i] = Convert.ToString((i-4) * timeint);
            }

            for (int i = 4; i < output.Length; i++)
            {
                for (int j = 0; j <= nudHiChan.Value - nudLoChan.Value; j++)
                {
                    output[i] = output[i] + ", " + Convert.ToString(data[j, i - 4]);
                }
            }


            saveFD.InitialDirectory = "C:\\Users\\demaysj\\Documents";
            saveFD.Title = "Save to CSV";
            saveFD.FileName = "";
            saveFD.Filter = "CSV|*.csv";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                fileName = saveFD.FileName;

                System.IO.StreamWriter objWriter = new System.IO.StreamWriter(saveFD.FileName, true);

                for (int i = 0; i < output.Length; i++)
                {
                    objWriter.WriteLine(output[i]);
                }

                objWriter.Close();

            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string fileName;
            string textline = "";
            int len = 0;



            openFD.InitialDirectory = "C:\\Users\\demaysj\\Documents";
            openFD.Title = "Open a CSV";
            openFD.FileName = "";
            openFD.Filter = "CSV|*.csv";

            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                fileName = openFD.FileName;
                System.IO.StreamReader objReader = new System.IO.StreamReader(openFD.FileName);

                do
                {
                    textline = textline + objReader.ReadLine() + "\r\n";
                    len++;
                }
                while (objReader.Peek() != -1);

                string input;
                string[] alteredinput;
                string[,] data;
                int i = 0;
                do
                {
                    input = objReader.ReadLine();
                    alteredinput = input.Split(',');

                    for(int j = 0; j < alteredinput.Length; j++)
                    {
                        
                    }
                    i++;
                }
                while (objReader.Peek() != -1);



                objReader.Close();
            }
        }
    }
}
