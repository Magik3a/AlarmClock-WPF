using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace budilnik_1._00.Pages
{

    /// <summary>
    /// Interaction logic for page1.xaml
    /// </summary>
    public partial class page1 : UserControl
    {
        
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public int hours = -1;
        public int minutes = -1;
        private string alarmSongUrl = "";
        private MediaPlayer mediaPlayer = new MediaPlayer();


        public page1()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);
         
            Timer.Start();
        }

        private void btnHoursUp_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Hours.Text);

            buff++;
            if (buff > 23)
            {
                buff = 0;
                this.Hours.Text = buff.ToString();
            }

            this.Hours.Text = buff.ToString();
        }

        private void btnHoursDown_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Hours.Text);
            buff--;
            if (buff < 0)
            {
                buff = 23;
                this.Hours.Text = buff.ToString();
            }

            this.Hours.Text = buff.ToString();
        }

        private void btnMinUp_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Minutes.Text);
            buff++;
            if (buff > 59)
            {
                buff = 0;
                this.Minutes.Text = buff.ToString();
            }

            this.Minutes.Text = buff.ToString();
        }

        private void btnMinDown_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Minutes.Text);
            buff--;
            if (buff < 0)
            {
                buff = 59;
                this.Minutes.Text = buff.ToString();
            }

            this.Minutes.Text = buff.ToString();
        }

        private void SetTheAllarm_Click(object sender, RoutedEventArgs e)
        {
            GetTheTime();
        }

        public void GetTheTime()
        {
            hours =int.Parse(this.Hours.Text);
            minutes = int.Parse(this.Minutes.Text);
            this.ListAlarms.Text = "";
            this.ListAlarms.Text += "Selected days: \n" + SelectedDays;
            this.ListAlarms.Text += "\n ON: " + hours + ":" + minutes;
        }


        /// <summary>
        /// Sets all toggle buttons to "off"
        /// </summary>
        public void resetControl()
        {
            tbSun.IsChecked = false;
            tbMon.IsChecked = false;
            tbTue.IsChecked = false;
            tbWed.IsChecked = false;
            tbThu.IsChecked = false;
            tbFri.IsChecked = false;
            tbSat.IsChecked = false;
        }

        /// <summary>
        /// Used to get and set selected days, is returned as comma separated string
        /// </summary>
        public string SelectedDays
        {
            get
            {
                string selected = "";
                int totalDaysSelected = 0;

                if ((bool)tbSun.IsChecked)
                {
                    selected += "Sun,";
                    totalDaysSelected++;
                }
                if ((bool)tbMon.IsChecked)
                {
                    selected += "Mon,";
                    totalDaysSelected++;
                }
                if ((bool)tbTue.IsChecked)
                {
                    selected += "Tue,";
                    totalDaysSelected++;
                }
                if ((bool)tbWed.IsChecked)
                {
                    selected += "Wed,";
                    totalDaysSelected++;
                }
                if ((bool)tbThu.IsChecked)
                {
                    selected += "Thu,";
                    totalDaysSelected++;
                }
                if ((bool)tbFri.IsChecked)
                {
                    selected += "Fri,";
                    totalDaysSelected++;
                }
                if ((bool)tbSat.IsChecked)
                {
                    selected += "Sat,";
                    totalDaysSelected++;
                }

                if (totalDaysSelected == 7)
                {
                    selected = "Every Day";
                }
                else if (totalDaysSelected == 2 && (bool)tbSun.IsChecked && (bool)tbSat.IsChecked)
                {
                    selected = "Weekend";
                }
                else if (totalDaysSelected == 5 && !(bool)tbSun.IsChecked && !(bool)tbSat.IsChecked)
                {
                    selected = "Weekdays";
                }
                return selected;
            }

            set
            {
                bool everyday = value.Contains("Every Day");
                bool weekend = value.Contains("Weekend");
                bool weekdays = value.Contains("Weekdays");
                bool sun = everyday || weekend || value.Contains("Sun");
                bool mon = everyday || weekdays || value.Contains("Mon");
                bool tue = everyday || weekdays || value.Contains("Tue");
                bool wed = everyday || weekdays || value.Contains("Wed");
                bool thu = everyday || weekdays || value.Contains("Thu");
                bool fri = everyday || weekdays || value.Contains("Fri");
                bool sat = everyday || weekend || value.Contains("Sat");

                resetControl();

                if (sun)
                {
                    tbSun.IsChecked = true;
                }
                if (mon)
                {
                    tbMon.IsChecked = true;
                }
                if (tue)
                {
                    tbTue.IsChecked = true;
                }
                if (wed)
                {
                    tbWed.IsChecked = true;
                }
                if (thu)
                {
                    tbThu.IsChecked = true;
                }
                if (fri)
                {
                    tbFri.IsChecked = true;
                    tbFri.Background = Brushes.Blue;
                }
                if (sat)
                {
                    tbSat.IsChecked = true;
                    tbSat.Background = Brushes.Blue;
                }
            }
        }

       

          


            
        
        private void Timer_Click(object sender, EventArgs e)
        {
           
            DateTime d;

            d = DateTime.Now;

            if (d.Hour == hours && d.Second < 1)
            {
                if (d.Minute == minutes)
                {
                    AlarmOnSound();
                }
              
            }
        
         

          
        }

       
           
        public void AlarmOnSound()
        {
          
            SystemSounds.Asterisk.Play();
            if (alarmSongUrl != "")
            {
                mediaPlayer.Open(new Uri(alarmSongUrl));
                mediaPlayer.Play();
               
            }
            else
            {
                ChooseSong();
            }
          
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0.5;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = true;
            da.RepeatBehavior = RepeatBehavior.Forever;
            //da.RepeatBehavior=new RepeatBehavior(3);
            this.stop.BeginAnimation(OpacityProperty, da);

           

        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = VolumeSlider.Value;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new OpenFileDialog();
            dialog.Title = "Choose Media";
            if (dialog.ShowDialog() == true)
            {
                alarmSongUrl =  dialog.FileName;
                MediaName.Text = dialog.FileName;
            }
        
        }

        private void ChooseSong()
        {
            if (MediaName.Text != "No Media" )
            {
              
            }
            else if(alarmSongUrl == "")
            {
                MessageBox.Show("Choose song or radio.");

               
            }
            else
            {
   
                mediaPlayer.Open(new Uri(alarmSongUrl));
            }
        }

       
        //private void Zrock_Click(object sender, RoutedEventArgs e)
        //{
        //    var some = this.Zrock.Content;
        //    if (some == "ON")
        //    {


        //        this.Zrock.Content = "OFF";
            
        //    }
        //    else
        //    {
        //        this.Zrock.Content = "ON";
                
        //    }
           
        //}

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
            {
                return;
            }
            var some = radioButton.Name;
            switch (some)
            {
                case "zrock": alarmSongUrl = "http://46.10.150.123:80/z-rock.mp3"; break;
                case "ednorock": alarmSongUrl = "http://149.13.0.81:80/radio1rock128"; break;
                case "JugoMania": alarmSongUrl = "http://88.80.96.25:8020/"; break;
                case "njoy": alarmSongUrl = "http://46.10.150.123:80/njoy.mp3"; break;
                case "fresh": alarmSongUrl = "http://193.108.24.21:8000/fresh"; break;
                case "energy": alarmSongUrl = "http://149.13.0.81:80/nrj128"; break;

                default: alarmSongUrl = "http://46.10.150.123:80/z-rock.mp3";
                    break;
            }
            
        }
      
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            AlarmOnSound();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
          
            mediaPlayer.Stop();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromSeconds(2));
            da.AutoReverse = true;
            da.RepeatBehavior = RepeatBehavior.Forever;
            //da.RepeatBehavior=new RepeatBehavior(3);
            this.stop.BeginAnimation(OpacityProperty, da);
            this.stop.Opacity = 0;
        }

        

       

    

    

    }
}
