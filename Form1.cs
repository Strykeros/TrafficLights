using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLights
{
    public partial class TrafficLights : Form
    {
        private Timer timerSwitch = null;
        private Timer timerBlink = null;
        private int timeCounter = 0;
        

        public bool greenLight { get; set; }

        public TrafficLights()
        {
            
            InitializeComponent();
            RoundRedLight();
            RoundYellowLight();
            RoundGreenLight();
            InitializeTrafficLights();
            InitializeTimerSwitch();
            InitializeTimerBlink();
        }

        private void RoundRedLight()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, RedLight.Width - 3, RedLight.Height - 3);
            Region rg = new Region(gp);
            RedLight.Region = rg;
        }

        private void RoundYellowLight()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, YellowLight.Width - 3, YellowLight.Height - 3);
            Region rg = new Region(gp);
            YellowLight.Region = rg;
        }

        private void RoundGreenLight()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, GreenLight.Width - 3, GreenLight.Height - 3);
            Region rg = new Region(gp);
            GreenLight.Region = rg;
        }

        private void InitializeTimerSwitch()
        {
            RedLight.BackColor = Color.Red;
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }


        private void InitializeTimerBlink()
        {
            timerBlink = new Timer();
            timerBlink.Interval = 1000;
            timerBlink.Tick += new EventHandler(TimerBlink_Tick);
        }

        private void TimerBlink_Tick(object sender, EventArgs e)
        {
            if (GreenLight.BackColor == Color.Gray)
            {
                GreenLight.BackColor = Color.Green;
            }
            else
            {
                GreenLight.BackColor = Color.Gray;
            }
        }

        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            SwitchLights();
        }

        private void SwitchLights()
        {
            switch (timeCounter)
            {
                case 0:
                    RedLight.BackColor = Color.Red;
                    break;
                case 3:
                    YellowLight.BackColor = Color.Yellow;
                    //RedLight.BackColor = Color.Gray;
                    break;
                case 5:
                    RedLight.BackColor = Color.Gray;
                    YellowLight.BackColor = Color.Gray;
                    GreenLight.BackColor = Color.Green;
                    break;
                case 6:
                    timerBlink.Start();
                    break;
                case 13:
                    timerBlink.Stop();
                    YellowLight.BackColor = Color.Yellow;
                    GreenLight.BackColor = Color.Gray;
                    break;
                case 15:
                    YellowLight.BackColor = Color.Gray;
                    RedLight.BackColor = Color.Red;
                    timeCounter = -1;
                    break;
            }
            timeCounter++;
        }

        private void InitializeTrafficLights()
        {
            RedLight.BackColor = Color.Gray;
            YellowLight.BackColor = Color.Gray;
            GreenLight.BackColor = Color.Gray;
        }
    }
}


