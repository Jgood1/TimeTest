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
        //Time1 time;                               //private int hour;    // 0 -23
        //private int minute;  // 0-59
        //private int second;  // 0-59
        // remove hours, minutes and seconds 
        private int SecondsSinceMidnight;
        // throws exception and does not catch it locally
        public static void ThrowExceptionWithoutCatch()
        {
            // throw exception, but do not catch it
            try
            {
                Console.WriteLine("In ThrowExceptionWithoutCatch");

                throw new Exception("Exception in ThrowExceptionWithoutCatch");
            }

            // finally executes because corresponding try executed
            finally
            {
                Console.WriteLine("Finally executed in " + "ThrowExceptionWithoutCatch");
            }

            // unreachable code; would generate logic error 
            Console.WriteLine("This will never be printed");

        } // end method ThrowExceptionWithoutCatch

        // throws exception, catches it and rethrows it
        
        public static void ThrowExceptionWithCatch()
        {
            // try block throws exception
            try
            {
                Console.WriteLine("In ThrowExceptionWithCatch");

                throw new Exception ("Invalid Time Error");
                
            }

            // catch exception thrown in try block
            catch (Exception error)
            {
                MessageBox.Show("Message: " + error.Message);
            }
           
            // finally executes because corresponding try executed
            finally
            {
                Console.WriteLine("Finally executed in ThrowExceptionWithCatch");
            }

            Console.WriteLine("End of ThrowExceptionWithCatch");

        } // end method ThrowExceptionWithCatch
        public static void DoesNotThrowException()
        {
            // try block does not throw any exceptions 
            try
            {
                Console.WriteLine("In DoesNotThrowException");
            }

            // this catch never executes -  - real applications would not catch in same function as exception was thrown
            catch
            {
                Console.WriteLine("This catch never executes");
            }

            // finally executes because corresponding try executed
            finally
            {
                Console.WriteLine("Finally executed in DoesNotThrowException");
            }

            Console.WriteLine("End of DoesNotThrowException");

        } // end method DoesNotThrowException






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
                if (value >= 0 && value < 24)
                {

                    SecondsSinceMidnight = (this.Minute * 60) + this.Second;//being set to what time is without hour current hour in seconds
                    SecondsSinceMidnight += 3600 * value; // adding new hour in seconds
                   
                    //DoesNotThrowException();

                }
                else
                {
                    ThrowExceptionWithCatch();
                }
                // ((value >= 0 && value < 24) ? value : 0);
            }
        }
        public int Minute
        {
            get
            {
                return (SecondsSinceMidnight % 3600) / 60;
            }
            set
            {
                if (value >= 0 && value <60)
                {
                    //SecondsSinceMidnight = (SecondsSinceMidnight % 3600); // subtracting current Minutes in seconds
                    SecondsSinceMidnight = (this.Hour * 3600) + (this.Second);
                    SecondsSinceMidnight += (value * 60);
                    
                    //DoesNotThrowException();

                }//((value >= 0 && value < 60) ? value : 0);
                else
                {
                    ThrowExceptionWithCatch();
                }
            }
        }
        public int Second
        {
            get
            {
                return (SecondsSinceMidnight % 3600) % 60 ;
            }
            set
            {
                if (value >= 0 && value < 60)
                {
                    SecondsSinceMidnight = (this.Minute * 60) + (this.Hour * 3600);
                    SecondsSinceMidnight += value; //((value >= 0 && value < 60) ? value : 0);
                    
                    //DoesNotThrowException();
                }
                else
                {
                    ThrowExceptionWithCatch();
                }
            }
        }

        public void SetTime(int hourValue, int minuteValue, int secondValue)
        {
            SecondsSinceMidnight = 0;
            //this.Hour = (hourValue >= 0 && hourValue < 24) ?hourValue : 0;
            if (hourValue >= 0 && hourValue < 24)
            {
                this.Hour = hourValue;
            }
            else
            {
                ThrowExceptionWithCatch();
            }
            //this.Minute = (minuteValue >= 0 && minuteValue < 60) ? minuteValue : 0;
            if (minuteValue >= 0 && minuteValue < 60)
            {
                this.Minute = minuteValue;
            }
            else
            {
                ThrowExceptionWithCatch();
            }
            //this.Second = (secondValue >= 0 && secondValue < 60) ? secondValue : 0;
            if (secondValue >= 0 && secondValue < 60)
            {
                this.Second = secondValue;
            }
            else 
            {
                ThrowExceptionWithCatch();
            }
            
        } // end method SetTime

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {
            return String.Format("{0:D2}:{1:D2}:{2:D2}", this.Hour, this.Minute, this.Second);
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
            time.SetTime(8, 14, 53);
            // append new string representations of time to output
            output += "\n\nUniversal time after SetTime is: " +
               time.ToUniversalString() +
               "\nStandard time after SetTime is: " +
               time.ToStandardString();

            // attempt invalid time settings
            time.SetTime(99,99, 99);

            output += "\n\nAfter attempting invalid settings: " +
               "\nUniversal time: " + time.ToUniversalString() +
               "\nStandard time: " + time.ToStandardString();

            MessageBox.Show(output, "Testing Class Time1");

        } // end method Main

    } // end class Time1
}
