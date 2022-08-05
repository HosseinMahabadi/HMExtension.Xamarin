using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HMExtension.Xamarin.Component
{
    public class Date
    {
        private GregorianCalendar MiladiCalendar = new GregorianCalendar();
        private PersianCalendar ShamsiCalendar = new PersianCalendar();
        private HijriCalendar GhamariCalendar = new HijriCalendar();

        public DayOfWeek GetDayOfWeekForShamsiCalendar(int ShamsiYear, int ShamsiMonth, int ShamsiDay)
        {
            if (ShamsiYear < 1000 || ShamsiYear > 3000)
            {
                throw new Exception("سال شمسی در بازه مجاز نیست");
            }

            if (ShamsiMonth < 1 || ShamsiMonth > 12)
            {
                throw new Exception("ماه شمسی در بازه مجاز نیست");
            }

            if (ShamsiDay < 1 || ShamsiDay > 31)
            {
                throw new Exception("روز در ماه شمسی در بازه مجاز نیست");
            }

            DateTime MiladiDate;

            try
            {
                MiladiDate = new DateTime(ShamsiYear, ShamsiMonth, ShamsiDay, ShamsiCalendar);
            }
            catch (Exception ex)
            {
                throw new Exception("این تاریخ غیر معتبر است");
            }

            return ShamsiCalendar.GetDayOfWeek(MiladiDate);
        }

        public DayOfWeek GetDayOfWeekForShamsiCalendar(int ShamsiYear, ShamsiMonthType ShamsiMonth, int ShamsiDay)
        {
            return GetDayOfWeekForShamsiCalendar(ShamsiYear, (int)ShamsiMonth + 1, ShamsiDay);
        }
        public string GetMonthName(int num)
        {
            switch (num)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }
            return "فروردین";
        }

        public int GetDaysCountOfMonth(int year, int month)
        {
            if (month > 12 || month < 1)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }
            else if (month > 0 && month < 7)
            {
                return 31;
            }
            else if (month > 6 && month < 12)
            {
                return 30;
            }
            else if ((year - 1391) % 4 == 0)
            {
                return 30;
            }
            else
            {
                return 29;
            }
        }

        public int GetDaysCountOfMonth(int year, ShamsiMonthType month)
        {
            return GetDaysCountOfMonth(year, (int)month + 1);
        }

        public int GetDayOfWeek(DayOfWeek Day)
        {
            switch (Day)
            {
                case DayOfWeek.Saturday:
                    return 0;
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 3;
                case DayOfWeek.Wednesday:
                    return 4;
                case DayOfWeek.Thursday:
                    return 5;
                case DayOfWeek.Friday:
                    return 6;
                default:
                    return 0;
            }
        }

        public DateType ShamsiToMiladi(int ShamsiYear, int ShamsiMonth, int ShamsiDay)
        {
            if (ShamsiYear < 1000 || ShamsiYear > 3000)
            {
                throw new Exception("سال شمسی در بازه مجاز نیست");
            }

            if (ShamsiMonth < 1 || ShamsiMonth > 12)
            {
                throw new Exception("ماه شمسی در بازه مجاز نیست");
            }

            if (ShamsiDay < 1 || ShamsiDay > 31)
            {
                throw new Exception("ماه شمسی در بازه مجاز نیست");
            }

            try
            {
                var MiladiDate = new DateTime(ShamsiYear, ShamsiMonth, ShamsiDay, ShamsiCalendar);
                return new DateType(MiladiDate.Year, MiladiDate.Month, MiladiDate.Day, CalendarType.Miladi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateType GhamariToMiladi(int GhamariYear, int GhamariMonth, int GhamariDay)
        {
            if (GhamariYear < 1000 || GhamariYear > 3000)
            {
                throw new Exception("سال قمری در بازه مجاز نیست");
            }

            if (GhamariMonth < 1 || GhamariMonth > 12)
            {
                throw new Exception("ماه قمری در بازه مجاز نیست");
            }

            if (GhamariDay < 1 || GhamariDay > 31)
            {
                throw new Exception("ماه قمری در بازه مجاز نیست");
            }

            DateTime MiladiDate;
            try
            {
                MiladiDate = new DateTime(GhamariYear, GhamariMonth, GhamariDay, GhamariCalendar);
                return new DateType(MiladiDate.Year, MiladiDate.Month, MiladiDate.Day, CalendarType.Miladi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DateType GhamariToShamsi(int GhamariYear, int GhamariMonth, int GhamariDay)
        {
            if (GhamariYear < 1000 || GhamariYear > 3000)
            {
                throw new Exception("سال قمری در بازه مجاز نیست");
            }

            if (GhamariMonth < 1 || GhamariMonth > 12)
            {
                throw new Exception("ماه قمری در بازه مجاز نیست");
            }

            if (GhamariDay < 1 || GhamariDay > 31)
            {
                throw new Exception("ماه قمری در بازه مجاز نیست");
            }

            try
            {
                DateType temp = GhamariToMiladi(GhamariYear, GhamariMonth, GhamariDay);
                return MiladiToShamsi(temp.Year, temp.Month, temp.Day);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GhamariToShamsi(string GhamariDate)
        {
            if (IsDate(GhamariDate, new HijriCalendar()))
            {
                string TempDate = this.GhamariToMiladiString(GhamariDate);
                return this.MiladiToShamsi(TempDate);
            }
            else
            {
                return null;
            }
        }

        public DateType MiladiToGhamari(int MiladiYear, int MiladiMonth, int MiladiDay)
        {
            if (MiladiYear < 1000 || MiladiYear > 3000)
            {
                throw new Exception("سال در بازه مجاز نیست");
            }

            if (MiladiMonth < 1 || MiladiMonth > 12)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }

            if (MiladiDay < 1 || MiladiDay > 31)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }

            DateTime MiladiDate = new DateTime(MiladiYear, MiladiMonth, MiladiDay);
            try
            {
                return new DateType(GhamariCalendar.GetYear(MiladiDate), GhamariCalendar.GetMonth(MiladiDate), GhamariCalendar.GetDayOfMonth(MiladiDate), CalendarType.Ghamari);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string MiladiToGhamari(string MiladiDate)
        {
            if (IsDate(MiladiDate, new GregorianCalendar()))
            {
                int Day, Month, Year;

                DateTime MD = Convert.ToDateTime(MiladiDate);

                Day = GhamariCalendar.GetDayOfMonth(MD);
                Month = GhamariCalendar.GetMonth(MD);
                Year = GhamariCalendar.GetYear(MD);

                return GetDateString(Year, Month, Day);
            }
            else
            {
                return null;
            }
        }

        public DateType MiladiToShamsi(int MiladiYear, int MiladiMonth, int MiladiDay)
        {
            if (MiladiYear < 1000 || MiladiYear > 3000)
            {
                throw new Exception("سال در بازه مجاز نیست");
            }

            if (MiladiMonth < 1 || MiladiMonth > 12)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }

            if (MiladiDay < 1 || MiladiDay > 31)
            {
                throw new Exception("ماه در بازه مجاز نیست");
            }

            DateTime MiladiDate = new DateTime(MiladiYear, MiladiMonth, MiladiDay);
            try
            {
                return new DateType(ShamsiCalendar.GetYear(MiladiDate), ShamsiCalendar.GetMonth(MiladiDate), ShamsiCalendar.GetDayOfMonth(MiladiDate), CalendarType.Shamsi);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string MiladiToShamsi(string MiladiDate)
        {
            if (IsDate(MiladiDate, new GregorianCalendar()))
            {
                int Day, Month, Year;

                DateTime MD = Convert.ToDateTime(MiladiDate);

                Day = ShamsiCalendar.GetDayOfMonth(MD);
                Month = ShamsiCalendar.GetMonth(MD);
                Year = ShamsiCalendar.GetYear(MD);

                return GetDateString(Year, Month, Day);
            }
            else
            {
                return null;
            }
        }

        public DateType ShamsiToGhamari(int ShamsiYear, int ShamsiMonth, int ShamsiDay)
        {
            if (ShamsiYear < 1000 || ShamsiYear > 3000)
            {
                throw new Exception("سال شمسی در بازه مجاز نیست");
            }

            if (ShamsiMonth < 1 || ShamsiMonth > 12)
            {
                throw new Exception("ماه شمسی در بازه مجاز نیست");
            }

            if (ShamsiDay < 1 || ShamsiDay > 31)
            {
                throw new Exception("ماه شمسی در بازه مجاز نیست");
            }

            try
            {
                DateType temp = ShamsiToMiladi(ShamsiYear, ShamsiMonth, ShamsiDay);
                return MiladiToGhamari(temp.Year, temp.Month, temp.Day);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ShamsiToGhamari(string ShamsiDate)
        {
            if (IsDate(ShamsiDate, new PersianCalendar()))
            {
                string TempDate = this.ShamsiToMiladiString(ShamsiDate);
                return this.MiladiToGhamari(TempDate);
            }
            else
            {
                return null;
            }
        }

        public string GetShamsiMonthName(int Month)
        {
            switch (Month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return null;
            }
        }

        public string GetMiladiMonthName(int Month)
        {
            switch (Month)
            {
                case 1:
                    return "ژانویه";
                case 2:
                    return "فوریه";
                case 3:
                    return "مارس";
                case 4:
                    return "آوریل";
                case 5:
                    return "مه";
                case 6:
                    return "ژوئن";
                case 7:
                    return "ژوئیه";
                case 8:
                    return "اوت";
                case 9:
                    return "سپتامبر";
                case 10:
                    return "اکتبر";
                case 11:
                    return "نوامبر";
                case 12:
                    return "دسامبر";
                default:
                    return null;
            }
        }

        public string GetGhamariMonthName(int Month)
        {
            switch (Month)
            {
                case 1:
                    return "محرم";
                case 2:
                    return "صفر";
                case 3:
                    return "ربیع‌الاول";
                case 4:
                    return "ربیع‌الثانی";
                case 5:
                    return "جمادی‌الاول";
                case 6:
                    return "جمادی‌الثانی";
                case 7:
                    return "رجب";
                case 8:
                    return "شعبان";
                case 9:
                    return "رمضان";
                case 10:
                    return "شوال";
                case 11:
                    return "ذیقعده";
                case 12:
                    return "ذیحجه";
                default:
                    return null;
            }
        }

        public string GetMiladiMonthNameForCalendar(int Year, int Month)
        {
            int LastDayOfMonth = this.GetDaysCountOfMonth(Year, Month);
            DateType TempDate1 = ShamsiToMiladi(Year, Month, 1);
            DateType TempDate2 = ShamsiToMiladi(Year, Month, LastDayOfMonth);

            string Name1 = this.GetMiladiMonthName(TempDate1.Month);
            string Name2 = this.GetMiladiMonthName(TempDate2.Month);

            if (Name1 == Name2)
            {
                return Name1;
            }
            else
            {
                return Name1 + " - " + Name2;
            }
        }

        public string GetGhamariMonthNameForCalendar(int Year, int Month)
        {
            int LastDayOfMonth = this.GetDaysCountOfMonth(Year, Month);
            DateType TempDate1 = ShamsiToGhamari(Year, Month, 1);
            DateType TempDate2 = ShamsiToGhamari(Year, Month, LastDayOfMonth);

            string Name1 = this.GetGhamariMonthName(TempDate1.Month);
            string Name2 = this.GetGhamariMonthName(TempDate2.Month);

            if (Name1 == Name2)
            {
                return Name1;
            }
            else
            {
                return Name1 + " - " + Name2;
            }
        }

        public string GetMiladiYear(int Year)
        {
            int LastMonthDays = this.GetDaysCountOfMonth(Year, 12);
            DateType TempDate1 = ShamsiToMiladi(Year, 1, 1);
            DateType TempDate2 = ShamsiToMiladi(Year, 12, LastMonthDays);

            string Year1 = TempDate1.Year.ToString();
            string Year2 = TempDate2.Year.ToString();

            if (Year1 == Year2)
            {
                return Year1;
            }
            else
            {
                return Year1 + " - " + Year2;
            }
        }

        public string GetGhamariYear(int Year)
        {
            int LastMonthDays = this.GetDaysCountOfMonth(Year, 12);
            DateType TempDate1 = ShamsiToGhamari(Year, 1, 1);
            DateType TempDate2 = ShamsiToGhamari(Year, 12, LastMonthDays);

            string Year1 = TempDate1.Year.ToString();
            string Year2 = TempDate2.Year.ToString();

            if (Year1 == Year2)
            {
                return Year1;
            }
            else
            {
                return Year1 + " - " + Year2;
            }
        }

        /*public List<DateType> ConvertCalendarDayToDateType(List<CalendarDay> CalendarDays)
        {
            try
            {
                List<DateType> Temp = new List<DateType>();
                foreach (CalendarDay CD in CalendarDays)
                {
                    Temp.Add(CD.GetDate(CalendarType.Miladi));
                }

                return Temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        /*   public List<string> ConvertCalendarDayToString(List<CalendarDay> CalendarDays)
           {
               try
               {
                   List<string> Temp = new List<string>();
                   foreach (CalendarDay CD in CalendarDays)
                   {
                       Temp.Add(CD.GetDate(CalendarType.Miladi).GetDateString('-'));
                   }

                   return Temp;
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               }
           }*/

        public string GetMiladiDateForFristDayOfShamsiYear(int ShamsiYear)
        {
            DateType MiladiDate = ShamsiToMiladi(ShamsiYear, 1, 1);
            return MiladiDate.GetDateString('-');
        }

        public string GetMiladiDateForLastDayOfShamsiYear(int ShamsiYear)
        {
            int LastMonthDays = this.GetDaysCountOfMonth(ShamsiYear, 12);
            DateType MiladiDate = ShamsiToMiladi(ShamsiYear, 12, LastMonthDays);

            return MiladiDate.GetDateString('-');
        }

        public bool IsDate(string DateString, Calendar DateCalender)
        {
            try
            {
                if (!string.IsNullOrEmpty(DateString))
                {
                    DateString = DateString.Trim();

                    if(DateString.Length < 8 || DateString.Length > 10)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                string[] DateArray = new string[3];
                DateArray = DateString.Split('/');

                DateTime temp = DateCalender.ToDateTime(int.Parse(DateArray[0]), int.Parse(DateArray[1]), int.Parse(DateArray[2]), 0, 0, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ShamsiToMiladiString(string ShamsiDate)
        {
            if (IsDate(ShamsiDate, new PersianCalendar()))
            {
                int Day, Month, Year;

                string[] DateString = new string[3];
                DateString = ShamsiDate.Split('/');

                Day = int.Parse(DateString[2]);
                Month = int.Parse(DateString[1]);
                Year = int.Parse(DateString[0]);

                DateTime Miladi = ShamsiCalendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);

                return GetDateString(Miladi.Year, Miladi.Month, Miladi.Day);
            }
            else
            {
                return null;
            };
        }

        public string GhamariToMiladiString(string GhamariDate)
        {
            if (IsDate(GhamariDate, new HijriCalendar()))
            {
                int Day, Month, Year;

                string[] DateString = new string[3];
                DateString = GhamariDate.Split('/');

                Day = int.Parse(DateString[2]);
                Month = int.Parse(DateString[1]);
                Year = int.Parse(DateString[0]);

                DateTime Miladi = GhamariCalendar.ToDateTime(Year, Month, Day, 0, 0, 0, 0);
                return GetDateString(Miladi.Year, Miladi.Month, Miladi.Day);
            }
            else
            {
                return null;
            }
        }

        public string GetDateString(int Year, int Month, int Day)
        {
            string DateString = Year.ToString() + "/";
            DateString += AdditionalStrings.CompleteNumber(Month, 2) + "/";
            DateString += AdditionalStrings.CompleteNumber(Day, 2);

            return DateString;
        }

        public string GetDateString(int Year, int Month, int Day, int Hour = -1, int Minute = -1, int Second = -1)
        {
            string DateString = Year.ToString() + "/";
            DateString += AdditionalStrings.CompleteNumber(Month, 2) + "/";
            DateString += AdditionalStrings.CompleteNumber(Day, 2);

            if (Hour > -1 && Minute > -1 && Second > -1)
            {
                DateString += " " + Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString();
            }

            return DateString;
        }

        public int GetCurrentShamsiYear()
        {
            try
            {
                DateType Temp = new DateType(DateTime.Today);
                Temp.Calendar = CalendarType.Shamsi;
                return Temp.Year;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public System.Globalization.Calendar ConvertCalendarToGlobalization(CalendarType Calendar)
        {
            switch (Calendar)
            {
                case (CalendarType.Ghamari):
                    {
                        return new System.Globalization.HijriCalendar();
                    }
                case (CalendarType.Miladi):
                    {
                        return new System.Globalization.GregorianCalendar();
                    }
                case (CalendarType.Shamsi):
                    {
                        return new System.Globalization.PersianCalendar();
                    }
                default:
                    return null;
            }
        }
    }
}
