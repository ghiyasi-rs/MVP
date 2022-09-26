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
          
            var maxScore = _playerInfoList.Max(l => l.Score);
            var maxScorePlayer = _playerInfoList
                            .Where(l => l.Score == maxScore).Select(p => p.PlayerName).FirstOrDefault();
            result.Add(maxScorePlayer, maxScore);

            return result;
        }
    }    

}
