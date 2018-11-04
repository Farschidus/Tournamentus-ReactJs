using System;
using System.Collections.Generic;

namespace Tournamentus.Core.Eseye.ApiClient
{
    public class EseyeResponseSIMs
    {
        public int TotRecs { get; set; }
        public List<Sim> Sims { get; set; }
        public EseyeResponseStatus.StatusItem Status { get; set; }

        public class Sim
        {
            public string MSISDN { get; set; }
            public string FriendlyName { get; set; }
            public string ICCID { get; set; }
            public string IpAddress { get; set; }
            public string Group { get; set; }
            public string Status { get; set; }
            public string Alert { get; set; }
            public string Controls { get; set; }
            public string Activated { get; set; }
        }
    }
}
