using System;


namespace BowlingConsoleApplication.Utils
{
    public class BowlingUtils
    {

        public class badScoreException : Exception { }
        public void ValidateThirdBall(int first,
                                      int second,
                                      int third,
                                      int specialScoreValue)
        {
            if (first + second < specialScoreValue && third > 0)
            {
                throw new badScoreException();
            }
        }

        public void ValidateTwoBalls(int first,
                                     int second,
                                     int specialScoreValue)
        {
            if (first != specialScoreValue && first + second > specialScoreValue)
            {
                throw new badScoreException();
            }
        }

        public void ValidateSingleScore(int ball,
                                        int specialScoreValue)
        {
            if (ball < 0 || ball > specialScoreValue)
            {
                throw new badScoreException();
            }
        }
    }
}
