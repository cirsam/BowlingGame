using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGameLib
{
    public class BowlingGame
    {
        private List<int> rolls = new List<int>();
        public int Score {
            get {

                var score = 0;
                int rollIndex = 0;

                for (var frame = 0; frame<=10;frame++)
                {
                    if (IsListInRange(rollIndex))
                    {
                        if (rolls[rollIndex]==10)
                        {
                            score += rolls[rollIndex] + rolls[rollIndex + 1]+rolls[rollIndex+2];

                            rollIndex++;
                        }
                        else if (IsSparePlay(rollIndex))
                        {
                            //this is a spare
                            score += rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];

                            rollIndex += 2;
                        }
                        else
                        {
                            score += rolls[rollIndex] + rolls[rollIndex + 1];
                            rollIndex += 2;
                        }
                    }
                }

                return score;
            } 
        }

        private bool IsSparePlay(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsListInRange(int rollIndex)
        {
            return rollIndex < rolls.Count() - 1;
        }

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

    }
}
