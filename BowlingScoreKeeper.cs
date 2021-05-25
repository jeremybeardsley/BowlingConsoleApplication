using System;


namespace BowlingConsoleApplication
{
    public class BowlingScoreKeeper
    {
        private readonly Frame[] game = new Frame[10];
        private int thisFrame;
        public int ThisFrame {
            get => thisFrame; 
            set => thisFrame = value; 
        }
        private Frame PrevFrame
        {
            get
            {
                return game[ThisFrame - 1];
            }
        }

        private Frame prev2Frame
        {
            get
            {
                return game[ThisFrame - 2];
            }
        }

        public int Score { get; private set; }

        public void BowlFrame(Frame frame)
        {
            SpecialScoring(frame);

            Score += frame.FrameScore;
            game[ThisFrame++] = frame;
        }

        private bool IsTwoConsecutiveStrikes
        {
            get
            {
                var twoStrikesInARow = false;
                if (ThisFrame > 1)
                {
                    if (IsPrevFrameStrike&& prev2Frame.IsStrike)
                    {
                        twoStrikesInARow = true;
                    }
                }
                return twoStrikesInARow;
            }
        }

        private bool IsPrevFrameStrike
        {
            get
            {
                var prevFrameStrike = false;
                if (ThisFrame > 0)
                    if (PrevFrame.IsStrike)
                    {
                        prevFrameStrike = true;
                    }
                return prevFrameStrike;
            }
        }

        private bool IsPrevFrameSpare
        {
            get
            {
                var prevFrameSpare = false;
                if (ThisFrame > 0)
                {
                    if (PrevFrame.IsSpare)
                    {
                        prevFrameSpare = true;
                    }
                }
                return prevFrameSpare;
            }
        }

        

        private void SpecialScoring(Frame frame)
        {
            if (!IsTwoConsecutiveStrikes)
            {
                if (IsPrevFrameStrike)
                {
                    Score += frame.FrameScore;
                }
                else if (IsPrevFrameSpare)
                {
                    Score += frame.FirstBall;
                }
            }
            else
            {
                Score += frame.FrameScore + frame.FirstBall;
            }
        }

        public void RunHardCodedRollsBowler1()
        {

            BowlingScoreKeeper Bowler1 = new BowlingScoreKeeper();
            Bowler1.BowlFrame(new Frame(2, 8));
            Bowler1.BowlFrame(new Frame(9, 0));
            Bowler1.BowlFrame(new Frame(0, 5));
            Bowler1.BowlFrame(Frame.Strike);
            Bowler1.BowlFrame(new Frame(2, 8));
            Bowler1.BowlFrame(new Frame(9, 0));
            Bowler1.BowlFrame(new Frame(4, 3));
            Bowler1.BowlFrame(new Frame(6, 4));
            Bowler1.BowlFrame(new Frame(2, 3));
            Bowler1.BowlFrame(new FinalFrame(9, 1, 10));
            Console.WriteLine("Final Score:" + Bowler1.Score);
        }
    }
}