using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMExtension.Xamarin.Component
{
    public class DateType
    {
        public int Year = 1390;
        public int Month = 1;
        public int Day = 1;
        public int Hour = 0;
        public int Minute = 0;
        public int Second = 0;
        private Date MyDateLib = new Date();
        private CalendarType _calendar = CalendarType.Shamsi;

        /// <summary>
        /// A date of type DateType can shows in three ways. Gregorian calendar, Shamsi calendar, Hijri calendar. Change calendar to convert.
        /// </summary>
        public CalendarType Calendar
        {
            get
            {
                return _calendar;
            }
            set
            {
                if (_calendar != value)
                {
                    switch (_calendar)
                    {
                        case CalendarType.Shamsi:
                            {
                                if (value == CalendarType.Miladi)
                                {
                                    DateType Temp = MyDateLib.ShamsiToMiladi(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                else if (value == CalendarType.Ghamari)
                                {
                                    DateType Temp = MyDateLib.ShamsiToGhamari(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                break;
                            }

                        case CalendarType.Miladi:
                            {
                                if (value == CalendarType.Shamsi)
                                {
                                    DateType Temp = MyDateLib.MiladiToShamsi(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                else if (value == CalendarType.Ghamari)
                                {
                                    DateType Temp = MyDateLib.MiladiToGhamari(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                break;
                            }

                        case CalendarType.Ghamari:
                            {
                                if (value == CalendarType.Shamsi)
                                {
                                    DateType Temp = MyDateLib.GhamariToShamsi(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                else if (value == CalendarType.Miladi)
                                {
                                    DateType Temp = MyDateLib.GhamariToMiladi(this.Year, this.Month, this.Day);
                                    Year = Temp.Year;
                                    Month = Temp.Month;
                                    Day = Temp.Day;
                                }
                                break;
                            }
                    }

                    _calendar = value;
                }
            }
        }

        public DateType(int Year, int Month, int Day)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
        }

        /// <summary>
        /// Costractor
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public DateType(int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            if (Year < 1000 || Year > 3000)
            {
                throw new Exception("سال در بازه مجاز نیست");
            }
            if (Month < 1 || Month > 12)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }
            if (Day < 1 || Day > 31)
            {
                throw new Exception("روز در بازه مجاز نیست");
            }

            if (Hour < 0 || Hour > 23)
            {
                throw new Exception("ساعت در بازه مجاز نیست");
            }
            if (Minute < 0 || Minute > 59)
            {
                throw new Exception("دقیقه در بازه مجاز نیست");
            }
            if (Second < 0 || Second > 59)
            {
                throw new Exception("ثانیه در بازه مجاز نیست");
            }

            this.Year = Year;
            this.Month = Month;
            this.Day = Day;

            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        /// <param name="calendar"></param>
        public DateType(int Year, int Month, int Day, int Hour, int Minute, int Second, CalendarType calendar)
        {
            if (Year < 1000 || Year > 3000)
            {
                throw new Exception("سال در بازه مجاز نیست");
            }
            if (Month < 1 || Month > 12)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }
            if (Day < 1 || Day > 31)
            {
                throw new Exception("روز در بازه مجاز نیست");
            }

            if (Hour < 0 || Hour > 23)
            {
                throw new Exception("ساعت در بازه مجاز نیست");
            }
            if (Minute < 0 || Minute > 59)
            {
                throw new Exception("دقیقه در بازه مجاز نیست");
            }
            if (Second < 0 || Second > 59)
            {
                throw new Exception("ثانیه در بازه مجاز نیست");
            }

            this.Year = Year;
            this.Month = Month;
            this.Day = Day;

            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;

            _calendar = calendar;
        }

        public DateType(int Year, int Month, int Day, CalendarType calendar)
        {
            if (Year < 1000 || Year > 3000)
            {
                throw new Exception("سال در بازه مجاز نیست");
            }
            if (Month < 1 || Month > 12)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }
            if (Day < 1 || Day > 31)
            {
                throw new Exception("روز در بازه مجاز نیست");
            }

            this.Year = Year;
            this.Month = Month;
            this.Day = Day;

            _calendar = calendar;
        }

        public DateType(DateType Date)
        {
            this.Year = Date.Year;
            this.Month = Date.Month;
            this.Day = Date.Day;
            _calendar = Date._calendar;
        }

        public DateType(DateTime Date)
        {
            this.Year = Date.Year;
            this.Month = Date.Month;
            this.Day = Date.Day;

            this.Hour = Date.Hour;
            this.Minute = Date.Minute;
            this.Second = Date.Second;

            _calendar = CalendarType.Miladi;
        }

        public DateType(string Date, CalendarType Calendar = CalendarType.Shamsi)
        {
            if (!string.IsNullOrEmpty(Date))
            {
                Date = Date.Trim();

                if (MyDateLib.IsDate(Date, MyDateLib.ConvertCalendarToGlobalization(Calendar)))
                {
                    string[] DateArray = new string[3];
                    DateArray = Date.Split('/');

                    Year = int.Parse(DateArray[0]);
                    Month = int.Parse(DateArray[1]);
                    Day = int.Parse(DateArray[2]);

                    _calendar = Calendar;
                }
            }
        }

        public DateType()
        { }

        /// <summary>
        /// Returns a date in string format with optional seperator
        /// </summary>
        /// <param name="Seperator">A character for using between day and month and year</param>
        /// <returns>
        /// Date in string format
        /// </returns>
        public string GetDateString(char Seperator)
        {
            return this.Year.ToString() + Seperator + AdditionalStrings.CompleteNumber(this.Month, 2) + Seperator + AdditionalStrings.CompleteNumber(this.Day, 2);
        }

        /// <summary>
        /// Returns a date and time in string format with optional seperator for date and time
        /// </summary>
        /// <param name="DateSeperator">
        /// A character for using between day and month and year
        /// </param>
        /// <param name="TimeSeperator">
        /// A character for using between hour and minute and second
        /// </param>
        /// <param name="IncludeSeconds">
        /// If true, second will display in string
        /// </param>
        /// <returns></returns>
        public string GetDateTimeString(char DateSeperator, char TimeSeperator, bool IncludeSeconds = true)
        {
            string DateString = this.Year.ToString() + DateSeperator + AdditionalStrings.CompleteNumber(this.Month, 2) + DateSeperator + AdditionalStrings.CompleteNumber(this.Day, 2);
            string TimeString = AdditionalStrings.CompleteNumber(Hour, 2) + TimeSeperator + AdditionalStrings.CompleteNumber(Minute, 2);
            if (IncludeSeconds)
            {
                TimeString += TimeSeperator + AdditionalStrings.CompleteNumber(Second, 2);
            }
            return TimeString + "  " + DateString;
        }

        public static bool operator ==(DateType DT1, DateType DT2)
        {
            try
            {
                var temp1 = DT1.Calendar;
                var temp2 = DT2.Calendar;

                DT1.Calendar = CalendarType.Miladi;
                DT2.Calendar = CalendarType.Miladi;

                var Answer = false;

                if (DT1.Day == DT2.Day && DT1.Month == DT2.Month && DT1.Year == DT2.Year)
                {
                    Answer = true;
                }

                DT1.Calendar = temp1;
                DT2.Calendar = temp2;

                return Answer;
            }
            catch
            {
                return false;
            }
        }

        public static bool operator !=(DateType DT1, DateType DT2)
        {
            try
            {
                var temp1 = DT1.Calendar;
                var temp2 = DT2.Calendar;

                DT1.Calendar = CalendarType.Miladi;
                DT2.Calendar = CalendarType.Miladi;

                var Answer = true;

                if (DT1.Day == DT2.Day && DT1.Month == DT2.Month && DT1.Year == DT2.Year)
                {
                    Answer = false;
                }

                DT1.Calendar = temp1;
                DT2.Calendar = temp2;

                return Answer;
            }
            catch
            {
                return false;
            }
        }

        public static bool operator >(DateType DT1, DateType DT2)
        {
            try
            {
                var temp1 = DT1.Calendar;
                var temp2 = DT2.Calendar;

                DT1.Calendar = CalendarType.Miladi;
                DT2.Calendar = CalendarType.Miladi;

                var Answer = false;

                if (DT1.Year > DT2.Year)
                {
                    Answer = true;
                }
                else if(DT1.Year == DT2.Year && DT1.Month > DT2.Month)
                {
                    Answer = true;
                }
                else if(DT1.Year == DT2.Year && DT1.Month == DT2.Month && DT1.Day > DT2.Day)
                {
                    Answer = true;
                }

                DT1.Calendar = temp1;
                DT2.Calendar = temp2;

                return Answer;
            }
            catch
            {
                return false;
            }
        }

        public static bool operator <(DateType DT1, DateType DT2)
        {
            try
            {
                var temp1 = DT1.Calendar;
                var temp2 = DT2.Calendar;

                DT1.Calendar = CalendarType.Miladi;
                DT2.Calendar = CalendarType.Miladi;

                var Answer = false;

                if (DT1.Year < DT2.Year)
                {
                    Answer = true;
                }
                else if (DT1.Year == DT2.Year && DT1.Month < DT2.Month)
                {
                    Answer = true;
                }
                else if (DT1.Year == DT2.Year && DT1.Month == DT2.Month && DT1.Day < DT2.Day)
                {
                    Answer = true;
                }

                DT1.Calendar = temp1;
                DT2.Calendar = temp2;

                return Answer;
            }
            catch
            {
                return false;
            }
        }

        public static bool operator >=(DateType DT1, DateType DT2)
        {
            try
            {
                if(DT1 > DT2 || DT1 == DT2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool operator <=(DateType DT1, DateType DT2)
        {
            try
            {
                if (DT1 < DT2 || DT1 == DT2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
