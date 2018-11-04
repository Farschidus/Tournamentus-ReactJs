using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public partial class PredictScore
    {
        [Key]
        public byte PredictScoreId { get; set; }
        public int Score { get; set; }
        [StringLength(64)]
        public string Description { get; set; }

        public virtual ICollection<UserPrediction> UserPredictions { get; set; }
    }
}
