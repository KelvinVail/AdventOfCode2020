using System;
using System.Globalization;

namespace Day02
{
    public abstract class PasswordBase
    {
        protected PasswordBase(string record)
        {
            Password = GetPassword(record);
            RequiredCharacter = GetRequiredCharacter(record);
            FirstNumber = GetFirstNumber(record);
            SecondNumber = GetSecondNumber(record);
        }

        protected string Password { get; }

        protected char RequiredCharacter { get; }

        protected int FirstNumber { get; }

        protected int SecondNumber { get; }

        public abstract bool IsValid();

        private static string GetPassword(string record)
        {
            if (!RecordIsValid(record)) return null;
            return record.Split(": ")[1];
        }

        private static char GetRequiredCharacter(string record)
        {
            if (!RecordIsValid(record)) return char.Parse("|");
            return char.Parse(Policy(record).Split(" ")[1]);
        }

        private static int GetFirstNumber(string record)
        {
            if (!RecordIsValid(record)) return -1;
            return int.Parse(
                Policy(record).Split(" ")[0].Split("-")[0],
                NumberStyles.Integer,
                CultureInfo.CurrentCulture);
        }

        private static int GetSecondNumber(string record)
        {
            if (!RecordIsValid(record)) return -1;
            return int.Parse(
                Policy(record).Split(" ")[0].Split("-")[1],
                NumberStyles.Integer,
                CultureInfo.CurrentCulture);
        }

        private static bool RecordIsValid(string record)
        {
            if (!record.Contains(": ", StringComparison.CurrentCulture)) return false;
            if (!record.Contains(" ", StringComparison.CurrentCulture)) return false;
            if (!record.Contains("-", StringComparison.CurrentCulture)) return false;

            return true;
        }

        private static string Policy(string record)
        {
            return record.Split(": ")[0];
        }
    }
}
