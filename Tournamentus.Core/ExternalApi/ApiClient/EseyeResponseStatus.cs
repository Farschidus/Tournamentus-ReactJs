namespace Tournamentus.Core.Eseye.ApiClient
{
    public class EseyeResponseStatus
    {
        public StatusItem Status { get; set; }

        public class StatusItem
        {
            public string Status { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }
        }
    }
}
