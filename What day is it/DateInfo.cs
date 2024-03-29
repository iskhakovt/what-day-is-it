﻿/*************************************************
 *                                               *
 *     What day is it?                           *
 *                                               *
 *     Author: Timur Iskhakov                    *
 *     E-mail: iskhakovt@gmail.com               *
 *                                               *
 *************************************************/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What_day_is_it
{
    public static class DateInfo
    {
        #region Public analyse

        public static String getInformation(DateTime Date)
        {
            if (!Data.ImportantDateExists && !Data.AnoterBirthdayExists && !Data.YourBirthdayExists)
            {
                String shortResult = Vocabulary.noInfo() + Environment.NewLine;

                Holidays.HolidayEvent shortGetHoliday = Holidays.findHoliday(Date);

                if (shortGetHoliday.Holiday != Holidays.HolidayType.None)
                {
                    shortResult += Vocabulary.holidayText(shortGetHoliday) + Environment.NewLine;
                }

                if (Date.Month == monthFebruary)
                {
                    if (Date.Day > (dayMen - daysAlert) && Date.Day < (dayMen - 1))
                    {
                        shortResult += Vocabulary.menDay(dayMen - Date.Day) + Environment.NewLine;
                    }

                    if (Date.Day > (dayValentine - daysAlert) && Date.Day < (dayValentine - 1))
                    {
                        shortResult += Vocabulary.valentine(dayValentine - Date.Day) + Environment.NewLine;
                    }
                }

                if (Date.Month == monthMarch)
                {
                    if (Date.Day > (dayWomen - daysAlert) && Date.Day < (dayWomen - 1))
                    {
                        shortResult += Vocabulary.womenDay(dayWomen - Date.Day) + Environment.NewLine;
                    }
                }


                return shortResult;
            }

            String result = String.Empty;

            if (Data.ImportantDateExists)
            {
                result += getDateInfo(Date);

                Warning dayInfo = analyseNum(Diff(Data.ImportantDate, Date));

                if (dayInfo != Warning.None)
                {
                    result += Vocabulary.Analyse(dayInfo) + Environment.NewLine;
                }

                if (Date != Data.ImportantDate && (Date - Data.ImportantDate).Days < maxDaysInMonth)
                {
                    if (Date.Month == Data.ImportantDate.Month || (Date.Day < Data.ImportantDate.Day))
                    {
                        result += Vocabulary.lessMonth() + Environment.NewLine;
                    }
                }

                String microInfo;

                microInfo = hoursAnalyse(Date);
                if (microInfo != String.Empty)
                {
                    result += microInfo + Environment.NewLine;
                }

                microInfo = minutesAnalyse(Date);
                if (microInfo != String.Empty)
                {
                    result += microInfo + Environment.NewLine;
                }

                microInfo = secondsAnalyse(Date);
                if (microInfo != String.Empty)
                {
                    result += microInfo + Environment.NewLine;
                }
            }

            if (Data.AnoterBirthdayExists)
            {
                if (Diff(Data.AnoterBirthday, Date) < 0)
                {
                    result += Vocabulary.noPartnerYet() + Environment.NewLine;
                }
                else
                {
                    DateTime toBirthday = Data.AnoterBirthday;

                    while (toBirthday.Year != Date.Year)
                    {
                        toBirthday = toBirthday.AddYears(1);
                    }

                    Int32 diff = Diff(Date, toBirthday);

                    if (diff > daysAlertBirthday && diff < daysAlert)
                    {
                        result += Vocabulary.birthday(diff) + Environment.NewLine;
                    }
                }
            }

            Holidays.HolidayEvent getHoliday = Holidays.findHoliday(Date);

            if (getHoliday.Holiday != Holidays.HolidayType.None)
            {
                result += Vocabulary.holidayText(getHoliday) + Environment.NewLine;
            }

            if (Date.Month == monthFebruary)
            {
                if (Date.Day > (dayMen - daysAlert) && Date.Day < (dayMen - 1))
                {
                    result += Vocabulary.menDay(dayMen - Date.Day) + Environment.NewLine;
                }

                if (Date.Day > (dayValentine - daysAlert) && Date.Day < (dayValentine - 1))
                {
                    result += Vocabulary.valentine(dayValentine - Date.Day) + Environment.NewLine;
                }
            }

            if (Date.Month == monthMarch)
            {
                if (Date.Day > (dayWomen - daysAlert) && Date.Day < (dayWomen - 1))
                {
                    result += Vocabulary.womenDay(dayWomen - Date.Day) + Environment.NewLine;
                }
            }

            if (Data.YourBirthdayExists)
            {
                if (Diff(Data.YourBirthday, Date) < 0)
                {
                    result += Vocabulary.noYouYet() + Environment.NewLine;
                }
                else
                {
                    DateTime toBirthday = Data.YourBirthday;

                    while (toBirthday.Year != Date.Year)
                    {
                        toBirthday = toBirthday.AddYears(1);
                    }

                    Int32 diff = Diff(Date, toBirthday);

                    if (Math.Abs(diff) < daysYourAlert)
                    {
                        result += Vocabulary.yourBirthday(diff) + Environment.NewLine;
                    }
                }
            }

            return result;
        }

        public static String getCloseInformation(DateTime Date)
        {
            String result = String.Empty;

            if (Data.ImportantDateExists)
            {
                if (Date.Day == Data.ImportantDate.Day)
                {
                    Int32 yearDiff = Date.Year - Data.ImportantDate.Year;

                    if (Date.Month == Data.ImportantDate.Month)
                    {
                        result += Vocabulary.exactYears(yearDiff);
                    }
                    else
                    {
                        Int32 monthDiff = (Date.Month - Data.ImportantDate.Month) + yearDiff * 12;
                        result += Vocabulary.exactMonth(monthDiff);
                    }
                }

                DateInfo.Warning info = DateInfo.analyseNum(DateInfo.Diff(Data.ImportantDate, Date));

                if (info != DateInfo.Warning.None)
                {
                    result += Vocabulary.countDaysTime(DateInfo.Diff(Data.ImportantDate, Date));
                    result += Vocabulary.Analyse(info);
                }

                result += hoursAnalyse(Date);
                result += minutesAnalyse(Date);
                result += secondsAnalyse(Date);
            }

            if (Data.AnoterBirthdayExists && DateInfo.Diff(Date, Data.AnoterBirthday) >= 0)
            {
                DateTime toBirthday = Data.AnoterBirthday;

                while (toBirthday.Year != Date.Year)
                {
                    toBirthday = toBirthday.AddYears(1);
                }

                Int32 diff = DateInfo.Diff(Date, toBirthday);

                if (diff == 0)
                {
                    result += Vocabulary.birthday();
                }
            }

            Holidays.HolidayEvent getHoliday = Holidays.findHoliday(Date);

            if (getHoliday.Holiday != Holidays.HolidayType.None && getHoliday.Today)
            {
                result += Vocabulary.holidayText(getHoliday);
            }

            if (Data.YourBirthdayExists && DateInfo.Diff(Date, Data.YourBirthday) >= 0)
            {
                DateTime toBirthday = Data.YourBirthday;

                while (toBirthday.Year != Date.Year)
                {
                    toBirthday = toBirthday.AddYears(1);
                }

                Int32 diff = DateInfo.Diff(Date, toBirthday);

                if (diff == 0)
                {
                    result += Vocabulary.yourBirthday();
                }
            }

            return result;
        }

        private static String getDateInfo(DateTime Date)
        {
            if (!Data.ImportantDateExists)
            {
                throw new Exception("getDateInfo was called, but ImportantDate doesn't exist");
            }

            String result = String.Empty;

            Int32 days = Diff(Data.ImportantDate, Date);

            if (days == 0)
            {
                return Vocabulary.gotPartner() + Environment.NewLine;
            }
            else if (days < 0)
            {
                return Vocabulary.noPartner() + Environment.NewLine;
            }

            result += Vocabulary.countDaysTime(days) + Environment.NewLine;

            if (days < daysEnough)
            {
                return result;
            }

            if (Date.Day == Data.ImportantDate.Day)
            {
                Int32 yearDiff = Date.Year - Data.ImportantDate.Year;

                if (Date.Month == Data.ImportantDate.Month)
                {
                    result += Vocabulary.exactYears(yearDiff) + Environment.NewLine;
                }
                else
                {
                    Int32 monthDiff = (Date.Month - Data.ImportantDate.Month) + yearDiff * monthInYear;
                    result += Vocabulary.exactMonth(monthDiff) + Environment.NewLine;
                }
            }

            return result;
        }

        #endregion

        #region Micro analyse

        private static String hoursAnalyse(DateTime Date)
        {
            String result = String.Empty;

            if (Diff(Data.ImportantDate, Date) >= daysEnough)
            {
                DateTime tryFind = Date;
                Boolean found = false;

                while (!found && tryFind.Day == Date.Day)
                {
                    tryFind = tryFind.AddHours(1);

                    TimeSpan difference = tryFind - Data.ImportantDate;

                    Int32 hoursDiff = difference.Hours;
                    hoursDiff += Diff(Data.ImportantDate, tryFind) * hoursInDay;

                    Warning hoursInfo = analyseNum(hoursDiff);

                    if (enoughForHour(hoursInfo) || hoursInfo == Warning.EqualSymbols)
                    {
                        result += tryFind.ToLongTimeString() + moreMicroInfo + Environment.NewLine;
                        result += Vocabulary.countHoursTime(hoursDiff) + Vocabulary.Analyse(hoursInfo);
                        found = true;
                    }
                }
            }

            return result;
        }

        private static String minutesAnalyse(DateTime Date)
        {
            String result = String.Empty;

            if (Diff(Data.ImportantDate, Date) >= daysEnough)
            {
                DateTime tryFind = Date;
                Boolean found = false;

                while (!found && tryFind.Day == Date.Day)
                {
                    tryFind = tryFind.AddMinutes(1);

                    TimeSpan difference = tryFind - Data.ImportantDate;

                    Int32 minutesDiff =  difference.Minutes + difference.Hours * minutesInHour;
                    minutesDiff += Diff(Data.ImportantDate, tryFind) * hoursInDay * minutesInHour;

                    Warning minutesInfo = analyseNum(minutesDiff);

                    if (enoughForMinute(minutesInfo) || minutesInfo == Warning.EqualSymbols)
                    {
                        result += tryFind.ToLongTimeString() + moreMicroInfo + Environment.NewLine;
                        result += Vocabulary.countMinutesTime(minutesDiff) + Vocabulary.Analyse(minutesInfo);
                        found = true;
                    }
                }
            }

            return result;
        }

        private static String secondsAnalyse(DateTime Date)
        {
            String result = String.Empty;

            if (Diff(Data.ImportantDate, Date) >= daysEnough)
            {
                DateTime tryFind = Date;
                Boolean found = false;

                while (!found && tryFind.Day == Date.Day)
                {
                    tryFind = tryFind.AddSeconds(1);

                    TimeSpan difference = tryFind - Data.ImportantDate;

                    Int32 secondsDiff = difference.Seconds + difference.Minutes * secondsInMinute + difference.Hours * minutesInHour * secondsInMinute;
                    secondsDiff += Diff(Data.ImportantDate, tryFind) * hoursInDay * minutesInHour * secondsInMinute;

                    Warning secondsInfo = analyseNum(secondsDiff);

                    if (enoughForSecond(secondsInfo) || secondsInfo == Warning.EqualSymbols)
                    {
                        result += tryFind.ToLongTimeString() + moreMicroInfo + Environment.NewLine;
                        result += Vocabulary.countSecondsTime(secondsDiff) + Vocabulary.Analyse(secondsInfo);
                        found = true;
                    }
                }
            }

            return result;
        }

        private static Boolean enoughForHour(Warning info)
        {
            return (enoughForMinute(info) || info == Warning.DivTenThousand || info == Warning.DivThousand);
        }

        private static Boolean enoughForMinute(Warning info)
        {
            return (enoughForSecond(info) || info == Warning.DivHundredThousand);
        }

        private static Boolean enoughForSecond(Warning info)
        {
            return (info == Warning.DivBillion || info == Warning.DivHundredMillion || info == Warning.DivTenMillion || info == Warning.DivMillion);
        }

        #endregion

        private static Int32 Diff(DateTime First, DateTime Second)
        {
            return (Second - First).Days;
        }

        #region Numbers analyse

        public enum Warning { DivBillion, DivHundredMillion, DivTenMillion, DivMillion, DivHundredThousand, DivTenThousand, DivThousand, DivHundred, EqualSymbols, Symmetric, EqualDiff, None };

        private static Warning analyseNum(Int32 num)
        {
            if (!Data.ImportantDateExists || num < daysEnough)
            {
                return Warning.None;
            }

            if (num % billion == 0)
            {
                return Warning.DivBillion;
            }

            if (num % hundredMillion == 0)
            {
                return Warning.DivHundredMillion;
            }

            if (num % tenMillion == 0)
            {
                return Warning.DivTenMillion;
            }

            if (num % million == 0)
            {
                return Warning.DivMillion;
            }

            if (num % hundredThousand == 0)
            {
                return Warning.DivHundredThousand;
            }

            if (num % tenThousand == 0)
            {
                return Warning.DivTenThousand;
            }

            if (num % thousand == 0)
            {
                return Warning.DivThousand;
            }

            if (num % hundred == 0)
            {
                return Warning.DivHundred;
            }

            String str = num.ToString();
            Int32 Length = str.Length;

            Boolean equal = true;
            for (Int32 i = 1; i < Length && equal; ++i)
            {
                if (str[i] != str[i - 1])
                {
                    equal = false;
                }
            }

            if (equal)
            {
                return Warning.EqualSymbols;
            }

            Boolean sym = true;
            for (Int32 i = 0; i < Length / 2 && sym; ++i)
            {
                if (str[i] != str[Length - i - 1])
                {
                    sym = false;
                }
            }

            if (sym)
            {
                return Warning.Symmetric;
            }

            if (str.Length > 2)
            {
                Boolean equalDiff = true;
                Int32 diff = str[1] - str[0];

                for (Int32 i = 2; i < Length && equalDiff; ++i)
                {
                    if (str[i] - str[i - 1] != diff)
                    {
                        equalDiff = false;
                    }
                }

                if (equalDiff)
                {
                    return Warning.EqualDiff;
                }
            }

            return Warning.None;
        }

        #endregion

        #region Constants

        private static Int32 monthFebruary =        2;
        private static Int32 monthMarch =           3;
        private static Int32 dayValentine =         14;
        private static Int32 dayMen =               23;
        private static Int32 dayWomen =             8;

        private static Int32 daysAlert =            6;
        private static Int32 daysAlertBirthday =    -2;
        private static Int32 daysYourAlert =        2;
        private static Int32 daysEnough =           11;

        private static Int32 maxDaysInMonth =       31; 
        private static Int32 secondsInMinute =      60;
        private static Int32 minutesInHour =        60;
        private static Int32 hoursInDay =           24;
        private static Int32 monthInYear =          12;

        private static Int32 hundred =              100;
        private static Int32 thousand =             1000;
        private static Int32 tenThousand =          10000;
        private static Int32 hundredThousand =      100000;
        private static Int32 million =              1000000;
        private static Int32 tenMillion =           10000000;
        private static Int32 hundredMillion =       100000000;
        private static Int32 billion =              1000000000;

        private static String moreMicroInfo = ": ";

        #endregion
    }
}
