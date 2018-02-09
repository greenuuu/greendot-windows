using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using ShadowSocks.Controller;
using ShadowSocks.Util;
using ShadowSocks.Properties;

using MaterialSkin;
using MaterialSkin.Controls;

namespace ShadowSocks.View
{
    public partial class Log : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        long lastOffset;
        string filename;
        Timer timer;
        const int BACK_OFFSET = 65536;
        ShadowSocksController mainController;
        
        private static readonly object _lock = new object();

        #region Traffic Chart
        Queue<TrafficInfo> trafficInfoQueue = new Queue<TrafficInfo>();
        const int queueMaxLength = 60;
        long lastInbound, lastOutbound;
        long maxSpeed = 0, lastMaxSpeed = 0;
        const long minScale = 50;
        BandwidthScaleInfo bandwidthScale;
        List<float> inboundPoints = new List<float>();
        List<float> outboundPoints = new List<float>();
        TextAnnotation inboundAnnotation = new TextAnnotation();
        TextAnnotation outboundAnnotation = new TextAnnotation();
        #endregion

        public Log()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Amber900, Accent.Amber700, TextShade.WHITE);

            this.filename = Logging.LogFilePath;
            this.Icon = Icon.FromHandle(Resources.logo.GetHicon());

            this.mainController = ViewManager.instance.MainController;
            this.mainController.TrafficChanged += controller_TrafficChanged;
        }

        private void UpdateTrafficChart()
        {
            lock (_lock)
            {
                if (trafficInfoQueue.Count == 0)
                    return;

                inboundPoints.Clear();
                outboundPoints.Clear();
                maxSpeed = 0;
                foreach (var trafficInfo in trafficInfoQueue)
                {
                    inboundPoints.Add(trafficInfo.inbound);
                    outboundPoints.Add(trafficInfo.outbound);
                    maxSpeed = Math.Max(maxSpeed, Math.Max(trafficInfo.inbound, trafficInfo.outbound));
                }
                lastInbound = trafficInfoQueue.Last().inbound;
                lastOutbound = trafficInfoQueue.Last().outbound;
            }

            if (maxSpeed > 0)
            {
                lastMaxSpeed -= lastMaxSpeed / 32;
                maxSpeed = Math.Max(minScale, Math.Max(maxSpeed, lastMaxSpeed));
                lastMaxSpeed = maxSpeed;
            }
            else
            {
                maxSpeed = lastMaxSpeed = minScale;
            }

            bandwidthScale = Utils.GetBandwidthScale(maxSpeed);
            
            inboundPoints = inboundPoints.Select(p => p / bandwidthScale.unit).ToList();
            outboundPoints = outboundPoints.Select(p => p / bandwidthScale.unit).ToList();

            if (trafficChart.IsHandleCreated)
            {
                trafficChart.Series["Inbound"].Points.DataBindY(inboundPoints);
                trafficChart.Series["Outbound"].Points.DataBindY(outboundPoints);
                trafficChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##} " + bandwidthScale.unitName;
                trafficChart.ChartAreas[0].AxisY.Maximum = bandwidthScale.value;
                inboundAnnotation.AnchorDataPoint = trafficChart.Series["Inbound"].Points.Last();
                inboundAnnotation.Text = Utils.FormatBandwidth(lastInbound);
                outboundAnnotation.AnchorDataPoint = trafficChart.Series["Outbound"].Points.Last();
                outboundAnnotation.Text = Utils.FormatBandwidth(lastOutbound);
                trafficChart.Annotations.Clear();
                trafficChart.Annotations.Add(inboundAnnotation);
                trafficChart.Annotations.Add(outboundAnnotation);
            }
        }

        private void controller_TrafficChanged(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (trafficInfoQueue.Count == 0)
                {
                    for (int i = 0; i < queueMaxLength; i++)
                    {
                        trafficInfoQueue.Enqueue(new TrafficInfo(0, 0));
                    }

                    foreach (var trafficPerSecond in this.mainController.trafficPerSecondQueue)
                    {
                        trafficInfoQueue.Enqueue(new TrafficInfo(trafficPerSecond.inboundIncreasement,
                                                                 trafficPerSecond.outboundIncreasement));
                        if (trafficInfoQueue.Count > queueMaxLength)
                            trafficInfoQueue.Dequeue();
                    }
                }
                else
                {
                    var lastTraffic = this.mainController.trafficPerSecondQueue.Last();
                    trafficInfoQueue.Enqueue(new TrafficInfo(lastTraffic.inboundIncreasement,
                                                             lastTraffic.outboundIncreasement));
                    if (trafficInfoQueue.Count > queueMaxLength)
                        trafficInfoQueue.Dequeue();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateContent();
            UpdateTrafficChart();
        }

        private void InitContent()
        {
            using (StreamReader reader = new StreamReader(new FileStream(filename,
                     FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                if (reader.BaseStream.Length > BACK_OFFSET)
                {
                    reader.BaseStream.Seek(-BACK_OFFSET, SeekOrigin.End);
                    reader.ReadLine();
                }

                string line = "";
                StringBuilder appendText = new StringBuilder(1024);
                while ((line = reader.ReadLine()) != null)
                    appendText.Append(line + Environment.NewLine);

                LogMessageTextBox.AppendText(appendText.ToString());
                LogMessageTextBox.ScrollToCaret();

                lastOffset = reader.BaseStream.Position;
            }
        }

        private void UpdateContent()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(filename,
                         FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    reader.BaseStream.Seek(lastOffset, SeekOrigin.Begin);

                    string line = "";
                    bool changed = false;
                    StringBuilder appendText = new StringBuilder(128);
                    while ((line = reader.ReadLine()) != null)
                    {
                        changed = true;
                        appendText.Append(line + Environment.NewLine);
                    }

                    if (changed)
                    {
                        LogMessageTextBox.AppendText(appendText.ToString());
                        LogMessageTextBox.ScrollToCaret();
                    }

                    lastOffset = reader.BaseStream.Position;
                }
            }
            catch (FileNotFoundException)
            {
            }

            lblWindowTitle.Text = "运行日志" +
                $" [in: {Utils.FormatBytes(this.mainController.InboundCounter)}，out: {Utils.FormatBytes(this.mainController.OutboundCounter)}]";
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            timer = null;
            this.mainController.TrafficChanged -= controller_TrafficChanged;
        }

        private void Log_Load(object sender, EventArgs e)
        {
            InitContent();

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        
        private class TrafficInfo
        {
            public long inbound;
            public long outbound;

            public TrafficInfo(long inbound, long outbound)
            {
                this.inbound = inbound;
                this.outbound = outbound;
            }
        }
    }
}
