using System;

namespace BowlingConsoleApplication
{
    public partial class Frame
    {
        public int FirstBall { get; protected set; }
        public int SecondBall { get; protected set; }
        protected const int specialScoreValue = 10;
        public static Frame Strike { get { return new Frame(10, 0); } }

        public virtual int FrameScore => FirstBall + SecondBall;
        public bool IsStrike
        {
            get
            {
                return FirstBall == Frame.specialScoreValue;
            }
        }
        public bool IsSpare
        {
            get
            {
                return (IsStrike == false) && (FrameScore == Frame.specialScoreValue);
            }
        }

        protected Frame() { }

        public Frame(
            int firstBall,
            int secondBall)
        {
            if (firstBall < 0 || secondBall < 0)
            {
                throw new NumOutofRangeException();
            }
            if (firstBall + secondBall > specialScoreValue)
            {
                throw new OverflowException();
            }
            FirstBall = firstBall;
            SecondBall = secondBall;
        }
    }
}
