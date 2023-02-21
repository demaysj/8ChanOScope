using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            double timeint = ((double)(1 / nudSamRate.Value));

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
    }
}
