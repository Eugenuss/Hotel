using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using HotelAIS;
using HotelAIS.Windows.ForDirector;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class StatisticMoney : Window
    {
        public StatisticMoney(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();

            try
            {
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                int idFrom, idTo;
                double daysBetween = (dateTo - dateFrom).TotalDays;
                int[] moneys = new int[(int) daysBetween];
                for (int i = 0; i < daysBetween; i++)
                {
                    moneys[i] = 0;
                }
            
                ChartValues<double> values = new ChartValues<double>();
                int tries = 0;
                for (int i = 0; i < daysBetween; i++)
                {
                    DataTable table = new DataTable();
                    string sql = "select Cost from hotelhistory where EnterDay=\'" +
                                 dateFrom.AddDays(i).ToShortDateString() + "\'";
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                    sda.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            moneys[i] +=  Convert.ToInt32(table.Rows[j].ItemArray.GetValue(0).ToString());
                        }
                    }
                    else
                    {
                        moneys[i] = 0;
                    }
                

                
                }
                for (int j = 0; j < moneys.Length; j++)
                {
                    values.Add(moneys[j]);
                }

                connect.Close();

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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}