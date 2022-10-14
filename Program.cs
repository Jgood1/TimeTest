﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jgood1TimeTest
{
    // Time1 class definition
    public class Time1 : Object
    {
        //Time1 time;                               //private int hour;    // 0 -23
                                                    //private int minute;  // 0-59
                                                    //private int second;  // 0-59
        // remove hours, minutes and seconds 
        private int SecondsSinceMidnight;
        
        // Time1 constructor initializes instance variables to 
        // zero to set default time to midnight
        public Time1()
        {
            SetTime(0, 0, 0);
        }
        // main entry point for application

        public int Hour
        {
           
            get
            {
                return SecondsSinceMidnight / 3600;
            }
            set
            {
                SecondsSinceMidnight += 3600 * value; // ((value >= 0 && value < 24) ? value : 0);
            }
        }
        public int Minute
        {
            get
            {
                return (SecondsSinceMidnight % 3600) /60;
            }
            set
            {
                SecondsSinceMidnight += (value * 60); //((value >= 0 && value < 60) ? value : 0);
            }
        }
        public int Second
        {
            get
            {
                return (SecondsSinceMidnight % 3600) %60;
            }
            set
            {
                SecondsSinceMidnight += value; //((value >= 0 && value < 60) ? value : 0);
            }
        }
      
        public void SetTime(int hourValue, int minuteValue, int secondValue)
        {
            SecondsSinceMidnight = 0;
            this.Hour = (hourValue >= 0 && hourValue < 24) ?
              hourValue : 0;
            this.Minute = (minuteValue >= 0 && minuteValue < 60) ?
                  minuteValue : 0;
            this.Second = (secondValue >= 0 && secondValue < 60) ?
               secondValue : 0;
            
        } // end method SetTime

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", this.Hour,this.Minute, this.Second);
        }

        // convert time to standard-time (12 hour) format string
        public string ToStandardString()
        {
            return String.Format("{0}:{1:D2}:{2:D2} {3}",
               ((this.Hour == 12 || this.Hour == 0) ? 12 : this.Hour % 12),
               this.Minute, this.Second, (this.Hour < 12 ? "AM" : "PM"));
        }
   
        static void Main(string[] args)
        {
            Time1 time = new Time1();  // calls Time1 constructor
            string output;
            time.SetTime(0, 0, 0);
            // assign string representation of time to output
            output = "Initial universal time is: " +
               time.ToUniversalString() +
               "\nInitial standard time is: " +
               time.ToStandardString();

            // attempt valid time settings
            time.SetTime(12, 14, 53);

            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString();

            // attempt invalid time settings
            time.SetTime(10, 0, 0);

            output += "\n\nAfter attempting invalid settings: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();

            MessageBox.Show(output, "Testing Class Time1");

        } // end method Main

    } // end class Time1
}
