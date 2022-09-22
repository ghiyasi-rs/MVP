using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Class
{
    public class Sport
    {
        public string SportName { get; set; }
        public string PlayerName { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public string TeamName { get; set; }
        public virtual int Score { get; set; }
        public string Position { get; set; }
    }
}
