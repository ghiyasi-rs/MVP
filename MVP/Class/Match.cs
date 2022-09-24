using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Class
{
    public class Match
    {
        public string SportName { get; set; }
        public string PlayerName { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public string TeamName { get; set; }
        public virtual int Score { get; set; }
        public string Position { get; set; }


        public Dictionary<string, int> GetMachBestPlayer(List<Match> _playerInfoList)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            var maxScorePlayer = _playerInfoList
                .Where(l => l.Score == _playerInfoList.Max(l => l.Score)).Select(p => p.PlayerName).FirstOrDefault();
            var maxScore = _playerInfoList
                .Where(l => l.Score == _playerInfoList.Max(l => l.Score)).Select(p => p.Score).FirstOrDefault();

            result[maxScorePlayer] = maxScore;
            return result;
        }
    }

    

}
