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
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : UserControl
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private string musicPlearUrl = "";

        public Play()
        {
            InitializeComponent();
        }

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
                case "zrock": musicPlearUrl = "http://46.10.150.123:80/z-rock.mp3"; break;
                case "ednorock": musicPlearUrl = "http://149.13.0.81:80/radio1rock128"; break;
                case "JugoMania": musicPlearUrl = "http://88.80.96.25:8020/"; break;
                case "njoy": musicPlearUrl = "http://46.10.150.123:80/njoy.mp3"; break;
                case "fresh": musicPlearUrl = "http://193.108.24.21:8000/fresh"; break;
                case "energy": musicPlearUrl = "http://149.13.0.81:80/nrj128"; break;
                case "BgRadio": musicPlearUrl = "http://149.13.0.81:80/bgradio128"; break;
                case "ClassicFm": musicPlearUrl = "http://46.10.150.123:80/classic-fm.mp3"; break;
                case "JazzFm": musicPlearUrl = "http://46.10.150.123:80/jazz-fm.mp3"; break;
                case "Melody": musicPlearUrl = "http://46.10.150.123:80/melody.mp3"; break;
                case "City": musicPlearUrl = "http://149.13.0.81:80/city64"; break;

                default: musicPlearUrl = "http://46.10.150.123:80/z-rock.mp3";
                    break;
            }

            if (musicPlearUrl == "")
            {
                MessageBox.Show("Choose a station");
            }
            else
            {
            
                this.Stream.Text = musicPlearUrl;
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
            if (musicPlearUrl != "")
            {
                mediaPlayer.Open(new Uri(musicPlearUrl));
                mediaPlayer.Play();
            }
            else
            {
                MessageBox.Show("Choose a station");
            }
         
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }



    }
}
