using MVP.Class;
using MVP.Domain.Enum;
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
        private List<Match> _match;
        private FileValidation _fileValidation = new FileValidation();
        private FileOperations _fileOperations = new FileOperations();

        public MVP()
        {
            InitializeComponent();
        }
        
        private void btn_MVP_Click(object sender, EventArgs e)
        {

            _bestPlayers.Clear();
            
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Text|*.txt";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in choofdlog.FileNames)
                {
                    bool _isValid = _fileValidation.IsValidFile(file);
                    if (_isValid)
                    {
                        _match = _fileOperations.ReadFileContent(file);
                        _bestPlayers=_fileOperations.AnalyzeFile(_match);
                    }
                }
            }
              
            GetMvp();

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
            else
                MessageBox.Show("Can not find MVP.");
        }
    }
}
