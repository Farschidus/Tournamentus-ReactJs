using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournamentus.Core.Api
{
    public class AppSettings
    {
        public Security Security { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
    }

    public class Security
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
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
