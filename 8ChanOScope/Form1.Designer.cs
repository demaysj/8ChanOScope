namespace _8ChanOScope
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbConfig = new System.Windows.Forms.GroupBox();
            this.lblAD = new System.Windows.Forms.Label();
            this.lblAcqTime = new System.Windows.Forms.Label();
            this.tbAD = new System.Windows.Forms.TextBox();
            this.tbAcqTime = new System.Windows.Forms.TextBox();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnAcquire = new System.Windows.Forms.Button();
            this.lblChanRng = new System.Windows.Forms.Label();
            this.lblSamNum = new System.Windows.Forms.Label();
            this.nudSamNum = new System.Windows.Forms.NumericUpDown();
            this.lblHiChan = new System.Windows.Forms.Label();
            this.lblLowChan = new System.Windows.Forms.Label();
            this.lblSamRate = new System.Windows.Forms.Label();
            this.lblTermConfig = new System.Windows.Forms.Label();
            this.lblVrange = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.nudHiChan = new System.Windows.Forms.NumericUpDown();
            this.nudLoChan = new System.Windows.Forms.NumericUpDown();
            this.nudSamRate = new System.Windows.Forms.NumericUpDown();
            this.cbTermCon = new System.Windows.Forms.ComboBox();
            this.cbVoltRng = new System.Windows.Forms.ComboBox();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.gbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiChan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoChan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamRate)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(439, 19);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(561, 408);
            this.chart1.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            title1.ForeColor = System.Drawing.Color.IndianRed;
            title1.Name = "Title1";
            title1.Text = "Voltage vs. Time";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Name = "xTitle";
            title2.Text = "Time (s)";
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title3.Name = "yTitle";
            title3.Text = "Voltage (V)";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.Titles.Add(title3);
            // 
            // gbConfig
            // 
            this.gbConfig.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbConfig.Controls.Add(this.lblAD);
            this.gbConfig.Controls.Add(this.lblAcqTime);
            this.gbConfig.Controls.Add(this.tbAD);
            this.gbConfig.Controls.Add(this.tbAcqTime);
            this.gbConfig.Controls.Add(this.btnClr);
            this.gbConfig.Controls.Add(this.btnAcquire);
            this.gbConfig.Controls.Add(this.lblChanRng);
            this.gbConfig.Controls.Add(this.lblSamNum);
            this.gbConfig.Controls.Add(this.nudSamNum);
            this.gbConfig.Controls.Add(this.lblHiChan);
            this.gbConfig.Controls.Add(this.lblLowChan);
            this.gbConfig.Controls.Add(this.lblSamRate);
            this.gbConfig.Controls.Add(this.lblTermConfig);
            this.gbConfig.Controls.Add(this.lblVrange);
            this.gbConfig.Controls.Add(this.lblDev);
            this.gbConfig.Controls.Add(this.nudHiChan);
            this.gbConfig.Controls.Add(this.nudLoChan);
            this.gbConfig.Controls.Add(this.nudSamRate);
            this.gbConfig.Controls.Add(this.cbTermCon);
            this.gbConfig.Controls.Add(this.cbVoltRng);
            this.gbConfig.Controls.Add(this.cbDevice);
            this.gbConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbConfig.Location = new System.Drawing.Point(12, 12);
            this.gbConfig.Name = "gbConfig";
            this.gbConfig.Size = new System.Drawing.Size(414, 415);
            this.gbConfig.TabIndex = 1;
            this.gbConfig.TabStop = false;
            this.gbConfig.Text = "DAQ Configuration";
            // 
            // lblAD
            // 
            this.lblAD.AutoSize = true;
            this.lblAD.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAD.Location = new System.Drawing.Point(247, 239);
            this.lblAD.Name = "lblAD";
            this.lblAD.Size = new System.Drawing.Size(79, 13);
            this.lblAD.TabIndex = 20;
            this.lblAD.Text = "A/D Rate (S/s)";
            // 
            // lblAcqTime
            // 
            this.lblAcqTime.AutoSize = true;
            this.lblAcqTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAcqTime.Location = new System.Drawing.Point(247, 195);
            this.lblAcqTime.Name = "lblAcqTime";
            this.lblAcqTime.Size = new System.Drawing.Size(94, 13);
            this.lblAcqTime.TabIndex = 19;
            this.lblAcqTime.Text = "Acquisition time (s)";
            // 
            // tbAD
            // 
            this.tbAD.Location = new System.Drawing.Point(250, 255);
            this.tbAD.Name = "tbAD";
            this.tbAD.ReadOnly = true;
            this.tbAD.Size = new System.Drawing.Size(100, 20);
            this.tbAD.TabIndex = 18;
            // 
            // tbAcqTime
            // 
            this.tbAcqTime.Location = new System.Drawing.Point(250, 211);
            this.tbAcqTime.Name = "tbAcqTime";
            this.tbAcqTime.ReadOnly = true;
            this.tbAcqTime.Size = new System.Drawing.Size(100, 20);
            this.tbAcqTime.TabIndex = 17;
            // 
            // btnClr
            // 
            this.btnClr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClr.Location = new System.Drawing.Point(233, 307);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(108, 77);
            this.btnClr.TabIndex = 16;
            this.btnClr.Text = "Clear Chart";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnAcquire
            // 
            this.btnAcquire.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcquire.Location = new System.Drawing.Point(81, 307);
            this.btnAcquire.Name = "btnAcquire";
            this.btnAcquire.Size = new System.Drawing.Size(108, 77);
            this.btnAcquire.TabIndex = 15;
            this.btnAcquire.Text = "Acquire";
            this.btnAcquire.UseVisualStyleBackColor = true;
            this.btnAcquire.Click += new System.EventHandler(this.btnAcquire_Click);
            // 
            // lblChanRng
            // 
            this.lblChanRng.AutoSize = true;
            this.lblChanRng.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblChanRng.Location = new System.Drawing.Point(22, 158);
            this.lblChanRng.Name = "lblChanRng";
            this.lblChanRng.Size = new System.Drawing.Size(84, 13);
            this.lblChanRng.TabIndex = 14;
            this.lblChanRng.Text = "Channel Range:";
            // 
            // lblSamNum
            // 
            this.lblSamNum.AutoSize = true;
            this.lblSamNum.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSamNum.Location = new System.Drawing.Point(249, 142);
            this.lblSamNum.Name = "lblSamNum";
            this.lblSamNum.Size = new System.Drawing.Size(134, 13);
            this.lblSamNum.TabIndex = 13;
            this.lblSamNum.Text = "Number Samples/Channel:";
            // 
            // nudSamNum
            // 
            this.nudSamNum.Location = new System.Drawing.Point(250, 158);
            this.nudSamNum.Name = "nudSamNum";
            this.nudSamNum.Size = new System.Drawing.Size(121, 20);
            this.nudSamNum.TabIndex = 12;
            this.nudSamNum.ValueChanged += new System.EventHandler(this.nudSamNum_ValueChanged);
            // 
            // lblHiChan
            // 
            this.lblHiChan.AutoSize = true;
            this.lblHiChan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblHiChan.Location = new System.Drawing.Point(22, 239);
            this.lblHiChan.Name = "lblHiChan";
            this.lblHiChan.Size = new System.Drawing.Size(74, 13);
            this.lblHiChan.TabIndex = 11;
            this.lblHiChan.Text = "High Channel:";
            // 
            // lblLowChan
            // 
            this.lblLowChan.AutoSize = true;
            this.lblLowChan.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblLowChan.Location = new System.Drawing.Point(22, 176);
            this.lblLowChan.Name = "lblLowChan";
            this.lblLowChan.Size = new System.Drawing.Size(72, 13);
            this.lblLowChan.TabIndex = 10;
            this.lblLowChan.Text = "Low Channel:";
            // 
            // lblSamRate
            // 
            this.lblSamRate.AutoSize = true;
            this.lblSamRate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSamRate.Location = new System.Drawing.Point(249, 86);
            this.lblSamRate.Name = "lblSamRate";
            this.lblSamRate.Size = new System.Drawing.Size(113, 13);
            this.lblSamRate.TabIndex = 9;
            this.lblSamRate.Text = "Channel Sample Rate:";
            // 
            // lblTermConfig
            // 
            this.lblTermConfig.AutoSize = true;
            this.lblTermConfig.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTermConfig.Location = new System.Drawing.Point(22, 102);
            this.lblTermConfig.Name = "lblTermConfig";
            this.lblTermConfig.Size = new System.Drawing.Size(115, 13);
            this.lblTermConfig.TabIndex = 8;
            this.lblTermConfig.Text = "Terminal Configuration:";
            // 
            // lblVrange
            // 
            this.lblVrange.AutoSize = true;
            this.lblVrange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVrange.Location = new System.Drawing.Point(249, 34);
            this.lblVrange.Name = "lblVrange";
            this.lblVrange.Size = new System.Drawing.Size(81, 13);
            this.lblVrange.TabIndex = 7;
            this.lblVrange.Text = "Voltage Range:";
            // 
            // lblDev
            // 
            this.lblDev.AutoSize = true;
            this.lblDev.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDev.Location = new System.Drawing.Point(22, 34);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(44, 13);
            this.lblDev.TabIndex = 6;
            this.lblDev.Text = "Device:";
            // 
            // nudHiChan
            // 
            this.nudHiChan.Location = new System.Drawing.Point(25, 255);
            this.nudHiChan.Name = "nudHiChan";
            this.nudHiChan.Size = new System.Drawing.Size(183, 20);
            this.nudHiChan.TabIndex = 5;
            this.nudHiChan.ValueChanged += new System.EventHandler(this.nudHiChan_ValueChanged);
            // 
            // nudLoChan
            // 
            this.nudLoChan.Location = new System.Drawing.Point(25, 192);
            this.nudLoChan.Name = "nudLoChan";
            this.nudLoChan.Size = new System.Drawing.Size(183, 20);
            this.nudLoChan.TabIndex = 4;
            this.nudLoChan.ValueChanged += new System.EventHandler(this.nudLoChan_ValueChanged);
            // 
            // nudSamRate
            // 
            this.nudSamRate.Location = new System.Drawing.Point(250, 102);
            this.nudSamRate.Name = "nudSamRate";
            this.nudSamRate.Size = new System.Drawing.Size(121, 20);
            this.nudSamRate.TabIndex = 3;
            this.nudSamRate.ValueChanged += new System.EventHandler(this.nudSamRate_ValueChanged);
            // 
            // cbTermCon
            // 
            this.cbTermCon.FormattingEnabled = true;
            this.cbTermCon.Items.AddRange(new object[] {
            "Differential",
            "RSE",
            "NRSE"});
            this.cbTermCon.Location = new System.Drawing.Point(25, 118);
            this.cbTermCon.Name = "cbTermCon";
            this.cbTermCon.Size = new System.Drawing.Size(183, 21);
            this.cbTermCon.TabIndex = 2;
            // 
            // cbVoltRng
            // 
            this.cbVoltRng.FormattingEnabled = true;
            this.cbVoltRng.Items.AddRange(new object[] {
            "+/- 10V",
            "+/- 5V",
            "+/- 1V",
            "+/- 0.2V"});
            this.cbVoltRng.Location = new System.Drawing.Point(250, 50);
            this.cbVoltRng.Name = "cbVoltRng";
            this.cbVoltRng.Size = new System.Drawing.Size(121, 21);
            this.cbVoltRng.TabIndex = 1;
            this.cbVoltRng.SelectedIndexChanged += new System.EventHandler(this.cbVoltRng_SelectedIndexChanged);
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(25, 50);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(183, 21);
            this.cbDevice.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1012, 438);
            this.Controls.Add(this.gbConfig);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.gbConfig.ResumeLayout(false);
            this.gbConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHiChan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLoChan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSamRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox gbConfig;
        private System.Windows.Forms.NumericUpDown nudHiChan;
        private System.Windows.Forms.NumericUpDown nudLoChan;
        private System.Windows.Forms.NumericUpDown nudSamRate;
        private System.Windows.Forms.ComboBox cbTermCon;
        private System.Windows.Forms.ComboBox cbVoltRng;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label lblHiChan;
        private System.Windows.Forms.Label lblLowChan;
        private System.Windows.Forms.Label lblSamRate;
        private System.Windows.Forms.Label lblTermConfig;
        private System.Windows.Forms.Label lblVrange;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label lblAD;
        private System.Windows.Forms.Label lblAcqTime;
        private System.Windows.Forms.TextBox tbAD;
        private System.Windows.Forms.TextBox tbAcqTime;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.Button btnAcquire;
        private System.Windows.Forms.Label lblChanRng;
        private System.Windows.Forms.Label lblSamNum;
        private System.Windows.Forms.NumericUpDown nudSamNum;
    }
}

