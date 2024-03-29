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
    static class Vocabulary
    {
        public static String today()
        {
            return "Между прочим, сегодня ";
        }

        public static String noInfo()
        {
            if (Data.Sex)
            {
                return "Ты ничего не указал!\nКак я могу работать?!\n";
            }
            else
            {
                return "Ты ничего не указала!\nКак я могу работать?!\n";
            }
        }

        public static String errorString()
        {
            return "Ошибка";
        }

        public static String partnerEarly()
        {
            if (Data.Sex)
            {
                return "Вы не могли начать встречаться до того, как родилась твоя девушка!";
            }
            else
            {
                return "Вы не могли начать встречаться до того, как родился твой парень!";
            }
        }

        public static String partnerExactBirthday()
        {
            if (Data.Sex)
            {
                return "Вы не могли начать встречаться в день рождения твоей девушки!";
            }
            else
            {
                return "Вы не могли начать встречаться в день рождения твоего парня!";
            }
        }

        public static String youEarly()
        {
            if (Data.Sex)
            {
                return "Вы не могли начать встречаться до того, как ты родился!";
            }
            else
            {
                return "Вы не могли начать встречаться до того, как ты родилась!";
            }
        }

        public static String yourExactBirthdayBirthday()
        {
            return "Вы не могли начать встречаться в день твоего рождения!";
        }

        public static String rememberBoy()
        {
            return "Я помню, когда у моего парня день рождения";
        }

        public static String rememberGirl()
        {
            return "Я помню, когда у моей девушки день рождения";
        }

        public static String Analyse(DateInfo.Warning warning)
        {
            switch (warning)
            {
                case DateInfo.Warning.DivBillion:
                    return "Это число делится на миллиард.\n";
                case DateInfo.Warning.DivHundredMillion:
                    return "Это число делится на сто милионов.\n";
                case DateInfo.Warning.DivTenMillion:
                    return "Это число делится на десять милионов.\n";
                case DateInfo.Warning.DivMillion:
                    return "Это число делится на миллион.\n";
                case DateInfo.Warning.DivHundredThousand:
                    return "Это число делится на сто тысяч.\n";
                case DateInfo.Warning.DivTenThousand:
                    return "Это число делится на десять тысяч.\n";
                case DateInfo.Warning.DivThousand:
                    return "Это число делится на тысячу.\n";
                case DateInfo.Warning.DivHundred:
                    return "Это число делится на сто.\n";
                case DateInfo.Warning.EqualSymbols:
                    return "Это число состоит из одинаковых цифр.\n";
                case DateInfo.Warning.Symmetric:
                    return "Это число симметрично.\n";
                case DateInfo.Warning.EqualDiff:
                    return "Это красивое число.\n";
                default:
                    return String.Empty;
            }
        }

        public static String valentine(Int32 diff = 0)
        {
            return "До для святого Валентина осталось " + diff + " " + Vocabulary.day(diff) + ".\n";
        }

        public static String menDay(Int32 diff = 0)
        {
            return "До дня защитника отечества осталось " + diff + " " + day(diff) + ".\n";
        }

        public static String womenDay(Int32 diff = 0)
        {
            return "До международного женского дня осталось " + diff + " " + day(diff) + ".\n";
        }

        public static String noPartnerYet()
        {
            if (Data.Sex)
            {
                return "Твоя девушка еще не родилась.\n";
            }
            else
            {
                return "Твой парень еще не родился.\n";
            }
        }

        public static String noYouYet()
        {
            return "Ты еще не родился.\n";
        }

        public static String yourBirthday(Int32 diff = 0)
        {
            if (diff == 0)
            {
                return "Сегодня твой день рождения!\n";
            }
            else if (diff == 1)
            {
                return "Завтра твой день рождения.\n";
            }
            else if (diff == -1)
            {
                return "Вчера был твой день рождения.\n";
            }

            throw new Exception("Birthday difference is too big");
        }

        public static String birthday(Int32 diff = 0)
        {
            if (Data.Sex)
            {
                return girlBirthday(diff);
            }
            else
            {
                return boyBirthday(diff);
            }
        }

        private static String girlBirthday(Int32 diff)
        {
            if (diff == 0)
            {
                return "Сегодня день рождения твоей девушки!\n";
            }
            else if (diff == 1)
            {
                return "Завтра день рождения твоей девушки!\n";
            }
            else if (diff == -1)
            {
                return "Вчера у твоей девушки был день рождения.\n";
            }
            else
            {
                return "День рождения твоей девушки через " + diff + " " + day(diff) + ".\n";
            }
        }

        private static String boyBirthday(Int32 diff)
        {
            if (diff == 0)
            {
                return "Сегодня день рождения твоего парня!\n";
            }
            else if (diff == 1)
            {
                return "Завтра день рождения твоего парня!\n";
            }
            else if (diff == -1)
            {
                return "Вчера у твоего парня был день рождения.\n";
            }
            else
            {
                return "День рождения твоего парня через " + diff + " " + day(diff) + ".\n";
            }
        }

        public static String gotPartner()
        {
            if (Data.Sex)
            {
                return "У тебя сегодня появилась девувшка!\n                   Поздравляю!!!\n";
            }
            else
            {
                return "У тебя сегодня появился парень!\n                Поздравляю!!!\n";
            }
        }

        public static String noPartner()
        {
            if (Data.Sex)
            {
                return "У тебя нет девушки.\n";
            }
            else
            {
                return "У тебя нет парня.\n";
            }
        }

        public static String countDaysTime(Int32 num)
        {
            return "Вы встречаетесь уже " + num + " " + day(num) + ".\n";
        }

        public static String countHoursTime(Int32 num)
        {
            return "Вы встречаетесь уже " + num + " " + hour(num) + ".\n";
        }

        public static String countMinutesTime(Int32 num)
        {
            return "Вы встречаетесь уже " + num + " " + minute(num) + ".\n";
        }

        public static String countSecondsTime(Int32 num)
        {
            return "Вы встречаетесь уже " + num + " " + second(num) + ".\n";
        }

        public static String lessMonth()
        {
         return "Это меньше месяца...\n";
        }

        public static String exactYears(Int32 num)
        {
            return "Вы встречаетесь ровно " + num + " " + year(num) + "!\n";
        }

        public static String exactMonth(Int32 num)
        {
            return "Вы встречаетесь ровно " + num + " " + month(num) + ".\n";
        }

        #region Words

        private static String year(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Year cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "лет";
            }
            else if (num % 10 == 1)
            {
                return "год";
            }
            else
            {
                return "года";
            }
        }

        private static String month(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Month cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "месяцев";
            }
            else if (num % 10 == 1)
            {
                return "месяц";
            }
            else
            {
                return "месяца";
            }
        }

        private static String day(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Day cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "дней";
            }
            else if (num % 10 == 1)
            {
                return "день";
            }
            else
            {
                return "дня";
            }
        }

        private static String hour(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Hour cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "часов";
            }
            else if (num % 10 == 1)
            {
                return "час";
            }
            else
            {
                return "часа";
            }
        }

        private static String minute(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Minute cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "минут";
            }
            else if (num % 10 == 1)
            {
                return "минута";
            }
            else
            {
                return "минуты";
            }
        }

        private static String second(Int32 num)
        {
            if (num <= 0)
            {
                throw new Exception("Vocabulary.Minute cannot work with such num: " + num);
            }

            num %= 100;

            if (num % 10 > 4 || num % 10 == 0 || num / 10 == 1)
            {
                return "секунд";
            }
            else if (num % 10 == 1)
            {
                return "секунда";
            }
            else
            {
                return "секунды";
            }
        }

        #endregion

        public static String criticalError()
        {
            return "Критическая ошибка";
        }

        public static String noAtAll()
        {
            return "Ближайших важных событий нет\n";
        }

        public static String noMore()
        {
            return "Больше важных событий нет\n";
        }

        public static String holidayText(Holidays.HolidayEvent Event)
        {
            if (Event.Holiday == Holidays.HolidayType.None)
            {
                throw new Exception("Vocabulary got None Holiday");
            }

            String result = String.Empty;

            if (Event.Today)
            {
                result = "Сегодня ";
            }
            else
            {
                result = "Завтра ";
            }

            switch (Event.Holiday)
            {
                case Holidays.HolidayType.DayOfRussia:
                    result += "день России.";
                    break;
                case Holidays.HolidayType.DayOfVictory:
                    result += "день победы.";
                    break;
                case Holidays.HolidayType.FirstOfMay:
                    result += "праздник весны и труда.";
                    break;
                case Holidays.HolidayType.MenDay:
                    result += "день защитника Отечества.";
                    break;
                case Holidays.HolidayType.NationalUnity:
                    result += "день народного единства.";
                    break;
                case Holidays.HolidayType.NewYear:
                    result += "новый год.";
                    break;
                case Holidays.HolidayType.ValentineDay:
                    result += "день святого Валентина.";
                    break;
                case Holidays.HolidayType.WomenDay:
                    result += "международный женский день.";
                    break;
            }

            result += Environment.NewLine;
            return result;
        }

        public static String soon()
        {
            return "Скоро ";
        }

        public static String contextNotifications(Boolean show)
        {
            if (show)
            {
                return "Скрыть всплывающие уведомления";
            }
            else
            {
                return "Показать всплывающие уведомления";
            }
        }

        public static String contextStartUp(Boolean startUp)
        {
            if (startUp)
            {
                return "Отключить автозапуск";
            }
            else
            {
                return "Включить автозапуск";
            }
        }
    }
}
