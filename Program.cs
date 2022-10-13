using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time1Test
{
    // Time1 class definition
    public class Time1 : Object
    {
        //private int hour;    // 0 -23
        //private int minute;  // 0-59
        //private int second;  // 0-59
        // remove hours, minutes and seconds 
        private int SecondsSinceMidnight;
        Time1 time;
        // Time1 constructor initializes instance variables to 
        // zero to set default time to midnight
        public Time1()
        {
            SetTime(0, 0, 0);
        }



        public int Hour
        {
            get
            {
                return (SecondsSinceMidnight / 3600);
            }
            set
            {
                SecondsSinceMidnight = ((value >= 0 && value < 24) ? value : 0);
            }
        }
        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = ((value >= 0 && value < 60) ? value : 0);
            }
        }
        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                second = ((value >= 0 && value < 60) ? value : 0);
            }
        }
        // Set new time value in 24-hour format. Perform validity
        // checks on the data. Set invalid values to zero.
        public void SetTime(int hourValue, int minuteValue, int secondValue)
        {
            time.Hour = (hourValue >= 0 && hourValue < 24) ?
               hourValue : 0;
            time.Minute = (minuteValue >= 0 && minuteValue < 60) ?
               minuteValue : 0;
            time.Second = (secondValue >= 0 && secondValue < 60) ?
               secondValue : 0;

        } // end method SetTime

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", time.Hour, time.Minute, time.Second);
        }

        // convert time to standard-time (12 hour) format string
        public string ToStandardString()
        {
            return String.Format("{0}:{1:D2}:{2:D2} {3}",
               ((time.Hour == 12 || time.Hour == 0) ? 12 : time.Hour % 12),
               time.Minute, time.Second, (time.Hour < 12 ? "AM" : "PM"));
        }
        //public string ToNewString()
        //{
        //    return String.Format("{0}", (hour * 3600) + (minute * 60) + second);
        //}
        // main entry point for application
        static void Main(string[] args)
        {
            Time1 time = new Time1();  // calls Time1 constructor
            string output;

            // assign string representation of time to output
            output = "Initial universal time is: " +
               time.ToUniversalString() +
               "\nInitial standard time is: " +
               time.ToStandardString();

            // attempt valid time settings
            time.SetTime(13, 27, 6);

            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString();

            // attempt invalid time settings
            time.SetTime(99, 99, 99);

            output += "\n\nAfter attempting invalid settings: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();

            MessageBox.Show(output, "Testing Class Time1");

        } // end method Main

    } // end class Time1
}

