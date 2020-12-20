using System.Linq;

namespace Day02
{
    public class SledPassword : PasswordBase
    {
        public SledPassword(string record)
            : base(record)
        {
        }

        public override bool IsValid()
        {
            if (Password is null) return false;

            var occurrences = Password.Count(c => c == RequiredCharacter);

            return occurrences >= FirstNumber && occurrences <= SecondNumber;
        }
    }
}
