using MVP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Class
{
    public class FileOperations
    {
        private List<Dictionary<string, int>> _bestPlayers = new List<Dictionary<string, int>>();
        private List<Match> _match;
        public List<Match> ReadFileContent(string FilePath)
        {
            List<string> _fileContent = new List<string>();
            string[] _lineInfo;
            string _sportName = "";
            Match _player;

            _match = new List<Match>();
            foreach (string line in System.IO.File.ReadLines(FilePath))
            {
                _fileContent.Add(line);
                _sportName = _fileContent[0];
                _lineInfo = line.Split(';');
                if (_lineInfo.Length > 1)
                {

                    switch (_sportName.ToUpper())
                    {
                        case nameof(Sports.BASKETBALL):
                            {


                                 var _basketballPlayer = new Basketball()
                                {
                                    SportName = _sportName,
                                    PlayerName = _lineInfo[0],
                                    NickName = _lineInfo[1],
                                    Number = int.Parse(_lineInfo[2]),
                                    TeamName = _lineInfo[3],
                                    Position = _lineInfo[4],
                                    ScoredPoint = int.Parse(_lineInfo[5]),
                                    Rebound = int.Parse(_lineInfo[6]),
                                    Assist = int.Parse(_lineInfo[7]),
                                };

                                _match.Add(_basketballPlayer);
                                break;
                            }


                        case nameof(Sports.HANDBALL):

                            var _handballPlayer = new Handball()
                            {
                                SportName = _sportName,
                                PlayerName = _lineInfo[0],
                                NickName = _lineInfo[1],
                                Number = int.Parse(_lineInfo[2]),
                                TeamName = _lineInfo[3],
                                Position = _lineInfo[4],
                                GoalMade = int.Parse(_lineInfo[5]),
                                GoalReceived = int.Parse(_lineInfo[6]),

                            };
                            _match.Add(_handballPlayer);
                            break;
                    }
                }
            }
            return _match;
        }

        public List<Dictionary<string, int>> AnalyzeFile(List<Match> _playerInfoList)
        {
            var sportName = _playerInfoList[0].SportName;

            switch (sportName.ToUpper())
            {
                case nameof(Sports.BASKETBALL):

                    {
                        Basketball _basketball = new Basketball();
                        var _list = _basketball.GetListBasketball(_playerInfoList);
                        if (_list != null)
                        {
                            _basketball.GetWinnerTeam(_list);
                            var _bestBasketball = _basketball.GetMachBestPlayer(_playerInfoList);
                            _bestPlayers.Add(_bestBasketball);
                        }
                        break;
                    }
                case nameof(Sports.HANDBALL):
                    {
                        Handball _handball = new Handball();
                        var _list = _handball.GetListHandball(_playerInfoList);
                        if (_list != null)
                        {
                            _handball.GetWinnerTeam(_list);
                            var _bestHandball = _handball.GetMachBestPlayer(_playerInfoList);
                            _bestPlayers.Add(_bestHandball);
                        }

                        break;
                    }
            }
            return _bestPlayers;

        }
    }
}
