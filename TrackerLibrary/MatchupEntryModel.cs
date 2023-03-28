using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents one team in a matchup
    /// </summary>
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents one team in a Matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score for this team
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Represents the matchup that this team campe from as a winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
