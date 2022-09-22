using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MVP.Class
{
    public class Basketball : Sport
    {
        public int ScoredPoint;
        public int Rebound;
        public int Assist;

        public override int Score
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
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 3) + (Assist * 1);
                        break;
                    }
                case "F":
                    {
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 2) + (Assist * 2);
                        break;
                    }
                case "C":
                    {
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 1) + (Assist * 3);
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
