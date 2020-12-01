using System;
using System.Collections.Generic;
using System.ComponentModel;
using LiveCharts.Defaults;
using LiveCharts.Geared;

namespace Geared.Wpf.Scrollable
{
    public class ScrollableViewModel : INotifyPropertyChanged
    {
        private Func<double, string> _formatter;
        private double _from;
        private double _to;

        public ScrollableViewModel()
        {
            var now = DateTime.Now;
            int[] trend = new[]
            {
                15000 * 3, 15000 * 1, 15000 * 3, 15000 * 4, 15000 * 4, 15000 * 22, 15000 * 12, 15000 * 13, 15000 * 14,
                15000 * 2, 15000 * 1, 15000 * 3, 15000 * 0, 15000 * 2, 15000 * 6, 15000 * 1, 15000 * 11, 15000 * 42,
                15000 * 42, 15000 * 24, 15000 * 42, 15000 * 21, 15000 * 23, 15000 * 21, 15000 * 12, 15000 * 32,
                15000 * 21, 15000 * 32, 15000 * 20
            };
            var l = new List<DateTimePoint>();
            var r = new Random();

            for (var i = 0; i < trend.Length; i++)
            {
                now = now.AddHours(1);
                l.Add(new DateTimePoint(now.AddDays(i), trend[i]));
            }

            Formatter = x => new DateTime((long) x).ToString("yyyy");

            Values = l.AsGearedValues().WithQuality(Quality.High);

            From = DateTime.Now.AddHours(12).Ticks;
            To = DateTime.Now.AddHours(24).Ticks;
        }

        public object Mapper { get; set; }
        public GearedValues<DateTimePoint> Values { get; set; }

        public double From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged("From");
            }
        }

        public double To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged("To");
            }
        }

        public Func<double, string> Formatter
        {
            get { return _formatter; }
            set
            {
                _formatter = value;
                OnPropertyChanged("Formatter");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}