using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Class
{

    public class Handball2 : Match
    {
        public int InitialRatingPoints;
        public int GoalMade;
        public int GoalReceived;
        public int Award;

        public const int ValidFieldItem = 7;
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
                        _sumPlayerScore = 50 + (GoalMade * 5) - (GoalReceived * 2);
                        break;
                    }
                case "F":
                    {
                        _sumPlayerScore = 20 + GoalMade - GoalReceived;
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

        public List<Handball2> GetListHandball(List<Match> _sportList)
        {
            var _handballList = new List<Handball2>();

            _sportList.ForEach(match =>
            {
                var _handball = (Handball2)match;

                _handballList.Add(_handball);
            });


            var _teams = _handballList.GroupBy(t => t.TeamName).ToList();

            var _firstTeamPlayers = _handballList.Where(t => t.TeamName == _teams[0].Key.ToString()).Select(p => p.PlayerName).ToList();
            var _secondTeamPlayers = _handballList.Where(t => t.TeamName == _teams[1].Key.ToString()).Select(p => p.PlayerName).ToList();


            var result = _firstTeamPlayers.Intersect(_secondTeamPlayers);

            if (!result.Any())
                return _handballList;
            else
                return null;// Player cannot play in two team in match

        }

        public List<Handball2> GetWinnerTeam(List<Handball2> _playerInfoList)
        {

            var result = _playerInfoList
               .GroupBy(x => new { x.TeamName })
               .Select(x => new Match
               {
                   TeamName = x.First().TeamName,
                   Score = x.Sum(y => Convert.ToInt32(y.GoalMade))
               }).ToList();

            if (result.Count() == 2 && result[0].Score == result[1].Score)
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
