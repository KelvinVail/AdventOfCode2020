using System;
using System.Globalization;
using System.Linq;

namespace Day02
{
    public class Password
    {
        private readonly string _password;
        private readonly char _requiredCharacter;
        private readonly int _minOccurrences;
        private readonly int _maxOccurrences;

        public Password(string record)
        {
            _password = GetPassword(record);
            _requiredCharacter = RequiredCharacter(record);
            _minOccurrences = MinOccurrences(record);
            _maxOccurrences = MaxOccurrences(record);
        }

        public bool IsValid()
        {
            if (_password is null) return false;

            var occurrences = _password.Count(c => c == _requiredCharacter);

            return occurrences >= _minOccurrences && occurrences <= _maxOccurrences;
        }

        private static string GetPassword(string record)
        {
            if (!RecordIsValid(record)) return null;
            return record.Split(": ")[1];
        }

        private static char RequiredCharacter(string record)
        {
            if (!RecordIsValid(record)) return char.Parse("|");
            return char.Parse(Policy(record).Split(" ")[1]);
        }

        private static int MinOccurrences(string record)
        {
            if (!RecordIsValid(record)) return -1;
            return int.Parse(
                Policy(record).Split(" ")[0].Split("-")[0],
                NumberStyles.Integer,
                CultureInfo.CurrentCulture);
        }

        private static int MaxOccurrences(string record)
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
