using MVP.Class;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    public partial class MVP : Form
    {

        private List<Dictionary<string, int>> _bestPlayers = new List<Dictionary<string, int>>();
        public List<Match> _playerInfoList;

        public FileValidation _fileValidation = new FileValidation();
        public MVP()
        {
            InitializeComponent();
        }

       

        public List<Match> ReadFile(string FilePath)
        {
            List<string> _fileContent = new List<string>();
            string[] _lineInfo;
            string _sportName = "";
            Match _player;

            _playerInfoList = new List<Match>();
            foreach (string line in System.IO.File.ReadLines(FilePath))
            {
                _fileContent.Add(line);
                _sportName = _fileContent[0];
                _lineInfo = line.Split(';');
                if (_lineInfo.Length > 1)
                {

                    switch (_sportName.ToUpper())
                    {
                        case "BASKETBALL":
                            {


                                var _players = new Basketball()
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


                                _playerInfoList.Add(_players);




                                break;
                            }


                        case "HANDBALL":

                            _player = new Handball()
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
                            _playerInfoList.Add(_player);
                            break;

                    }
                }


            }
            return _playerInfoList;

        }

        public void AnalizeFile(List<Match> _playerInfoList)
        {

            var sportName = _playerInfoList[0].SportName;

            switch (sportName.ToUpper())
            {
                case "BASKETBALL":
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
                case "HANDBALL":
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


        }

        public void GetMvp()
        {
            if (_bestPlayers.Count > 0)
            {
                var results = _bestPlayers.SelectMany(d => d)
                                .GroupBy(d => d.Key)
                                .Select(g => new
                                {
                                    GroupName = g.Key,
                                    MaxValue = g.Max(i => i.Value)
                                });
                lbl_MVP.Text = results.Select(p => p.GroupName).FirstOrDefault().ToString();
            }


        }

        private void btn_MVP_Click(object sender, EventArgs e)
        {

            _bestPlayers.Clear();

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in choofdlog.FileNames)
                {

                    bool _isValid = _fileValidation.IsValidFile(item);
                    if (_isValid)
                    {
                        ReadFile(item);
                        AnalizeFile(_playerInfoList);

                    }
                }
            }





            GetMvp();

        }
    }
}
