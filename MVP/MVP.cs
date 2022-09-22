using MVP.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVP
{
    public partial class MVP : Form
    {
        

        private Dictionary<string, Dictionary<string, int>> _playersInfo = new Dictionary<string, Dictionary<string, int>>();
        
        public MVP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
            foreach (var item in choofdlog.FileNames)
            {

                ReadFile(item);

            }

            foreach (var item in _playersInfo)
            {
                Dictionary<string, int> t = _playersInfo[item.Key.ToString()];
                string[] row = { item.Key.ToString(), GetTeamSumScore (t).ToString(), GetTeamBestPlayer(t).ToString(), GetTeamBestPlayerScore(t).ToString() };
                dataGridView1.Rows.Add(row);
                
            }            
            
        }

        public void ReadFile(string FilePath)
        {

            List<string> _fileContent = new List<string>();

            string _sportName = "";

            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(FilePath))
            {
                _fileContent.Add(line);
                _sportName = _fileContent[0];
                AnalizeFile(line, _sportName);


            }



        }

        public void AnalizeFile(string line, string sportName)
        {

            string[] _lineInfo = line.Split(';');

            Sport _playerInfo;


            if (_lineInfo.Length > 1)
            {

                switch (sportName.ToUpper())
                {
                    case "BASKETBALL":
                        {

                            _playerInfo = new Basketball()
                            {
                                PlayerName = _lineInfo[0],
                                NickName = _lineInfo[1],
                                Number = int.Parse(_lineInfo[2]),
                                TeamName = _lineInfo[3],
                                Position = _lineInfo[4],
                                ScoredPoint = int.Parse(_lineInfo[5]),
                                Rebound = int.Parse(_lineInfo[6]),
                                Assist = int.Parse(_lineInfo[7]),

                            };

                            Dictionary<string, int> _playerScore = new Dictionary<string, int>();
                            _playerScore.Add(_playerInfo.PlayerName, 10);


                            if (!_playersInfo.ContainsKey(_playerInfo.TeamName))

                                _playersInfo.Add(_playerInfo.TeamName, _playerScore);

                            else
                            {
                                _playersInfo[_playerInfo.TeamName].Add(_playerInfo.PlayerName, 10);

                            }


                            break;
                        }


                    case "HANDBALL":

                        _playerInfo = new HANDBALL()
                        {
                            PlayerName = _lineInfo[0],
                            NickName = _lineInfo[1],
                            Number = int.Parse(_lineInfo[2]),
                            TeamName = _lineInfo[3],
                            Position = _lineInfo[4],
                            GoalMade = int.Parse(_lineInfo[5]),
                            GoalReceived = int.Parse(_lineInfo[6]),


                        };
                        break;

                }
            }




        }

        public void GetTeamNames(string[] arrAllFiles)
        {
            List<string> arrTeamsName = new List<string>();

            foreach (var item in arrAllFiles)
            {
                arrTeamsName.Add(item);
            }
        }

        public string GetTeamBestPlayer(Dictionary<string, int> playersInfo)
        {

            var maxScorePlayer = playersInfo.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return maxScorePlayer;
        }

        public int GetTeamBestPlayerScore(Dictionary<string, int> playersInfo)
        {
            var maxScorePlayerKey = playersInfo.Aggregate((x, y) => x.Value > y.Value ? x : y).Value;
            return maxScorePlayerKey;
        }

        public int GetTeamSumScore(Dictionary<string, int> playersInfo)
        {
            var sumValueKey = 0;
            foreach (var player in playersInfo)
            {
                sumValueKey += int.Parse( playersInfo[player.Key].ToString());
            }
            return sumValueKey;
        }


    }
}
