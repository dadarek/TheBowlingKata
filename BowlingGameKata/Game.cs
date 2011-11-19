using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameKata
{
    public class Game
    {
        int[] rolls_ = new int[21];
        int currentRoll_ = 0;

        public void Roll(int pins)
        {
            rolls_[currentRoll_++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += rolls_[frameIndex] + rolls_[frameIndex + 1];
                    frameIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls_[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            int frameScore = rolls_[frameIndex] + rolls_[frameIndex + 1];
            return frameScore == 10;
        }
        private int StrikeBonus(int frameIndex)
        {
            return rolls_[frameIndex + 1] + rolls_[frameIndex + 2];
        }
        private int SpareBonus(int frameIndex)
        {
            return rolls_[frameIndex + 2];
        }
    }
}
