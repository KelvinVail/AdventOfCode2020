namespace Day02
{
    public class TobogganPassword : PasswordBase
    {
        public TobogganPassword(string record)
            : base(record)
        {
        }

        public override bool IsValid()
        {
            if (Password is null) return false;
            return OnlyOnePositionHit();
        }

        private bool OnlyOnePositionHit()
        {
            return (PositionOneHit() && !PositionTwoHit())
                || (!PositionOneHit() && PositionTwoHit());
        }

        private bool PositionOneHit()
        {
            if (Password.Length < FirstNumber) return false;
            return Password[FirstNumber - 1] == RequiredCharacter;
        }

        private bool PositionTwoHit()
        {
            if (Password.Length < SecondNumber) return false;
            return Password[SecondNumber - 1] == RequiredCharacter;
        }
    }
}
