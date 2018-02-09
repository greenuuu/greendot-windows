namespace ShadowSocks.View
{
    partial class Log
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.lblWindowTitle = new System.Windows.Forms.Label();
            this.LogMessageTextBox = new System.Windows.Forms.TextBox();
            this.trafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panLog = new System.Windows.Forms.Panel();
            this.panChart = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trafficChart)).BeginInit();
            this.panLog.SuspendLayout();
            this.panChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWindowTitle
            // 
            this.lblWindowTitle.AutoSize = true;
            this.lblWindowTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWindowTitle.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWindowTitle.ForeColor = System.Drawing.Color.White;
            this.lblWindowTitle.Location = new System.Drawing.Point(11, 10);
            this.lblWindowTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWindowTitle.Name = "lblWindowTitle";
            this.lblWindowTitle.Size = new System.Drawing.Size(92, 27);
            this.lblWindowTitle.TabIndex = 0;
            this.lblWindowTitle.Text = "运行日志";
            // 
            // LogMessageTextBox
            // 
            this.LogMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LogMessageTextBox.BackColor = System.Drawing.Color.Black;
            this.LogMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogMessageTextBox.Enabled = false;
            this.LogMessageTextBox.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.LogMessageTextBox.ForeColor = System.Drawing.Color.White;
            this.LogMessageTextBox.Location = new System.Drawing.Point(15, 9);
            this.LogMessageTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.LogMessageTextBox.MaxLength = 2147483647;
            this.LogMessageTextBox.Multiline = true;
            this.LogMessageTextBox.Name = "LogMessageTextBox";
            this.LogMessageTextBox.Size = new System.Drawing.Size(570, 261);
            this.LogMessageTextBox.TabIndex = 1;
            // 
            // trafficChart
            // 
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 5D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 61D;
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.trafficChart.ChartAreas.Add(chartArea1);
            legend1.MaximumAutoSize = 25F;
            legend1.Name = "Legend1";
            this.trafficChart.Legends.Add(legend1);
            this.trafficChart.Location = new System.Drawing.Point(0, 10);
            this.trafficChart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.trafficChart.Name = "trafficChart";
            this.trafficChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.DarkOrange;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.LegendText = "入站";
            series1.Name = "Inbound";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(197)))), ((int)(((byte)(116)))));
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.LegendText = "出站";
            series2.Name = "Outbound";
            this.trafficChart.Series.Add(series1);
            this.trafficChart.Series.Add(series2);
            this.trafficChart.Size = new System.Drawing.Size(601, 220);
            this.trafficChart.TabIndex = 2;
            // 
            // panLog
            // 
            this.panLog.BackColor = System.Drawing.Color.Black;
            this.panLog.Controls.Add(this.LogMessageTextBox);
            this.panLog.Location = new System.Drawing.Point(0, 46);
            this.panLog.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panLog.Name = "panLog";
            this.panLog.Size = new System.Drawing.Size(601, 285);
            this.panLog.TabIndex = 3;
            // 
            // panChart
            // 
            this.panChart.BackColor = System.Drawing.Color.White;
            this.panChart.Controls.Add(this.trafficChart);
            this.panChart.Location = new System.Drawing.Point(0, 327);
            this.panChart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panChart.Name = "panChart";
            this.panChart.Size = new System.Drawing.Size(601, 242);
            this.panChart.TabIndex = 4;
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 569);
            this.Controls.Add(this.panChart);
            this.Controls.Add(this.panLog);
            this.Controls.Add(this.lblWindowTitle);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Log_FormClosing);
            this.Load += new System.EventHandler(this.Log_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trafficChart)).EndInit();
            this.panLog.ResumeLayout(false);
            this.panLog.PerformLayout();
            this.panChart.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWindowTitle;
        private System.Windows.Forms.TextBox LogMessageTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart trafficChart;
        private System.Windows.Forms.Panel panLog;
        private System.Windows.Forms.Panel panChart;
    }
}