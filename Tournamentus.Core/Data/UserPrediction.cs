using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public partial class UserPrediction
    {
        [Key]
        public int UserPredictId { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public byte? PredictScoreId { get; set; }
        [Required, StringLength(8)]
        public string Prediction { get; set; }

        [ForeignKey("MatchId")]
        public virtual Match Match { get; set; }
        [ForeignKey("PredictScoreId")]
        public virtual PredictScore PredictScore { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
