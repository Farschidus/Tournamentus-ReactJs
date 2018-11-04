using System.Collections.Generic;

namespace Tournamentus.Core.Eseye.ApiClient
{
    public class EseyeRequestGetSIMs
    {
        public SearchCriteriaItem SearchCriteria { get; set; }
        public string SortOrder { get; set; }
        public string StartRec { get; set; }
        public string NumRecs { get; set; }

        public class SearchCriteriaItem
        {
            public string State { get; set; }
            public string Group { get; set; }
            public string Tariff { get; set; }
            public string MatchString { get; set; }
            public string MatchType { get; set; } = "E";
            public string MatchFields { get; set; } = "I";
        }
    }
}
