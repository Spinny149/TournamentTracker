﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents one turnament model
    /// </summary>
    public class TournamentModel
    {
        /// <summary>
        /// Represents tournament phase
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents entry money to bet
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Represents teams in tournament
        /// </summary>
        public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        
        /// <summary>
        /// Represents prizes to win???
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// 
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();


    }
}
