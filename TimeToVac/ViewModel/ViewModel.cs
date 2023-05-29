using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TimeToVac.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property
        private string timeRemaining;

        public string TimeRemaining
        {
            get { return timeRemaining; }
            set
            {
                if (timeRemaining != value)
                {
                    timeRemaining = value;
                    OnPropertyChanged("TimeRemaining");
                }
            }
        }

        #endregion
       
        #region MainViewModel
        public MainViewModel()
        {

            string hour = "10";
            int hourInt = Int32.Parse(hour);

            var targetDate = new DateTime(2023, 6, 23, 10, 0, 0);
            var timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
            {
                var timeSpan = targetDate - DateTime.Now;
                TimeRemaining = FormatTimeRemaining(timeSpan);
            };

            timer.Start();
        }
        #endregion

        #region FormatTimeRemaining
        private string FormatTimeRemaining(TimeSpan timeSpan)
        {
            return $"{timeSpan.Days} dni , {timeSpan.Hours} godzin , {timeSpan.Minutes} minut, {timeSpan.Seconds} sekund";
        }

        #endregion 

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }



}



