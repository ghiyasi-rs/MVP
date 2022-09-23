using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.LinkLabel;

namespace MVP.Class
{
    public class BASKETBALL : Sport
    {
        public int ScoredPoint;
        public int Rebound;
        public int Assist;

        public int ValidFieldItem = 8;
        public override int Score
        {
            get { return CalcutePlayerScore(); }
        }

        public int CalcutePlayerScore()
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

        public List<BASKETBALL> GetWinnerTeam(List<BASKETBALL> _playerInfoList)
        {

            var result = _playerInfoList
               .GroupBy(x => new { x.TeamName })
               .Select(x => new Sport
               {
                   TeamName = x.First().TeamName,
                   Score = x.Sum(y => Convert.ToInt32(y.ScoredPoint))
               }).OrderByDescending(s=>s.Score);


            foreach (var item in _playerInfoList.Where(t => t.TeamName == result.Select(t => t.TeamName).FirstOrDefault()))
            {
                item.Score = 10;
            }
            return _playerInfoList;
        }

        public Dictionary<string,int> GetMachBestPlayer (List<Sport> _playerInfoList)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var maxScorePlayer = _playerInfoList
                .Where(l => l.Score == _playerInfoList.Max(l => l.Score)).Select(p=>p.PlayerName).FirstOrDefault();
            var maxScore = _playerInfoList
                .Where(l => l.Score == _playerInfoList.Max(l => l.Score)).Select(p => p.Score).FirstOrDefault();

            result[maxScorePlayer] = maxScore;
            return result;
        }
    }
}
