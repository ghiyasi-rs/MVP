using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Class
{
    
    public class HANDBALL : Sport
    {
        public int InitialRatingPoints;
        public int GoalMade;
        public int GoalReceived;
        public int ValidFieldItem = 7;
        public int Score
        {
            get { return CalcuteScore(); }

        }


        public int CalcuteScore()
        {
            int _sumPlayerScore = 0;
            switch (Position)
            {
                case "G":
                    {
                        _sumPlayerScore = 50 + (GoalMade * 5) - (GoalReceived * 2);
                        break;
                    }
                case "F":
                    {
                        _sumPlayerScore =  20 + GoalMade  - GoalReceived ;
                        break;
                    }
               
                default:
                    {
                        _sumPlayerScore = 0;
                        break;
                    }

            }
            return _sumPlayerScore;

        }
    }
}
