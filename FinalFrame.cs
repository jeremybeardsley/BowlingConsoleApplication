using BowlingConsoleApplication.Utils;

namespace BowlingConsoleApplication
{
    public class FinalFrame : Frame
    {
        private int thirdBall;

        public int ThirdBall { get => thirdBall; private set => thirdBall = value; }

        public override int FrameScore => base.FrameScore + ThirdBall;

        public FinalFrame(
            int firstBall,
            int secondBall,
            int thirdBall)
        {
            var thisSpecialScore = specialScoreValue;
            var util = new BowlingUtils();
            util.ValidateSingleScore(firstBall, thisSpecialScore);
            util.ValidateSingleScore(secondBall, thisSpecialScore);
            util.ValidateSingleScore(thirdBall, thisSpecialScore);
            util.ValidateTwoBalls(firstBall, secondBall, thisSpecialScore);
            if (firstBall == thisSpecialScore)
            {
                util.ValidateTwoBalls(secondBall, thirdBall, thisSpecialScore);
            }
            util.ValidateThirdBall(firstBall, secondBall, thirdBall, thisSpecialScore);
            FirstBall = firstBall;
            SecondBall = secondBall;
            ThirdBall = thirdBall;
        }
    }
}
