using MVP.Class;
using System.Numerics;
using static MVP.Form1;
using static System.Formats.Asn1.AsnWriter;

namespace MVP
{
    public partial class Form1 : Form
    {
        private List<string> _teamsName = new List<string>();
        private List<string> _sportsName = new List<string>();
        List<string> _matchBestPlayer = new List<string>();
        List<Dictionary<string, int>> _teamScore = new List<Dictionary<string, int>>();

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            _teamsName.Clear();
            _sportsName.Clear();

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

            listBox1.DataSource = _sportsName;



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


            _sportsName.Add(_fileContent[0]);




        }

        public void AnalizeFile(string line, string sportName)
        {
           
            string[] _lineInfo = line.Split(';');
            Sport _playerInfo = new Sport();
           

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

                            _teamScore.Add(_playerInfo.TeamName, _playerInfo.sc);

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


    }
}