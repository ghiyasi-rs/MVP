using static MVP.Form1;

namespace MVP
{
    public partial class Form1 : Form
    {
        private List<string> _teamsName = new List<string>();
        private List<string> _sportsName = new List<string>();
        List<string> _matchBestPlayer = new List<string>();
        List<PlayerInfo> _players = new List<PlayerInfo>();
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

            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines(FilePath))
            {
                _fileContent.Add(line);
                AnalizeFile(line);

            }


            _sportsName.Add(_fileContent[0]);



        }

        public void AnalizeFile(string line)
        {
            List<string> _matchTeams = new List<string>();
            string[] _playerInfo ;
            _playerInfo = line.Split(";");
           
            PlayerInfo playerInfo = new PlayerInfo()
            {
                _playerName = _playerInfo[0],
                _teamName= _playerInfo[1],
                _score=1
            };

          _players.Add(playerInfo);

           


        }
        public void GetTeamNames(string[] arrAllFiles)
        {
            List<string> arrTeamsName = new List<string>();

            foreach (var item in arrAllFiles)
            {
                arrTeamsName.Add(item);
            }
        }
       public class PlayerInfo 
            {
            public string _playerName;
            public string _teamName;
            public int _score;
            }

    }
}