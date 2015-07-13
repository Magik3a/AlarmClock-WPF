using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace budilnik_1._00.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public Home()
        {
            InitializeComponent();

            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();


            
        }
        private void Timer_Click(object sender, EventArgs e)
        {

            DateTime d;
            page1 child = new page1();
   

            d = DateTime.Now;

            label1.Content = d.Hour + " : " + d.Minute + " : " + d.Second;
            this.HomeAlarm.Text ="Day: " + d.Day +" "+  d.DayOfWeek + " Month: " + d.Month;

            var hours = child.hours;
            var min = child.minutes;

            if (d.Hour == hours && d.Second < 1)
            {
                if (d.Minute == min)
                {
                    child.AlarmOnSound();
                }
              
            }
        }

       
    }
}
