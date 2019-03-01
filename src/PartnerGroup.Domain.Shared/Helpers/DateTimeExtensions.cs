using System;
using System.Linq;
using System.Collections.Generic;

namespace PartnerGroup.Domain.Shared.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime GetBrazilianTime(this DateTime dateTime)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, tzi);
        }

        public static DateTime? GetBrazilianTime(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            var tzi = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTime(Convert.ToDateTime(dateTime), tzi);
        }

        public static string GetNameOfMonth(this int month, int year)
        {
            var yearFormat = year.ToString().Substring(2, 2);

            var dictionary = new Dictionary<int, string>
            {
                {1, $"Jan/{yearFormat}"},
                {2, $"Fev/{yearFormat}"},
                {3, $"Mar/{yearFormat}"},
                {4, $"Abr/{yearFormat}"},
                {5, $"Mai/{yearFormat}"},
                {6, $"Jun/{yearFormat}"},
                {7, $"Jul/{yearFormat}"},
                {8, $"Ago/{yearFormat}"},
                {9, $"Set/{yearFormat}"},
                {10, $"Out/{yearFormat}"},
                {11, $"Nov/{yearFormat}"},
                {12, $"Dez/{yearFormat}"}
            };

            return dictionary.FirstOrDefault(x => x.Key == month).Value;
        }
    }
}
