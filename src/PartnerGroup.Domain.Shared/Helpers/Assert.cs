using System;
using System.Linq;
using System.Text;
using Flunt.Notifications;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PartnerGroup.Domain.Shared.Helpers
{
    public class Assert : Notifiable
    {
        static IList<Notification> _notification = new List<Notification>();
        public static void Add(string property, string message)
        {
            _notification.Add(new Notification(property, message));
        }

        public static IList<Notification> ListNotifications()
        {
            var Notifications = _notification;
            _notification = new List<Notification>();
            return Notifications;
        }

        public static bool IsValid()
        {
            return !_notification.Any();
        }

        public static void AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertStringNotNullOrEmpty(string stringValue, string message)
        {
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertStringNullOrEmpty(string stringValue, string message)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(stringValue))
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentNotEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentNull(object object1, string message)
        {
            if (object1 != null)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentRange(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertArgumentTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertStateFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertStateTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertDateMin(DateTime dateValue, string message)
        {
            if (dateValue == DateTime.MinValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertDateMax(DateTime dateValue, string message)
        {
            if (dateValue == DateTime.MaxValue)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertMultiple(int value, int multiple, string message)
        {
            if (value % multiple != 0)
            {
                Add(nameof(string.Empty), message);
            }
        }

        public static void AssertDateRange(DateTime startDate, DateTime endDate, bool betweenNow)
        {
            if (startDate == DateTime.MinValue || startDate == DateTime.MaxValue)
                throw new InvalidOperationException("Data inicial inválida.");
            if (endDate == DateTime.MinValue || endDate == DateTime.MaxValue)
                throw new InvalidOperationException("Data final inválida.");

            if (startDate > endDate)
                throw new InvalidOperationException("Data inicial maior que a data final.");
            if (betweenNow)
            {
                if (startDate > DateTime.Now)
                    throw new InvalidOperationException("Data inicial maior que data atual.");
                if (endDate > DateTime.Now)
                    throw new InvalidOperationException("Data final maior que data atual.");
            }
        }

        public static string ClearMask(string text, params string[] characters)
        {
            try
            {
                foreach (string Character in characters)
                {
                    text = text.Replace(Character, string.Empty);
                }
                return text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string RemoveAccents(string text, bool trim = true, bool upperCase = true)
        {
            if (trim)
            {
                text = text.Trim();
            }

            if (upperCase)
            {
                text = text.ToUpper();
            }

            var NormalizedString = text.Normalize(NormalizationForm.FormD);
            var StringBuilder = new StringBuilder();

            foreach (var c in NormalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    StringBuilder.Append(c);
                }
            }
            return StringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static void ValidateCnpj(string text, string message)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            text = text.Trim();
            text = text.Replace(".", "").Replace("-", "").Replace("/", "");

            if (text.Length != 14)
                throw new InvalidOperationException(message);

            tempCnpj = text.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            var result = text.EndsWith(digito);
            if (!result)
                throw new InvalidOperationException(message);
        }

        public static void ValidateCpf(string text, string message)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int soma;
            int resto;

            text = text.Trim();
            text = text.Replace(".", "").Replace("-", "");

            if (text.Length != 11)
                throw new InvalidOperationException(message);

            tempCpf = text.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            var result = text.EndsWith(digito);
            if (!result)
                throw new InvalidOperationException(message);
        }

        public static void ValidatePis(string text, string message)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;

            if (text.Trim().Length != 11)
                throw new InvalidOperationException(message);

            text = text.Trim();
            text = text.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(text[i].ToString()) * multiplicador[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var result = text.EndsWith(resto.ToString());
            if (!result)
                throw new InvalidOperationException(message);
        }

        public static void ValidateCep(string cep, string message)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }

            bool result = Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
            if (!result)
                throw new InvalidOperationException(message);
        }

        protected void SelfAssertArgumentEquals(object object1, object object2, string message)
        {
            Assert.AssertArgumentEquals(object1, object2, message);
        }

        protected void SelfAssertArgumentFalse(bool boolValue, string message)
        {
            Assert.AssertArgumentFalse(boolValue, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int maximum, string message)
        {
            Assert.AssertArgumentLength(stringValue, maximum, message);
        }

        protected void SelfAssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            Assert.AssertArgumentLength(stringValue, minimum, maximum, message);
        }

        protected void SelfAssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Assert.AssertArgumentMatches(pattern, stringValue, message);
        }

        protected void SelfAssertArgumentNotEmpty(string stringValue, string message)
        {
            Assert.AssertArgumentNotEmpty(stringValue, message);
        }

        protected void SelfAssertArgumentNotEquals(object object1, object object2, string message)
        {
            Assert.AssertArgumentNotEquals(object1, object2, message);
        }

        protected void SelfAssertArgumentNotNull(object object1, string message)
        {
            Assert.AssertArgumentNotNull(object1, message);
        }

        protected void SelfAssertArgumentRange(double value, double minimum, double maximum, string message)
        {
            Assert.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(float value, float minimum, float maximum, string message)
        {
            Assert.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(int value, int minimum, int maximum, string message)
        {
            Assert.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentRange(long value, long minimum, long maximum, string message)
        {
            Assert.AssertArgumentRange(value, minimum, maximum, message);
        }

        protected void SelfAssertArgumentTrue(bool boolValue, string message)
        {
            Assert.AssertArgumentTrue(boolValue, message);
        }

        protected void SelfAssertStateFalse(bool boolValue, string message)
        {
            Assert.AssertStateFalse(boolValue, message);
        }

        protected void SelfAssertStateTrue(bool boolValue, string message)
        {
            Assert.AssertStateTrue(boolValue, message);
        }

        protected void SelfAssertMultiple(int value, int multiple, string message)
        {
            Assert.AssertMultiple(value, multiple, message);
        }
    }
}
