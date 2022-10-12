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
        private int hour;    // 0 -23
        private int minute;  // 0-59
        private int second;  // 0-59

        // Time1 constructor initializes instance variables to 
        // zero to set default time to midnight
        public Time1()
        {
            SetTime(0, 0, 0);
        }

        // Set new time value in 24-hour format. Perform validity
        // checks on the data. Set invalid values to zero.
        public void SetTime(int hourValue, int minuteValue, int secondValue)
        {
            hour = (hourValue >= 0 && hourValue < 24) ?
               hourValue : 0;
            minute = (minuteValue >= 0 && minuteValue < 60) ?
               minuteValue : 0;
            second = (secondValue >= 0 && secondValue < 60) ?
               secondValue : 0;

        } // end method SetTime

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        }

        // convert time to standard-time (12 hour) format string
        public string ToStandardString()
        {
            return String.Format("{0}:{1:D2}:{2:D2} {3}",
               ((hour == 12 || hour == 0) ? 12 : hour % 12),
               minute, second, (hour < 12 ? "AM" : "PM"));
        }
        public string ToNewString()
        {
            return String.Format("{0}", (hour * 3600) + (minute * 60) + second);
        }
        static void Main(string[] args)
        {
            Time1 time = new Time1();  // calls Time1 constructor
            string output;

            // assign string representation of time to output
            output = "Initial universal time is: " +
               time.ToUniversalString() +
               "\nInitial standard time is: " +
               time.ToStandardString() +
               "\nNew Time is : " +
               time.ToNewString();

            // attempt valid time settings
            time.SetTime(13, 27, 6);

            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString() +
               "\nNew Time after SetTime is: " +
               time.ToNewString();

            // attempt invalid time settings
            time.SetTime(99, 99, 99);

            output += "\n\nAfter attempting invalid settings: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();

            MessageBox.Show(output, "Testing Class Time1");

        } // end method Main
    } // end class Time1
}

