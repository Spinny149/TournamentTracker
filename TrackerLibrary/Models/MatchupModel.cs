using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one match in tournament
    /// </summary>
    public class MatchupModel
    {
        /// <summary>
        /// Represents teams that were involved in this match
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Represents winner of the round
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// Represents round number
        /// </summary>
        public int MatchupRound { get; set; }
        

    }
}
