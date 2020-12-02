using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class StatisticFreeRooms : Window/*UserControl*/
    {
        static DateTime dateFrom = Convert.ToDateTime("02.12.2020");
        static DateTime dateTo = Convert.ToDateTime("01.01.2021");
        double daysBetween = (dateTo - dateFrom).TotalDays;

        public StatisticFreeRooms()
        {
            InitializeComponent();

            // Not so genius code that generate money for the day
            List<double> randomMoney = new List<double>();
            Random rand = new Random();
            for (int i = 0; i <= daysBetween; i++)
            {
                randomMoney.Add(15000 * rand.Next(0, 33));
            }
            // Not so genius code of translate List<double> to CharValues
            ChartValues<double> values = new ChartValues<double>();
            for (int i = 0; i < randomMoney.Count; i++)
            {
                values.Add(randomMoney[i]);
            }
            
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Доход с комнат.",
                    Values = values
                }
            };

            // adding series will update and animate the chart automatically
            // SeriesCollection.Add(new ColumnSeries
            // {
            //     Title = "2016",
            //     Values = new ChartValues<double> { 11, 56, 42 }
            // });
            //
            // also adding values updates and animates the chart automatically
            // SeriesCollection[1].Values.Add(48d);

            // Genius code that find days between 2 dates (like 01.01.2020)
            List<string> dateBetween = new List<string>();
            for (int i = 0; i <= daysBetween; i++)
            {
                dateBetween.Add(dateFrom.AddDays(i).ToString().Remove(10));
            }
            Labels = dateBetween.ToArray();


            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}