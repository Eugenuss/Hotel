using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HotelAIS;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class StatisticFreeRooms : Window /*UserControl*/
    {
        public StatisticFreeRooms(DateTime dateFrom, DateTime dateTo)
        {
            InitializeComponent();

            try
            {
                // // Not so genius code that generate money for the day
                // double daysBetween = (dateTo - dateFrom).TotalDays; 
                // List<double> randomMoney = new List<double>();
                // Random rand = new Random();
                // for (int i = 0; i <= daysBetween; i++)
                // {
                //     randomMoney.Add(rand.Next(0, 33));
                // }
                // // Not so genius code of translate List<double> to CharValues
                // ChartValues<double> values = new ChartValues<double>();
                // for (int i = 0; i < randomMoney.Count; i++)
                // {
                //     values.Add(randomMoney[i]);
                // }
                MySqlConnect connect = new MySqlConnect();
                connect.Open();
                int idFrom, idTo;
                double daysBetween = (dateTo - dateFrom).TotalDays;
                int[] freeRoomsCount = new int[(int) daysBetween];
                for (int i = 0; i < daysBetween; i++)
                {
                    freeRoomsCount[i] = 0;
                }

                
                ChartValues<double> values = new ChartValues<double>();
                int tries = 0;
                for (int i = 0; i < daysBetween; i++)
                {
                    DataTable table = new DataTable();
                    string sql = "select FreeRoomsTotal from hotelhistory where EnterDay=\'" +
                                 dateFrom.AddDays(i).ToShortDateString() + "\'";
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, connect.conn);
                    sda.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        for (int j = 0; j < table.Rows.Count; j++)
                        {
                            freeRoomsCount[i] = Convert.ToInt32(table.Rows[0].ItemArray.GetValue(0).ToString());
                        }
                    }
                    else
                    {
                        freeRoomsCount[i] = freeRoomsCount[i - 1];
                    }
                }


                for (int j = 0; j < freeRoomsCount.Length; j++)
                {
                    values.Add(freeRoomsCount[j]);
                }

                connect.Close();

                SeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Кол-во свободных комнат.",
                        Values = values,
                        ColumnPadding=0,
                        Opacity = 0
                    }
                };

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
        private void LoginWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                Process.Start("Manual.pdf");
            }
        }
    }
}