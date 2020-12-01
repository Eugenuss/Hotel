using System;

namespace HotelAIS
{
    public class Guests
    {
        public Guests(string f_name, string s_name, string t_name, int series, int number, DateTime arrivalDate, 
            DateTime outDate)
        {
            this.f_name = f_name;
            this.s_name = s_name;
            this.t_name = t_name;
            this.series = series;
            this.number = number;
            this.arrivalDate = arrivalDate;
            this.outDate = outDate;

        }

        public string f_name { get; set; }
        public string s_name { get; set; }
        public string t_name { get; set; }
        public int series { get; set; }
        public int number { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime outDate { get; set; }
    }
}