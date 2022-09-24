using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.LinkLabel;

namespace MVP.Class
{
    public class Basketball : Match
    {
        public int ScoredPoint;
        public int Rebound;
        public int Assist;
        public int Award;

        public const int ValidFieldItem = 8;
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
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 3) + (Assist * 1) + Award;
                        break;
                    }
                case "F":
                    {
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 2) + (Assist * 2) + Award;
                        break;
                    }
                case "C":
                    {
                        _sumPlayerScore = (ScoredPoint * 2) + (Rebound * 1) + (Assist * 3) + Award;
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

        public List<Basketball> GetListBasketball(List<Match> _sportList)
        {
            var _basketBallList = new List<Basketball>();

            _sportList.ForEach(match =>
            {
                var _basketBall = (Basketball)match;

                _basketBallList.Add(_basketBall);
            });


            var _teams = _basketBallList.GroupBy(t=>t.TeamName).ToList();

            var _firstTeamPlayers = _basketBallList.Where(t => t.TeamName == _teams[0].Key.ToString()).Select(p => p.PlayerName).ToList();
            var _secondTeamPlayers = _basketBallList.Where(t => t.TeamName == _teams[1].Key.ToString()).Select(p => p.PlayerName).ToList();


            var result = _firstTeamPlayers.Intersect(_secondTeamPlayers);

            if (!result.Any())
                return _basketBallList;
            else
                return null;
        }

        public List<Basketball> GetWinnerTeam(List<Basketball> _playerInfoList)
        {

            var result = _playerInfoList
               .GroupBy(x => new { x.TeamName })
               .Select(x => new Match
               {
                   TeamName = x.First().TeamName,
                   Score = x.Sum(y => Convert.ToInt32(y.ScoredPoint))
               }).ToList();

            if (result.Count() == 2 && result[0].Score == result[1].Score )
            {
                return null; // match should have winner;

            }

            else
            {

                var _winnerTeam = result.OrderByDescending(s => s.Score).Select(t => t.TeamName).FirstOrDefault();



                var _returnList = _playerInfoList.Where(w => w.TeamName == _winnerTeam).ToList();
                _returnList.ForEach(s => s.Award = 10);

                return _returnList;
            }    
           



        }

    }
}
