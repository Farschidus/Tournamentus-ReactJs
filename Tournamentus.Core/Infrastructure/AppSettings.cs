using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamentus.Core
{
    public class AppSettings
    {
        public string WhoKnows { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
    }

    public class ConnectionStrings
    {
        public string TournamentusDb { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
